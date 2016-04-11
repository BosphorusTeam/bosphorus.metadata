using System.Collections.Generic;

namespace Bosphorus.Metadata.Core.Metadata.Registration
{
    public class DefaultMetadataRepository<TOwner> : IMetadataRepository<TOwner>
    {
        public IList<IMetadata<TOwner>> Metadatas { get; }

        public DefaultMetadataRepository()
        {
            Metadatas = new List<IMetadata<TOwner>>();
        }

    }
}