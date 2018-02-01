using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SeleniumBasedTests.common.utils
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

        public bool IsElementVisible(By by)
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

        public bool IsElementClickable(By by)
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

        public bool IsElementClickable(IWebElement element)
        {
            WebDriverWait wait = CreateWebDriverWait();
            try
            {
                wait.Until(ExpectedConditions.ElementToBeClickable(element));
                return true;
            }
            catch (WebDriverTimeoutException e)
            {
                log.Error("Element not found!", e);
                return false;
            }
        }

        public bool IsElementPresent(By by)
        {
            WebDriverWait wait = CreateWebDriverWait();
            try
            {
                wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(by));
                return true;
            }
            catch (WebDriverTimeoutException e)
            {
                log.Error("Element not found!", e);
                return false;
            }
        }

        public bool IsElementDisappear(By by)
        {
            WebDriverWait wait = CreateWebDriverWait();
            try
            {
                wait.Until(ExpectedConditions.InvisibilityOfElementLocated(by));
                return true;
            }
            catch (WebDriverTimeoutException e)
            {
                log.Error("Element should not be visible!", e);
                return false;
            }
        }

        public void ClickElement(By by)
        {
            WebDriverWait wait = CreateWebDriverWait();
            wait.Until((d) =>
            {
                if (IsElementClickable(by))
                {
                    webDriver.FindElement(by).Click();
                }
                return true;
            });
        }

        public void ClickElement(IWebElement element)
        {
            WebDriverWait wait = CreateWebDriverWait();
            wait.Until((d) =>
            {
                if (IsElementClickable(element))
                {
                    element.Click();
                }
                return true;
            });
        }

        public String GetElementText(By by, int timeoutInSeconds)
        {
            WebDriverWait wait = CreateWebDriverWait();
            return wait.Until((d) =>
            {
                try
                {
                    if (IsElementVisible(by))
                    {
                        return webDriver.FindElement(by).GetAttribute("text");
                    }
                }
                catch (NoSuchElementException e)
                {
                    log.Error("Element not found! Can't get element's text...", e);
                }
                return "";
            });
        }

        public String GetElementAttribute(By by, String attributeName, int timeoutInSeconds)
        {
            WebDriverWait wait = CreateWebDriverWait();
            return wait.Until((d) =>
            {
                try
                {
                    if(webDriver.FindElement(by).GetAttribute(attributeName) != null)
                    {
                        return webDriver.FindElement(by).GetAttribute(attributeName);
                    }
                }
                catch (NoSuchElementException e)
                {
                    log.Error("Element not found! Can't get '" + attributeName + "'...", e);
                }
                return "";
            });
        }
    }
}
