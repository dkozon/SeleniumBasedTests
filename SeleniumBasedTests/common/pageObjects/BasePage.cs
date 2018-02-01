using OpenQA.Selenium;
using SeleniumBasedTests.common.utils;

namespace SeleniumBasedTests.common.pageObjects
{
    abstract class BasePage
    {
        public IWebDriver webDriver;
        public CustomWait customWait;

        public BasePage(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
            customWait = new CustomWait(webDriver);
        }

        public string Title
        {
            get { return webDriver.Title; }
        }

        public void LoadPage(string url)
        {
            webDriver.Url = url;
        }

        public abstract bool IsLoaded();
    }
}
