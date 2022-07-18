using System.Text.Json.Serialization;

namespace Arditi.JuheAPI;

public sealed record MultipleResultResponse<TResult> : Response
{
    [JsonPropertyName("result")] public IEnumerable<TResult>? Result { get; set; }
}
