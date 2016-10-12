using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Update;
using System.Threading;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore.Query;

namespace SPR.EntityFrameworkCore.MongoDb.Storage
{
    public class MongoDbDatabase : Database
    {
        public MongoDbDatabase([NotNull] IQueryCompilationContextFactory queryCompilationContextFactory) 
            : base(queryCompilationContextFactory)
        {
        }

        public override int SaveChanges(IReadOnlyList<IUpdateEntry> entries)
        {
            throw new NotImplementedException();
        }

        public override Task<int> SaveChangesAsync(IReadOnlyList<IUpdateEntry> entries, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }
    }
}
