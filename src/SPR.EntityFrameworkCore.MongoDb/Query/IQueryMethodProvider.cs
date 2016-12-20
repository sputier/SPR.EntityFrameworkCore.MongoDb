using System.Reflection;

namespace SPR.EntityFrameworkCore.MongoDb.Query
{
    public interface IQueryMethodProvider
    {
        MethodInfo ShapedQueryMethod { get; }
    }
}
