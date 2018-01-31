using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace SeleniumBasedTests.google.pageObjects
{
    class LoginGooglePage : BasePage
    {

        [FindsBy(How = How.XPath, Using = ".//input[@id='identifierId']")]
        public IWebElement emailField { get; set; }

        [FindsBy(How = How.Id, Using = "identifierNext")]
        public IWebElement nextButton { get; set; }

        public LoginGooglePage(IWebDriver webDriver) : base(webDriver)
        {

        }
    }
}
