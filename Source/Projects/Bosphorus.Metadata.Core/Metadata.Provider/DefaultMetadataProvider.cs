using System.Collections.Generic;
using System.Linq;

namespace Bosphorus.Metadata.Core.Metadata.Provider
{
    public class DefaultMetadataProvider<TOwner> : IMetadataProvider<TOwner>
    {
        private readonly IList<IMetadataBuilder<TOwner>> metadataBuilders;

        public DefaultMetadataProvider(IList<IMetadataBuilder<TOwner>> metadataBuilders)
        {
            this.metadataBuilders = metadataBuilders;
        }

        public IQueryable<IMetadata<TOwner>> GetMetadatas(TOwner owner)
        {
            IQueryable<IMetadata<TOwner>> result = metadataBuilders.SelectMany(builder => builder.Build(owner)).AsQueryable();
            return result;
        }
    }
}