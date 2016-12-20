using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Query.ExpressionVisitors;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Utilities;
using SPR.EntityFrameworkCore.MongoDb.Bson;
using SPR.EntityFrameworkCore.MongoDb.Metadata;
using SPR.EntityFrameworkCore.MongoDb.Query.Expressions;
using SPR.EntityFrameworkCore.MongoDb.Query.ExpressionVisitors.Internal;
using SPR.EntityFrameworkCore.MongoDb.Query.Internal;
using System;
using System.Linq.Expressions;
using System.Reflection;

namespace SPR.EntityFrameworkCore.MongoDb.Query.ExpressionVisitors
{
    public class MongoDbEntityQueryableExpressionVisitor : EntityQueryableExpressionVisitor
    {
        private readonly IModel _model;
        private readonly IMongoDbAnnotationsProvider _annotationsProvider;
        private readonly IFindExpressionFactory _findExpressionFactory;
        private readonly IMaterializerFactory _materializerFactory;
        private readonly IShaperCommandContextFactory _shaperCommandContextFactory;
        private readonly IValueBufferFromBsonShaperFactory _valueBufferShaperFactory;


        public MongoDbEntityQueryableExpressionVisitor(
            [NotNull] EntityQueryModelVisitor entityQueryModelVisitor,
            [NotNull] IModel model,
            [NotNull] IMongoDbAnnotationsProvider annotationsProvider,
            [NotNull] IFindExpressionFactory findExpressionFactory,
            [NotNull] IMaterializerFactory materializerFactory,
            [NotNull] IShaperCommandContextFactory shaperCommandContextFactory,
            [NotNull] IValueBufferFromBsonShaperFactory valueBufferShaperFactory)
            : base(Check.NotNull(entityQueryModelVisitor, nameof(entityQueryModelVisitor)))
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

        private new MongoDbEntityQueryModelVisitor QueryModelVisitor => (MongoDbEntityQueryModelVisitor)base.QueryModelVisitor;

        protected override Expression VisitEntityQueryable([NotNull] Type elementType)
        {
            Check.NotNull(elementType, nameof(elementType));

            var entityType = _model.FindEntityType(elementType);
            var collectionName = _annotationsProvider.For(entityType).CollectionName;

            var findExpression = _findExpressionFactory.Create();

            findExpression.SetCollectionExpression(new CollectionExpression(collectionName, elementType));

            var shaper = CreateShaper(elementType, entityType, findExpression);

            Func<IBsonQueryGenerator> createQueryGenerator = findExpression.CreateBsonQueryGenerator;
            var valueBufferShaper = _valueBufferShaperFactory.Create(findExpression);

            return Expression.Call(
                QueryModelVisitor.QueryCompilationContext.QueryMethodProvider
                    .ShapedQueryMethod
                    .MakeGenericMethod(shaper.Type),
                EntityQueryModelVisitor.QueryContextParameter,
                Expression.Constant(_shaperCommandContextFactory.Create(createQueryGenerator)),
                Expression.Constant(shaper),
                Expression.Constant(valueBufferShaper)); 
        }

        private Shaper CreateShaper(Type elementType, IEntityType entityType, FindExpression findExpression)
        {
            Shaper shaper;

            var materializer
                = _materializerFactory
                    .CreateMaterializer(
                        entityType,
                        findExpression,
                        (p, se) =>
                            se.AddToProjection(
                                _annotationsProvider.For(p).FieldName,
                                p)
                        ).Compile();

            shaper
                = (Shaper)_createEntityShaperMethodInfo.MakeGenericMethod(elementType)
                    .Invoke(null, new object[]
                    {
                                entityType.DisplayName(),
                                QueryModelVisitor.QueryCompilationContext.IsTrackingQuery,
                                entityType.FindPrimaryKey(),
                                materializer
                    });

            return shaper;
        }

        private static readonly MethodInfo _createEntityShaperMethodInfo
           = typeof(MongoDbEntityQueryableExpressionVisitor).GetTypeInfo()
               .GetDeclaredMethod(nameof(CreateEntityShaper));

        [UsedImplicitly]
        private static IShaper<TEntity> CreateEntityShaper<TEntity>(
            string entityType,
            bool trackingQuery,
            IKey key,
            Func<ValueBuffer, object> materializer)
            where TEntity : class
            => new BufferedEntityShaper<TEntity>(
                    entityType,
                    trackingQuery,
                    key,
                    materializer);
    }
}
