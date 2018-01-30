using OpenQA.Selenium;

namespace SeleniumBasedTests
{
    class BasePage
    {
        public IWebDriver webDriver;

        public BasePage(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
        }

        public string Title
        {
            get { return webDriver.Title; }
        }

        public void LoadPage(string url)
        {
            webDriver.Url = url;
        }
    }
}
