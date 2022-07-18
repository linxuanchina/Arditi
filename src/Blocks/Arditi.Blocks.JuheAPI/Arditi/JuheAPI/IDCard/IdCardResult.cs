using System.Text.Json.Serialization;

namespace Arditi.JuheAPI.IDCard;

public sealed record IdCardResult
{
    [JsonPropertyName("area")] public string? Area { get; set; }
    [JsonPropertyName("sex")] public string? Sex { get; set; }
    [JsonPropertyName("birthday")] public string? Birthday { get; set; }
}
