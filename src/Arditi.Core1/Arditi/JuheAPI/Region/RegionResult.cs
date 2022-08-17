using System.Text.Json.Serialization;

namespace Arditi.JuheAPI.Region;

public sealed record RegionResult
{
    [JsonPropertyName("id")] public string? Id { get; set; }
    [JsonPropertyName("name")] public string? Name { get; set; }
    [JsonPropertyName("fid")] public string? FId { get; set; }
    [JsonPropertyName("level_id")] public string? LevelId { get; set; }
}
