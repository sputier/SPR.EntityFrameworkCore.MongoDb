using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Query.ExpressionVisitors;
using Microsoft.EntityFrameworkCore.Query.ExpressionVisitors.Internal;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace SPR.EntityFrameworkCore.MongoDb.Query
{
    public class MongoDbEntityQueryModelVisitor : EntityQueryModelVisitor
{

    public MongoDbEntityQueryModelVisitor(
        [NotNull] IQueryOptimizer queryOptimizer,
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
        [NotNull] IExpressionPrinter expressionPrinter,
        [NotNull] QueryCompilationContext queryCompilationContext)
        : base(
                queryOptimizer,
                navigationRewritingExpressionVisitorFactory,
                subQueryMemberPushDownExpressionVisitor,
                querySourceTracingExpressionVisitorFactory,
                entityResultFindingExpressionVisitorFactory,
                taskBlockingExpressionVisitor,
                memberAccessBindingExpressionVisitorFactory,
                orderingExpressionVisitorFactory,
                projectionExpressionVisitorFactory,
                entityQueryableExpressionVisitorFactory,
                queryAnnotationExtractor,
                resultOperatorHandler,
                entityMaterializerSource,
                expressionPrinter,
                queryCompilationContext)
    {
    }

        public new virtual MongoDbQueryCompilationContext QueryCompilationContext
            => (MongoDbQueryCompilationContext)base.QueryCompilationContext;

    }
}
