using SPR.EntityFrameworkCore.MongoDb.Query.Expressions;

namespace SPR.EntityFrameworkCore.MongoDb.Query.Internal
{
    public class ValueBufferFromBsonShaperFactory : IValueBufferFromBsonShaperFactory
    {
        public IValueBufferFromBsonShaper Create(FindExpression findExpression)
            => new ValueBufferFromBsonShaper(findExpression);
    }
}
