using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Firefox;
using System.Configuration;

namespace SeleniumBasedTests.common.tests
{
    public class BaseTest
    {
        private static string browser = ConfigurationManager.AppSettings["browser"];

        protected static IWebDriver webDriver;

        protected BaseTest()
        {
            setDriver();
            webDriver.Manage().Window.Maximize();
        }

        public void Close()
        {
            webDriver.Quit();
        }

        public IWebDriver getDriver
        {
            get { return webDriver; }
        }

        private void setDriver()
        {
            switch(browser)
            {
                case "Chrome":
                    webDriver = new ChromeDriver();
                    break;
                case "IE":
                    webDriver = new InternetExplorerDriver();
                    break;
                case "Firefox":
                    webDriver = new FirefoxDriver();
                    break;
            }
        }
    }
}
