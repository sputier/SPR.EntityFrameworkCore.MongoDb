using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Update;
using Microsoft.EntityFrameworkCore.Utilities;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SPR.EntityFrameworkCore.MongoDb.Storage
{
    public class MongoDbDatabase : Database
    {
        public MongoDbDatabase(
            [NotNull] IQueryCompilationContextFactory queryCompilationContextFactory)
            : base(
                    Check.NotNull(queryCompilationContextFactory,
                                nameof(queryCompilationContextFactory)))
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
