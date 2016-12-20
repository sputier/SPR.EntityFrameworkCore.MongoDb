using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage;
using SPR.EntityFrameworkCore.MongoDb.Query.Expressions;
using System;
using System.Linq.Expressions;

namespace SPR.EntityFrameworkCore.MongoDb.Query.ExpressionVisitors.Internal
{
    public interface IMaterializerFactory
    {
        Expression<Func<ValueBuffer, object>> CreateMaterializer(
            [NotNull] IEntityType entityType,
            [NotNull] FindExpression findExpression,
            [NotNull] Func<IProperty, FindExpression, int> projectionAdder);
    }
}
