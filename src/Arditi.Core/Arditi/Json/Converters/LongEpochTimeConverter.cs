using System.Text.Json;
using System.Text.Json.Serialization;

namespace Arditi.Json.Converters;

public sealed class LongEpochTimeConverter : JsonConverter<DateTime>
{
    public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) =>
        EpochTimeHelper.LongEpochTimeToDateTime(reader.GetInt64());


    public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options) =>
        writer.WriteNumberValue(EpochTimeHelper.DateTimeToLongEpochTime(value));
}
