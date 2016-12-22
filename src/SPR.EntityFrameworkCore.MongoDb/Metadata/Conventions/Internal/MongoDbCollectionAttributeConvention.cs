using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore.Metadata.Conventions.Internal;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SPR.EntityFrameworkCore.MongoDb.Attributes;
using SPR.EntityFrameworkCore.MongoDb.Metadata.Internal;
using System;

namespace SPR.EntityFrameworkCore.MongoDb.Metadata.Conventions.Internal
{
    public class MongoDbCollectionAttributeConvention : EntityTypeAttributeConvention<CollectionAttribute>
    {
        public override InternalEntityTypeBuilder Apply(
            [NotNull] InternalEntityTypeBuilder entityTypeBuilder, 
            [NotNull] CollectionAttribute attribute)
        {
            if (!string.IsNullOrWhiteSpace(attribute.Name))
            {
                entityTypeBuilder.MongoDb(ConfigurationSource.DataAnnotation).HasName(attribute.Name);
            }

            return entityTypeBuilder;
        }
    }
}
