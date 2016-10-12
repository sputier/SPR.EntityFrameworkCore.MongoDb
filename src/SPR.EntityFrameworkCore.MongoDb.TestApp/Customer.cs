namespace SPR.EntityFrameworkCore.MongoDb.TestApp
{
    public class Customer
    {
        public ObjectId Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        //Cette propriété est génératrice d'exception : Address n'a pas de clé primaire...
        //public Address Address { get; set; }

        public string PhoneNumber { get; set; }
    }

    public class Address
    {
        public string Address1 { get; set; }

        public string Address2 { get; set; }

        public string ZipCode { get; set; }

        public string City { get; set; }

        public string Country { get; set; }
    }
}