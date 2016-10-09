using Microsoft.EntityFrameworkCore.ValueGeneration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SPR.EntityFrameworkCore.MongoDb.ValueGenerator.Internal
{
    public class MongoDbValueGeneratorCache : ValueGeneratorCache, IValueGeneratorCache
    {
        public override Microsoft.EntityFrameworkCore.ValueGeneration.ValueGenerator GetOrAdd(IProperty property, IEntityType entityType, Func<IProperty, IEntityType, Microsoft.EntityFrameworkCore.ValueGeneration.ValueGenerator> factory)
        {
            return base.GetOrAdd(property, entityType, factory);
        }
    }
}
