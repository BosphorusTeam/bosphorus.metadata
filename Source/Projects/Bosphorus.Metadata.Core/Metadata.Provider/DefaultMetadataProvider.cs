using System.Linq;
using Bosphorus.Metadata.Core.Metadata.Repository;

namespace Bosphorus.Metadata.Core.Metadata.Provider
{
    public class DefaultMetadataProvider<TOwner> : IMetadataProvider<TOwner>
    {
        private readonly IMetadataRepository<TOwner> repository;

        public DefaultMetadataProvider(IMetadataRepository<TOwner> repository)
        {
            this.repository = repository;
        }

        public IQueryable<IMetadata<TOwner>> Metadatas => repository.Metadatas.AsQueryable();
    }
}