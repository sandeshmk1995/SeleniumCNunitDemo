using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SeleniumCAzure.Utility
{
    public class Utils
    {
         public IWebDriver driver;
         public Utils(IWebDriver driver)
        {
            this.driver = driver;
        }

        public WebDriverWait GetWait(int time)
        {
            WebDriverWait wait = new WebDriverWait(driver,TimeSpan.FromSeconds(time));
            return wait;
        }

        public void Click(By locator, int ?time=null)
        {
            int timeout = time ?? 10;
            try
            {
                GetWait(timeout).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(locator));
                driver.FindElement(locator).Click();
            }
            catch(Exception ex)
            {
                DriverFactory.BaseTest.test.Value!.Fail("Failed to click on element: " + locator.ToString());
                DriverFactory.BaseTest.test.Value.Fail(ex);  
                throw;
            }

        }

        public void TypeIntoTextbox(By locator, string text, int? time = null)
        {
            int timeout = time ?? 10;
            try
            {
                GetWait(timeout).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(locator)).SendKeys(text);
            }
            catch (Exception ex)
            {
                DriverFactory.BaseTest.test.Value!.Fail("Failed to type text on element: " + locator.ToString());
                DriverFactory.BaseTest.test.Value.Fail(ex);
                throw;
            }
        }
    }
}
