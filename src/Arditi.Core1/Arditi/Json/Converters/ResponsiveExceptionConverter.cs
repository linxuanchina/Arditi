using System.Text.Json;
using System.Text.Json.Serialization;
using Arditi.Application;

namespace Arditi.Json.Converters;

public sealed class ResponsiveExceptionConverter : JsonConverter<IRevealableException>
{
    public override bool CanConvert(Type typeToConvert) =>
        typeof(ApplicationException).IsAssignableFrom(typeToConvert);

    public override IRevealableException Read(ref Utf8JsonReader reader, Type typeToConvert,
        JsonSerializerOptions options) =>
        throw new NotSupportedException($"{nameof(ApplicationException)} can not be deserialized");

    public override void Write(Utf8JsonWriter writer, IRevealableException value,
        JsonSerializerOptions options)
    {
        void WritePropertyName(string propertyName) =>
            writer.WritePropertyName(options.PropertyNamingPolicy?.ConvertName(propertyName) ?? propertyName);

        writer.WriteStartObject();

        WritePropertyName(nameof(value.Code));
        writer.WriteStringValue(value.Code);

        WritePropertyName(nameof(value.Description));
        writer.WriteStringValue(value.Description);

        if (options.DefaultIgnoreCondition == JsonIgnoreCondition.Never ||
            (options.DefaultIgnoreCondition is JsonIgnoreCondition.WhenWritingDefault
                or JsonIgnoreCondition.WhenWritingNull && value.Context.IsNotNull()))
        {
            WritePropertyName(nameof(value.Context));
            JsonSerializer.Serialize(writer, value.Context, options);
        }

        writer.WriteEndObject();
    }
}
