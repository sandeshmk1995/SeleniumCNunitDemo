using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;

namespace SeleniumCAzure.Report
{
    public class ExtentManager
    {
        public static ExtentReports? extent;
        public static ExtentReports GetExtent()
        {
            if(extent == null)
            {
                var repoRoot = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent.FullName;
                var reportFolder = Path.Combine(repoRoot, "Report");
                Directory.CreateDirectory(reportFolder);

                var reportPath = Path.Combine(reportFolder, "MyReport_" + DateTime.Now.ToString("ddMMyyyy_HHmmss") + ".html");
                var reporter = new ExtentSparkReporter(reportPath);
                extent = new ExtentReports();
                extent.AttachReporter(reporter);
            }
            return extent;
        }
    }
}
