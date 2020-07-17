using Flunt.Validations;
using PaymentContext.Shared.ValueObjects;

namespace PaymentContext.Domain.ValueObjects
{
    public class Address : ValueObject
    {
        public Address(string street, string number, string neighborhood, string city, string stade, string country, string zipCode)
        {
            Street = street;
            Number = number;
            Neighborhood = neighborhood;
            City = city;
            Stade = stade;
            Country = country;
            ZipCode = zipCode;

            AddNotifications(new Contract().Requires().HasMinLen(Street, 3, "Address.Street", "Name is so short."));
        }

        public string Street { get; private set; }
        public string Number { get; private set; }
        public string Neighborhood { get; private set; }
        public string City { get; private set; }
        public string Stade { get; private set; }
        public string Country { get; private set; }
        public string ZipCode { get; private set; }

    }
}
