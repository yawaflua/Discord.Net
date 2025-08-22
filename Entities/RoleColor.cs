using yawaflua.Discord.Net.Interfaces.Models;

namespace yawaflua.Discord.Net.Entities;

internal class RoleColor : IRoleColor
{
    public int Primary { get; set; }
    public int? Secondary { get; set; }
    public int? Tertiary { get; set; }
}