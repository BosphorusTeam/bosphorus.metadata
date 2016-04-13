using System.Linq;
using Castle.Windsor;

namespace Bosphorus.Metadata.Core.Metadata.Provider
{
    public class GenericMetadataProvider
    {
        private readonly IWindsorContainer container;

        public GenericMetadataProvider(IWindsorContainer container)
        {
            this.container = container;
        }

        public IQueryable<IMetadata<TOwner>> GetMetadatas<TOwner>()
        {
            var metadataProvider = container.Resolve<IMetadataProvider<TOwner>>();
            var result = metadataProvider.Metadatas;
            return result;
        }

        public IQueryable<IMetadata<TOwner>> GetMetadatas<TOwner>(TOwner owner)
        {
            var metadatas = GetMetadatas<TOwner>();
            var result = metadatas.Where(metadata => metadata.Owner.Equals(owner));
            return result;
        }
    }
}
