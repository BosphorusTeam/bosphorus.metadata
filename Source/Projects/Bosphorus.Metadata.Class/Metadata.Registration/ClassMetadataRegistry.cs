using System;
using System.Linq.Expressions;
using System.Reflection;
using Bosphorus.Metadata.Core.Metadata.Registration;

namespace Bosphorus.Metadata.Class.Metadata.Registration
{
    public class ClassMetadataRegistry<TModel>
    {
        private readonly IMetadataRepository<Type> typeMetadataRepository;
        private readonly IMetadataRepository<PropertyInfo> propertyMetadataRepository;

        public ClassMetadataRegistry(IMetadataRepository<Type> typeMetadataRepository, IMetadataRepository<PropertyInfo> propertyMetadataRepository)
        {
            this.typeMetadataRepository = typeMetadataRepository;
            this.propertyMetadataRepository = propertyMetadataRepository;
        }

        public MetadataRegistry<Type> Type => typeMetadataRepository.RegistryFor(typeof(TModel));

        public MetadataRegistry<PropertyInfo> Property(Expression<Func<TModel, object>> propertyExpression)
        {
            MemberExpression memberExpression = GetMemberExpression(propertyExpression);
            PropertyInfo memberInfo = memberExpression.Member as PropertyInfo;
            var metadataRegistry = propertyMetadataRepository.RegistryFor(memberInfo);
            return metadataRegistry;
        }

        private MemberExpression GetMemberExpression(Expression<Func<TModel, object>> expression)
        {
            MemberExpression body = expression.Body as MemberExpression ?? ((UnaryExpression)expression.Body).Operand as MemberExpression;
            return body;
        }
    }

}