using System;
using System.Linq;

namespace SPR.EntityFrameworkCore.MongoDb.TestApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {



                using (var context = new MongoDbContext())
                {
                    Console.WriteLine("Tentative de chargement des données de la collection Customer");

                    var data = context.Customers.ToList();

                    foreach (var customer in data)
                    {
                        Console.WriteLine($"Id : {customer.Id} - Client : {customer.FirstName} {customer.LastName} - Tel : {customer.PhoneNumber}");
                    }
                }

                using (var context = new MongoDbContext())
                {
                    Console.WriteLine("Tentative de chargement des données de la collection City");

                    var cities = context.Cities.Select(c => new { c.Name, c.Id, c.Zip }).ToList();

                    foreach (var ville in cities)
                    {
                        Console.WriteLine($"Id : {ville.Id} - Nom : {ville.Name} - Zip : {ville.Zip}");
                    }
                }

            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Message);

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(ex.StackTrace);
            }

            Console.ReadLine();
        }
    }
}

