namespace yawaflua.Discord.Net.Interfaces.Models;

public interface IGuildMember
{
    public IUser User { get; set; }
    public string? Nick { get; set; }
    public string? AvatarHash { get; set; }
    public string? BannerHash { get; set; }
    public List<IRole> Roles { get; set; }
    public DateTime JoinedAt { get; set; }
    public DateTime? PremiumSince { get; set; }
    public bool IsDeaf { get; set; }
    public bool IsMute { get; set; }
    public int Flags { get; set; }
    public bool IsPending { get; set; }
    public DateTime? CommunicationDisabledUntil { get; set; }
    public IAvatarDecoration? AvatarDecoration { get; set; }
}