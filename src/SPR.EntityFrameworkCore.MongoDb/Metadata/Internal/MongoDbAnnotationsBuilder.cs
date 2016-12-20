using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore.Utilities;
using SPR.EntityFrameworkCore.MongoDb.Metadata;

namespace Microsoft.EntityFrameworkCore.Metadata.Internal
{
    public class MongoDbAnnotationsBuilder : MongoDbAnnotations
    {
        public MongoDbAnnotationsBuilder(
            [NotNull] InternalMetadataBuilder internalBuilder,
            ConfigurationSource configurationSource)
            : base(internalBuilder.Metadata)
        {
            Check.NotNull(internalBuilder, nameof(internalBuilder));

            MetadataBuilder = internalBuilder;
            ConfigurationSource = configurationSource;
        }

        public virtual ConfigurationSource ConfigurationSource { get; }

        public virtual InternalMetadataBuilder MetadataBuilder { get; }

        public override bool SetAnnotation(
            string annotationName,
            object value)
            => MetadataBuilder.HasAnnotation(annotationName, value, ConfigurationSource);

        public override bool CanSetAnnotation(
            string annotationName,
            object value)
            => MetadataBuilder.CanSetAnnotation(annotationName, value, ConfigurationSource);
    }
}
