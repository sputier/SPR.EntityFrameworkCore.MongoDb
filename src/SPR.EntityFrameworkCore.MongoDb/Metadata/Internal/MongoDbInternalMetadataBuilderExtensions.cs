using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace SPR.EntityFrameworkCore.MongoDb.Metadata.Internal
{
    public static class MongoDbInternalMetadataBuilderExtensions
    {
        public static MongoDbPropertyBuilderAnnotations MongoDb(
            [NotNull] this InternalPropertyBuilder builder,
            ConfigurationSource configurationSource)
            => new MongoDbPropertyBuilderAnnotations(builder, configurationSource, MongoDbFullAnnotationsNames.Instance);
    }
}