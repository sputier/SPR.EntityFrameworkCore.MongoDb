using Microsoft.EntityFrameworkCore.Metadata.Conventions.Internal;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SPR.EntityFrameworkCore.MongoDb.Attributes;
using SPR.EntityFrameworkCore.MongoDb.Metadata.Internal;
using System.Reflection;

namespace SPR.EntityFrameworkCore.MongoDb.Metadata.Conventions.Internal
{
    public class MongoDbFieldAttributeConvention : PropertyAttributeConvention<FieldAttribute>
    {
        public override InternalPropertyBuilder Apply(
            InternalPropertyBuilder propertyBuilder, 
            FieldAttribute attribute, 
            MemberInfo clrMember)
        {
            if (!string.IsNullOrWhiteSpace(attribute.Name))
            {
                propertyBuilder.MongoDb(ConfigurationSource.DataAnnotation).HasColumnName(attribute.Name);
            }

            if (!string.IsNullOrWhiteSpace(attribute.TypeName))
            {
                propertyBuilder.MongoDb(ConfigurationSource.DataAnnotation).HasColumnType(attribute.TypeName);
            }

            return propertyBuilder;
        }
    }
}
