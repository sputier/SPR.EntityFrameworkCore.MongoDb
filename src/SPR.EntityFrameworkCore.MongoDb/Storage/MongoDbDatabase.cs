using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Update;
using Remotion.Linq;
using System.Threading;

namespace SPR.EntityFrameworkCore.MongoDb.Storage
{
    public class MongoDbDatabase : IDatabase
    {
        public Func<QueryContext, IAsyncEnumerable<TResult>> CompileAsyncQuery<TResult>(QueryModel queryModel)
        {
            throw new NotImplementedException();
        }

        public Func<QueryContext, IEnumerable<TResult>> CompileQuery<TResult>(QueryModel queryModel)
        {
            throw new NotImplementedException();
        }

        public int SaveChanges(IReadOnlyList<IUpdateEntry> entries)
        {
            throw new NotImplementedException();
        }

        public Task<int> SaveChangesAsync(IReadOnlyList<IUpdateEntry> entries, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }
    }
}
