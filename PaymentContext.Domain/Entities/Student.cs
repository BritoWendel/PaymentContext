using System.Collections.Generic;
using System.Linq;
using PaymentContext.Domain.Entities.ValueObjects;
using Paymentcontext.Shared.Entities;
using PaymentContext.Domain.ValueObjects;
using Flunt.Validations;

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
            if(subscription.Payments.Count == 0)
            {

            }
            if (HasSubscriptionActive())
                AddNotification("Student.Subscription", "Student already has active subscription.");

            AddNotifications(new Contract().Requires()
                .IsFalse(HasSubscriptionActive(), "Student.Subscription", "Student already has active subscription.")
                .IsGreaterThan(0,subscription.Payments.Count, "Student.Subscription.Payments", "This subscriptin does not have paymentest."));
        }
        private bool HasSubscriptionActive()
        {
            foreach(var sub in _subscriptions)
                if (sub.Active)
                    return true;
            return false;
        }
    }
}