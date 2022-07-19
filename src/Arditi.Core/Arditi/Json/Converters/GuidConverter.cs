using System.Text.Json;
using System.Text.Json.Serialization;

namespace Arditi.Json.Converters;

public sealed class GuidConverter : JsonConverter<Guid>
{
    public override Guid Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) =>
        reader.GetGuid();

    public override void Write(Utf8JsonWriter writer, Guid value, JsonSerializerOptions options) =>
        writer.WriteStringValue(GuidHelper.Format(value));
}
