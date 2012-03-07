using System.Windows;
using ApprovalTests;
using ApprovalTests.Reporters;
using ApprovalTests.Wpf;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MsTestProject.Helpers;
using MsTestProject.Lib;

namespace MsTestProject
{
    [TestClass]
    [UseReporter(typeof(ImageReporter),typeof(PsClipboardReporter))]
    public class VerificationOfGuiScreens
    {
        [TestMethod]
         public void VerifyInvoiceView()
        {
            var wpfWindow = new Window();
            var view = new InvoiceView();
            wpfWindow.Content = view;
            WpfApprovals.Verify(wpfWindow);
        }
    }
}