using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using SeleniumBasedTests.common.utils;
using SeleniumBasedTests.common.pageObjects;


namespace SeleniumBasedTests.google.pageObjects
{
    class MainGooglePage : BasePage
    {
        [FindsBy(How = How.XPath, Using = ".//a[contains(text(), 'Sign in')]")]
        private IWebElement signInButton { get; set; }

        private By signInButtonLocator = By.XPath(".//a[contains(text(), 'Sign in')]");

        public MainGooglePage(IWebDriver webDriver) : base(webDriver)
        {            
        }

        public MainGooglePage SignInButtonClick()
        {
            customWait.ClickElement(signInButton);
            return this;
        }

        public override bool IsLoaded()
        {
            return customWait.IsElementVisible(signInButtonLocator);
        }
    }
}
