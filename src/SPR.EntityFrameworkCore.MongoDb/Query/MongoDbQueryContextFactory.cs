using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Utilities;
using SPR.EntityFrameworkCore.MongoDb.Storage.Internal;

namespace SPR.EntityFrameworkCore.MongoDb.Query
{
    public class MongoDbQueryContextFactory : QueryContextFactory
{
    private readonly IMongoDbConnection _connection;

    public MongoDbQueryContextFactory(
        [NotNull] ICurrentDbContext currentContext,
        [NotNull] IConcurrencyDetector concurrencyDetector,
        [NotNull] IMongoDbConnection connection)
        : base(
              Check.NotNull(currentContext, nameof(currentContext)),
              Check.NotNull(concurrencyDetector, nameof(concurrencyDetector)))
    {
        Check.NotNull(connection, nameof(connection));

        _connection = connection;
    }

    public override QueryContext Create()
        => new MongoDbQueryContext(
            CreateQueryBuffer, 
            StateManager, 
            ConcurrencyDetector, 
            _connection);
}
}