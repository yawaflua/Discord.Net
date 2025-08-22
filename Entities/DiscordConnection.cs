using System.Text.Json.Serialization;
using yawaflua.Discord.Net.Entities.Enums;
using yawaflua.Discord.Net.Interfaces.Models;

namespace yawaflua.Discord.Net.Entities;

internal class DiscordConnection : IConnection
{
    [JsonPropertyName("id")] public string Id { get; set; }
    [JsonPropertyName("name")] public string Name { get; set; }
    [JsonPropertyName("type")] public ConnectionType Type { get; set; }
    [JsonPropertyName("revoked")] public bool? Revoked { get; set; }
    [JsonPropertyName("integrations")] public object[] Integrations { get; set; }
    [JsonPropertyName("verified")] public bool? Verified { get; set; }
    [JsonPropertyName("friend_sync")] public bool? FriendSync { get; set; }
    [JsonPropertyName("show_activity")] public bool? ShowActivity { get; set; }
    [JsonPropertyName("two_way_link")] public bool? TwoWayLink { get; set; }
    [JsonPropertyName("visibility")] public ConnectionVisibility? Visibility { get; set; }
}