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
        private readonly IWindsorContainer container;

        public Installer(ITypeProvider typeProvider, IWindsorContainer container)
        {
            this.typeProvider = typeProvider;
            this.container = container;
        }

        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Classes.From(typeProvider.LoadedTypes)
                    .BasedOn(typeof(IClassMetadataRegisterer<>))
                    .WithService
                    .Self()
                    .Configure(Configure),

                Component
                    .For(typeof(ClassMetadataRegistry<>)),

                Component
                    .For(typeof(ClassMetadataProvider<>))
            );
        }

        private void Configure(ComponentRegistration registration)
        {
            registration.LifeStyle.Singleton.Start();
            registration.OnCreate(classRegisterer => ExecuteRegistration((dynamic)classRegisterer)); // GOOD TRICK :)
        }

        private void ExecuteRegistration<TModel>(IClassMetadataRegisterer<TModel> classMetadataRegisterer)
        {
            var classMetadataRegistry = container.Resolve<ClassMetadataRegistry<TModel>>();
            classMetadataRegisterer.Register(classMetadataRegistry);
        }
    }
}
