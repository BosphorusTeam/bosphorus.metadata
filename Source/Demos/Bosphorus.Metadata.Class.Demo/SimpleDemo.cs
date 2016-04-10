using Bosphorus.Assemble.BootStrapper.Runner.Demo.ExecutableItem;
using Bosphorus.Metadata.Class.Demo.Metadata;
using Bosphorus.Metadata.Class.Demo.Model;
using Bosphorus.Metadata.Class.Metadata;
using Bosphorus.Metadata.Class.Metadata.Provider;
using Castle.Windsor;

namespace Bosphorus.Metadata.Class.Demo
{
    public class SimpleDemo: AbstractMethodExecutionItemList
    {
        private readonly GenericClassMetadataProvider classMetadataProvider;

        public SimpleDemo(IWindsorContainer container, GenericClassMetadataProvider classMetadataProvider) 
            : base(container)
        {
            this.classMetadataProvider = classMetadataProvider;
        }

        public BusinessEntity Type_Simple()
        {
            BusinessEntity businessEntity = classMetadataProvider.Of<Customer>().GetMetadata<BusinessEntity>();
            return businessEntity;
        }

        public Identificator Member_Identificator()
        {
            Identificator identificator = classMetadataProvider.Of<Customer>().GetMemberMetadata<Identificator>();
            return identificator;
        }

        public Unique Member_Unique()
        {
            Unique unique = classMetadataProvider.Of<Customer>().GetMemberMetadata<Unique>();
            return unique;
        }

    }
}
