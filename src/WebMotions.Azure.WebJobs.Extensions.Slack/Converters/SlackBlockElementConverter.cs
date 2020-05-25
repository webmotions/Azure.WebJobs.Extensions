using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

namespace WebMotions.Azure.WebJobs.Extensions.Slack.Converters
{
    /// <summary>
    /// Converts a block element
    /// </summary>
    public class SlackBlockElementConverter : JsonConverter
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
                return GetBlockElement(item);
            }

            if (reader.TokenType == JsonToken.StartArray)
            {
                reader.Read();
                var ret = new List<object>();
                while (reader.TokenType != JsonToken.EndArray)
                {
                    var item = JObject.Load(reader);
                    ret.Add(GetBlockElement(item));
                    reader.Read();
                }

                return ret;
            }

            return null;
        }

        private object GetBlockElement(JObject item)
        {
            if (!item.TryGetValue("type", StringComparison.OrdinalIgnoreCase, out JToken blockElement))
            {
                throw new JsonException("The type property was not found.");
            }

            var blockElementTypeValue = blockElement.Value<string>();
            return SlackConverterHelpers.GetBlockElement(blockElementTypeValue, item);
        }

        public override bool CanConvert(Type objectType)
        {
            return true;
        }

        public override bool CanWrite => false;
    }
}