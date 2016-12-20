using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Utilities;
using SPR.EntityFrameworkCore.MongoDb.Bson;
using SPR.EntityFrameworkCore.MongoDb.Query.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace SPR.EntityFrameworkCore.MongoDb.Query.Expressions
{
    public class FindExpression : Expression
    {
#if DEBUG
        internal string DebugView => ToString();
#endif

        private readonly List<FieldExpression> _projection = new List<FieldExpression>();
        private CollectionExpression _collection;
        private readonly IBsonQueryGeneratorFactory _bsonQueryGeneratorFactory;

        public FindExpression([NotNull] IBsonQueryGeneratorFactory bsonQueryGeneratorFactory)
        {
            Check.NotNull(bsonQueryGeneratorFactory, nameof(bsonQueryGeneratorFactory));

            _bsonQueryGeneratorFactory = bsonQueryGeneratorFactory;
        }

        public override Type Type => _projection.Count == 1
            ? _projection[0].Type
            : typeof(object);

        public override ExpressionType NodeType => ExpressionType.Extension;

        public virtual FindExpression Clone()
        {
            var findExpression
                = new FindExpression(_bsonQueryGeneratorFactory);

            findExpression._projection.AddRange(_projection);

            findExpression.SetCollectionExpression(_collection);

            return findExpression;
        }

        public virtual IBsonQueryGenerator CreateBsonQueryGenerator()
            => _bsonQueryGeneratorFactory.Create(this);


        public virtual CollectionExpression Collection => _collection;

        public virtual IReadOnlyList<FieldExpression> Projection => _projection;

        public virtual int AddToProjection(
            [NotNull] string field,
            [NotNull] IProperty property)
        {
            Check.NotEmpty(field, nameof(field));
            Check.NotNull(property, nameof(property));

            var projectionIndex = GetProjectionIndex(property);

            if (projectionIndex == -1)
            {
                projectionIndex = _projection.Count;

                _projection.Add(new FieldExpression(field, property, _collection));
            }

            return projectionIndex;
        }

        public virtual int AddToProjection([NotNull] FieldExpression fieldExpression)
        {
            Check.NotNull(fieldExpression, nameof(fieldExpression));

            var projectionIndex
                = _projection
                    .FindIndex(ce =>
                    {
                        return ce?.Property == fieldExpression.Property
                               && ce?.Type == fieldExpression.Type
                               && ce.CollectionName == fieldExpression.CollectionName;
                    });

            if (projectionIndex == -1)
            {
                projectionIndex = _projection.Count;

                _projection.Add(fieldExpression);
            }

            return projectionIndex;
        }

        public virtual IEnumerable<Type> GetProjectionTypes()
        {
            if (_projection.Any())
            {
                return _projection.Select(e => e.Type);
            }

            return Enumerable.Empty<Type>();
        }

        public virtual void SetProjectionExpression([NotNull] FieldExpression expression)
        {
            Check.NotNull(expression, nameof(expression));

            ClearProjection();
            AddToProjection(expression);
        }

        public virtual void SetCollectionExpression([NotNull] CollectionExpression expression)
        {
            Check.NotNull(expression, nameof(expression));

            _collection = expression;
        }

        public virtual void ClearProjection()
        {
            _projection.Clear();
        }

        public virtual void RemoveRangeFromProjection(int index)
        {
            if (index < _projection.Count)
            {
                _projection.RemoveRange(index, _projection.Count - index);
            }
        }

        public virtual int GetProjectionIndex(
            [NotNull] IProperty property)
        {
            Check.NotNull(property, nameof(property));

            return _projection
                .FindIndex(ce =>
                {
                    return ce?.Property == property;
                });
        }

        protected override Expression Accept(ExpressionVisitor visitor)
        {
            Check.NotNull(visitor, nameof(visitor));

            var specificVisitor = visitor as IBsonExpressionVisitor;

            return specificVisitor != null
                ? specificVisitor.VisitFind(this)
                : base.Accept(visitor);
        }
    }
}
