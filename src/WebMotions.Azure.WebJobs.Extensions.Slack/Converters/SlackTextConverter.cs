using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using WebMotions.Azure.WebJobs.Extensions.Slack.Models.Objects;

namespace WebMotions.Azure.WebJobs.Extensions.Slack.Converters
{
    public class SlackTextConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.StartObject)
            {
                var item = JObject.Load(reader);
                return GetElement(item);
            }

            if (reader.TokenType == JsonToken.StartArray)
            {
                reader.Read();
                var ret = new List<object>();
                while (reader.TokenType != JsonToken.EndArray)
                {
                    var item = JObject.Load(reader);
                    ret.Add(GetElement(item));
                    reader.Read();
                }

                return ret;
            }

            return null;
        }

        private SlackText GetElement(JObject item)
        {
            if (!item.TryGetValue("type", StringComparison.OrdinalIgnoreCase, out JToken textType))
            {
                throw new JsonException("The type property was not found");
            }

            var textTypeValue = textType.Value<string>();
            if (!SlackConverterHelpers.TextMapping.TryGetValue(textTypeValue, out var textClassType))
            {
                throw new JsonException($"The type {textTypeValue} is not a text type that is supported");
            }

            return (SlackText)item.ToObject(textClassType);
        }

        public override bool CanConvert(Type objectType)
        {
            return true;
        }

        public override bool CanWrite => false;
    }
}