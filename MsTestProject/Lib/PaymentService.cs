using System.Collections.Generic;
using System.Linq;

namespace MsTestProject.Lib
{
    public enum PaymentTypes
    {
        CreditCard,
        BankDraft,
        Cash
    }

    public class SystemLevelOptions
    {
        public bool AreCreditCardMerchantsSetup(Customer c)
        {
            //maybe have some system level tables

            //then need to check for the customer
            //in this example we've only configured for 
            //customers in SD or NE state
            if(c.HomeAddress != null && 
                c.HomeAddress.State == "SD")
            {
                return true;
            }
            else if(c.HomeAddress != null &&
                c.HomeAddress.State == "NE")
            {
                return true;
            }
            return false;
        }
    }
    public class PaymentService
    {

        public PaymentTypes[] ApplicationAllowedPaymentTypes { get; set; }

        public IEnumerable<PaymentTypes> GetAllowedPaymentTypes(Customer c,decimal amount)
        {
            var systemOptions = new SystemLevelOptions();
            
            //we'll allways allow cash
            yield return PaymentTypes.Cash;
            
            //only allow bank if amount less than $100 and it is in our allowed payment types
            if(ApplicationAllowedPaymentTypes.Contains(PaymentTypes.BankDraft))
            {
                if(amount < 100M)
                {
                    yield return PaymentTypes.BankDraft;
                }
            }

            if(systemOptions.AreCreditCardMerchantsSetup(c))
            {
                if(ApplicationAllowedPaymentTypes.Contains(PaymentTypes.CreditCard))
                {
                    yield return PaymentTypes.CreditCard;
                }
            }
        }
    }
}