using System;
using ApprovalTests.Combinations;
using ApprovalTests.Reporters;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MsTestProject.Lib;
using System.Linq;

namespace MsTestProject
{
    [TestClass]
    [UseReporter(typeof(DiffReporter))]
    public class CombinatorialTesting
    {
        
        [TestMethod]
        public void VerifyCustomerPaymentOptions()
        {
            var possiblePaymentTypes = new[]
            {
                "BankDraft, CreditCard, Cash",
                "BankDraft, CreditCard",
                "BankDraft, Cash",
                "CreditCard, Cash",
                "CreditCard",
                "Cash",
                "BankDraft",
            };
            var amounts = new[] {0M, 10M, 100M, 200M};
            var customerLocations = new[] {"SD", "IA","NE"};

            CombinationApprovals.VerifyAllCombinations((allowedPaymentTypes,amount,location) =>
            {
                var paymentService = new PaymentService();
                var parts = allowedPaymentTypes.Split(',');

                paymentService.ApplicationAllowedPaymentTypes =
                    parts.Select(x => (PaymentTypes) System.Enum.Parse(typeof(PaymentTypes), x)).ToArray();

                var customer = new Customer()
                {
                    HomeAddress = new Address() {State = location}
                };

                var customerAllowedPaymentTypes = paymentService.GetAllowedPaymentTypes(customer, amount).ToArray();
                return string.Join(",", customerAllowedPaymentTypes);
            },possiblePaymentTypes,amounts,customerLocations);
        }
    }
}