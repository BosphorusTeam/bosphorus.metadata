using System.Reflection;
using Bosphorus.Metadata.Core.Metadata;

namespace Bosphorus.Metadata.Class.Metadata
{
    public static class PropertyMetadataExtensions
    {
        public static object GetValue(this IMetadata<PropertyInfo> extended, object model)
        {
            PropertyInfo propertyInfo = extended.Owner;
            object result = propertyInfo.GetValue(model);

            return result;
        }
    }
}
