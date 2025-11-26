using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;

namespace SeleniumCAzure.DriverFactory
{
    
    public class DriverManager
    {
       private static ThreadLocal<IWebDriver> driver = new ThreadLocal<IWebDriver>();

        public static void CreateDriver(string browserName)
        {
            if(browserName.Equals("chrome"))
            {
                driver.Value = new ChromeDriver();
            }
            else if(browserName == "firefox")
            {
                driver.Value = new FirefoxDriver();
            }
            else if (browserName == "edge")
            {
                driver.Value = new EdgeDriver();
            }
            else{
                throw new ArgumentException($"{browserName} is Browser not supported");
            }

        }

        public static IWebDriver GetDriver()
        {
            return driver.Value!;
        }

    }
}
