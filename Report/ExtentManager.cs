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
                var reporter = new ExtentSparkReporter("C:\\SeleniumCAzure\\Report\\ExtentReports\\MyReport_" + DateTime.Now.ToString("ddMMyyyy_HHmmss") +".html");
                extent = new ExtentReports();
                extent.AttachReporter(reporter);
            }
            return extent;
        }
    }
}
