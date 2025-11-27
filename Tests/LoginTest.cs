using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AventStack.ExtentReports.Model;
using SeleniumCAzure.Config;
using SeleniumCAzure.DriverFactory;
using SeleniumCAzure.Pages;

namespace SeleniumCAzure.Tests
{
    public class LoginTest : BaseTest
    {
        LoginPage loginPage;

        [SetUp]
        public void setPages()
        {
            loginPage = new LoginPage(driver);          
        }

        [Test,Category("login")]
        [Order(1)]
        public void VerifyLogin()
        {
            loginPage.Login();
            string title = driver.Title;
            Console.WriteLine(title);
            var repoRoot = Environment.GetEnvironmentVariable("BUILD_SOURCESDIRECTORY");
            repoRoot = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory)
                                        .Parent.Parent.Parent.FullName;
        

            string reportFolder = Path.Combine(repoRoot, "Report", "ExtentReports");
            Console.WriteLine(reportFolder);
            Assert.That(title, Is.EqualTo("Account – Sauce Demo"));
            test.Value!.Info("User logged in Successfully");
        }

    }
}
