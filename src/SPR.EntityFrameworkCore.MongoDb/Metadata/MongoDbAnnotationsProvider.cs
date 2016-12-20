using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Utilities;
using SPR.EntityFrameworkCore.MongoDb.Metadata.Internal;

namespace SPR.EntityFrameworkCore.MongoDb.Metadata
{
    public class MongoDbAnnotationsProvider : IMongoDbAnnotationsProvider
    {
        public IMongoDbModelAnnotations For([NotNull] IModel model) 
            => new MongoDbModelAnnotations(Check.NotNull(model, nameof(model)), MongoDbFullAnnotationsNames.Instance);

        public IMongoDbPropertyAnnotations For([NotNull] IProperty property) 
            => new MongoDbPropertyAnnotations(Check.NotNull(property, nameof(property)), MongoDbFullAnnotationsNames.Instance);

        public IMongoDbKeyAnnotations For([NotNull] IKey key)
            => new MongoDbKeyAnnotations(Check.NotNull(key, nameof(key)), MongoDbFullAnnotationsNames.Instance);

        public IMongoDbEntityTypeAnnotations For([NotNull] IEntityType entityType)
            => new MongoDbEntityTypeAnnotations(Check.NotNull(entityType, nameof(entityType)), MongoDbFullAnnotationsNames.Instance);
    }
}
