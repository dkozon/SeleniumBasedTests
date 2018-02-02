using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using SeleniumBasedTests.common.pageObjects;
using SeleniumBasedTests.common.utils;
using System;

namespace SeleniumBasedTests.internet.pageObjects
{
    class MainPage : BasePage
    {

        [FindsBy(How = How.XPath, Using = "//h1[contains(text(), 'Welcome to the-internet')]")]
        private IWebElement theInternetHeader { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[contains(text(), 'File Upload')]")]
        private IWebElement fileUploadLink { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[contains(text(), 'Drag and Drop')]")]
        private IWebElement dragAndDropLink { get; set; }

        private By theInternetHeaderLocator = By.XPath("//h1[contains(text(), 'Welcome to the-internet')]");

        public MainPage(IWebDriver webDriver) : base(webDriver)
        {
        }

        public MainPage ClickUploadLink()
        {
            customWait.ClickElement(fileUploadLink);
            return this;
        }

        public MainPage ClickDragAndDropLink()
        {
            dragAndDropLink.Click();
            return this;
        }

        public override bool IsLoaded()
        {
            return customWait.IsElementVisible(theInternetHeaderLocator);
        }
    }
}
