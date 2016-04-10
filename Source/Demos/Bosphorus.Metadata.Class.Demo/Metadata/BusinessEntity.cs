using System;
using Bosphorus.Metadata.Core.Metadata;

namespace Bosphorus.Metadata.Class.Demo.Metadata
{
    public class BusinessEntity: IMetadata<Type>
    {
        public Type Owner { get; set; }
    }
}