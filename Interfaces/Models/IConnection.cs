using yawaflua.Discord.Net.Entities.Enums;

namespace yawaflua.Discord.Net.Interfaces.Models;

public interface IConnection
{
    public string Id { get; set; }
    public string Name { get; set; }
    public ConnectionType Type { get; set; }
    public bool? Revoked { get; set; }
    public object[] Integrations { get; set; }
    public bool? Verified { get; set; }
    public bool? FriendSync { get; set; }
    public bool? ShowActivity { get; set; }
    public bool? TwoWayLink { get; set; }
    public ConnectionVisibility? Visibility { get; set; }
}