using System.Collections.Generic;

namespace Bosphorus.Metadata.Core.Metadata.Provider
{
    public interface IMetadataBuilder<TOwner>
    {
        IEnumerable<IMetadata<TOwner>> Build(TOwner owner);

    }
}