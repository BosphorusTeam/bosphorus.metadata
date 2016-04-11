using Bosphorus.Common.Api.Container;
using Bosphorus.Common.Api.Symbol;
using Bosphorus.Metadata.Class.Metadata.Provider;
using Bosphorus.Metadata.Class.Metadata.Registration;
using Castle.Facilities.Startable;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace Bosphorus.Metadata.Class
{
    public class Installer: IBosphorusInstaller
    {
        private readonly ITypeProvider typeProvider;

        public Installer(ITypeProvider typeProvider)
        {
            this.typeProvider = typeProvider;
        }

        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Classes.From(typeProvider.LoadedTypes)
                    .BasedOn(typeof(ClassMetadataRegisterer<>))
                    .WithService
                    .Self()
                    .Configure(registration => registration.LifeStyle.Singleton.Start()),

                Component
                    .For(typeof(ClassMetadataProvider<>)),

                Component
                    .For<GenericClassMetadataProvider>()
            );
        }
    }
}
