using Arditi.Json.Converters;

namespace System.Text.Json;

public static class JsonSerializerOptionsExtensions
{
    public static JsonSerializerOptions AddApplicationExceptionConverter(this JsonSerializerOptions options)
    {
        options.Converters.Add(new ApplicationExceptionConverter());
        return options;
    }
}
