using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Bosphorus.Metadata.Class.Metadata.Provider;
using Bosphorus.Metadata.Core.Metadata;
using Bosphorus.Metadata.Core.Metadata.Provider;

namespace Bosphorus.Metadata.Class.Metadata.Registration
{
    public abstract class ClassMetadataRegisterer<TModel> : IMetadataBuilder<Type>, IMetadataBuilder<PropertyInfo>
    {
        private readonly List<IMetadata<Type>> typeMetadatas;
        private readonly List<IMetadata<PropertyInfo>> propertyMetadatas;

        protected ClassMetadataRegisterer()
        {
            this.typeMetadatas = new List<IMetadata<Type>>();
            this.propertyMetadatas = new List<IMetadata<PropertyInfo>>();

            ClassMetadataRegistration<TModel> registration = new ClassMetadataRegistration<TModel>(typeof(TModel), typeMetadatas, propertyMetadatas);
            Register(registration);

            this.typeMetadatas.AddRange(propertyMetadatas.Select(metadata => new PropertyMetadataWrapper() {ChildMetadata = metadata, Owner = typeof(TModel)} ));
        }

        protected abstract void Register(ClassMetadataRegistration<TModel> registration);

        public IEnumerable<IMetadata<Type>> Build(Type owner)
        {
            if (owner != typeof (TModel))
            {
                return Enumerable.Empty<IMetadata<Type>>();
            }

            return typeMetadatas;
        }
        public IEnumerable<IMetadata<PropertyInfo>> Build(PropertyInfo owner)
        {
            if (owner.ReflectedType != typeof (TModel))
            {
                return Enumerable.Empty<IMetadata<PropertyInfo>>();
            }

            return propertyMetadatas;
        }

    }
}