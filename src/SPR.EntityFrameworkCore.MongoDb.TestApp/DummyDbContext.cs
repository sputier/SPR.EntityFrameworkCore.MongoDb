using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SPR.EntityFrameworkCore.MongoDb.TestApp
{
    public class DummyDbContext : DbContext
    {
        private string connectionString = "mongodb://localhost:32769/";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseMongoDb(this.connectionString);
        }

        public DbSet<Customer> Customers { get; set; }
    }
}
