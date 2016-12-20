using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore.Utilities;
using Remotion.Linq.Parsing;
using SPR.EntityFrameworkCore.MongoDb.Query.Bson;
using SPR.EntityFrameworkCore.MongoDb.Query.Expressions;
using SPR.EntityFrameworkCore.MongoDb.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace SPR.EntityFrameworkCore.MongoDb.Bson
{
    public class BsonQueryGenerator : ThrowingExpressionVisitor, IBsonQueryGenerator, IBsonExpressionVisitor
    {
        private FindExpression _findExpression;
        private readonly IBsonCommandBuilderFactory _bsonCommandBuilderFactory;

        private IBsonCommandBuilder _bsonCommandBuilder;

        public BsonQueryGenerator([NotNull] IBsonCommandBuilderFactory bsonCommandBuilderFactory,
                                  [NotNull] FindExpression findExpression)
        {
            _bsonCommandBuilderFactory = bsonCommandBuilderFactory;
            _findExpression = findExpression;
        }

        public IMongoDbFindCommand GenerateBsonCommand()
        {
            _bsonCommandBuilder = _bsonCommandBuilderFactory.Create();

            Visit(_findExpression);

            return _bsonCommandBuilder.Build();
        }

        protected override Exception CreateUnhandledItemException<T>(T unhandledItem, string visitMethod)
            => new NotImplementedException(visitMethod);

        public virtual IValueBufferFactory CreateValueBufferFactory(
                        IValueBufferFactoryFactory valueBufferFactoryFactory)
        {
            Check.NotNull(valueBufferFactoryFactory, nameof(valueBufferFactoryFactory));

            return valueBufferFactoryFactory.Create(_findExpression.GetProjectionTypes().ToArray(), indexMap: null);
        }

        public Expression VisitField([NotNull] FieldExpression fieldExpression)
        {
            Check.NotNull(fieldExpression, nameof(fieldExpression));

            _bsonCommandBuilder.AddField(fieldExpression.Name);

            return fieldExpression;
        }

        private void VisitProjection(IReadOnlyList<FieldExpression> fieldExpressions)
            => fieldExpressions.ToList().ForEach(fieldExpr => VisitField(fieldExpr));

        public Expression VisitFind([NotNull] FindExpression findExpression)
        {
            Check.NotNull(findExpression, nameof(findExpression));

            VisitCollection(findExpression.Collection);

            if (findExpression.Projection.Any())
                VisitProjection(findExpression.Projection);

            return findExpression;
        }

        public Expression VisitCollection([NotNull] CollectionExpression collectionExpression)
        {
            Check.NotNull(collectionExpression, nameof(collectionExpression));

            _bsonCommandBuilder.AddCollection(collectionExpression.Name, collectionExpression.EntityType);

            return collectionExpression;
        }
    }
}
