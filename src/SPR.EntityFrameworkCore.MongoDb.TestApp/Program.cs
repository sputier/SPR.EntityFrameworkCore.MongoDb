using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SPR.EntityFrameworkCore.MongoDb.TestApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                using (var context = new DummyDbContext())
                {
                    Console.WriteLine("DummyDbContext created");

                    var entity = new Customer()
                    {
                        FirstName = "Sebastien",
                        LastName = "Putier",
                        Address = new Address
                        {
                            Address1 = "1ere ligne d'adresse",
                            Address2 = "2eme ligne d'adresse",
                            ZipCode = "01023",
                            City = "Une ville",
                            Country = "France"
                        },
                        PhoneNumber = "0601020304"
                    };

                    Console.WriteLine("Entity created");

                    context.Add(entity);
                    Console.WriteLine("Entity added");

                    context.SaveChanges();
                    Console.WriteLine("Entity saved");
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
