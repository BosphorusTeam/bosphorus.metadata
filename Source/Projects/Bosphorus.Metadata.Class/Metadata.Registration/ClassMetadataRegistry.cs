using System;
using System.Linq.Expressions;
using System.Reflection;
using Bosphorus.Metadata.Core.Metadata.Registration;
using Bosphorus.Metadata.Core.Metadata.Repository;

namespace Bosphorus.Metadata.Class.Metadata.Registration
{
    public class ClassMetadataRegistry<TModel>
    {
        private readonly GenericMetadataRepostiory genericMetadataRepostiory;

        public ClassMetadataRegistry(GenericMetadataRepostiory genericMetadataRepostiory)
        {
            this.genericMetadataRepostiory = genericMetadataRepostiory;
        }

        public MetadataRegistry<Type> Type => genericMetadataRepostiory.RegistryFor(typeof(TModel));

        public MetadataRegistry<PropertyInfo> Property(Expression<Func<TModel, object>> propertyExpression)
        {
            MemberExpression memberExpression = GetMemberExpression(propertyExpression);
            PropertyInfo memberInfo = memberExpression.Member as PropertyInfo;
            var metadataRegistry = genericMetadataRepostiory.RegistryFor(memberInfo);
            return metadataRegistry;
        }

        private MemberExpression GetMemberExpression(Expression<Func<TModel, object>> expression)
        {
            MemberExpression body = expression.Body as MemberExpression ?? ((UnaryExpression)expression.Body).Operand as MemberExpression;
            return body;
        }
    }

}