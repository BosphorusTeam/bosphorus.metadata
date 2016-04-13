using Bosphorus.Metadata.Class.Demo.Metadata;
using Bosphorus.Metadata.Class.Metadata;
using Bosphorus.Metadata.Class.Metadata.Registration;

namespace Bosphorus.Metadata.Class.Demo.Model
{
    public class BankMetadataRegisterer: IClassMetadataRegisterer<Bank>
    {
        public void Register(ClassMetadataRegistry<Bank> model)
        {
            model.Type.Is<BusinessEntity>().Is<StaticData>();
            model.Property(x => x.Id).Is<Unique>().Is<Identificator>();
        }

    }
}
