using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace SeleniumCAzure.Report
{
    public class ScreenshotHelper
    {
        public static string CaptureScreenshot(IWebDriver driver, string name)
        {
            string folderPath = "C:\\SeleniumCAzure\\Report\\Screenshots\\";
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
            var screenshot = ((ITakesScreenshot)driver).GetScreenshot();
            string path = $"{folderPath}/{name}_{DateTime.Now:HHmmss}.png";
            screenshot.SaveAsFile(path);
            return path;
        }
    }
}
