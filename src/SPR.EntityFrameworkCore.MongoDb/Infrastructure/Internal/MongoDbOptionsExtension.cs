using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore.Utilities;
using JetBrains.Annotations;

namespace SPR.EntityFrameworkCore.MongoDb.Infrastructure.Internal
{
    public class MongoDbOptionsExtension : IDbContextOptionsExtension
    {
        public string ConnectionString { get; set; }

        public MongoDbOptionsExtension()
        {
        }

        public MongoDbOptionsExtension([NotNull] MongoDbOptionsExtension copyFrom)
        {
            Check.NotNull(copyFrom, nameof(copyFrom));

            this.ConnectionString = copyFrom.ConnectionString;
        }

        public void ApplyServices([NotNull] IServiceCollection services)
        {
            Check.NotNull(services, nameof(services));

            services.AddEntityFrameworkMongoDb();
        }
    }
}
