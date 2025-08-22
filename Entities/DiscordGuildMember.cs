using System.Text.Json.Serialization;
using yawaflua.Discord.Net.Interfaces.Models;

namespace yawaflua.Discord.Net.Entities;

internal class DiscordGuildMember : IGuildMember
{
    private DiscordUser User { get; set; }
    public string? Nick { get; set; }
    [JsonPropertyName("avatar")]
    public string? AvatarHash { get; set; }
    [JsonPropertyName("banner")]
    public string? BannerHash { get; set; }
    public List<IRole> Roles { get; set; }
    public DateTime JoinedAt { get; set; }
    public DateTime? PremiumSince { get; set; }
    [JsonPropertyName("deaf")]
    public bool IsDeaf { get; set; }
    [JsonPropertyName("mute")]
    public bool IsMute { get; set; }
    public int Flags { get; set; }
    [JsonPropertyName("pending")]
    public bool IsPending { get; set; }
    [JsonPropertyName("communication_disabled_until")]
    public DateTime? CommunicationDisabledUntil { get; set; }
    private AvatarDecoration? AvatarDecoration { get; set; }
    
    IUser IGuildMember.User
    {
        get => User;
        set => User = value as DiscordUser;
    }

    IAvatarDecoration IGuildMember.AvatarDecoration
    {
        get => AvatarDecoration;
        set => AvatarDecoration = value as AvatarDecoration;
    }
}