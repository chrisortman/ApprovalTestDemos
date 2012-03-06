using System;
using ApprovalTests;
using ApprovalTests.Reporters;
using ApprovalUtilities.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MsTestProject.Lib;

namespace MsTestProject
{
    [TestClass]
    public class TraditionalSpecificationTest
    {
        [TestMethod]
        public void FullnameIsFirstnameAndLastname()
        {
            var customer = new Customer
            {
                Firstname = "Bart",
                Lastname = "Simpson"
            };

            Assert.AreEqual("Bart Simpson",customer.Fullname());
        } 

        [TestMethod]
        [UseReporter(typeof(DiffReporter))]
        public void Approval_FullnameIsFirstnameAndLastname()
        {
            var customer = new Customer
            {
                Firstname = "Bartx",
                Lastname = "Simpson"
            };           
            Approvals.Verify(customer.Fullname() + Environment.NewLine);
        }
    }
}