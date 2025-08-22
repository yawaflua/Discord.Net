using yawaflua.Discord.Net.Entities.Enums;

namespace yawaflua.Discord.Net.Interfaces.Models;

public interface IGuild
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string? IconHash { get; set; }
    public string? BannerHash { get; set; }
    public bool IsOwner { get; set; }
    public string Permissions { get; set; }
    public IEnumerable<GuildFeature> Features { get; set; }
    public int ApproximateMemberCount { get; set; }
    public int ApproximatePresenceCount { get; set; }
    
    public string GetIconUrl(int size = 128);
    public string GetBannerUrl(int size = 128);
}