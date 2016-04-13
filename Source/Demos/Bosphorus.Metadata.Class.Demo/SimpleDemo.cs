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
        private readonly ClassMetadataProvider<Customer> customerMetadataProvider;

        public SimpleDemo(IWindsorContainer container, ClassMetadataProvider<Customer> customerMetadataProvider) 
            : base(container)
        {
            this.customerMetadataProvider = customerMetadataProvider;
        }

        public BusinessEntity Type_Simple()
        {
            BusinessEntity businessEntity = customerMetadataProvider.GetMetadata<BusinessEntity>();
            return businessEntity;
        }

        public Identificator Member_Identificator()
        {
            Identificator identificator = customerMetadataProvider.GetMemberMetadata<Identificator>();
            return identificator;
        }

        public Unique Member_Unique()
        {
            Unique unique = customerMetadataProvider.GetMemberMetadata<Unique>();
            return unique;
        }

    }
}
