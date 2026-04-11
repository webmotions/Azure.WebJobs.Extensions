using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace WebMotions.Azure.WebJobs.Extensions.Slack.Converters
{
    /// <summary>
    /// Converts a block element
    /// </summary>
    public class SlackBlockElementConverter : JsonConverter<object>
    {
        public override bool CanConvert(Type typeToConvert)
        {
            return true;
        }

        public override object? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.StartObject)
            {
                using var doc = JsonDocument.ParseValue(ref reader);
                return GetBlockElement(doc.RootElement, options);
            }

            if (reader.TokenType == JsonTokenType.StartArray)
            {
                var list = new List<object?>();

                while (reader.Read())
                {
                    if (reader.TokenType == JsonTokenType.EndArray)
                        break;

                    using var doc = JsonDocument.ParseValue(ref reader);
                    var element = GetBlockElement(doc.RootElement, options);

                    if (element != null)
                        list.Add(element);
                }

                return list;
            }

            return null;
        }

        private object? GetBlockElement(JsonElement element, JsonSerializerOptions options)
        {
            if (element.ValueKind != JsonValueKind.Object)
                return null;

            if (!element.TryGetProperty("type", out var typeProperty))
            {
                throw new JsonException("The type property was not found.");
            }

            var typeValue = typeProperty.GetString();

            if (string.IsNullOrWhiteSpace(typeValue))
            {
                throw new NullReferenceException($"{nameof(typeValue)} is null or whitespace");
            }

            return SlackConverterHelpers.GetBlockElement(typeValue, element);
        }

        public override void Write(Utf8JsonWriter writer, object value, JsonSerializerOptions options)
        {
            JsonSerializer.Serialize(writer, value, value.GetType(), options);
        }
    }
}