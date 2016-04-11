using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using Bosphorus.Metadata.Core.Metadata;
using Bosphorus.Metadata.Core.Metadata.Registration;

namespace Bosphorus.Metadata.Class.Metadata.Registration
{
    public class ClassMetadataRegistration<TModel>: DefaultMetadataRegistration<Type>
    {
        private readonly IList<IMetadata<PropertyInfo>> propertyMetadatas;

        public ClassMetadataRegistration(Type owner, IList<IMetadata<Type>> typeMetadatas, IList<IMetadata<PropertyInfo>> propertyMetadatas)
            : base(owner, typeMetadatas)
        {
            this.propertyMetadatas = propertyMetadatas;
        }

        public IMetadataRegistration<PropertyInfo> Property(Expression<Func<TModel, object>> propertyExpression)
        {
            MemberExpression memberExpression = GetMemberExpression(propertyExpression);
            PropertyInfo memberInfo = memberExpression.Member as PropertyInfo;
            IMetadataRegistration<PropertyInfo> memberMetadataRegistration = new DefaultMetadataRegistration<PropertyInfo>(memberInfo, propertyMetadatas);
            return memberMetadataRegistration;
        }

        private MemberExpression GetMemberExpression(Expression<Func<TModel, object>> expression)
        {
            MemberExpression body = expression.Body as MemberExpression ?? ((UnaryExpression)expression.Body).Operand as MemberExpression;
            return body;
        }

   }

}