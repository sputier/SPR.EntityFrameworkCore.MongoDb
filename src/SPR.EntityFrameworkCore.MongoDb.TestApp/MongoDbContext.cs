using Microsoft.EntityFrameworkCore;
using SPR.EntityFrameworkCore.MongoDb.Attributes;

namespace SPR.EntityFrameworkCore.MongoDb.TestApp
{
    public class MongoDbContext : DbContext
    {
        private string _connectionString = ConnectionParameters.ConnectionString;
        private string _databaseName = ConnectionParameters.DatabaseName;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMongoDb(_connectionString, _databaseName);
        }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<City> Cities { get; set; }
    }

    public class City
    {
        [Field("_id")]
        public string Id { get; set; }

        public string Zip { get; set; }

        public string Name { get; set; }

        public int Population { get; set; }

        public string State { get; set; }
    }


    public class Customer
    {
        [Field("_id")]
        public string Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PhoneNumber { get; set; }
    }

    public struct Address
    {
        public string Address1 { get; set; }

        public string Address2 { get; set; }

        public string ZipCode { get; set; }

        public string City { get; set; }

        public string Country { get; set; }
    }
}
