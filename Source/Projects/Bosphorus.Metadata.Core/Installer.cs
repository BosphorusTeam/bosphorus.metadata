using Bosphorus.Common.Api.Container;
using Bosphorus.Common.Api.Symbol;
using Bosphorus.Metadata.Core.Metadata.Provider;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace Bosphorus.Metadata.Core
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
                    .BasedOn(typeof(IMetadataBuilder<>))
                    .WithService
                    .FromInterface(),

                Component
                    .For(typeof(IMetadataProvider<>))
                    .ImplementedBy(typeof(DefaultMetadataProvider<>))
            );
        }
    }
}
