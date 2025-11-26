using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using SeleniumCAzure.Config;
using SeleniumCAzure.Utility;
using SeleniumExtras.PageObjects;



namespace SeleniumCAzure.Pages
{
    public class LoginPage : Utils
    {       
       public LoginPage(IWebDriver driver) : base(driver)
        {       
        }

        private readonly By UserName = By.Id("customer_email");
        private readonly By Password = By.Id("customer_password");
        private readonly By LoginButton = By.CssSelector("[value='Sign In']");

        public void Login()
        {
            driver.Navigate().GoToUrl(ConfigManager.configR.url);
            TypeIntoTextbox(UserName, ConfigManager.configR.username!);
            TypeIntoTextbox(Password, ConfigManager.configR.password!);
            Click(LoginButton);
        }
        public void Login(string username, string pwd)
        {
            driver.Navigate().GoToUrl(ConfigManager.configR.url);
            TypeIntoTextbox(UserName, username);
            TypeIntoTextbox(Password, pwd);
            Click(LoginButton);
        }



    }
}
