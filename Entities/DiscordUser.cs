using System.Text.Json.Serialization;
using yawaflua.Discord.Net.Entities.Enums;
using yawaflua.Discord.Net.Interfaces.Models;

namespace yawaflua.Discord.Net.Entities;

internal class DiscordUser : IUser
{
    [JsonPropertyName("id")]
    public ulong Id { get; set; }
    
    [JsonPropertyName("username")]
    public string Username { get; set; }
    
    [JsonPropertyName("global_name")]
    public string GlobalName { get; set; }
    
    [JsonPropertyName("discriminator")]
    public string Discriminator { get; set; }
    
    [JsonPropertyName("avatar")]
    public string? AvatarHash { get; set; }
    
    [JsonPropertyName("bot")]
    public bool? Bot { get; set; }
    
    [JsonPropertyName("system")]
    public bool? System { get; set; }
    
    [JsonPropertyName("mfa_enabled")]
    public bool? MfaEnabled { get; set; }
    
    [JsonPropertyName("banner")]
    public string? Banner { get; set; }
    
    [JsonPropertyName("accent_color")]
    public int? AccentColor { get; set; }
    
    [JsonPropertyName("locale")]
    public string? Locale { get; set; }
    
    [JsonPropertyName("verified")]
    public bool? Verified { get; set; }
    
    [JsonPropertyName("email")]
    public string? Email { get; set; }
    
    [JsonPropertyName("flags")]
    public UserFlag? Flags { get; set; }
    
    [JsonPropertyName("premium_type")]
    public PremiumType? PremiumType { get; set; }
    
    [JsonPropertyName("public_flags")]
    public UserFlag? PublicFlags { get; set; }
    
    [JsonPropertyName("avatar_decoration")]
    public AvatarDecoration? AvatarDecoration { get; set; }

    IAvatarDecoration IUser.AvatarDecoration
    {
        get => AvatarDecoration;
        set => AvatarDecoration = value as AvatarDecoration;
    }

    public string GetAvatarUrl(int size = 128)
    {
        if (string.IsNullOrEmpty(AvatarHash))
        {
            return string.Empty;
        }

        return $"https://cdn.discordapp.com/avatars/{Id}/{AvatarHash}.png?size={size}";
    }

    public string GetBannerUrl(int size = 128)
    {
        if (string.IsNullOrEmpty(AvatarHash))
        {
            return string.Empty;
        }

        return $"https://cdn.discordapp.com/banners/{Id}/{AvatarHash}.png?size={size}";
    }
}