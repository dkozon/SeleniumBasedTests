using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SeleniumBasedTests
{
    class CustomWait
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private static readonly int DEFAULT_TIMEOUT_IN_SEC = 10;
        private IWebDriver webDriver;

        public CustomWait(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
        }

        public WebDriverWait CreateWebDriverWait()
        {
            return new WebDriverWait(webDriver, TimeSpan.FromSeconds(DEFAULT_TIMEOUT_IN_SEC));
        }

        public bool IsElementPresent(By by)
        {
            WebDriverWait wait = CreateWebDriverWait();
            try
            {
                wait.Until(ExpectedConditions.ElementIsVisible(by));
                return true;
            }
            catch(WebDriverTimeoutException e)
            {
                log.Error("Element not found!", e);
                return false;
            }
        }

        public bool IsElementClicable(By by)
        {
            WebDriverWait wait = CreateWebDriverWait();
            try
            {
                wait.Until(ExpectedConditions.ElementToBeClickable(by));
                return true;
            }
            catch (WebDriverTimeoutException e)
            {
                log.Error("Element not found!", e);
                return false;
            }
        }
    }
}
