using System.Text.Json;
using System.Text.Json.Serialization;

namespace Microsoft.AspNetCore.Mvc;

public static class JsonOptionsExtensions
{
    public static JsonOptions ConfigureJsonSerializer(this JsonOptions options)
    {
        options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
        options.JsonSerializerOptions.IgnoreReadOnlyFields = false;
        options.JsonSerializerOptions.IgnoreReadOnlyProperties = false;
        options.JsonSerializerOptions.IncludeFields = false;
        options.JsonSerializerOptions.MaxDepth = 64;
        options.JsonSerializerOptions.NumberHandling = JsonNumberHandling.Strict;
        options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
        options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
        options.JsonSerializerOptions.ReadCommentHandling = JsonCommentHandling.Disallow;
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
        options.JsonSerializerOptions.UnknownTypeHandling = JsonUnknownTypeHandling.JsonNode;
        options.JsonSerializerOptions.WriteIndented = false;
        options.JsonSerializerOptions
            .AddGuidConverter()
            .AddLongEpochTimeConverter()
            .AddApplicationExceptionConverter();
        return options;
    }
}
