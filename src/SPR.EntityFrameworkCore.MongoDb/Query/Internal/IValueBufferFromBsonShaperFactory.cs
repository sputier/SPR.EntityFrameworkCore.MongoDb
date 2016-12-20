using SPR.EntityFrameworkCore.MongoDb.Query.Expressions;

namespace SPR.EntityFrameworkCore.MongoDb.Query.Internal
{
    public interface IValueBufferFromBsonShaperFactory
    {
        IValueBufferFromBsonShaper Create(FindExpression findExpression);
    }
}
