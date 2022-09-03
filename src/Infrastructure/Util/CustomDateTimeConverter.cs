using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Infrastructure.Util;

public class CustomDateTimeConverter: JsonConverter<DateTime>
{
    private readonly string _formato = Constants.DATE_TIME_FORMAT;
    private readonly IFormatProvider _formatProvider = new CultureInfo(Constants.CULTURE_INFO);

    public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        return DateTime.ParseExact(reader.GetString() ?? string.Empty, _formato, _formatProvider);
    }

    public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.ToString(_formato));
    }
}