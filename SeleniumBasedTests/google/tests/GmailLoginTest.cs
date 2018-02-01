﻿using System;
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
        private PageObjectManager manager;

        public GmailLoginTest()
        {
            manager = new PageObjectManager(webDriver);
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
                    .AlternateClickNextButton();
                    //.clickNextButton();
            //TODO: assertion
            manager.PasswordPage()
                    .EnterPassword("testtest1")
                    .NextButtonClick();
        }
    }
}
