using System.Collections.Specialized;
using System.Net.Http.Headers;
using System.Text.Json;
using yawaflua.Discord.Net.Interfaces.Models;

namespace yawaflua.Discord.Net.Entities;

internal class DiscordSession (IToken token, HttpClient httpClient, ScopesBuilder scopes, ulong clientId, string clientSecret, string redirectUri, bool prompt) : ISession
{
    private async Task<T?> _req<T>(string endpoint, HttpMethod? method = null) where T : class
    {
        using var request = new HttpRequestMessage(method ?? HttpMethod.Get, $"https://discord.com/api/{endpoint}");
        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token.AccessToken);
        var response = await httpClient.SendAsync(request);
        if (!response.IsSuccessStatusCode)
        {
            return null;
        }

        var responseString = await response.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<T?>(responseString) ?? null;
    }
    
    public async Task<IList<IGuild>?> GetGuildsAsync(CancellationToken cancellationToken = default)
    {
        if (token.AccessToken is null)
        {
            throw new ArgumentNullException(nameof(token), "Token cannot be null.");
        }

        return await _req<DiscordGuild[]>("users/@me/guilds");
    }

    public async Task<IGuildMember?> GetGuildMemberAsync(ulong guildId, CancellationToken cancellationToken = default)
    {
        if (token.AccessToken is null)
        {
            throw new ArgumentNullException(nameof(token), "Token cannot be null.");
        }

        return await _req<DiscordGuildMember>($"users/@me/guilds/{guildId}/member");
    }

    public async Task<IGuildMember?> AddMemberToGuildAsync(ulong guildId, ulong userId, CancellationToken cancellationToken = default)
    {
        if (token.AccessToken is null)
        {
            throw new ArgumentNullException(nameof(token), "Token cannot be null.");
        }

        return await _req<DiscordGuildMember>($"guilds/{guildId}/members/{userId}", HttpMethod.Put);
    }

    public async Task<IUser?> GetCurrentUserAsync(CancellationToken cancellationToken = default)
    {
        if (token.AccessToken is null)
        {
            throw new ArgumentNullException(nameof(token), "Token cannot be null.");
        }

        return await _req<DiscordUser>("users/@me");
    }

    public async Task<IConnection?> GetConnectionAsync(CancellationToken cancellationToken = default)
    {
        if (token.AccessToken is null)
        {
            throw new ArgumentNullException(nameof(token), "Token cannot be null.");
        }
        return await _req<DiscordConnection>("users/@me/connections");
    }

    public IToken GetToken(CancellationToken cancellationToken = default)
    {
        if (token.AccessToken is null)
        {
            throw new ArgumentNullException(nameof(token), "Token cannot be null.");
        }
        return token;
    }
}