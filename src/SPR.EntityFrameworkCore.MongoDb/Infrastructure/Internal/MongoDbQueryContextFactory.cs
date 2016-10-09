using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using Microsoft.EntityFrameworkCore.Internal;

namespace SPR.EntityFrameworkCore.MongoDb.Infrastructure.Internal
{
    public class MongoDbQueryContextFactory : QueryContextFactory
    {
        public MongoDbQueryContextFactory(/*[NotNullAttribute]*/ IStateManager stateManager,
                                  /*[NotNullAttribute]*/ IConcurrencyDetector concurrencyDetector,
                                  /*[NotNullAttribute]*/ IChangeDetector changeDetector)
            : base(stateManager, concurrencyDetector, changeDetector)
        {
        }

        public override QueryContext Create()
        {
            throw new NotImplementedException();
        }
    }
}
