using System.Net.Http.Headers;
using System.Text.Json;
using System.Text.Json.Serialization;
using yawaflua.Discord.Net.Interfaces.Models;

namespace yawaflua.Discord.Net.Entities;

internal class OAuthToken (HttpClient client, ulong ClientId, string ClientSecret) : IToken
{
    [JsonPropertyName("access_token")] public string AccessToken { get; set; }

    [JsonPropertyName("expires_in")] public int ExpiresIn { get; set; }

    [JsonPropertyName("refresh_token")] public string RefreshToken { get; set; }

    [JsonPropertyName("scope")] public string Scope { get; set; }

    [JsonPropertyName("token_type")] public string TokenType { get; set; }
    public Task RevokeAsync(CancellationToken cancellationToken = default)
    {
        using var request = new HttpRequestMessage(HttpMethod.Post, "https://discord.com/api/oauth2/token/revoke")
        {
            Content = new FormUrlEncodedContent(new Dictionary<string, string>
            {
                { "token", AccessToken },
                { "client_id", ClientId.ToString() },
                { "client_secret", ClientSecret }
            })
        };
        return client.SendAsync(request, cancellationToken)
            .ContinueWith(task =>
            {
                if (!task.Result.IsSuccessStatusCode)
                {
                    throw new Exception("Failed to revoke token.");
                }
            }, cancellationToken);
    }

    public async Task RefreshAsync(CancellationToken cancellationToken = default)
    {
        using var request = new HttpRequestMessage(HttpMethod.Post, "https://discord.com/api/oauth2/token")
        {
            Content = new FormUrlEncodedContent(new Dictionary<string, string>
            {
                { "grant_type", "refresh_token" },
                { "refresh_token", RefreshToken },
            })
        };
        var byteArray = System.Text.Encoding.ASCII.GetBytes($"{ClientId}:{ClientSecret}");
        request.Headers.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
        var req = await client.SendAsync(request, cancellationToken);
        if (!req.IsSuccessStatusCode)
        {
            throw new Exception("Failed to refresh token.");
        }
        var responseString = await req.Content.ReadAsStringAsync();
        var newToken = JsonSerializer.Deserialize<OAuthToken>(responseString);
        if (newToken is null)
        {
            throw new Exception("Failed to deserialize token.");
        }
        AccessToken = newToken.AccessToken;
        ExpiresIn = newToken.ExpiresIn;
        RefreshToken = newToken.RefreshToken;
        Scope = newToken.Scope;
        TokenType = newToken.TokenType;
    }
}