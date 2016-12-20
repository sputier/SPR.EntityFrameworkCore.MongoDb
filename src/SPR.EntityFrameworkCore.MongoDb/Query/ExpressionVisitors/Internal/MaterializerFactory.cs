using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Utilities;
using SPR.EntityFrameworkCore.MongoDb.Query.Expressions;
using System;
using System.Linq.Expressions;

namespace SPR.EntityFrameworkCore.MongoDb.Query.ExpressionVisitors.Internal
{
    public class MaterializerFactory : IMaterializerFactory
    {
        private readonly IEntityMaterializerSource _entityMaterializerSource;

        public MaterializerFactory(
            [NotNull] IEntityMaterializerSource entityMaterializerSource)
        {
            Check.NotNull(entityMaterializerSource, nameof(entityMaterializerSource));

            _entityMaterializerSource = entityMaterializerSource;
        }

        public virtual Expression<Func<ValueBuffer, object>> CreateMaterializer(
            IEntityType entityType,
            FindExpression findExpression,
            Func<IProperty, FindExpression, int> projectionAdder)
        {
            Check.NotNull(entityType, nameof(entityType));
            Check.NotNull(findExpression, nameof(findExpression));
            Check.NotNull(projectionAdder, nameof(projectionAdder));

            var valueBufferParameter
                = Expression.Parameter(typeof(ValueBuffer), "valueBuffer");

            var indexMap = new int[entityType.PropertyCount()];
            var propertyIndex = 0;

            foreach (var property in entityType.GetProperties())
            {
                indexMap[propertyIndex++]
                    = projectionAdder(property, findExpression);
            }

            var materializer
                = _entityMaterializerSource
                    .CreateMaterializeExpression(
                        entityType, valueBufferParameter, indexMap);

            return Expression.Lambda<Func<ValueBuffer, object>>(materializer, valueBufferParameter);
        }
    }
}
