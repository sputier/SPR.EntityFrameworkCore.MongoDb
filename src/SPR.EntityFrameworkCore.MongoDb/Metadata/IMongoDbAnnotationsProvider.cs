using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SPR.EntityFrameworkCore.MongoDb.Metadata
{
    public interface IMongoDbAnnotationsProvider
    {
        IMongoDbEntityTypeAnnotations For([NotNull] IEntityType entityType);
        IMongoDbKeyAnnotations For([NotNull] IKey key);
        IMongoDbModelAnnotations For([NotNull] IModel model);
        IMongoDbPropertyAnnotations For([NotNull] IProperty property);
    }
}
