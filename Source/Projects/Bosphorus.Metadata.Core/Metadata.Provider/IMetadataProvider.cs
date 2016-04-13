using System.Linq;

namespace Bosphorus.Metadata.Core.Metadata.Provider
{
    public interface IMetadataProvider<out TOwner>
    {
        IQueryable<IMetadata<TOwner>> Metadatas { get; }

    }
}
