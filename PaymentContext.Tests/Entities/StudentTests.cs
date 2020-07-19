using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Entities.ValueObjects;
using PaymentContext.Domain.Entities.Enums;
using System.Runtime.Serialization;
using System;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Tests.Entities
{
    [TestClass]
    public class StudentTests
    {
        private readonly Student _student;
        private readonly Subscription _subscription;
        private readonly Name _name;
        private readonly Document _document;
        private readonly Email _email;
        private readonly Address _address;

        public StudentTests()
        {
            _name = new Name("Brune", "Wayne");
            _document = new Document("11111111122", EDocumentType.CPF);
            _email = new Email("batman@dc.com");
            _student = new Student(_name, _document, _email);
            _subscription = new Subscription(null);
            _address = new Address("Street", "45", "fdafda", "Gotan", "fdfdf", "EUA", "3232323");
        }
        [TestMethod]
        public void ShouldReturnErrorWhenHadActiveSubscription()
        {
            var payment = new PaypalPayment(_email, "12345678", DateTime.Now, DateTime.Now.AddDays(10), 10, 10, "Wayner corp", _document, _address);
            _subscription.AddPayment(payment);

            _student.AddSubscription(_subscription);
            _student.AddSubscription(_subscription);

            Assert.IsTrue(_student.Invalid);
        }
        [TestMethod]
        public void ShouldReturnErrorWhenSubscriptionHasNoPayment()
        {
            _student.AddSubscription(_subscription);

            Assert.IsTrue(_student.Invalid);
        }
        [TestMethod]
        public void ShouldReturnSuccessWhenHadNoActiveSubscription()
        {
            var payment = new PaypalPayment(_email, "12345678", DateTime.Now, DateTime.Now.AddDays(10), 10, 10, "Wayner corp", _document, _address);
            _subscription.AddPayment(payment);

            _student.AddSubscription(_subscription);
            _student.AddSubscription(_subscription);

            Assert.IsTrue(_student.Valid);
        }
    }
}