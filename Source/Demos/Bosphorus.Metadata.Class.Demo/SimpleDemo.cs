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
        private readonly ClassMetadata<Customer> customerMetadata;

        public SimpleDemo(IWindsorContainer container, ClassMetadata<Customer> customerMetadata) 
            : base(container)
        {
            this.customerMetadata = customerMetadata;
        }

        public BusinessEntity Type_BusinessEntity()
        {
            BusinessEntity businessEntity = customerMetadata.Get<BusinessEntity>();
            return businessEntity;
        }

        public Identificator Member_Identificator()
        {
            Identificator identificator = customerMetadata.GetProperty<Identificator>();
            return identificator;
        }

        public Unique Member_Unique()
        {
            Unique unique = customerMetadata.GetProperty<Unique>();
            return unique;
        }

    }
}
