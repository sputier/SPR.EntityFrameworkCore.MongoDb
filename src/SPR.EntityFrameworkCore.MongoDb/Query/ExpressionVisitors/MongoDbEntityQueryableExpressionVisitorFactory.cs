using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Query.ExpressionVisitors;
using Microsoft.EntityFrameworkCore.Utilities;
using Remotion.Linq.Clauses;
using SPR.EntityFrameworkCore.MongoDb.Metadata;
using SPR.EntityFrameworkCore.MongoDb.Query.Expressions;
using SPR.EntityFrameworkCore.MongoDb.Query.ExpressionVisitors.Internal;
using SPR.EntityFrameworkCore.MongoDb.Query.Internal;
using System.Linq.Expressions;

namespace SPR.EntityFrameworkCore.MongoDb.Query.ExpressionVisitors
{
    public class MongoDbEntityQueryableExpressionVisitorFactory : IEntityQueryableExpressionVisitorFactory
    {
        private readonly IModel _model;
        private readonly IMongoDbAnnotationsProvider _annotationsProvider;
        private readonly IFindExpressionFactory _findExpressionFactory;
        private readonly IMaterializerFactory _materializerFactory;
        private readonly IShaperCommandContextFactory _shaperCommandContextFactory;
        private readonly IValueBufferFromBsonShaperFactory _valueBufferShaperFactory;

        public MongoDbEntityQueryableExpressionVisitorFactory(
                [NotNull] IModel model,
                [NotNull] IMongoDbAnnotationsProvider annotationsProvider,
                [NotNull] IFindExpressionFactory findExpressionFactory,
                [NotNull] IMaterializerFactory materializerFactory,
                [NotNull] IShaperCommandContextFactory shaperCommandContextFactory,
                [NotNull] IValueBufferFromBsonShaperFactory valueBufferShaperFactory
        )
        {
            Check.NotNull(model, nameof(model));
            Check.NotNull(annotationsProvider, nameof(annotationsProvider));
            Check.NotNull(findExpressionFactory, nameof(findExpressionFactory));
            Check.NotNull(materializerFactory, nameof(materializerFactory));
            Check.NotNull(shaperCommandContextFactory, nameof(shaperCommandContextFactory));
            Check.NotNull(valueBufferShaperFactory, nameof(valueBufferShaperFactory));

            _model = model;
            _annotationsProvider = annotationsProvider;
            _findExpressionFactory = findExpressionFactory;
            _materializerFactory = materializerFactory;
            _shaperCommandContextFactory = shaperCommandContextFactory;
            _valueBufferShaperFactory = valueBufferShaperFactory;
        }

        public ExpressionVisitor Create(
            EntityQueryModelVisitor entityQueryModelVisitor,
            IQuerySource querySource)
            => new MongoDbEntityQueryableExpressionVisitor(
                entityQueryModelVisitor, 
                _model, 
                _annotationsProvider, 
                _findExpressionFactory,
                _materializerFactory,
                _shaperCommandContextFactory,
                _valueBufferShaperFactory);
    }
}
