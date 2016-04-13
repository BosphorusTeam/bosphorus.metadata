using System.Collections.Generic;

namespace Bosphorus.Metadata.Core.Metadata.Repository
{
    public class DefaultMetadataRepository<TOwner> : IMetadataRepository<TOwner>
    {
        public ICollection<IMetadata<TOwner>> Metadatas { get; }

        public DefaultMetadataRepository()
        {
            Metadatas = new List<IMetadata<TOwner>>();
        }

    }
}