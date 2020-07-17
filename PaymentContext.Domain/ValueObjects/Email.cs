using PaymentContext.Shared.ValueObjects;
using Flunt.Notifications;
using Flunt.Validations;

namespace PaymentContext.Domain.Entities.ValueObjects
{
    public class Email : ValueObject
    {
        public Email(string address)
        {
            Address = address;
            AddNotifications(new Contract().Requires().IsEmail(Address, "Email.Address", "Invalid e-mail"));
        }

        public string Address { get; private set; }
    }
}