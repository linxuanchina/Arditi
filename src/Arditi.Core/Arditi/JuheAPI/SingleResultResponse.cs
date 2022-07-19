using System.Text.Json.Serialization;

namespace Arditi.JuheAPI;

public sealed record SingleResultResponse<TResult> : Response
{
    [JsonPropertyName("result")]
    public TResult? Result { get; set; }
}
