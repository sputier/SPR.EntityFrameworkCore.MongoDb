using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JetBrains.Annotations;

namespace SPR.EntityFrameworkCore.MongoDb.Infrastructure
{
    public class MongoDbContextOptionsBuilder : DbContextOptionsBuilder
    {
        public MongoDbContextOptionsBuilder([NotNull] DbContextOptionsBuilder optionBuilder) 
            : base(optionBuilder.Options)
        {
        }

        public MongoDbContextOptionsBuilder([NotNull] DbContextOptions options) 
            : base(options)
        {
        }
    }
}
