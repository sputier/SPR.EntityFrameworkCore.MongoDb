using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using Microsoft.EntityFrameworkCore.Internal;

namespace SPR.EntityFrameworkCore.MongoDb.Query
{
    public class MongoDbQueryContextFactory : QueryContextFactory
    {
        public MongoDbQueryContextFactory([NotNull] IStateManager stateManager, 
                                          [NotNull] IConcurrencyDetector concurrencyDetector, 
                                          [NotNull] IChangeDetector changeDetector) 
            : base(stateManager, concurrencyDetector, changeDetector)
        {
        }

        public override QueryContext Create()
        {
            throw new NotImplementedException();
        }
    }
}
