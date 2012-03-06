using System.Collections.Generic;
using System.Text;
using ApprovalUtilities.Utilities;

namespace MsTestProject.Lib
{
    public class Invoice
    {
        public Invoice()
        {
            LineItems = new List<InvoiceLineItem>();
        }

        public List<InvoiceLineItem> LineItems { get; set; }

        public decimal SubTotal { get; set; }

        public decimal Total { get; set; }

        public string Header { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine(Header);            
            sb.AppendLine("----------------------------".PadRight(40));
            foreach(var item in LineItems)
            {                
                sb.AppendFormat("{0}{1}", item.Description.PadRight(15), item.Price.ToString().PadLeft(25));
                sb.AppendLine();
            }

            sb.AppendLine("-------".PadLeft(40));
            sb.AppendFormat("{0}", SubTotal.ToString("c").PadLeft(40));
            sb.AppendLine();
            sb.AppendFormat("{0}", Total.ToString("c").PadLeft(40));
            sb.AppendLine();

            return sb.ToString();

        }
    }
}