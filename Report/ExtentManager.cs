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
                // Create Reports folder if it doesn't exist
                var reportFolder = Path.Combine(Directory.GetCurrentDirectory(), "Reports");
                Directory.CreateDirectory(reportFolder);

                // Save ExtentReport inside Reports folder
                var reportPath = Path.Combine(reportFolder, "MyReport_" + DateTime.Now.ToString("ddMMyyyy_HHmmss") + ".html");
                var reporter = new ExtentSparkReporter(reportPath);
                extent = new ExtentReports();
                extent.AttachReporter(reporter);
            }
            return extent;
        }
    }
}
