using System.Text.Json;
using System.Text.Json.Serialization;
using Autofac;

namespace Arditi.Json;

[NamedService(nameof(JuheApiJsonSerializerOptionsFactory))]
public sealed class JuheApiJsonSerializerOptionsFactory : IJsonSerializerOptionsFactory
{
    public JsonSerializerOptions CreateJsonSerializerOptions()
    {
        return new JsonSerializerOptions(JsonSerializerDefaults.General)
        {
            DefaultIgnoreCondition = JsonIgnoreCondition.Never,
            IgnoreReadOnlyFields = false,
            IgnoreReadOnlyProperties = false,
            IncludeFields = false,
            MaxDepth = 64,
            NumberHandling = JsonNumberHandling.Strict,
            PropertyNameCaseInsensitive = true,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            ReadCommentHandling = JsonCommentHandling.Skip,
            ReferenceHandler = ReferenceHandler.IgnoreCycles,
            UnknownTypeHandling = JsonUnknownTypeHandling.JsonNode,
            WriteIndented = false
        };
    }
}
