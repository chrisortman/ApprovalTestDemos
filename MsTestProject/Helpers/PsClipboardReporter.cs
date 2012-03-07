using System.Windows;
using ApprovalTests.Core;
using ApprovalTests.Reporters;

namespace MsTestProject.Helpers
{
    public class PsClipboardReporter : IApprovalFailureReporter
    {
        public void Report(string approved, string received)
        {
            Clipboard.SetText(string.Format("Move-Item -Force \"{0}\" \"{1}\"", received, approved));
        }
    }
}