using System;
using System.Reflection;
using Bosphorus.Metadata.Class.Demo.Metadata;
using Bosphorus.Metadata.Class.Metadata;
using Bosphorus.Metadata.Class.Metadata.Registration;
using Bosphorus.Metadata.Core.Metadata.Registration;

namespace Bosphorus.Metadata.Class.Demo.Model
{
    public class BankMetadataRegisterer: ClassMetadataRegisterer<Bank>
    {
        protected override void Register(ClassMetadataRegistry<Bank> model)
        {
            model.Type.Is<BusinessEntity>().Is<StaticData>();
            model.Property(x => x.Id).Is<Unique>().Is<Identificator>();
        }

        public BankMetadataRegisterer(IMetadataRepository<Type> typeMetadataRepository, IMetadataRepository<PropertyInfo> propertyMetadataRepository) : base(typeMetadataRepository, propertyMetadataRepository)
        {
        }
    }
}
