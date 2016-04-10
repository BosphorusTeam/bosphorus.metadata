using Castle.Windsor;

namespace Bosphorus.Metadata.Class.Metadata.Provider
{
    public class GenericClassMetadataProvider
    {
        private readonly IWindsorContainer container;

        public GenericClassMetadataProvider(IWindsorContainer container)
        {
            this.container = container;
        }

        public ClassMetadataProvider<TModel> Of<TModel>()
        {
            ClassMetadataProvider<TModel> result = container.Resolve<ClassMetadataProvider<TModel>>();
            return result;
        }
    }
}
