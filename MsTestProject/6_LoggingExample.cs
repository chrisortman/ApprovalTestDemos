using System;
using System.Text;
using System.Linq;
using ApprovalTests;
using ApprovalTests.Reporters;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MsTestProject
{
    [TestClass]
    [UseReporter(typeof(DiffReporter))]
    public class LoggingExample
    {
        [TestMethod]
        public void TraceExecutionUsingLoggingIsUsefulForEveryone()
        {
            var task = new DataCleanupTask();
            task.Process(new[]
            {
                "1,Feature1,1/15/2011",
                "2,Feature2,1/15/2011",
                "3,Feature3,1/15/2013",
                "4,Feature4,1/15/2011",
                "5,Feature5,1/15/2011",
                "6,Feature6,5/15/2011",
                "7,Feature7,1/15/2011",
                "8,Feature8,9/15/2009",
                "9,Feature9,1/15/2011",
                "10,Feature10,1/15/2011",
                "11,Feature11,1/15/2011",
                "12,Feature12,1/15/2010",
                "13,Feature13,1/15/2011",
                "14,Feature14,1/15/2011",
                "15,Feature15,1/15/2011",
                "16,Feature16,2/15/2010",
                "17,Feature17,6/15/2008",
                "18,Feature18,1/15/2011",
                "19,Feature19,1/15/2011",
                "20,Feature20,1/15/2011",
                "21,Feature20,1/15/2011",

            });

            Approvals.Verify(task.Log.Dump());
            
        }
    }
    public class DataCleanupTask
    {
        private class Record
        {
            public int FeatureId { get; set; }
            public string Feature { get; set; }
            public DateTime ActivationDate { get; set; }

        }

        public CleanupLogger Log { get; set; }

        public void Process(string[] linesFromFile)
        {
            Log = new CleanupLogger();

            var records = linesFromFile.Select(x =>
            {
                var parts = x.Split(',');
                return new Record()
                {
                    FeatureId = Convert.ToInt32(parts[0]),
                    Feature = parts[1],
                    ActivationDate = DateTime.Parse(parts[2])
                };
            });

            foreach(var record in records)
            {
                Log.Message("Processing feature " + record.Feature + " with id " + record.FeatureId);

                //Odd number features need to have have their price adjusted
                if(record.FeatureId % 2 == 1)
                {
                    Log.Message("Adjust price by 2% because of odd feature ID " + record.FeatureId);
                }

                if(record.ActivationDate < new DateTime(2010, 1, 25))
                {
                    Log.Message("Remove feature because of activation date " + record.ActivationDate);
                    Log.TraceSql(String.Format(@"
DELETE FROM Features Where Id = {0}
", record.FeatureId));

                }
            }
        }
    }

    public class CleanupLogger
    {
        private StringBuilder sb = new StringBuilder();

        public void Message(string s)
        {
            sb.AppendLine(s);
        }

        public void TraceSql(string sql)
        {
            sb.AppendLine("Execute SQL");
            sb.AppendLine(sql.Trim());
        }

        public string Dump()
        {
            return sb.ToString();
        }
    }
}