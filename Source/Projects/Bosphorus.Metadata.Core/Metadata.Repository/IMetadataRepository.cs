using System.Collections.Generic;

namespace Bosphorus.Metadata.Core.Metadata.Repository
{
    public interface IMetadataRepository<TOwner>
    {
        ICollection<IMetadata<TOwner>> Metadatas { get; }

    }

}