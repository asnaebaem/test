using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject1.Methods
{
    public static class SeleniumMethods
    {
        public static IWebDriver ConfigureDriver(IWebDriver driver, string driverType, string driverPath)
        {
            switch(driverType)
            {
                case "ie":
                {
                    driver = new InternetExplorerDriver(driverPath);
                    break; 
                }
                case "firefox":
                {
                    driver = new FirefoxDriver();
                    break;
                }
                case "chrome":
                {
                    driver = new ChromeDriver(driverPath);
                    break;
                }                
            }
            driver.Manage().Window.Maximize();
            return driver;
        }
        public static IWebDriver GoToWebSite(IWebDriver driver, string URL)
        {
            driver.Navigate().GoToUrl(URL);
            return driver;
        }
    }

}
