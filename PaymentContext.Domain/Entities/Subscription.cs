using Flunt.Validations;
using Paymentcontext.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PaymentContext.Domain.Entities
{
    public class Subscription : Entity
    {
        private IList<Payment> _payment;
        public Subscription(DateTime? expiredDate)
        {
            CreateDate = DateTime.Now;
            LastUpdateDate = DateTime.Now;
            ExpiredDate = expiredDate;
            Active = true;
            _payment = new List<Payment>();
        }

        public DateTime CreateDate { get; private set; }
        public DateTime LastUpdateDate { get; private set; }
        public DateTime? ExpiredDate { get; private set; }
        public bool Active { get; private set; }
        public IReadOnlyCollection<Payment> Payments { get { return _payment.ToArray(); } }

        public void AddPayment(Payment payment)
        {
            AddNotifications(new Contract().Requires()
                .IsGreaterThan(DateTime.Now, payment.PaidDate, "Subscription.Payments", "The payment date has be..."));
            _payment.Add(payment);
        }

        public void Actvate(){
            Active = true;
            LastUpdateDate = DateTime.Now;
        }
        public void Inactivate(){
            Active = false;
            LastUpdateDate = DateTime.Now;
        }
    }
}