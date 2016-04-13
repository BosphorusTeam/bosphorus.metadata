using Bosphorus.Metadata.Class.Demo.Metadata;
using Bosphorus.Metadata.Class.Metadata;
using Bosphorus.Metadata.Class.Metadata.Registration;

namespace Bosphorus.Metadata.Class.Demo.Model
{
    public class CustomerMetadataRegisterer: IClassMetadataRegisterer<Customer>
    {
        public void Register(ClassMetadataRegistry<Customer> model)
        {
            model.Type.Is<BusinessEntity>();
            model.Property(x => x.Id).Is<Identificator>().Is<Unique>();
        }

    }
}
