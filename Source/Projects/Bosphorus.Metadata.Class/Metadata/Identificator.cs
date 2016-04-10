using System.Reflection;
using Bosphorus.Metadata.Core.Metadata;

namespace Bosphorus.Metadata.Class.Metadata
{
    public class Identificator : IMetadata<PropertyInfo>
    {
        public PropertyInfo Owner { get; set; }
    }
}