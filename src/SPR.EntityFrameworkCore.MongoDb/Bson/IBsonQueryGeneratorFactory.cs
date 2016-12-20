using SPR.EntityFrameworkCore.MongoDb.Query.Expressions;

namespace SPR.EntityFrameworkCore.MongoDb.Bson
{
    public interface IBsonQueryGeneratorFactory
    {
        IBsonQueryGenerator Create(FindExpression finExpression);
    }
}
