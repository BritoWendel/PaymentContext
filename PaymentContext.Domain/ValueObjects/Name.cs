using Flunt.Validations;
using PaymentContext.Shared.ValueObjects;

namespace PaymentContext.Domain.Entities.ValueObjects
{
    public class Name : ValueObject
    {
        public Name(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
            AddNotifications(new Contract().Requires().HasMinLen(FirstName, 3, "Name.FirstName", "Name is so short.")
                                                      .HasMinLen(LastName, 3, "Name.LastName", "Name is so short")
                                                      .HasMaxLen(FirstName, 40, "Name.FirstName", "Name is so long.")
                                                      .HasMaxLen(LastName, 40, "Name.LastName", "Name is so long."));
        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }
    }
}