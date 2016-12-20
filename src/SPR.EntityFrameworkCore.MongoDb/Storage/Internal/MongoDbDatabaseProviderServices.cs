using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata.Conventions.Internal;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Query.ExpressionVisitors;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Utilities;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using SPR.EntityFrameworkCore.MongoDb.Infrastructure;
using SPR.EntityFrameworkCore.MongoDb.Metadata.Conventions.Internal;
using SPR.EntityFrameworkCore.MongoDb.Query;
using SPR.EntityFrameworkCore.MongoDb.Query.ExpressionVisitors;
using SPR.EntityFrameworkCore.MongoDb.ValueGeneration.Internal;
using System;

namespace SPR.EntityFrameworkCore.MongoDb.Storage.Internal
{
    public class MongoDbDatabaseProviderServices : DatabaseProviderServices
    {
        public MongoDbDatabaseProviderServices([NotNull] IServiceProvider services)
            : base(Check.NotNull(services, nameof(services)))
        {
        }

        public override IDatabaseCreator Creator
        {
            get { throw new NotImplementedException(); }
        }

        public override IDatabase Database
            => GetService<MongoDbDatabase>();

        public override IEntityQueryableExpressionVisitorFactory EntityQueryableExpressionVisitorFactory
            => GetService<MongoDbEntityQueryableExpressionVisitorFactory>();

        public override IEntityQueryModelVisitorFactory EntityQueryModelVisitorFactory
            => GetService<MongoDbEntityQueryModelVisitorFactory>();

        public override string InvariantName
        {
            get { throw new NotImplementedException(); }
        }

        public override IModelSource ModelSource
            => GetService<MongoDbModelSource>();

        public override IQueryContextFactory QueryContextFactory
            => GetService<MongoDbQueryContextFactory>();


        public override IDbContextTransactionManager TransactionManager
        {
            get { throw new NotImplementedException(); }
        }

        public override IValueGeneratorCache ValueGeneratorCache
            => GetService<MongoDbValueGeneratorCache>();

        public override IQueryCompilationContextFactory QueryCompilationContextFactory
            => GetService<MongoDbQueryCompilationContextFactory>();

        public override IConventionSetBuilder ConventionSetBuilder
            => GetService<MongoDbConventionSetBuilder>();
    }
}
