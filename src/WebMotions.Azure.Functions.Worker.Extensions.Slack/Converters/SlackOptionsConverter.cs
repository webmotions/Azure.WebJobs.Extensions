using System.Text.Json;
using System.Text.Json.Serialization;
using WebMotions.Azure.Functions.Worker.Extensions.Slack.Models.Objects;

namespace WebMotions.Azure.Functions.Worker.Extensions.Slack.Converters
{
    public class SlackOptionsConverter : JsonConverter<List<object>>
    {
        public override bool CanConvert(Type typeToConvert)
        {
            return true;
        }

        public override List<object>? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            //if (reader.TokenType == JsonTokenType.StartObject)
            //{
            //    using var doc = JsonDocument.ParseValue(ref reader);
            //    return GetOptionElement(doc.RootElement, options);
            //}

            if (reader.TokenType == JsonTokenType.StartArray)
            {
                var list = new List<object?>();

                while (reader.Read())
                {
                    if (reader.TokenType == JsonTokenType.EndArray)
                        break;

                    using var doc = JsonDocument.ParseValue(ref reader);
                    var element = GetOptionElement(doc.RootElement, options);

                    if (element != null)
                        list.Add(element);
                }

                return list!;
            }

            return null;
        }

        private object? GetOptionElement(JsonElement element, JsonSerializerOptions options)
        {
            if (element.ValueKind != JsonValueKind.Object)
            {
                return null;
            }

            if (element.TryGetProperty("text", out _))
            {
                return JsonSerializer.Deserialize<SlackOption>(element.GetRawText(), options);
            }

            if (element.TryGetProperty("label", out _))
            {
                return JsonSerializer.Deserialize<SlackOptionGroup>(element.GetRawText(), options);
            }

            return null;
        }

        public override void Write(Utf8JsonWriter writer, List<object> value, JsonSerializerOptions options)
        {
            JsonSerializer.Serialize(writer, value, value.GetType(), options);
        }
    }
}