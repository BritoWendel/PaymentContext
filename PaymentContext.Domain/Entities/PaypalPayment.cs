using System;
using PaymentContext.Domain.Entities.ValueObjects;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Domain.Entities
{
    public class PaypalPayment : Payment
    {
        public PaypalPayment(Email email, string transactionCode, DateTime paidDate, DateTime expireDate, decimal total, decimal totalPaid, string owner, Document document, Address address) : base (paidDate, expireDate, total, totalPaid, owner, document, address)
        {
            Email = email;
            TransactionCode = transactionCode;
        }

        public Email Email { get; private set; }
        public string TransactionCode { get; private set; }
    }
}