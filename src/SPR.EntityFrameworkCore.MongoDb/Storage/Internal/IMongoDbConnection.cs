using MongoDB.Driver;
using System.Collections.Generic;

namespace SPR.EntityFrameworkCore.MongoDb.Storage.Internal
{
    public interface IMongoDbConnection
    {
        string ConnectionString { get; }
        string DatabaseName { get; }

        IMongoClient DbConnection { get; }

        void Open();

        void OpenDatabase();

        void Close();

        IEnumerable<MongoDB.Bson.BsonDocument> ExecuteQuery(
          string collectionName,
          string projection);

    }
}
