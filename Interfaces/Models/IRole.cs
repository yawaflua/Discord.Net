using yawaflua.Discord.Net.Entities.Enums;

namespace yawaflua.Discord.Net.Interfaces.Models;

public interface IRole
{
    public string Id { get; set; }
    public string Name { get; set; }
    [Obsolete("Deprecated integer representation of hexadecimal color code")]
    public int Color { get; set; }
    
    public IRoleColor Colors { get; set; }
    
    public bool IsHoisted { get; set; }
    public bool IsManaged { get; set; }
    public bool IsMentionable { get; set; }
    
    public int Position { get; set; }
    public ulong? Permissions { get; set; }
    
    public string? IconHash { get; set; }
    public string? UnicodeEmoji { get; set; }
    
    public Dictionary<RoleTags, ulong?>? Tags { get; set; }
}