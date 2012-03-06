using ApprovalTests.Reporters;

namespace MsTestProject.Helpers
{
    public class KdiffReporter : GenericDiffReporter
    {
        public static string PATH = DotNet4Utilities.GetPathInProgramFilesX86("kdiff3\\kdiff3.exe");
            
        public KdiffReporter()  
            : base(KdiffReporter.PATH,"{0} {1} --merge -o {1}", string.Format("Could not find Kdiff3 at {0}, please install it cinst install kdiff3", KdiffReporter.PATH))
        {
        }
    }
}