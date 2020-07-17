using System.Collections.Generic;
using System.Linq;
using PaymentContext.Domain.Entities.ValueObjects;
using Paymentcontext.Shared.Entities;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Domain.Entities
{
    public class Student : Entity
    {
        private IList<Subscription> _subscriptions;
        public Student(Name name, Document document, Email email)
        {
            Name = name;
            Document = document;
            Email = email;
            _subscriptions = new List<Subscription>();

            AddNotifications(name, document, email);
        }

        public Name Name { get; private set; }
        public Document Document { get; private set; }   
        public Email Email { get; private set; }
        public Address Address { get; private set; }
        public IReadOnlyCollection<Subscription> Subscription { get {return _subscriptions.ToArray();} }

        public void AddSubscription(Subscription subscription)
        {
            //Cancela todas as outras assinatudas e coloca a nova como principal
            foreach(var sub in Subscription)
                sub.Inactivate();

            _subscriptions.Add(subscription);
        }
    }
}