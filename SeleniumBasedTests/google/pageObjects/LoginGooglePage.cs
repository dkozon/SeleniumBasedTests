using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using SeleniumBasedTests.common.pageObjects;
using SeleniumBasedTests.common.utils;

namespace SeleniumBasedTests.google.pageObjects
{
    class LoginGooglePage : BasePage
    {
        [FindsBy(How = How.XPath, Using = ".//input[@id='identifierId']")]
        private IWebElement emailField { get; set; }

        [FindsBy(How = How.Id, Using = "identifierNext")]
        private IWebElement nextButton { get; set; }

        private By emailFieldLocator = By.XPath(".//input[@id='identifierId']");

        private By nextButtonLocator = By.Id("identifierNext");

        public LoginGooglePage(IWebDriver webDriver) : base(webDriver)
        {
        }

        public LoginGooglePage EnterMailAddress(string login)
        {
            customWait.ClickElement(emailField);
            emailField.SendKeys(login);
            return this;
        }

        public LoginGooglePage ClickNextButton()
        {
            customWait.ClickElement(nextButton);
            return this;
        }

        public LoginGooglePage AlternateClickNextButton()
        {
            customWait.IsElementVisible(nextButtonLocator);
            IJavaScriptExecutor js = (IJavaScriptExecutor)webDriver;
            js.ExecuteScript("arguments[0].click();", nextButton);
            return this;
        }

        public override bool IsLoaded()
        {
            return customWait.IsElementVisible(emailFieldLocator) && customWait.IsElementVisible(nextButtonLocator);
        }
    }
}
