using JetBrains.Annotations;
using SPR.EntityFrameworkCore.MongoDb.Metadata;
using SPR.EntityFrameworkCore.MongoDb.Metadata.Internal;

namespace Microsoft.EntityFrameworkCore.Metadata.Internal
{
    public class MongoDbPropertyBuilderAnnotations : MongoDbPropertyAnnotations
    {
        public MongoDbPropertyBuilderAnnotations(
            [NotNull] InternalPropertyBuilder internalBuilder,
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

        private InternalPropertyBuilder PropertyBuilder
            => ((Property)Property).Builder;

        public virtual bool HasColumnName([CanBeNull] string value) 
            => SetFieldName(value);

        public virtual bool HasColumnType([CanBeNull] string value)
            => SetFieldType(value);
    }
}
