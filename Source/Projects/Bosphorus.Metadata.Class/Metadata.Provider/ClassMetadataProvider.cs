using System;
using System.Linq;
using System.Reflection;
using Bosphorus.Metadata.Core.Metadata;
using Bosphorus.Metadata.Core.Metadata.Provider;

namespace Bosphorus.Metadata.Class.Metadata.Provider
{
    public class ClassMetadataProvider<TModel>
    {
        private readonly GenericMetadataProvider genericMetadataProvider;

        public ClassMetadataProvider(GenericMetadataProvider genericMetadataProvider)
        {
            this.genericMetadataProvider = genericMetadataProvider;
        }

        public TMetadata GetMetadata<TMetadata>()
            where TMetadata : IMetadata<Type>
        {
            var result = genericMetadataProvider.GetMetadatas(typeof (TModel))
                .OfType<TMetadata>()
                .FirstOrDefault();

            return result;
        }

        public TMetadata GetMemberMetadata<TMetadata>()
            where TMetadata : IMetadata<PropertyInfo>
        {
            var result = genericMetadataProvider.GetMetadatas<PropertyInfo>()
                .OfType<TMetadata>()
                .FirstOrDefault(metadata => metadata.Owner.ReflectedType == typeof(TModel));

            return result;
        }
    }
}
