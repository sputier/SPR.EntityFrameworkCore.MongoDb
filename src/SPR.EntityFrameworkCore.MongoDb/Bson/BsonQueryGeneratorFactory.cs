using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore.Utilities;
using SPR.EntityFrameworkCore.MongoDb.Query.Expressions;
using SPR.EntityFrameworkCore.MongoDb.Storage;

namespace SPR.EntityFrameworkCore.MongoDb.Bson
{
    public class BsonQueryGeneratorFactory : IBsonQueryGeneratorFactory
    {
        private readonly IBsonCommandBuilderFactory _bsonCommandBuilderFactory;

        public BsonQueryGeneratorFactory([NotNull] IBsonCommandBuilderFactory bsonCommandBuilderFactory
                                         )
        {
            Check.NotNull(bsonCommandBuilderFactory, nameof(bsonCommandBuilderFactory));

            _bsonCommandBuilderFactory = bsonCommandBuilderFactory;
        }

        public IBsonQueryGenerator Create(FindExpression findExpression)
            => new BsonQueryGenerator(_bsonCommandBuilderFactory, findExpression);
    }
}
