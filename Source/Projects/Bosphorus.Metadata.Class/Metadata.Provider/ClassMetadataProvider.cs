using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Bosphorus.Metadata.Core.Metadata;
using Bosphorus.Metadata.Core.Metadata.Provider;
using Bosphorus.Metadata.Core.Metadata.Registration;

namespace Bosphorus.Metadata.Class.Metadata.Provider
{
    public class ClassMetadataProvider<TModel>
    {
        private readonly IQueryable<IMetadata<Type>> typeMetadatas;
        private readonly IQueryable<IMetadata<PropertyInfo>> propertyMetadatas;

        public ClassMetadataProvider(IMetadataRepository<Type> typeMetadataRepository, IMetadataRepository<PropertyInfo> propertyMetadataRepository)
        {
            typeMetadatas = typeMetadataRepository.Metadatas.Where(metadata => metadata.Owner == typeof (TModel)).AsQueryable();
            propertyMetadatas = propertyMetadataRepository.Metadatas.Where(metadata => metadata.Owner.ReflectedType == typeof(TModel)).AsQueryable();
        }

        public TMetadata GetMetadata<TMetadata>()
            where TMetadata : IMetadata<Type>
        {
            TMetadata result = typeMetadatas
                .OfType<TMetadata>()
                .FirstOrDefault();

            return result;
        }

        public TMetadata GetMemberMetadata<TMetadata>()
            where TMetadata : class, IMetadata<PropertyInfo>
        {
            return propertyMetadatas.First(metadata => metadata.GetType() == typeof (TMetadata)) as TMetadata;
        }
    }
}
