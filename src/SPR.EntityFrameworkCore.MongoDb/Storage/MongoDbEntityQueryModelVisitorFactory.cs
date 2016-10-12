using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Query.ExpressionVisitors;
using Microsoft.EntityFrameworkCore.Query.ExpressionVisitors.Internal;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace SPR.EntityFrameworkCore.MongoDb.Storage
{
    public class MongoDbEntityQueryModelVisitorFactory : EntityQueryModelVisitorFactory
    {
        public MongoDbEntityQueryModelVisitorFactory([NotNull] IQueryOptimizer queryOptimizer, 
                                                     [NotNull] INavigationRewritingExpressionVisitorFactory navigationRewritingExpressionVisitorFactory, 
                                                     [NotNull] ISubQueryMemberPushDownExpressionVisitor subQueryMemberPushDownExpressionVisitor, 
                                                     [NotNull] IQuerySourceTracingExpressionVisitorFactory querySourceTracingExpressionVisitorFactory, 
                                                     [NotNull] IEntityResultFindingExpressionVisitorFactory entityResultFindingExpressionVisitorFactory, 
                                                     [NotNull] ITaskBlockingExpressionVisitor taskBlockingExpressionVisitor, 
                                                     [NotNull] IMemberAccessBindingExpressionVisitorFactory memberAccessBindingExpressionVisitorFactory, 
                                                     [NotNull] IOrderingExpressionVisitorFactory orderingExpressionVisitorFactory, 
                                                     [NotNull] IProjectionExpressionVisitorFactory projectionExpressionVisitorFactory, 
                                                     [NotNull] IEntityQueryableExpressionVisitorFactory entityQueryableExpressionVisitorFactory, 
                                                     [NotNull] IQueryAnnotationExtractor queryAnnotationExtractor, 
                                                     [NotNull] IResultOperatorHandler resultOperatorHandler, 
                                                     [NotNull] IEntityMaterializerSource entityMaterializerSource, 
                                                     [NotNull] IExpressionPrinter expressionPrinter) 
            : base(queryOptimizer, navigationRewritingExpressionVisitorFactory, subQueryMemberPushDownExpressionVisitor, querySourceTracingExpressionVisitorFactory, entityResultFindingExpressionVisitorFactory, taskBlockingExpressionVisitor, memberAccessBindingExpressionVisitorFactory, orderingExpressionVisitorFactory, projectionExpressionVisitorFactory, entityQueryableExpressionVisitorFactory, queryAnnotationExtractor, resultOperatorHandler, entityMaterializerSource, expressionPrinter)
        {
        }

        public override EntityQueryModelVisitor Create(QueryCompilationContext queryCompilationContext, EntityQueryModelVisitor parentEntityQueryModelVisitor)
        {
            throw new NotImplementedException();
        }
    }
}
