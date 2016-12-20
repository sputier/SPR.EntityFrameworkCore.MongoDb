using JetBrains.Annotations;
using SPR.EntityFrameworkCore.MongoDb.Bson;
using System;

namespace SPR.EntityFrameworkCore.MongoDb.Query.Internal
{
    public interface IShaperCommandContextFactory
    {
        ShaperCommandContext Create([NotNull] Func<IBsonQueryGenerator> bsonQueryGeneratorFunc);
    }
}
