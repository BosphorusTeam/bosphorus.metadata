using System.Reflection;
using Bosphorus.Metadata.Core.Metadata;

namespace Bosphorus.Metadata.Class.Metadata
{
    public class Unique: IMetadata<PropertyInfo>
    {
        public PropertyInfo Owner { get; set; }
    }
}