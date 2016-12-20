using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Query.ExpressionVisitors.Internal;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Microsoft.EntityFrameworkCore.Utilities;
using Microsoft.Extensions.Logging;
using System;

namespace SPR.EntityFrameworkCore.MongoDb.Query
{
    public class MongoDbQueryCompilationContext : QueryCompilationContext
    {
        private readonly IQueryMethodProvider _queryMethodProvider;

        public MongoDbQueryCompilationContext([NotNull] IModel model, 
                                              [NotNull] ILogger logger, 
                                              [NotNull] IEntityQueryModelVisitorFactory entityQueryModelVisitorFactory, 
                                              [NotNull] IRequiresMaterializationExpressionVisitorFactory requiresMaterializationExpressionVisitorFactory, 
                                              [NotNull] ILinqOperatorProvider linqOperatorProvider, 
                                              [NotNull] Type contextType,
                                              [NotNull] IQueryMethodProvider queryMethodProvider,
                                              bool trackQueryResults) 
            : base(model, logger, entityQueryModelVisitorFactory, requiresMaterializationExpressionVisitorFactory, linqOperatorProvider, contextType, trackQueryResults)
        {
            Check.NotNull(queryMethodProvider, nameof(queryMethodProvider));

            _queryMethodProvider = queryMethodProvider;
        }

        public IQueryMethodProvider QueryMethodProvider => _queryMethodProvider;
    }
}
