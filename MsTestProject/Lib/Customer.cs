using System;
using System.Collections.Generic;
using System.Xml.Linq;
using System.Linq;

namespace MsTestProject.Lib
{
    public class Customer
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public DateTime Birthday { get; set; }
        public Address HomeAddress { get; set; }
        public string DriversLicense { get; set; }
        public string SSN { get; set; }
        public string Phone1 { get; set; }
        public string Phone2 { get; set; }

        public string Fullname()
        {
            return string.Format("{0} {1}", Firstname, Lastname);
        }

        public XElement ToXml()
        {
            return new XElement("Customer",
                new XElement("Firstname",Firstname),
                new XElement("Lastname",Lastname),
                new XElement("Birthday",Birthday),
                new XElement("HomeAddress",
                    new XElement("City",HomeAddress.City),
                    new XElement("State",HomeAddress.State),
                    new XElement("Zip",HomeAddress.Zip)),
                new XElement("DriversLicense",DriversLicense),
                new XElement("SSN",SSN),
                new XElement("Phone1",Phone1),
                new XElement("Phone2",Phone2));
        } 
    }

    public class Address
    {
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
    }

    public class Order
    {
        private Dictionary<string, decimal> _orderItems = new Dictionary<string, decimal>(); 

        public void Add(string itemDescription, decimal itemPrice)
        {
            _orderItems.Add(itemDescription,itemPrice);    
        }

        public decimal SalesTax { get; set; }

        public Customer Customer { get; set; }

        public Invoice GenerateInvoice()
        {
            var invoice = new Invoice();
            invoice.Header = "Order for " + Customer.Fullname();

            foreach(var item in _orderItems)
            {
                invoice.LineItems.Add(new InvoiceLineItem()
                {
                    Description = item.Key,
                    Price = item.Value
                });
            }
            invoice.SubTotal = _orderItems.Values.Sum();
            invoice.Total = (SalesTax*invoice.SubTotal) + invoice.SubTotal;

            return invoice;
        }
    }


}