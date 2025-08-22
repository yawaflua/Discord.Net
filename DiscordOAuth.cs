using System.Collections.Specialized;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Web;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using yawaflua.Discord.Net.Entities;
using yawaflua.Discord.Net.Entities.Enums;
using yawaflua.Discord.Net.Interfaces;
using yawaflua.Discord.Net.Interfaces.Models;
using ISession = yawaflua.Discord.Net.Interfaces.Models.ISession;

namespace yawaflua.Discord.Net;

public class DiscordOAuth : IDiscord
{
    private ulong ClientId { get; set; }
    private string ClientSecret { get; set; } = string.Empty;
    private string? BotToken { get; set; }

    private string RedirectUri { get; set; }
    private bool Prompt { get; set; }
    private ScopesBuilder Scopes { get; set; }

    private string? AccessToken { get; set; }
    private IToken? token { get; set; }
    
    private readonly HttpClient _httpClient = new HttpClient();
    
    /// <summary>
    /// Now deprecated, use DiscordConfig instead.
    /// </summary>
    /// <param name="clientId"></param>
    /// <param name="clientSecret"></param>
    /// <param name="botToken"></param>
    [Obsolete]
    public static DiscordOAuth Configure(ulong clientId, string clientSecret, string? botToken = null)
    {
        return new DiscordOAuth(clientId, clientSecret, string.Empty, new ScopesBuilder(OAuthScope.Identify))
        {
            BotToken = botToken
        };
    }
    
    public DiscordOAuth(ulong clientId, string clientSecret, string redirectUri, ScopesBuilder scopes, string? botToken = null, bool prompt = true)
    {
        ClientId = clientId;
        ClientSecret = clientSecret;
        RedirectUri = redirectUri;
        Scopes = scopes;
        Prompt = prompt;
        BotToken = botToken;
    }
    
    public DiscordOAuth(DiscordConfig config)
    {
        ClientId = config.ClientId;
        ClientSecret = config.ClientSecret;
        RedirectUri = config.RedirectUri;
        Scopes = config.Scope;
        Prompt = config.Prompt;
        BotToken = config.Token;
    }
    
    [Obsolete]
    public DiscordOAuth(string redirectUri, ScopesBuilder scopes, bool prompt = true)
    {
        RedirectUri = redirectUri;
        Scopes = scopes;
        Prompt = prompt;
    }

    public static bool TryGetCode(HttpRequest request, out string? code)
    {
        code = null;
        if (request.Query.TryGetValue("code", out var codeQuery))
        {
            code = codeQuery;
            return true;
        }

        return false;
    }

    public static bool TryGetCode(HttpContext context, out string? code)
    {
        return TryGetCode(context.Request, out code);
    }

    public async Task<IToken?> GetTokenAsync(string code)
    {
        var content = new FormUrlEncodedContent(new Dictionary<string, string>
        {
            { "client_id", ClientId.ToString() },
            { "client_secret", ClientSecret },
            { "grant_type", "authorization_code" },
            { "code", code },
            { "redirect_uri", RedirectUri },
            { "scope", Scopes.ToString() }
        });

        var response = await _httpClient.PostAsync("https://discord.com/api/oauth2/token", content);
        var responseString = await response.Content.ReadAsStringAsync();
        var authToken = JsonSerializer.Deserialize<TokenDto>(responseString);
        AccessToken = authToken?.AccessToken;
        token = OAuthToken.FromDTO(authToken, _httpClient, ClientId, ClientSecret);
        return token;
    }

    public ISession CreateSession()
    {
        if (token != null)
            return new DiscordSession(token, _httpClient, Scopes, ClientId, ClientSecret, RedirectUri, Prompt);
        else 
            throw new InvalidOperationException("Token is not set. Please call GetTokenAsync first.");
    }
    
    public string GetAuthorizationUrl(string state)
    {

        var uri = new UriBuilder("https://discord.com/api/oauth2/authorize?");
        
        var queryParameters = HttpUtility.ParseQueryString(uri.Query);
        
        queryParameters["client_id"] = ClientId.ToString();
        queryParameters["redirect_uri"] = RedirectUri;
        queryParameters["response_type"] = "code";
        queryParameters["scope"] = Scopes.ToString();
        queryParameters["state"] = state;
        queryParameters["prompt"] = Prompt ? "consent" : "none";

        return uri + string.Join("&", queryParameters.AllKeys
            .SelectMany(key => queryParameters.GetValues(key)!
                .Select(value => String.Format("{0}={1}", HttpUtility.UrlEncode(key), HttpUtility.UrlEncode(value))))
            .ToArray());
        
    }

    
}