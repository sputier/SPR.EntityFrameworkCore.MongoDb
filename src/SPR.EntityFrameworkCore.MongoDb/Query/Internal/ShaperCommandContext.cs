using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore.Utilities;
using SPR.EntityFrameworkCore.MongoDb.Bson;
using SPR.EntityFrameworkCore.MongoDb.Storage;
using System;

namespace SPR.EntityFrameworkCore.MongoDb.Query.Internal
{
    public class ShaperCommandContext
    {
        private readonly IValueBufferFactoryFactory _valueBufferFactoryFactory;
        
        public ShaperCommandContext([NotNull] IValueBufferFactoryFactory valueBufferFactoryFactory,
                                    [NotNull] Func<IBsonQueryGenerator> bsonQueryGeneratorFunc)
        {
            Check.NotNull(valueBufferFactoryFactory, nameof(valueBufferFactoryFactory));
            Check.NotNull(bsonQueryGeneratorFunc, nameof(bsonQueryGeneratorFunc));

            _valueBufferFactoryFactory = valueBufferFactoryFactory;
            BsonQueryGeneratorFunc = bsonQueryGeneratorFunc;
        }

        public virtual Func<IBsonQueryGenerator> BsonQueryGeneratorFunc { get; }

        private IValueBufferFactory _valueBufferFactory;
        public IValueBufferFactory ValueBufferFactory => _valueBufferFactory;

        public virtual IMongoDbFindCommand GetCommand()
        {
            IMongoDbFindCommand mongoCommand;

            var generator = BsonQueryGeneratorFunc();
            mongoCommand = generator.GenerateBsonCommand();

            return mongoCommand;
        }

        public virtual void NotifyReaderCreated()
            => _valueBufferFactory = BsonQueryGeneratorFunc()
                                    .CreateValueBufferFactory(_valueBufferFactoryFactory);
    }
}
