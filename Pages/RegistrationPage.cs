using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using SeleniumCAzure.Config;
using SeleniumCAzure.Utility;

namespace SeleniumCAzure.Pages
{
    public class RegistrationPage : Utils
    {
        public RegistrationPage(IWebDriver driver) : base(driver)
        {
        }

        private readonly By SignUpLink = By.Id("customer_register_link");
        private readonly By FirstName = By.CssSelector("input[id='first_name']");
        private readonly By LastName = By.CssSelector("input[id='last_name']");
        private readonly By Email = By.CssSelector("input[id='email']");
        private readonly By Password = By.CssSelector("input[id='password']");
        private readonly By CreateButton = By.CssSelector("[value='Create']");
        public void CreateAccount(string[] accountData)
        {
            driver.Navigate().GoToUrl(ConfigManager.configR.url);
            Click(SignUpLink);
            TypeIntoTextbox(FirstName, accountData[0]);
            TypeIntoTextbox(LastName, accountData[1]);
            TypeIntoTextbox(Email, accountData[2]);
            TypeIntoTextbox(Password, accountData[3]);
            Click(CreateButton);
        }
    }
}
