using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Utilities;
using Microsoft.Extensions.DependencyInjection.Extensions;
using SPR.EntityFrameworkCore.MongoDb.Bson;
using SPR.EntityFrameworkCore.MongoDb.Infrastructure;
using SPR.EntityFrameworkCore.MongoDb.Infrastructure.Internal;
using SPR.EntityFrameworkCore.MongoDb.Metadata;
using SPR.EntityFrameworkCore.MongoDb.Metadata.Conventions.Internal;
using SPR.EntityFrameworkCore.MongoDb.Query;
using SPR.EntityFrameworkCore.MongoDb.Query.Expressions;
using SPR.EntityFrameworkCore.MongoDb.Query.ExpressionVisitors;
using SPR.EntityFrameworkCore.MongoDb.Query.ExpressionVisitors.Internal;
using SPR.EntityFrameworkCore.MongoDb.Query.Internal;
using SPR.EntityFrameworkCore.MongoDb.Storage;
using SPR.EntityFrameworkCore.MongoDb.Storage.Internal;
using SPR.EntityFrameworkCore.MongoDb.ValueGeneration.Internal;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class MongoDbServiceCollectionExtensions
    {
        public static IServiceCollection AddEntityFrameworkMongoDb(
              [NotNull] this IServiceCollection services)
        {
            Check.NotNull(services, nameof(services));
            services.TryAddEnumerable(ServiceDescriptor
                .Singleton<IDatabaseProvider, DatabaseProvider<MongoDbDatabaseProviderServices, MongoDbOptionsExtension>>());

            services.TryAdd(new ServiceCollection()
                .AddScoped<MongoDbConventionSetBuilder>()
                .AddScoped<MongoDbDatabaseProviderServices>()
                .AddScoped<IMongoDbConnection, MongoDbConnection>()
                .AddScoped<MongoDbQueryContextFactory>()
                .AddSingleton<MongoDbModelSource>()
                .AddScoped<MongoDbDatabase>()
                .AddScoped<MongoDbEntityQueryModelVisitorFactory>()
                .AddScoped<MongoDbEntityQueryableExpressionVisitorFactory>()
                .AddSingleton<IMongoDbAnnotationsProvider, MongoDbAnnotationsProvider>()
                .AddScoped<IFindExpressionFactory, FindExpressionFactory>()
                .AddScoped<IBsonQueryGeneratorFactory, BsonQueryGeneratorFactory>()
                .AddScoped<IMaterializerFactory, MaterializerFactory>()
                .AddScoped<IShaperCommandContextFactory, ShaperCommandContextFactory>()
                .AddScoped<MongoDbQueryCompilationContextFactory>()
                .AddScoped<IValueBufferFactoryFactory, ValueBufferFactoryFactory>()
                .AddSingleton<MongoDbValueGeneratorCache>()
                .AddScoped<IBsonCommandBuilderFactory, BsonCommandBuilderFactory>()
                .AddScoped<IValueBufferFromBsonShaperFactory, ValueBufferFromBsonShaperFactory>()
            );

            return services;
        }
    }
}
