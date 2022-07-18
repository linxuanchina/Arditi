using System.Text.Json;
using System.Text.Json.Serialization;

namespace Arditi.Json.Converters;

public sealed class ApplicationExceptionConverter : JsonConverter<Arditi.Application.ApplicationException>
{
    public override bool CanConvert(Type typeToConvert) =>
        typeof(ApplicationException).IsAssignableFrom(typeToConvert);

    public override Arditi.Application.ApplicationException Read(ref Utf8JsonReader reader, Type typeToConvert,
        JsonSerializerOptions options) =>
        throw new NotSupportedException($"{nameof(ApplicationException)} can not be deserialized");

    public override void Write(Utf8JsonWriter writer, Arditi.Application.ApplicationException value,
        JsonSerializerOptions options)
    {
        void WritePropertyName(string propertyName) =>
            writer.WritePropertyName(options.PropertyNamingPolicy?.ConvertName(propertyName) ?? propertyName);

        writer.WriteStartObject();

        WritePropertyName(nameof(value.Code));
        writer.WriteNumberValue(value.Code);

        WritePropertyName(nameof(value.Message));
        writer.WriteStringValue(value.Message);

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
