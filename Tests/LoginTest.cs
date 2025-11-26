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
            Assert.That(title, Is.EqualTo("Account – Sauce Demo"));
            test.Value!.Info("User logged in Successfully");
        }

    }
}
