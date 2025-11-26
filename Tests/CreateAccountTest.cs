using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeleniumCAzure.Config;
using SeleniumCAzure.DriverFactory;
using SeleniumCAzure.Pages;

namespace SeleniumCAzure.Tests
{
    public class CreateAccountTest : BaseTest
    {
        RegistrationPage registrationPage;
        string USERNAME;
        string PASSWORD;
        string[] Data;

        [SetUp]
        public void setPages()
        {
            registrationPage = new RegistrationPage(driver);
            USERNAME = ExcelReader.GetExcelValue(0, 2);
            PASSWORD = ExcelReader.GetExcelValue(0, 3);
            Data = new string[] { ExcelReader.GetExcelValue(0, 0), ExcelReader.GetExcelValue(0, 1), USERNAME, PASSWORD };
        }

        [Test, Category("login")]
        [Order(1)]
        public void VerifyCreateAccount()
        {
            registrationPage.CreateAccount(Data);
            string title = driver.Title;
            Console.WriteLine(title);
            Assert.That(title, Does.Contain("Sauce Demo"));
            test.Value!.Info("Single Account created Successfully");
        }

        [Test, Category("login"), TestCaseSource(typeof(ExcelReader), nameof(ExcelReader.GetAccountData))]
        [Order(2)]
        public void VerifyMultipleCreateAccount(string[] accData)
        {
            registrationPage.CreateAccount(accData);
            string title = driver.Title;
            Console.WriteLine(title);
            Assert.That(title, Does.Contain("Sauce Demo"));
            test.Value!.Info("Multiple Accounts created Successfully");
        }


    }
}
