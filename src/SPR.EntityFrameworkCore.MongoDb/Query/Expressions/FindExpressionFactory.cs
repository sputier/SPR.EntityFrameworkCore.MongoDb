using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore.Utilities;
using SPR.EntityFrameworkCore.MongoDb.Bson;

namespace SPR.EntityFrameworkCore.MongoDb.Query.Expressions
{
    public class FindExpressionFactory : IFindExpressionFactory
    {
        private readonly IBsonQueryGeneratorFactory _bsonQueryGeneratorFactory;

        public FindExpressionFactory([NotNull] IBsonQueryGeneratorFactory bsonQueryGeneratorFactory)
        {
            Check.NotNull(bsonQueryGeneratorFactory, nameof(bsonQueryGeneratorFactory));

            _bsonQueryGeneratorFactory = bsonQueryGeneratorFactory;
        }

        public FindExpression Create()
            => new FindExpression(_bsonQueryGeneratorFactory);
    }
}
