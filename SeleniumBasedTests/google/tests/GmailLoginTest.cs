using System;
using NUnit.Framework;
using SeleniumBasedTests.google.pageObjects;
using SeleniumBasedTests.common.tests;
using SeleniumBasedTests.common.utils;

namespace SeleniumBasedTests.google.tests
{
    [TestFixture]
    public class GmailLoginTest : BaseTest
    {
        private String url;
        private PageObjectGoogleManager manager;

        public GmailLoginTest()
        {
            manager = new PageObjectGoogleManager(webDriver);
        }

        [SetUp]
        public void StartTest()
        {
            url = UrlProvider.GetUrl(Url.GOOGLE_MAIN);
        }

        [TearDown]
        public void EndTest()
        {
            Close();
        }

        [Test]
        public void ShouldLoggedInTest()
        {
            manager.MainPage()
                    .LoadPage(url);
            manager.MainPage()
                    .SignInButtonClick();
            manager.LoginPage()
                    .EnterMailAddress("epam321")
                    //.AlternateClickNextButton();
                    .ClickNextButton();
            Assert.Equals("epam321@gmail.com", manager.PasswordPage().GetEmailDisplayed());
            manager.PasswordPage()
                    .EnterPassword("testtest1")
                    .NextButtonClick();
        }
    }
}
