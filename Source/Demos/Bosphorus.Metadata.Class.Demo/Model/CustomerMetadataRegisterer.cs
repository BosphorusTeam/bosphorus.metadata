using Bosphorus.Metadata.Class.Demo.Metadata;
using Bosphorus.Metadata.Class.Metadata;
using Bosphorus.Metadata.Class.Metadata.Registration;

namespace Bosphorus.Metadata.Class.Demo.Model
{
    public class CustomerMetadataRegisterer: ClassMetadataRegisterer<Customer>
    {
        protected override void Register(ClassMetadataRegistration<Customer> model)
        {
            model.Is<BusinessEntity>();
            model.Property(x => x.Id).Is<Identificator>().Is<Unique>();
        }
    }
}
