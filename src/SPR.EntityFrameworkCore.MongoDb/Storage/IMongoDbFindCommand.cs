using JetBrains.Annotations;
using MongoDB.Bson;
using SPR.EntityFrameworkCore.MongoDb.Storage.Internal;
using System.Collections.Generic;

namespace SPR.EntityFrameworkCore.MongoDb.Storage
{
    public interface IMongoDbFindCommand
    {
        IEnumerable<BsonDocument> ExecuteFind(
            [NotNull] IMongoDbConnection connection);

    }
}
