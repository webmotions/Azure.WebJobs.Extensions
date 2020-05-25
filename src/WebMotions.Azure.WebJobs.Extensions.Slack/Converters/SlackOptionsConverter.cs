using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using WebMotions.Azure.WebJobs.Extensions.Slack.Models.Objects;

namespace WebMotions.Azure.WebJobs.Extensions.Slack.Converters
{
    public class SlackOptionsConverter : JsonConverter
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
                return GetOptionElement(item);
            }

            if (reader.TokenType == JsonToken.StartArray)
            {
                reader.Read();
                var ret = new List<object>();
                while (reader.TokenType != JsonToken.EndArray)
                {
                    var item = JObject.Load(reader);
                    ret.Add(GetOptionElement(item));
                    reader.Read();
                }

                return ret;
            }

            return null;
        }

        private object GetOptionElement(JObject item)
        {
            if (item.TryGetValue("text", StringComparison.OrdinalIgnoreCase, out var _))
            {
                return item.ToObject<SlackOption>();
            }

            if (item.TryGetValue("label", StringComparison.OrdinalIgnoreCase, out var _))
            {
                return item.ToObject<SlackOptionGroup>();
            }

            return null;
        }

        public override bool CanConvert(Type objectType)
        {
            return true;
        }

        public override bool CanWrite => false;
    }
}