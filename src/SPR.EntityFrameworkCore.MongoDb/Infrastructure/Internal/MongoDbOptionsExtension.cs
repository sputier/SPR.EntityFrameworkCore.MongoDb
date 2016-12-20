using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Utilities;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace SPR.EntityFrameworkCore.MongoDb.Infrastructure.Internal
{
    public class MongoDbOptionsExtension : IDbContextOptionsExtension
    {
        private string _connectionString;
        private string _databaseName;

        public virtual string ConnectionString
        {
            get { return _connectionString; }
            [param: NotNull]
            set
            {
                Check.NotEmpty(value, nameof(value));

                _connectionString = value;
            }
        }

        public string DatabaseName
        {
            get { return _databaseName; }
            [param: NotNull]
            set
            {
                Check.NotEmpty(value, nameof(value));

                _databaseName = value;
            }
        }

        public MongoDbOptionsExtension()
        {
        }

        public MongoDbOptionsExtension([NotNull] MongoDbOptionsExtension copyFrom)
        {
            Check.NotNull(copyFrom, nameof(copyFrom));

            _connectionString = copyFrom.ConnectionString;
            _databaseName = copyFrom.DatabaseName;
        }

        public void ApplyServices([NotNull] IServiceCollection services)
        {
            Check.NotNull(services, nameof(services));

            services.AddEntityFrameworkMongoDb();
        }

        public static MongoDbOptionsExtension Extract([NotNull] IDbContextOptions options)
        {
            Check.NotNull(options, nameof(options));

            var mongoDbOptionsExtension
                = options.Extensions
                    .OfType<MongoDbOptionsExtension>()
                    .ToArray();

            if (mongoDbOptionsExtension.Length == 0)
            {
                throw new InvalidOperationException("No MongoDB database providers are configured.");
            }

            if (mongoDbOptionsExtension.Length > 1)
            {
                throw new InvalidOperationException("Multiple MongoDB database provider configurations found. A context can only be configured to use a single database provider.");
            }

            return mongoDbOptionsExtension[0];
        }
    }
}
