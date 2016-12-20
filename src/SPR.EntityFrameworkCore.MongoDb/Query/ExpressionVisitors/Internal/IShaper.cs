using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Storage;

namespace SPR.EntityFrameworkCore.MongoDb.Query.ExpressionVisitors.Internal
{
    public interface IShaper<TEntity>
    {
        TEntity Shape([NotNull] QueryContext queryContext, ValueBuffer valueBuffer);
    }
}
