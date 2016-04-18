using System;
using System.Linq;
using System.Reflection;
using Bosphorus.Metadata.Core.Metadata;
using Bosphorus.Metadata.Core.Metadata.Provider;

namespace Bosphorus.Metadata.Class.Metadata.Provider
{
    public class ClassMetadata<TModel>
    {
        private readonly GenericMetadataProvider genericMetadataProvider;

        public ClassMetadata(GenericMetadataProvider genericMetadataProvider)
        {
            this.genericMetadataProvider = genericMetadataProvider;
        }

        public TMetadata Get<TMetadata>()
            where TMetadata : IMetadata<Type>
        {
            var result = Query<TMetadata>().FirstOrDefault();
            return result;
        }

        public IQueryable<TMetadata> Query<TMetadata>()
            where TMetadata : IMetadata<Type>
        {
            var result = genericMetadataProvider.GetMetadatas(typeof (TModel))
                .OfType<TMetadata>();

            return result;
        }

        public TMetadata GetProperty<TMetadata>()
            where TMetadata : IMetadata<PropertyInfo>
        {
            var result = QueryProperty<TMetadata>().FirstOrDefault();
            return result;
        }

        public IQueryable<TMetadata> QueryProperty<TMetadata>()
            where TMetadata : IMetadata<PropertyInfo>
        {
            var result = genericMetadataProvider.GetMetadatas<PropertyInfo>()
                .Where(metadata => metadata.Owner.ReflectedType == typeof (TModel))
                .OfType<TMetadata>();

            return result;
        }
    }
}
