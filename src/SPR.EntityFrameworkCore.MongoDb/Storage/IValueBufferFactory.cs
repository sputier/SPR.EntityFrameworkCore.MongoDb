using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore.Storage;
using SPR.EntityFrameworkCore.MongoDb.Query.Internal;

namespace SPR.EntityFrameworkCore.MongoDb.Storage
{
    public interface IValueBufferFactory
    {
        ValueBuffer Create(
            [NotNull] MongoDB.Bson.BsonDocument recordData,
            [CanBeNull] IValueBufferFromBsonShaper valueBufferShaper);
    }
}
