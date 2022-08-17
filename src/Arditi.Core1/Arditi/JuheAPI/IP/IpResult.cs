using System.Text.Json.Serialization;

namespace Arditi.JuheAPI.IP;

public sealed record IpResult
{
    [JsonPropertyName("Country")] public string? Country { get; set; }
    [JsonPropertyName("Province")] public string? Province { get; set; }
    [JsonPropertyName("City")] public string? City { get; set; }
    [JsonPropertyName("Isp")] public string? Isp { get; set; }
}
