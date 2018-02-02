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

        public BasePage makeElementScaled(IWebElement uploadButton)
        {
            ((IJavaScriptExecutor)webDriver).ExecuteScript("arguments[0].style.transform='scale(1)';", uploadButton);
            return this;
        }

        public abstract bool IsLoaded();
    }
}
