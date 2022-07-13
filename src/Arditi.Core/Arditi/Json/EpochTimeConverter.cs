using System.Text.Json;
using System.Text.Json.Serialization;

namespace Arditi.Json;

public sealed class EpochTimeConverter : JsonConverter<DateTime>
{
    public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) =>
        EpochTimeHelper.EpochTimeToDateTime(reader.GetInt32());

    public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options) =>
        writer.WriteNumberValue(EpochTimeHelper.DateTimeToEpochTime(value));
}
