using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using SeleniumBasedTests.common.pageObjects;
using SeleniumBasedTests.common.utils;

namespace SeleniumBasedTests.google.pageObjects
{
    class PasswordGooglePage : BasePage
    {
        [FindsBy(How = How.Id, Using = "passwordNext")]
        private IWebElement passwordNextButton { get; set; }

        private By passwordNextButtonLocator = By.Id("passwordNext");

        [FindsBy(How = How.Name, Using = "password")]
        private IWebElement passwordField { get; set; }

        [FindsBy(How = How.Id, Using = "profileIdentifier")]
        private IWebElement emailDisplayText { get; set; }

        public PasswordGooglePage(IWebDriver webDriver) : base(webDriver)
        {
        }

        public PasswordGooglePage NextButtonClick()
        {
            customWait.ClickElement(passwordNextButton);
            return this;
        }

        public PasswordGooglePage EnterPassword(string password)
        {
            customWait.ClickElement(passwordField);
            passwordField.SendKeys(password);
            return this;
        }

        public string GetEmailDisplayed()
        {
            return customWait.CreateWebDriverWait().Until((IWebDriver ignored) => emailDisplayText.Text);
        }

        public override bool IsLoaded()
        {
            return customWait.IsElementVisible(passwordNextButtonLocator);
        }
    }
}
