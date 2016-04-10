using Bosphorus.Common.Api.Container;
using Bosphorus.Metadata.Class.Metadata.Provider;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace Bosphorus.Metadata.Class
{
    public class Installer: IBosphorusInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component
                    .For(typeof(ClassMetadataProvider<>)),

                Component
                    .For<GenericClassMetadataProvider>()
            );
        }
    }
}
