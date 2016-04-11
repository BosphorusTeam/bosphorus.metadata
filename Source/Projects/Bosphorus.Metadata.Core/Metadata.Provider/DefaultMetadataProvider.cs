using System.Collections.Generic;
using System.Linq;
using Bosphorus.Metadata.Core.Metadata.Registration;

namespace Bosphorus.Metadata.Core.Metadata.Provider
{
    public class DefaultMetadataProvider<TOwner> : IMetadataProvider<TOwner>
    {
        private readonly IMetadataRepository<TOwner> repository;

        public DefaultMetadataProvider(IMetadataRepository<TOwner> repository)
        {
            this.repository = repository;
        }

        public IEnumerable<IMetadata<TOwner>> GetMetadatas(TOwner owner)
        {
            var result = repository.Metadatas.Where(metadata => metadata.Owner.Equals(owner));
            return result;
        }
    }
}