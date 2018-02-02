using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using SeleniumBasedTests.common.pageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumBasedTests.internet.pageObjects
{
    class FileUploadPage : BasePage
    {
        [FindsBy(How = How.Id, Using = "file-upload")]
        private IWebElement fileUploadController { get; set; }

        [FindsBy(How = How.Id, Using = "file-submit")]
        private IWebElement uploadButton { get; set; }

        private By fileUploadControllerLocator = By.Id("file-upload");

        private string fileUploadConfirmation = "//div[@id='uploaded-files' and contains(text(), '%s')]";

        public FileUploadPage(IWebDriver webDriver) : base(webDriver)
        {
        }

        public FileUploadPage ClickUpload()
        {
            customWait.ClickElement(uploadButton);
            return this;
        }

        public FileUploadPage makeUploadButtonScaled()
        {
            makeElementScaled(uploadButton);
            return this;
        }

        public bool IsFileUploaded(string fileName)
        {
            return customWait.IsElementPresent(By.XPath(String.Format(fileUploadConfirmation, fileName)));
        }

        public override bool IsLoaded()
        {
            return customWait.IsElementVisible(fileUploadControllerLocator);
        }
    }
}
