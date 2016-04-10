using System.Linq;

namespace Bosphorus.Metadata.Core.Metadata.Provider
{
    public interface IMetadataProvider<TOwner>
    {
        IQueryable<IMetadata<TOwner>> GetMetadatas(TOwner owner);

    }
}
