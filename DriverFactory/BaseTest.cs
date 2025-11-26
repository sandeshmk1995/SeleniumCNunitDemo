using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AventStack.ExtentReports;
using OpenQA.Selenium;
using SeleniumCAzure.Config;
using SeleniumCAzure.Report;
using System.Threading;
using NUnit.Framework;

namespace SeleniumCAzure.DriverFactory
{
    
    public class BaseTest
    {
        public IWebDriver driver => DriverManager.GetDriver();

        public static ExtentReports? extent;
        //public static ExtentTest? test;
#pragma warning disable NUnit1032 // An IDisposable field/property should be Disposed in a TearDown method
        public static ThreadLocal<ExtentTest> test = new ThreadLocal<ExtentTest>();
#pragma warning restore NUnit1032 // An IDisposable field/property should be Disposed in a TearDown method

        [OneTimeSetUp]
        public void ReportSetUp()
        {
            extent = ExtentManager.GetExtent();
        }

        [SetUp]
        public void InItDriver()
        {
            test.Value = extent!.CreateTest(TestContext.CurrentContext.Test.Name);

            DriverManager.CreateDriver(ConfigManager.configR.browser!);
            driver.Manage().Window.Maximize();
        }
       
        [TearDown]
        public void OutItDriver()
        {
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            if (status == NUnit.Framework.Interfaces.TestStatus.Failed)
            {
                string errorMessage = TestContext.CurrentContext.Result.Message!;
                string stackTrace = TestContext.CurrentContext.Result.StackTrace!;
                string screenshot = ScreenshotHelper.CaptureScreenshot(driver, test.Value!.Model.Name);
                test.Value.Fail("Test Failed: " + errorMessage)
            .Fail("Stack Trace: " + stackTrace)
            .AddScreenCaptureFromPath(screenshot);
            }
            
            driver.Quit();
        }

        [OneTimeTearDown]
        public void ReportFlush()
        {        
            extent!.Flush();
        }
    }
}
