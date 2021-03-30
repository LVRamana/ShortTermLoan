using AudenTestProject.Support;
using AudenTestProject.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace AudenTestProject.PageObjects
{
    public class HomePage : HelperMethods
    {
        private IWebDriver Driver;

        public HomePage(IWebDriver driver)
        {
            Driver = driver;
        }

        IList<IWebElement> loanCalculator => Driver.FindElements(By.XPath("//div[@class='loan-calculator']/section"));

        IWebElement loanAmountHeader => Driver.FindElement(By.XPath("//loan-amount__header__range/h3"));

        IWebElement loanCalculatorSlider => Driver.FindElement(By.XPath("//input[@data-testid = 'loan-calculator-slider']"));

        IWebElement loanCalculatorAmount => Driver.FindElement(By.CssSelector("section.loan-amount"));

        IWebElement loanAmountValue => Driver.FindElement(By.XPath("//div[@class='loan-amount__header__amount']/span"));
        IWebElement RepaymentDayHeader => Driver.FindElement(By.XPath("//div[@class='loan-schedule__tab']/h3"));

        IWebElement FirstRepaymentDay => Driver.FindElement(By.XPath("//div[@class='loan-schedule__tab__panel__detail']//span[2]/label[1]"));

        IWebElement SecondRepaymentDay => Driver.FindElement(By.XPath("//div[@class='loan-schedule__tab__panel__detail']//span[2]/label[2]"));


        IList<IWebElement> loanReScheduleOptions => Driver.FindElements(By.XPath("//label[@class='loan-schedule__tab__panel__detail__tag__label']/input"));
        IWebElement loanBreakdownAmount => Driver.FindElement(By.XPath("//section[@class='loan-summary']//div[1]//div[1]"));
        IWebElement loanBreakdownTitle => Driver.FindElement(By.XPath("//section[@class='loan-summary']/div[1]/span"));

        IWebElement interestBreakdownAmount => Driver.FindElement(By.XPath("//section[@class='loan-summary']//div[2]//div[1]"));
        IWebElement interestBreakdownTitle => Driver.FindElement(By.XPath("//section[@class='loan-summary']/div[2]/span"));
        IWebElement totalBreakdownAmount => Driver.FindElement(By.XPath("//section[@class='loan-summary']//div[3]//div[1]"));

        IWebElement totalBreakdownTitle => Driver.FindElement(By.XPath("//section[@class='loan-summary']/div[3]/span"));
        IWebElement perMonthBreakdownAmount => Driver.FindElement(By.XPath("//section[@class='loan-summary']//div[4]//div[1]"));

        IWebElement perMonthBreakdownTitle => Driver.FindElement(By.XPath("//section[@class='loan-summary']/div[4]/span"));

        IWebElement checkEligibilityButton => Driver.FindElement(By.XPath("//button[@class='loan-calculator__apply']"));

        IWebElement lastWorkingDayButton => Driver.FindElement(By.XPath(" //button[@data-recurrencetype = 'MONTHLYLBD']"));

        private const string ChooseTheCalendarDate = "//button[@data-testid = 'loan-calculator-date-selector'][@value='{0}']";

        public By SelectDate(string value)
        {
            return By.XPath(string.Format(ChooseTheCalendarDate, value));
        }


        #region Methods

        //We can still refactor the following methods, but avoiding it for now due to time constraints
        public bool IsLoanAmountValueCorrect(string value) => IsValueCorrect(loanAmountValue,value);

        public bool IsLoanBreakDownAmountValueCorrect(string value) => IsValueCorrect(loanBreakdownAmount,value);

        public bool IsInterestAmountValueCorrect(string value) => IsValueCorrect(interestBreakdownAmount, value);

        public bool IsPerMonthAmountValueCorrect(string value) => IsValueCorrect(perMonthBreakdownAmount, value);

        public bool IsTotalAmountValueCorrect(string value) => IsValueCorrect(totalBreakdownAmount, value);

        public bool IsFirstRepaymentDateCorrect(string date) => IsValueCorrect(FirstRepaymentDay, date);

        public bool IsSecondRepaymentDateCorrect(string date) => IsValueCorrect(SecondRepaymentDay, date);
        public bool IsLastWorkingDayButtonDisplayed() => IsButtonDisplayed(lastWorkingDayButton); 
        public bool IsCheckAvailabilityButtonDisplayed() => IsButtonDisplayed(checkEligibilityButton);

        public void DragAndDrop(IWebElement element, int xOffset, int yOffset)
        {
            Actions actions = new Actions(Driver);
            actions.DragAndDropToOffset(element, xOffset, yOffset).Build().Perform();
        }
        public void MoveTheSliderToIncreaseTheLoanAmount(string amount)
        {
            if (amount.Equals("300"))
                DragAndDrop(loanCalculatorSlider, 862, 336);
            else if(amount.Equals("400"))
                DragAndDrop(loanCalculatorSlider, 1065, 336);
            else if (amount.Equals("500"))
                DragAndDrop(loanCalculatorSlider, 1270, 336);
        }

        public void ClickOnTheDate(string value)
        {
            Driver.FindElement(SelectDate(value)).Click();
        }

        #endregion

    }
}
