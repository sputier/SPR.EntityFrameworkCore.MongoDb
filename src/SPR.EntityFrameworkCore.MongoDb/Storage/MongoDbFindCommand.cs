using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore.Utilities;
using MongoDB.Bson;
using SPR.EntityFrameworkCore.MongoDb.Storage.Internal;
using System;
using System.Collections.Generic;

namespace SPR.EntityFrameworkCore.MongoDb.Storage
{
    public class MongoDbFindCommand : IMongoDbFindCommand
    {
        private readonly string _collectionName;
        private readonly string _projectionString;
        private readonly Type _collectionEntityType;

        public MongoDbFindCommand(string collectionName, Type collectionEntityType, string projectionString)
        {
            _collectionName = collectionName;
            _projectionString = projectionString;
            _collectionEntityType = collectionEntityType;
        }

        public IEnumerable<BsonDocument> ExecuteFind([NotNull] IMongoDbConnection connection)
        {
            Check.NotNull(connection, nameof(connection));

            connection.OpenDatabase();

            var result = connection.ExecuteQuery(_collectionName, _projectionString);

            return result;
        }
    }
}
