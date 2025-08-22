namespace yawaflua.Discord.Net;

public sealed class DiscordConfig
{
    public ulong ClientId { get; set; } 
    public string ClientSecret { get; set; } = string.Empty;
    public string RedirectUri { get; set; } = string.Empty;
    public ScopesBuilder Scope { get; set; }
    public bool Prompt { get; set; } = true;
    public string Token { get; set; } = string.Empty;
}