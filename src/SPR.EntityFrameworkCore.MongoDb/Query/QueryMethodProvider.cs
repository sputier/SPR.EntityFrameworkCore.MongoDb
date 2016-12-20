using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore.Query;
using SPR.EntityFrameworkCore.MongoDb.Query.ExpressionVisitors.Internal;
using SPR.EntityFrameworkCore.MongoDb.Query.Internal;
using System.Collections.Generic;
using System.Reflection;

namespace SPR.EntityFrameworkCore.MongoDb.Query
{
    public class QueryMethodProvider : IQueryMethodProvider
    {
        public virtual MethodInfo ShapedQueryMethod => _shapedQueryMethodInfo;

        private static readonly MethodInfo _shapedQueryMethodInfo
            = typeof(QueryMethodProvider).GetTypeInfo()
                .GetDeclaredMethod(nameof(_ShapedQuery));

        [UsedImplicitly]
        private static IEnumerable<T> _ShapedQuery<T>(
            QueryContext queryContext,
            ShaperCommandContext shaperCommandContext,
            IShaper<T> shaper,
            IValueBufferFromBsonShaper valueBufferShaper)
        {
            foreach (var valueBuffer in new QueryingEnumerable((MongoDbQueryContext)queryContext, shaperCommandContext, valueBufferShaper))
            {
                yield return shaper.Shape(queryContext, valueBuffer);
            }
        }
    }
}
