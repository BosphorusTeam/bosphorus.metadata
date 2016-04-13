using Bosphorus.Metadata.Core.Metadata.Registration;
using Castle.Windsor;

namespace Bosphorus.Metadata.Core.Metadata.Repository
{
    public class GenericMetadataRepostiory
    {
        private readonly IWindsorContainer container;

        public GenericMetadataRepostiory(IWindsorContainer container)
        {
            this.container = container;
        }

        public MetadataRegistry<TOwner> RegistryFor<TOwner>(TOwner owner)
        {
            var metadataRepository = container.Resolve<IMetadataRepository<TOwner>>();
            return new MetadataRegistry<TOwner>(owner, metadataRepository);
        }
    }
}
