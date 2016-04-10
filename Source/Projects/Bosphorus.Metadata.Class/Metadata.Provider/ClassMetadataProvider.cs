using System;
using System.Linq;
using System.Reflection;
using Bosphorus.Metadata.Core.Metadata;
using Bosphorus.Metadata.Core.Metadata.Provider;

namespace Bosphorus.Metadata.Class.Metadata.Provider
{
    public class ClassMetadataProvider<TModel>
    {
        private readonly IQueryable<IMetadata<Type>> metadatas;

        public ClassMetadataProvider(IMetadataProvider<Type> metadataProvider)
        {
            this.metadatas = metadataProvider.GetMetadatas(typeof (TModel));
        }

        public TMetadata GetMetadata<TMetadata>()
            where TMetadata : IMetadata<Type>
        {
            TMetadata result = metadatas
                .OfType<TMetadata>()
                .FirstOrDefault();

            return result;
        }

        public TMetadata GetMemberMetadata<TMetadata>()
            where TMetadata : IMetadata<PropertyInfo>
        {
            TMetadata result = metadatas
                .OfType<PropertyMetadataWrapper>()
                .Select(metadata => metadata.ChildMetadata)
                .OfType<TMetadata>()
                .FirstOrDefault();

            return result;
        }
    }
}
