using System.Text.Json.Serialization;
using yawaflua.Discord.Net.Interfaces.Models;

namespace yawaflua.Discord.Net.Entities;

internal class AvatarDecoration : IAvatarDecoration
{
    [JsonPropertyName("asset")]
    public string AssetHash { get; set; }
    [JsonPropertyName("sku_id")]
    public ulong AssetArticular { get; set; }
}