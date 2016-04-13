using Bosphorus.Common.Api.Container;
using Bosphorus.Metadata.Core.Metadata.Provider;
using Bosphorus.Metadata.Core.Metadata.Repository;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace Bosphorus.Metadata.Core
{
    public class Installer: IBosphorusInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component
                    .For(typeof(IMetadataProvider<>))
                    .ImplementedBy(typeof(DefaultMetadataProvider<>)),

                Component
                    .For<GenericMetadataProvider>(),

                Component
                    .For(typeof(IMetadataRepository<>))
                    .ImplementedBy(typeof(DefaultMetadataRepository<>)),

                Component
                    .For<GenericMetadataRepostiory>()
            );
        }
    }
}
