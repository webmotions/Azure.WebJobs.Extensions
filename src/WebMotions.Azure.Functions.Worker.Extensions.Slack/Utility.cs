using System.Reflection;
using System.Runtime.Serialization;

namespace WebMotions.Azure.Functions.Worker.Extensions.Slack
{
    internal static class Utility
    {
        internal static string? FirstOrDefault(params string?[] values)
        {
            return values.FirstOrDefault(v => !string.IsNullOrEmpty(v));
        }

        /// <summary>
        /// Gets a mapping between the enum member value and the metadata class
        /// </summary>
        /// <param name="enumType">The type of the enum</param>
        /// <returns>The mapping between the enum member value and the metadata class</returns>
        internal static IDictionary<string, Type> GetEnumMemberValueAndMetadata(Type enumType)
        {
            var ret = new Dictionary<string, Type>();
            var memInfo = enumType.GetMembers();

            foreach (var member in memInfo)
            {
                var attr1 = member.GetCustomAttribute(typeof(EnumMemberAttribute));
                var attr2 = member.GetCustomAttribute(typeof(EnumMetadataTypeAttribute));

                if (attr1 == null || attr2 == null)
                {
                    continue;
                }

                var enumMemberAttribute = (EnumMemberAttribute)attr1;
                var metadataAttribute = (EnumMetadataTypeAttribute)attr2;
                ret[enumMemberAttribute.Value!] = metadataAttribute.Type;
            }

            return ret;
        }
    }
}