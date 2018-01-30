using System;
using NUnit.Framework;
using OpenQA.Selenium;

namespace SeleniumBasedTests
{
    [TestFixture]
    public class AutomationCore : BaseTest
    {
        [SetUp]
        public void StartTest()
        {
            BasePage basePage = new BasePage(webDriver);
            basePage.LoadPage(UrlProvider.GetUrl(Url.THE_INTERNET));
        }
        [TearDown]
        public void Endtest()
        {
            Close();
        }
        [Test]
        public void BlogTest()
        {
            Assert.IsTrue(webDriver.Title.Contains("The Internet"));
        }
    }
}
