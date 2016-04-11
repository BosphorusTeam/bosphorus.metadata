using System;
using System.Collections.Generic;

namespace Bosphorus.Metadata.Core.Metadata.Registration
{
    public interface IMetadataRepository<TOwner>
    {
        IList<IMetadata<TOwner>> Metadatas { get; }

    }

}