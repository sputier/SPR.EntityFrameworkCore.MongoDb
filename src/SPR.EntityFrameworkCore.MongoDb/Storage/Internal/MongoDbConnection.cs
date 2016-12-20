using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Utilities;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;
using SPR.EntityFrameworkCore.MongoDb.Infrastructure.Internal;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SPR.EntityFrameworkCore.MongoDb.Storage.Internal
{
    public class MongoDbConnection : IMongoDbConnection
    {
        private ILogger _logger;
        private IMongoClient _connection;
        private string _connectionString;
        private string _databaseName;

        private IMongoDatabase _internalMongoDatabase;

        public string ConnectionString => _connectionString;
        public string DatabaseName => _databaseName;

        public IMongoClient DbConnection => _connection;

        public MongoDbConnection([NotNull] IDbContextOptions options, [NotNull] ILogger<MongoDbConnection> logger)
        {
            Check.NotNull(options, nameof(options));
            Check.NotNull(logger, nameof(logger));

            _logger = logger;

            var mongoDbOptions = MongoDbOptionsExtension.Extract(options);

            if (!string.IsNullOrWhiteSpace(mongoDbOptions.ConnectionString) 
                && !string.IsNullOrWhiteSpace(mongoDbOptions.DatabaseName))
            {
                _connectionString = mongoDbOptions.ConnectionString;
                _databaseName = mongoDbOptions.DatabaseName;
            }
            else
            {
                throw new InvalidOperationException("A MongoDB store has been configured without specifying the connection string to use.");
            }
        }

        protected virtual IMongoClient CreateDbConnection() 
            => new MongoClient(_connectionString);

        public void Open()
        {
            _connection = CreateDbConnection();
        }

        public void OpenDatabase()
        {
            _internalMongoDatabase = _connection.GetDatabase(_databaseName);
        }

        public void Close()
        {
        }

        public IEnumerable<MongoDB.Bson.BsonDocument> ExecuteQuery(string collectionName, string projection)
        {
            return _internalMongoDatabase.GetCollection<object>(collectionName)
                                              .Find("{}")
                                              .Project(projection)
                                              .ToList();
        }
    }
}
