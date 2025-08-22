using System.Text.Json.Serialization;
using yawaflua.Discord.Net.Entities.Enums;
using yawaflua.Discord.Net.Interfaces.Models;

namespace yawaflua.Discord.Net.Entities;

internal class DiscordGuild : IGuild
{
    [JsonPropertyName("id")] public ulong Id { get; set; }

    [JsonPropertyName("name")] public string Name { get; set; }

    [JsonPropertyName("icon")] public string? IconHash { get; set; }
    [JsonPropertyName("banner")] public string? BannerHash { get; set; }

    [JsonPropertyName("owner")] public bool IsOwner { get; set; }

    [JsonPropertyName("permissions")] public string Permissions { get; set; }

    [JsonPropertyName("features")] public IEnumerable<GuildFeature> Features { get; set; } = [];
    
    [JsonPropertyName("approximate_member_count")] public int ApproximateMemberCount { get; set; }

    [JsonPropertyName("approximate_presence_count")] public int ApproximatePresenceCount { get; set; }
    
    public string GetIconUrl(int size = 128)
    {
        if (string.IsNullOrEmpty(IconHash))
        {
            return string.Empty;
        }

        return $"https://cdn.discordapp.com/icons/{Id}/{IconHash}.png?size={size}";
    }

    public string GetBannerUrl(int size = 128)
    {
        if (string.IsNullOrEmpty(BannerHash))
        {
            return string.Empty;
        }

        return $"https://cdn.discordapp.com/banners/{Id}/{BannerHash}.png?size={size}";
    }
}