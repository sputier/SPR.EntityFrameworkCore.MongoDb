using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Query.ExpressionVisitors;
using Microsoft.EntityFrameworkCore.Query.ExpressionVisitors.Internal;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace SPR.EntityFrameworkCore.MongoDb.Query.Internal
{
    public class MongoDbQueryModelVisitorFactory : EntityQueryModelVisitorFactory
    {
        public MongoDbQueryModelVisitorFactory(/*[NotNullAttribute]*/ IQueryOptimizer queryOptimizer,
                                               /*[NotNullAttribute]*/ INavigationRewritingExpressionVisitorFactory navigationRewritingExpressionVisitorFactory,
                                               /*[NotNullAttribute]*/ ISubQueryMemberPushDownExpressionVisitor subQueryMemberPushDownExpressionVisitor,
                                               /*[NotNullAttribute]*/ IQuerySourceTracingExpressionVisitorFactory querySourceTracingExpressionVisitorFactory,
                                               /*[NotNullAttribute]*/ IEntityResultFindingExpressionVisitorFactory entityResultFindingExpressionVisitorFactory,
                                               /*[NotNullAttribute]*/ ITaskBlockingExpressionVisitor taskBlockingExpressionVisitor,
                                               /*[NotNullAttribute]*/ IMemberAccessBindingExpressionVisitorFactory memberAccessBindingExpressionVisitorFactory,
                                               /*[NotNullAttribute]*/ IOrderingExpressionVisitorFactory orderingExpressionVisitorFactory,
                                               /*[NotNullAttribute]*/ IProjectionExpressionVisitorFactory projectionExpressionVisitorFactory,
                                               /*[NotNullAttribute]*/ IEntityQueryableExpressionVisitorFactory entityQueryableExpressionVisitorFactory,
                                               /*[NotNullAttribute]*/ IQueryAnnotationExtractor queryAnnotationExtractor,
                                               /*[NotNullAttribute]*/ IResultOperatorHandler resultOperatorHandler,
                                               /*[NotNullAttribute]*/ IEntityMaterializerSource entityMaterializerSource,
                                               /*[NotNullAttribute]*/ IExpressionPrinter expressionPrinter) 
            : base(queryOptimizer, navigationRewritingExpressionVisitorFactory, subQueryMemberPushDownExpressionVisitor, querySourceTracingExpressionVisitorFactory, entityResultFindingExpressionVisitorFactory, taskBlockingExpressionVisitor, memberAccessBindingExpressionVisitorFactory, orderingExpressionVisitorFactory, projectionExpressionVisitorFactory, entityQueryableExpressionVisitorFactory, queryAnnotationExtractor, resultOperatorHandler, entityMaterializerSource, expressionPrinter)
        {
        }

        public override EntityQueryModelVisitor Create(QueryCompilationContext queryCompilationContext, EntityQueryModelVisitor parentEntityQueryModelVisitor)
        {
            throw new NotImplementedException();
        }
    }
}
