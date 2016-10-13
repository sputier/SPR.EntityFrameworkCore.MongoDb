using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Utilities;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using SPR.EntityFrameworkCore.MongoDb.Infrastructure;
using SPR.EntityFrameworkCore.MongoDb.Infrastructure.Internal;
using SPR.EntityFrameworkCore.MongoDb.Metadata.Conventions;
using SPR.EntityFrameworkCore.MongoDb.Query.ExpressionVisitors;
using SPR.EntityFrameworkCore.MongoDb.Storage;
using SPR.EntityFrameworkCore.MongoDb.Storage.Internal;
using SPR.EntityFrameworkCore.MongoDb.ValueGeneration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.EntityFrameworkCore.Infrastructure
{
    public static class MongoDbServiceCollectionExtensions
    {       /// <summary>
            ///     <para>
            ///         Adds the services required by the Mongo DB database provider for Entity Framework
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
        public static IServiceCollection AddEntityFrameworkMongoDb([NotNull] this IServiceCollection services)
        {
            Check.NotNull(services, nameof(services));

            services.TryAddEnumerable(ServiceDescriptor
                .Singleton<IDatabaseProvider, DatabaseProvider<MongoDbDatabaseProviderServices, MongoDbOptionsExtension>>());

            services.Replace(ServiceDescriptor
                .Scoped<Metadata.Conventions.Internal.IConventionSetBuilder>(i => new MongoDbConventionSetBuilder(new MongoDbTypeMapper())));

            //var s = services.First(desc => desc.ServiceType == typeof(Metadata.Conventions.Internal.IConventionSetBuilder));
            //services.Remove(s);
            //services.Add(ServiceDescriptor.Scoped<Metadata.Conventions.Internal.IConventionSetBuilder, MongoDbConventionSetBuilder>());

            services.TryAdd(new ServiceCollection()
                .AddSingleton<MongoDbValueGeneratorCache>()
                .AddSingleton<MongoDbModelSource>()
                .AddScoped<MongoDbConventionSetBuilder>()
                .AddScoped<MongoDbDatabaseProviderServices>()
                .AddScoped<MongoDbDatabase>()
                .AddScoped<IMongoDbTypeMapper, MongoDbTypeMapper>()
                .AddQuery()
            );

             return services;
        }

        private static IServiceCollection AddQuery(this IServiceCollection serviceCollection)
            => serviceCollection
                .AddScoped<MongoDbEntityQueryableExpressionVisitorFactory>()
                .AddScoped<MongoDbEntityQueryModelVisitorFactory>()
            ;

    }
}