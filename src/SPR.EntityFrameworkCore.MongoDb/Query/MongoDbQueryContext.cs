using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Microsoft.EntityFrameworkCore.Utilities;
using SPR.EntityFrameworkCore.MongoDb.Storage.Internal;
using System;

namespace SPR.EntityFrameworkCore.MongoDb.Query
{
    public class MongoDbQueryContext : QueryContext
    {
        private readonly IMongoDbConnection _connection;

        public MongoDbQueryContext([NotNull] Func<IQueryBuffer> queryBufferFactory,
                                   [NotNull] LazyRef<IStateManager> stateManager,
                                   [NotNull] IConcurrencyDetector concurrencyDetector,
                                   [NotNull] IMongoDbConnection connection)
            : base(queryBufferFactory, stateManager, concurrencyDetector)
        {
            Check.NotNull(connection, nameof(connection));

            _connection = connection;
        }

        public IMongoDbConnection Connection => _connection;
    }
}
