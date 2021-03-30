using AudenTestProject.Support;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace AudenTestProject.Utilities
{
    public class HelperMethods
    {
          public static void EnterText(IWebElement element, string value) => element.SendKeys(value);

        public static void Click(IWebElement element) => element.Click();

        public static void SelectByValue(IWebElement element, string value)
        {
            SelectElement selectElement = new SelectElement(element);
            selectElement.SelectByValue(value);
        }

        public static void SelectByText(IWebElement element, string text)
        {
            SelectElement selectElement = new SelectElement(element);
            selectElement.SelectByValue(text);
        }

  /*      public void DragAndDrop(IWebElement element, int xOffset, int yOffset)
        {
            Actions actions = new Actions();
            actions.DragAndDropToOffset(element, xOffset, yOffset).Build().Perform();
        }*/

        public bool IsValueCorrect(IWebElement element, string value) => element.Text.Equals(value);

        public bool IsButtonDisplayed(IWebElement element) => element.Displayed;
    }
}
