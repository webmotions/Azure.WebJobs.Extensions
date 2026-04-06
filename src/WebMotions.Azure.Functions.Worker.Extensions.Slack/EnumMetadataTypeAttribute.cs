namespace WebMotions.Azure.Functions.Worker.Extensions.Slack
{
    /// <summary>
    /// Specifies the metadata class to associate with a enum member value.
    /// </summary>
    [AttributeUsage(AttributeTargets.Field)]

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