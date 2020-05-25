using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;

namespace WebMotions.Azure.WebJobs.Extensions.Slack
{
    internal static class Utility
    {
        internal static string FirstOrDefault(params string[] values)
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

            for (int i = 0; i < memInfo.Length; i++)
            {
                var attr1 = memInfo[i].GetCustomAttribute(typeof(EnumMemberAttribute));
                var attr2 = memInfo[i].GetCustomAttribute(typeof(EnumMetadataTypeAttribute));

                if (attr1 == null || attr2 == null)
                {
                    continue;
                }

                var enumMemberAttribute = (EnumMemberAttribute)attr1;
                var metadatAttribute = (EnumMetadataTypeAttribute)attr2;
                ret[enumMemberAttribute.Value] = metadatAttribute.Type;
            }

            return ret;
        }
    }
}