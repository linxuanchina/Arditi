using System.Text.Json.Serialization;

namespace Arditi.JuheAPI.Mobile;

public sealed record MobileResult
{
    [JsonPropertyName("province")] public string? Province { get; set; }

    [JsonPropertyName("city")] public string? City { get; set; }

    [JsonPropertyName("areacode")] public string? AreaCode { get; set; }

    [JsonPropertyName("zip")] public string? Zip { get; set; }

    [JsonPropertyName("company")] public string? Company { get; set; }
}
