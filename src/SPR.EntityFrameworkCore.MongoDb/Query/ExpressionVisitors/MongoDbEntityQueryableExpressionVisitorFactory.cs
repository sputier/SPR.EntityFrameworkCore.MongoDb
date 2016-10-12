using Microsoft.EntityFrameworkCore.Query.ExpressionVisitors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Query;
using Remotion.Linq.Clauses;
using System.Linq.Expressions;

namespace SPR.EntityFrameworkCore.MongoDb.Query.ExpressionVisitors
{
    public class MongoDbEntityQueryableExpressionVisitorFactory : IEntityQueryableExpressionVisitorFactory
    {
        public ExpressionVisitor Create(EntityQueryModelVisitor entityQueryModelVisitor, IQuerySource querySource)
        {
            throw new NotImplementedException();
        }
    }
}
