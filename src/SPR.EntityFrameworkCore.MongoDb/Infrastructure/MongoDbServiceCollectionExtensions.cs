using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using Microsoft.EntityFrameworkCore.Utilities;
using Microsoft.EntityFrameworkCore.ValueGeneration.Internal;
using Microsoft.Extensions.DependencyInjection.Extensions;
using SPR.EntityFrameworkCore.MongoDb.Infrastructure;
using SPR.EntityFrameworkCore.MongoDb.Infrastructure.Internal;
using SPR.EntityFrameworkCore.MongoDb.Storage;
using SPR.EntityFrameworkCore.MongoDb.ValueGenerator.Internal;

// ReSharper disable once CheckNamespace
namespace Microsoft.Extensions.DependencyInjection
{
    /// <summary>
    ///     SQLite specific extension methods for <see cref="IServiceCollection" />.
    /// </summary>
    public static class MongoDbServiceCollectionExtensions
    {
        /// <summary>
        ///     <para>
        ///         Adds the services required by the SQLite database provider for Entity Framework
        ///         to an <see cref="IServiceCollection" />. You use this method when using dependency injection
        ///         in your application, such as with ASP.NET. For more information on setting up dependency
        ///         injection, see http://go.microsoft.com/fwlink/?LinkId=526890.
        ///     </para>
        ///     <para>
        ///         You only need to use this functionality when you want Entity Framework to resolve the services it uses
        ///         from an external dependency injection container. If you are not using an external
        ///         dependency injection container, Entity Framework will take care of creating the services it requires.
        ///     </para>
        /// </summary>
        /// <example>
        ///     <code>
        ///          public void ConfigureServices(IServiceCollection services)
        ///          {
        ///              var connectionString = "connection string to database";
        /// 
        ///              services
        ///                  .AddEntityFrameworkSqlite()
        ///                  .AddDbContext&lt;MyContext&gt;((serviceProvider, options) =>
        ///                      options.UseSqlite(connectionString)
        ///                             .UseInternalServiceProvider(serviceProvider));
        ///          }
        ///      </code>
        /// </example>
        /// <param name="services"> The <see cref="IServiceCollection" /> to add services to. </param>
        /// <returns>
        ///     The same service collection so that multiple calls can be chained.
        /// </returns>
        public static IServiceCollection AddEntityFrameworkMongoDb(/*[NotNull]*/ this IServiceCollection services)
        {
            //Check.NotNull(services, nameof(services));

            //services.AddRelational();

            services.TryAddEnumerable(ServiceDescriptor
                .Singleton<IDatabaseProvider, DatabaseProvider<MongoDbDatabaseProviderServices, MongoDbOptionsExtension>>());

            services.TryAdd(new ServiceCollection()
                .AddSingleton<MongoDbValueGeneratorCache>()
                .AddSingleton<MongoDbModelSource>()
                .AddScoped<MongoDbDatabaseCreator>()
                .AddScoped<MongoDbContextTransactionManager>()
                .AddScoped<MongoDbDatabaseProviderServices>()
                //.AddSingleton<SqliteAnnotationProvider>()
                //.AddSingleton<SqliteTypeMapper>()
                //.AddSingleton<SqliteSqlGenerationHelper>()
                //.AddSingleton<SqliteMigrationsAnnotationProvider>()
                //.AddScoped<SqliteConventionSetBuilder>()
                //.AddScoped<SqliteUpdateSqlGenerator>()
                //.AddScoped<SqliteModificationCommandBatchFactory>()
                //.AddScoped<SqliteMigrationsSqlGenerator>()
                //.AddScoped<SqliteHistoryRepository>()
                .AddQuery());

            return services;
        }

        private static IServiceCollection AddQuery(this IServiceCollection serviceCollection)
            => serviceCollection;
                //.AddScoped<SqliteCompositeMemberTranslator>()
                //.AddScoped<SqliteCompositeMethodCallTranslator>()
                //.AddScoped<SqliteQuerySqlGeneratorFactory>();
    }
}
