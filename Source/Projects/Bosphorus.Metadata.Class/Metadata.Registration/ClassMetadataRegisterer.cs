using System;
using System.Reflection;
using Bosphorus.Metadata.Core.Metadata.Registration;

namespace Bosphorus.Metadata.Class.Metadata.Registration
{
    public abstract class ClassMetadataRegisterer<TModel>
    {
        protected ClassMetadataRegisterer(IMetadataRepository<Type> typeMetadataRepository, IMetadataRepository<PropertyInfo> propertyMetadataRepository)
        {
            ClassMetadataRegistry<TModel> registry = new ClassMetadataRegistry<TModel>(typeMetadataRepository, propertyMetadataRepository);
            Register(registry);
        }

        protected abstract void Register(ClassMetadataRegistry<TModel> model);

    }
}