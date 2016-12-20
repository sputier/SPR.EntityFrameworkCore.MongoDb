using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Utilities;
using SPR.EntityFrameworkCore.MongoDb.Infrastructure.Internal;
using System;

namespace Microsoft.EntityFrameworkCore
{
    public static class MongoDbContextOptionsBuilderExtensions
    {
        public static DbContextOptionsBuilder UseMongoDb(
            [NotNull] this DbContextOptionsBuilder optionsBuilder,
            [NotNull] string connectionString,
            [NotNull] string databaseName,
            [CanBeNull] Action<DbContextOptionsBuilder> mongoDbOptionsAction = null)
        {
            Check.NotNull(optionsBuilder, nameof(optionsBuilder));
            Check.NotEmpty(connectionString, nameof(connectionString));
            Check.NotEmpty(databaseName, nameof(databaseName));

            var extension = GetOrCreateExtension(optionsBuilder);
            extension.ConnectionString = connectionString;
            extension.DatabaseName = databaseName;

            ((IDbContextOptionsBuilderInfrastructure)optionsBuilder).AddOrUpdateExtension(extension);

            mongoDbOptionsAction?.Invoke(new DbContextOptionsBuilder(optionsBuilder.Options));

            return optionsBuilder;
        }

        private static MongoDbOptionsExtension GetOrCreateExtension(DbContextOptionsBuilder options)
        {
            var existingExtension = options.Options.FindExtension<MongoDbOptionsExtension>();

            return existingExtension != null
                ? new MongoDbOptionsExtension(existingExtension)
                : new MongoDbOptionsExtension();
        }
    }
}
