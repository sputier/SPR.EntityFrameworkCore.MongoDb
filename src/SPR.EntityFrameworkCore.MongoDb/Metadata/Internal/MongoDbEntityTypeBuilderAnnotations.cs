using JetBrains.Annotations;
using SPR.EntityFrameworkCore.MongoDb.Metadata;
using SPR.EntityFrameworkCore.MongoDb.Metadata.Internal;

namespace Microsoft.EntityFrameworkCore.Metadata.Internal
{
    public class MongoDbEntityTypeBuilderAnnotations : MongoDbEntityTypeAnnotations
    {
        public MongoDbEntityTypeBuilderAnnotations(
            [NotNull] InternalEntityTypeBuilder internalBuilder,
            ConfigurationSource configurationSource,
            [CanBeNull] MongoDbFullAnnotationsNames providerFullAnnotationNames)
            : base(new MongoDbAnnotationsBuilder(
                            internalBuilder, 
                            configurationSource),
                  providerFullAnnotationNames)
        {
        }

        protected new virtual MongoDbAnnotationsBuilder Annotations 
            => (MongoDbAnnotationsBuilder)base.Annotations;

        private InternalEntityTypeBuilder EntityTypeBuilder
            => ((EntityType)EntityType).Builder;

        public virtual bool HasName([CanBeNull] string value) 
            => SetCollectionName(value);
    }
}
