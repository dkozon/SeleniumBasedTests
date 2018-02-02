using OpenQA.Selenium;
using SeleniumBasedTests.google.pageObjects;
using OpenQA.Selenium.Support.PageObjects;

namespace SeleniumBasedTests.common.utils
{
    class PageObjectGoogleManager
    {
        private readonly IWebDriver webDriver;
        private LoginGooglePage loginGooglePage;
        private MainGooglePage mainGooglePage;
        private PasswordGooglePage passwordGooglePage;

        public PageObjectGoogleManager(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
        }

        public LoginGooglePage LoginPage()
        {
            if (loginGooglePage == null)
            {
                loginGooglePage = PageFactory.InitElements<LoginGooglePage>(webDriver);
            }
            return loginGooglePage;
        }

        public MainGooglePage MainPage()
        {
            if (mainGooglePage == null)
            {
                mainGooglePage = PageFactory.InitElements<MainGooglePage>(webDriver);
            }
            return mainGooglePage;
        }

        public PasswordGooglePage PasswordPage()
        {
            if (passwordGooglePage == null)
            {
                passwordGooglePage = PageFactory.InitElements<PasswordGooglePage>(webDriver);
            }
            return passwordGooglePage;
        }
    }
}
