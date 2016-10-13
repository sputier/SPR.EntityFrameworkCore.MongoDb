using Microsoft.EntityFrameworkCore.ValueGeneration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SPR.EntityFrameworkCore.MongoDb.ValueGeneration
{
    public class MongoDbValueGeneratorCache : ValueGeneratorCache
    {
        public override ValueGenerator GetOrAdd(IProperty property, IEntityType entityType, Func<IProperty, IEntityType, ValueGenerator> factory)
        {
            return base.GetOrAdd(property, entityType, factory);
        }
    }
}
