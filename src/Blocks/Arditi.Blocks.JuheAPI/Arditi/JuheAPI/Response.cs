using System.Text.Json.Serialization;

namespace Arditi.JuheAPI;

public record Response
{
    [JsonPropertyName("error_code")]
    public int? ErrorCode { get; set; }

    [JsonPropertyName("reason")]
    public string? Reason { get; set; }
}
