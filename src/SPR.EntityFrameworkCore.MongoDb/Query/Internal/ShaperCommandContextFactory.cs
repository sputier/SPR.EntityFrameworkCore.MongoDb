using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore.Utilities;
using SPR.EntityFrameworkCore.MongoDb.Bson;
using SPR.EntityFrameworkCore.MongoDb.Storage;
using System;

namespace SPR.EntityFrameworkCore.MongoDb.Query.Internal
{
    public class ShaperCommandContextFactory : IShaperCommandContextFactory
    {
        private readonly IValueBufferFactoryFactory _valueBufferFactoryFactory;

        public ShaperCommandContextFactory([NotNull] IValueBufferFactoryFactory valueBufferFactoryFactory)
        {
            Check.NotNull(valueBufferFactoryFactory, nameof(valueBufferFactoryFactory));

            _valueBufferFactoryFactory = valueBufferFactoryFactory;
        }

        public ShaperCommandContext Create([NotNull] Func<IBsonQueryGenerator> bsonQueryGeneratorFactory)
            => new ShaperCommandContext(_valueBufferFactoryFactory, bsonQueryGeneratorFactory);
    }
}
