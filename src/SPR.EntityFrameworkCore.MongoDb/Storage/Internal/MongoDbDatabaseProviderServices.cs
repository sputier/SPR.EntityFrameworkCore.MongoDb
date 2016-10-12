using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Query.ExpressionVisitors;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using JetBrains.Annotations;
using SPR.EntityFrameworkCore.MongoDb.Query.ExpressionVisitors;
using SPR.EntityFrameworkCore.MongoDb.Infrastructure;
using System.Reflection;
using SPR.EntityFrameworkCore.MongoDb.Query;
using SPR.EntityFrameworkCore.MongoDb.ValueGeneration;

namespace SPR.EntityFrameworkCore.MongoDb.Storage.Internal
{
    public class MongoDbDatabaseProviderServices : DatabaseProviderServices
    {
        public MongoDbDatabaseProviderServices([NotNull] IServiceProvider services)
            : base(services)
        {
        }

        public override IDatabaseCreator Creator => GetService<MongoDbDatabaseCreator>();

        public override IDatabase Database => GetService<MongoDbDatabase>();

        public override IEntityQueryableExpressionVisitorFactory EntityQueryableExpressionVisitorFactory => GetService<MongoDbEntityQueryableExpressionVisitorFactory>();

        public override IEntityQueryModelVisitorFactory EntityQueryModelVisitorFactory => GetService<MongoDbEntityQueryModelVisitorFactory>();

        public override string InvariantName => GetType().GetTypeInfo().Assembly.GetName().Name;

        public override IModelSource ModelSource => GetService<MongoDbModelSource>();

        public override IQueryContextFactory QueryContextFactory => GetService<MongoDbQueryContextFactory>();

        public override IDbContextTransactionManager TransactionManager => GetService<MongoDbContextTransactionManager>();

        public override IValueGeneratorCache ValueGeneratorCache => GetService<MongoDbValueGeneratorCache>();
    }
}
