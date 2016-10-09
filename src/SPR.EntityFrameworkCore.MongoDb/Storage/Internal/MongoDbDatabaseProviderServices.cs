using System;
using System.Reflection;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.EntityFrameworkCore.Metadata.Conventions.Internal;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Query.ExpressionVisitors;
using Microsoft.EntityFrameworkCore.Update;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using Microsoft.EntityFrameworkCore.ValueGeneration.Internal;
using SPR.EntityFrameworkCore.MongoDb.Storage;
using SPR.EntityFrameworkCore.MongoDb.Query.ExpressionVisitors;
using SPR.EntityFrameworkCore.MongoDb.Query.Internal;
using SPR.EntityFrameworkCore.MongoDb.Infrastructure.Internal;
using SPR.EntityFrameworkCore.MongoDb.ValueGenerator.Internal;

namespace Microsoft.EntityFrameworkCore.Storage.Internal
{
    public class MongoDbDatabaseProviderServices : DatabaseProviderServices
    {
        public MongoDbDatabaseProviderServices(/*[NotNull]*/ IServiceProvider services)
            : base(services)
        {
        }

        public override string InvariantName => GetType().GetTypeInfo().Assembly.GetName().Name;

        public override IDatabaseCreator Creator => GetService<MongoDbDatabaseCreator>();

        public override IDatabase Database => GetService<MongoDbDatabase>();

        public override IEntityQueryableExpressionVisitorFactory EntityQueryableExpressionVisitorFactory => GetService<MongoDbEntityQueryableExpressionVisitorFactory>();

        public override IEntityQueryModelVisitorFactory EntityQueryModelVisitorFactory => GetService<MongoDbQueryModelVisitorFactory>();

        public override IModelSource ModelSource => GetService<MongoDbModelSource>();

        public override IQueryContextFactory QueryContextFactory => GetService<MongoDbQueryContextFactory>();

        public override IDbContextTransactionManager TransactionManager => GetService<MongoDbContextTransactionManager>();

        public override IValueGeneratorCache ValueGeneratorCache => GetService<MongoDbValueGeneratorCache>();

        //public override string InvariantName => GetType().GetTypeInfo().Assembly.GetName().Name;
        //public override IHistoryRepository HistoryRepository => GetService<SqliteHistoryRepository>();
        //public override ISqlGenerationHelper SqlGenerationHelper => GetService<SqliteSqlGenerationHelper>();
        //public override IMigrationsSqlGenerator MigrationsSqlGenerator => GetService<SqliteMigrationsSqlGenerator>();
        //public override IModelSource ModelSource => GetService<SqliteModelSource>();
        //public override IRelationalConnection RelationalConnection => GetService<SqliteRelationalConnection>();
        //public override IUpdateSqlGenerator UpdateSqlGenerator => GetService<SqliteUpdateSqlGenerator>();
        //public override IValueGeneratorCache ValueGeneratorCache => GetService<SqliteValueGeneratorCache>();
        //public override IRelationalTypeMapper TypeMapper => GetService<SqliteTypeMapper>();
        //public override IModificationCommandBatchFactory ModificationCommandBatchFactory => GetService<SqliteModificationCommandBatchFactory>();
        //public override IRelationalDatabaseCreator RelationalDatabaseCreator => GetService<SqliteDatabaseCreator>();
        //public override IConventionSetBuilder ConventionSetBuilder => GetService<SqliteConventionSetBuilder>();
        //public override IRelationalAnnotationProvider AnnotationProvider => GetService<SqliteAnnotationProvider>();
        //public override IMethodCallTranslator CompositeMethodCallTranslator => GetService<SqliteCompositeMethodCallTranslator>();
        //public override IMemberTranslator CompositeMemberTranslator => GetService<SqliteCompositeMemberTranslator>();
        //public override IMigrationsAnnotationProvider MigrationsAnnotationProvider => GetService<SqliteMigrationsAnnotationProvider>();
        //public override IQuerySqlGeneratorFactory QuerySqlGeneratorFactory => GetService<SqliteQuerySqlGeneratorFactory>();
    }
}
