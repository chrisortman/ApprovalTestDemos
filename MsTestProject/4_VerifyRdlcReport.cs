using ApprovalTests;
using ApprovalTests.RdlcReports;
using ApprovalTests.Reporters;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MsTestProject.Helpers;
using MsTestProject.Lib;

namespace MsTestProject
{
    [TestClass]
    [UseReporter(typeof(DiffReporter),typeof(PsClipboardReporter))]
    public class VerifyRdlcReport
    {
        [TestMethod]
         public void VerifyInvoiceReport()
        {
            var tble = new InvoiceReportDataset.BilledInvoicesDataTable();
             tble.AddBilledInvoicesRow("Bart Simpson", 10M, 13M);
             tble.AddBilledInvoicesRow("Homer Simpson", 15M, 20M);
             tble.AddBilledInvoicesRow("Marge Simpson", 10M, 13M);
             tble.AddBilledInvoicesRow("Lisa Simpson", 10M, 13M);
             tble.AddBilledInvoicesRow("Maggie Simpson", 10M, 13M);

            RdlcApprovals.VerifyReport("MsTestProject.Lib.BilledInvoicesReport.rdlc", tble);
        }
    }
}