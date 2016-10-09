using System;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Utilities;
using Microsoft.EntityFrameworkCore;
using SPR.EntityFrameworkCore.MongoDb.Infrastructure;

namespace SPR.EntityFrameworkCore.MongoDb
{
    /// <summary>
    ///     SQLite specific extension methods for <see cref="DbContextOptionsBuilder" />.
    /// </summary>
    public static class MongoDbContextOptionsBuilderExtensions
    {
        /// <summary>
        ///     Configures the context to connect to a MongoDB database.
        /// </summary>
        /// <param name="optionsBuilder"> The builder being used to configure the context. </param>
        /// <param name="connectionString"> The connection string of the database to connect to. </param>
        /// <param name="mongoDbOptionsAction">An optional action to allow additional SQLite specific configuration.</param>
        /// <returns> The options builder so that further configuration can be chained. </returns>
        public static DbContextOptionsBuilder UseMongoDb(
            /*[NotNull]*/ this DbContextOptionsBuilder optionsBuilder,
            /*[NotNull]*/ string connectionString,
            /*[CanBeNull]*/ Action<MongoDbContextOptionsBuilder> mongoDbOptionsAction = null)
        {
            //Check.NotNull(optionsBuilder, nameof(optionsBuilder));
            //Check.NotEmpty(connectionString, nameof(connectionString));

            var extension = GetOrCreateExtension(optionsBuilder);
            extension.ConnectionString = connectionString;
            ((IDbContextOptionsBuilderInfrastructure)optionsBuilder).AddOrUpdateExtension(extension);

            mongoDbOptionsAction?.Invoke(new MongoDbContextOptionsBuilder(optionsBuilder));

            return optionsBuilder;
        }

        ///// <summary>
        /////     Configures the context to connect to a SQLite database.
        ///// </summary>
        ///// <param name="optionsBuilder"> The builder being used to configure the context. </param>
        ///// <param name="connection">
        /////     An existing <see cref="DbConnection" /> to be used to connect to the database. If the connection is
        /////     in the open state then EF will not open or close the connection. If the connection is in the closed
        /////     state then EF will open and close the connection as needed.
        ///// </param>
        ///// <param name="mongoDbOptionsAction">An optional action to allow additional Mongo DB specific configuration.</param>
        ///// <returns> The options builder so that further configuration can be chained. </returns>
        //public static DbContextOptionsBuilder UseMongoDb(
        //    /*[NotNull]*/ this DbContextOptionsBuilder optionsBuilder,
        //    /*[NotNull]*/ DbConnection connection,
        //    /*[CanBeNull]*/ Action<MongoDbContextOptionsBuilder> mongoDbOptionsAction = null)
        //{
        //    //Check.NotNull(optionsBuilder, nameof(optionsBuilder));
        //    //Check.NotNull(connection, nameof(connection));

        //    var extension = GetOrCreateExtension(optionsBuilder);
        //    extension.Connection = connection;
        //    ((IDbContextOptionsBuilderInfrastructure)optionsBuilder).AddOrUpdateExtension(extension);

        //    mongoDbOptionsAction?.Invoke(new MongoDbContextOptionsBuilder(optionsBuilder));

        //    return optionsBuilder;
        //}

        /// <summary>
        ///     Configures the context to connect to a Mongo DB database.
        /// </summary>
        /// <typeparam name="TContext"> The type of context to be configured. </typeparam>
        /// <param name="optionsBuilder"> The builder being used to configure the context. </param>
        /// <param name="connectionString"> The connection string of the database to connect to. </param>
        /// <param name="mongoDbOptionsAction">An optional action to allow additional Mongo DB specific configuration.</param>
        /// <returns> The options builder so that further configuration can be chained. </returns>
        public static DbContextOptionsBuilder<TContext> UseMongoDb<TContext>(
            /*[NotNull]*/ this DbContextOptionsBuilder<TContext> optionsBuilder,
            /*[NotNull]*/ string connectionString,
            /*[CanBeNull]*/ Action<MongoDbContextOptionsBuilder> mongoDbOptionsAction = null)
            where TContext : DbContext
        => (DbContextOptionsBuilder<TContext>)UseMongoDb(
            (DbContextOptionsBuilder)optionsBuilder, connectionString, mongoDbOptionsAction);

        ///// <summary>
        /////     Configures the context to connect to a SQLite database.
        ///// </summary>
        ///// <typeparam name="TContext"> The type of context to be configured. </typeparam>
        ///// <param name="optionsBuilder"> The builder being used to configure the context. </param>
        ///// <param name="connection">
        /////     An existing <see cref="DbConnection" /> to be used to connect to the database. If the connection is
        /////     in the open state then EF will not open or close the connection. If the connection is in the closed
        /////     state then EF will open and close the connection as needed.
        ///// </param>
        ///// <param name="sqliteOptionsAction">An optional action to allow additional SQLite specific configuration.</param>
        ///// <returns> The options builder so that further configuration can be chained. </returns>
        //public static DbContextOptionsBuilder<TContext> UseMongoDb<TContext>(
        //    /*[NotNull]*/ this DbContextOptionsBuilder<TContext> optionsBuilder,
        //    /*[NotNull]*/ DbConnection connection,
        //    /*[CanBeNull]*/ Action<MongoDbContextOptionsBuilder> mongoDbOptionsAction = null)
        //    where TContext : DbContext
        //=> (DbContextOptionsBuilder<TContext>)UseMongoDb(
        //    (DbContextOptionsBuilder)optionsBuilder, connection, mongoDbOptionsAction);

        private static MongoDbOptionsExtension GetOrCreateExtension(DbContextOptionsBuilder options)
        {
            var existingExtension = options.Options.FindExtension<MongoDbOptionsExtension>();

            return existingExtension != null
                ? new MongoDbOptionsExtension(existingExtension)
                : new MongoDbOptionsExtension();
        }
    }
}
