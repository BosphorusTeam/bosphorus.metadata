using System;
using System.Reflection;
using Bosphorus.Metadata.Class.Demo.Metadata;
using Bosphorus.Metadata.Class.Metadata;
using Bosphorus.Metadata.Class.Metadata.Registration;
using Bosphorus.Metadata.Core.Metadata.Registration;

namespace Bosphorus.Metadata.Class.Demo.Model
{
    public class CustomerMetadataRegisterer: ClassMetadataRegisterer<Customer>
    {
        public CustomerMetadataRegisterer(IMetadataRepository<Type> typeMetadataRepository, IMetadataRepository<PropertyInfo> propertyMetadataRepository) : base(typeMetadataRepository, propertyMetadataRepository)
        {
        }

        protected override void Register(ClassMetadataRegistry<Customer> model)
        {
            model.Type.Is<BusinessEntity>();
            model.Property(x => x.Id).Is<Identificator>().Is<Unique>();
        }

    }
}
