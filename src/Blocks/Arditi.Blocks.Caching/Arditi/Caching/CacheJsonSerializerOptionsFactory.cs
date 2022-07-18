using System.Text.Json;
using System.Text.Json.Serialization;
using Arditi.Json;
using Autofac;

namespace Arditi.Caching;

[NamedService(nameof(CacheJsonSerializerOptionsFactory))]
public sealed class CacheJsonSerializerOptionsFactory : IJsonSerializerOptionsFactory
{
    public JsonSerializerOptions CreateJsonSerializerOptions() =>
        new JsonSerializerOptions(JsonSerializerDefaults.General)
            {
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
                IgnoreReadOnlyFields = false,
                IgnoreReadOnlyProperties = false,
                IncludeFields = false,
                MaxDepth = 64,
                NumberHandling = JsonNumberHandling.Strict,
                PropertyNameCaseInsensitive = true,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                ReadCommentHandling = JsonCommentHandling.Skip,
                ReferenceHandler = ReferenceHandler.Preserve,
                UnknownTypeHandling = JsonUnknownTypeHandling.JsonNode,
                WriteIndented = false
            }
            .AddGuidConverter()
            .AddLongEpochTimeConverter();
}
