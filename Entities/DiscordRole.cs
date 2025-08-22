using yawaflua.Discord.Net.Entities.Enums;
using yawaflua.Discord.Net.Interfaces.Models;

namespace yawaflua.Discord.Net.Entities;

internal class DiscordRole : IRole
{
    public string Id { get; set; }
    public string Name { get; set; }
    public int Color { get; set; }
    private RoleColor Colors { get; set; }
    public bool IsHoisted { get; set; }
    public bool IsManaged { get; set; }
    public bool IsMentionable { get; set; }
    public int Position { get; set; }
    public ulong? Permissions { get; set; }
    public string? IconHash { get; set; }
    public string? UnicodeEmoji { get; set; }
    public Dictionary<RoleTags, ulong?>? Tags { get; set; }
    
    IRoleColor IRole.Colors
    {
        get => Colors;
        set => Colors = (RoleColor)value;
    }
}