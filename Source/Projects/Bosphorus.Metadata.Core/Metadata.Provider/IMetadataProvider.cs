using System.Collections.Generic;

namespace Bosphorus.Metadata.Core.Metadata.Provider
{
    public interface IMetadataProvider<TOwner>
    {
        IEnumerable<IMetadata<TOwner>> GetMetadatas(TOwner owner);

    }
}
