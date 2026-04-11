using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using WebMotions.Azure.WebJobs.Extensions.Slack.Models.Objects;

namespace WebMotions.Azure.WebJobs.Extensions.Slack.Converters
{
    public class SlackTextConverter : JsonConverter<SlackText>
    {
        public override bool CanConvert(Type typeToConvert)
        {
            return true;
        }

        public override SlackText? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.StartObject)
            {
                using var doc = JsonDocument.ParseValue(ref reader);
                return GetElement(doc.RootElement, options);
            }

            return null;
        }

        private SlackText GetElement(JsonElement element, JsonSerializerOptions options)
        {
            if (element.ValueKind != JsonValueKind.Object)
            {
                throw new JsonException("Expected object for SlackText element");
            }

            if (!element.TryGetProperty("type", out var typeProperty))
            {
                throw new JsonException("The type property was not found");
            }

            var typeValue = typeProperty.GetString();

            if (string.IsNullOrWhiteSpace(typeValue))
            {
                throw new NullReferenceException($"{nameof(typeValue)} is null or whitespace");
            }

            if (!SlackConverterHelpers.TextMapping.TryGetValue(typeValue, out var textClassType))
            {
                throw new JsonException($"The type {typeValue} is not a text type that is supported");
            }

            return (SlackText)JsonSerializer.Deserialize(element.GetRawText(), textClassType, options)!;
        }

        public override void Write(Utf8JsonWriter writer, SlackText value, JsonSerializerOptions options)
        {
            JsonSerializer.Serialize(writer, value, value.GetType(), options);
        }
    }
}