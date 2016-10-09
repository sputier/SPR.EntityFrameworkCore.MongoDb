using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;

namespace SPR.EntityFrameworkCore.MongoDb.Storage
{
    public class MongoDbContextTransactionManager : IDbContextTransactionManager
    {
        public IDbContextTransaction BeginTransaction()
        {
            throw new NotImplementedException();
        }

        public Task<IDbContextTransaction> BeginTransactionAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        public void CommitTransaction()
        {
            throw new NotImplementedException();
        }

        public void RollbackTransaction()
        {
            throw new NotImplementedException();
        }
    }
}
