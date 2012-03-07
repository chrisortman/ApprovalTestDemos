namespace MsTestProject.Lib
{
    public class InvoiceLineItem
    {
        public string Description { get; set; }

        public decimal Price { get; set; }

        public override string ToString()
        {
            return string.Format("{0}.......{1}", Description, Price.ToString("c"));
        }
    }
}