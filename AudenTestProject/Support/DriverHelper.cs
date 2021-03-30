using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace AudenTestProject.Support
{
    public class DriverHelper
    {
        public IWebDriver Driver { get; set; }

        protected WebDriverWait wait;

        private WebDriverWait GenerateWebDriverWait(int seconds = 60)
        {
            return new WebDriverWait(Driver, TimeSpan.FromSeconds(seconds));
        }

        public void WaitForAnElement(IWebElement elementLocator)
        {
            GenerateWebDriverWait().Until(d => elementLocator.Displayed);
        }

        public IWebElement WaitForAnElementToPresent(IWebElement element)
        {
            GenerateWebDriverWait().Until(d => element.Displayed && element.Enabled);
            return element;
        }

    }
}
