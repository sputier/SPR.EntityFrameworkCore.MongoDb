using System;

namespace SPR.EntityFrameworkCore.MongoDb.Query.ExpressionVisitors.Internal
{
    public abstract class Shaper
    {
        public abstract Type Type { get; }
    }

}
