using System;

namespace WebMotions.Azure.WebJobs.Extensions.Slack
{
    /// <summary>
    /// Specifies the metadata class to associate with a enum member value.
    /// </summary>
    [System.AttributeUsage(System.AttributeTargets.Field, AllowMultiple = false)]

    public class EnumMetadataTypeAttribute : Attribute
    {
        public Type Type { get; private set; }
        public EnumMetadataTypeAttribute(Type type)
        {
            if (type == null)
            {
                throw new ArgumentNullException(nameof(type));
            }
            Type = type;
        }
    }
}