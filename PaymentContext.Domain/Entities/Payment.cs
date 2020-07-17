using System;
using Flunt.Validations;
using Paymentcontext.Shared.Entities;
using PaymentContext.Domain.Entities.ValueObjects;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Domain.Entities
{
    public abstract class Payment : Entity
    {
        protected Payment(DateTime paidDate, DateTime expireDate, decimal total, decimal totalPaid, string owner, Document document, Address address)
        {
            Number = Guid.NewGuid().ToString().Replace("-","").Substring(0,10).ToUpper();
            PaidDate = paidDate;
            ExpireDate = expireDate;
            Total = total;
            TotalPaid = totalPaid;
            Owner = owner;
            Document = document;
            Address = address;

            AddNotifications(new Contract().Requires()
                .IsGreaterThan(0, Total, "Payment.Total", "The total has not be 0")
                .IsGreaterOrEqualsThan(Total, TotalPaid, "Payment.TotalPaid", "The value paid is lower that payment"));
        }

        public string Number { get; private set; }
        public DateTime PaidDate { get; private set; }
        public DateTime ExpireDate { get; private  set; }
        public decimal Total { get; private set; }
        public decimal TotalPaid { get; private set; }
        public string Owner { get; private set; }
        public Document Document { get; private set; }
        public Address Address { get; private set; }
    }
}