using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace WebMotions.Azure.WebJobs.Extensions.Slack.Converters
{
    public class JsonStringEnumConverter<T> : JsonConverter<T> where T : struct, Enum
    {
        private static readonly Dictionary<string, T> _readMap = new Dictionary<string, T>(StringComparer.OrdinalIgnoreCase);
        private static readonly Dictionary<T, string> _writeMap = new Dictionary<T, string>();

        static JsonStringEnumConverter()
        {
            var type = typeof(T);

            foreach (var field in type.GetFields(BindingFlags.Public | BindingFlags.Static))
            {
                var enumValue = (T)field.GetValue(null)!;

                var enumMemberAttr = field.GetCustomAttribute<EnumMemberAttribute>();
                var name = enumMemberAttr?.Value ?? field.Name;

                _readMap[name] = enumValue;
                _writeMap[enumValue] = name;
            }
        }

        public override T Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var value = reader.GetString();

            if (value == null)
            {
                throw new JsonException($"Unable to convert null to enum {typeof(T)}");
            }

            if (_readMap.TryGetValue(value, out var enumValue))
            {
                return enumValue;
            }

            throw new JsonException($"Unknown value '{value}' for enum {typeof(T)}");
        }

        public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options)
        {
            if (_writeMap.TryGetValue(value, out var stringValue))
            {
                writer.WriteStringValue(stringValue);
                return;
            }

            writer.WriteStringValue(value.ToString());
        }
    }
}