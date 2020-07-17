using System;

namespace PaymentContext.Domain.Entities
{
    public class PaypalPayment : Payment
    {
        public PaypalPayment(string email, string transactionCode, DateTime paidDate, DateTime expireDate, decimal total, decimal totalPaid, string owner, string document, string address) : base (paidDate, expireDate, total, totalPaid, owner, document, address)
        {
            Email = email;
            TransactionCode = transactionCode;
        }

        public string Email { get; private set; }
        public string TransactionCode { get; private set; }
    }
}