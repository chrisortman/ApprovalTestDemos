using System;
using System.Collections;
using System.Linq;
using ApprovalTests;
using ApprovalTests.Reporters;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MsTestProject.Lib;

namespace MsTestProject
{
    [TestClass]
    public class ASlightlyLessContrivedExample
    {
        private Customer _customer;

        [TestInitialize]
        public void Setup()
        {
            _customer = new Customer()
            {
                Firstname = "Bart",
                Lastname = "Simpson",
                Birthday = new DateTime(1989, 12, 17),
                DriversLicense = "EatMyShorts",
                HomeAddress = new Address()
                {
                    City = "Springfield",
                    State = "XY",
                    Zip = "55555"
                },
                Phone1 = "1112223333",
                Phone2 = "9998887777",
                SSN = "123456789"

            };
        }

        [TestMethod]
        public void GenerateSomeXmlForACustomer()
        {
            var expectedXml = @"<Customer>
  <Firstname>Bart</Firstname>
  <Lastname>Simpson</Lastname>
  <Birthday>1989-12-17T00:00:00</Birthday>
  <HomeAddress>
    <City>Springfield</City>
    <State>XY</State>
    <Zip>55555</Zip>
  </HomeAddress>
  <DriversLicense>EatMyShorts</DriversLicense>
  <SSN>123456789</SSN>
  <Phone1>1112223333</Phone1>
  <Phone2>9998887777</Phone2>
</Customer>";
            Assert.AreEqual(expectedXml,_customer.ToXml());
        }

        [TestMethod]
        [UseReporter(typeof(DiffReporter))]
        public void Approval_GenerateSomeXmlForACustomer()
        {
            Approvals.Verify(_customer.ToXml() + Environment.NewLine);
        }

        [TestMethod]
        public void GenerateAnInvoiceForAnOrder()
        {
            var order = new Order();
            order.Add("Cheetos", 5M);
            order.Add("Doritos", 3M);
            order.Add("Mountain Dew", 5M);
            order.SalesTax = .06M;

            order.Customer = _customer;

            Invoice invoice = order.GenerateInvoice();

            Assert.AreEqual("Order for Bart Simpson",invoice.Header);
            Assert.AreEqual("Cheetos",invoice.LineItems[0].Description);
            Assert.AreEqual(5M, invoice.LineItems[0].Price);

            Assert.AreEqual("Doritos",invoice.LineItems[1].Description);
            Assert.AreEqual(3M, invoice.LineItems[1].Price);

            Assert.AreEqual("Mountain Dew",invoice.LineItems[2].Description);
            Assert.AreEqual(5M, invoice.LineItems[2].Price);

            Assert.AreEqual(13M, invoice.SubTotal);
            Assert.AreEqual(13.78M, invoice.Total);

        }

        [TestMethod]
        [UseReporter(typeof(DiffReporter))]
        public void Approval_GenerateInvoiceForOrder()
        {
            var order = new Order();
            order.Add("Cheetos", 5M);
            order.Add("Doritos", 3M);
            order.Add("Mountain Dew", 5M);
            order.SalesTax = .06M;

            order.Customer = _customer;

            Invoice invoice = order.GenerateInvoice();

            Approvals.Verify(invoice);
        }
    }
}