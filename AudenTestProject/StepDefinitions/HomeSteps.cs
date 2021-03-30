using AudenTestProject.PageObjects;
using AudenTestProject.Support;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace AudenTestProject.StepDefinitions
{
    [Binding]
    public class HomeSteps
    {
        private DriverHelper _driverHelper;
        HomePage homePage;

        public HomeSteps(DriverHelper driverHelper)
        {
            _driverHelper = driverHelper;
            homePage = new HomePage(_driverHelper.Driver);
        }

        [Given(@"I navigate to the Auden home page")]
        public void GivenINavigateToTheAudenHomePage()
        {
            _driverHelper.Driver.Navigate().GoToUrl("https://www.auden.co.uk/Credit/ShortTermLoan");
        }

        [When(@"I view the loan amount slider window")]
        public void WhenIViewTheLoanAmountSliderWindow()
        {
            //No coding required in this step
        }

        [Then(@"I expect the loan amount on the slider is set to '(.*)' by default")]
        public void ThenIExpectTheLoanAmountOnTheSliderIsSetToByDefault(string loanAmount)
        {
            Assert.AreEqual(homePage.IsLoanAmountValueCorrect(loanAmount), "Loan amount doesn't match with the expected default value on the site");
        }

        [Then(@"the repayment day is set to '(.*)'")]
        public void ThenTheRepaymentDayIsSetTo(string label)
        {
            Assert.AreEqual(homePage.IsLastWorkingDayButtonDisplayed(), string.Format("{0} button is not displayed", label));
        }

        [When(@"I view the instalment amount breakdown for default loan amount")]
        public void WhenIViewTheInstalmentAmountBreakdownForDefaultLoanAmount()
        {
            //No coding required in this step
        }

        [Then(@"I expect the loan amount is set to '(.*)'")]
        public void ThenIExpectTheLoanAmountIsSetTo(string loanAmount)
        {
            Assert.AreEqual(homePage.IsLoanBreakDownAmountValueCorrect(loanAmount), string.Format("Loan amount {0} doesn't match with the expected value in the breakdown section on the site", loanAmount));
        }

        [Then(@"the interest amount is updated to '(.*)'")]
        public void ThenTheInterestAmountIsUpdatedTo(string interestAmount)
        {
            Assert.AreEqual(homePage.IsInterestAmountValueCorrect(interestAmount), string.Format("Interest amount {0} doesn't match with the expected value in the breakdown section on the site", interestAmount));
        }

        [Then(@"the Total amount is updated to '(.*)'")]
        public void ThenTheTotalAmountIsUpdatedTo(string totalAmount)
        {
            Assert.AreEqual(homePage.IsTotalAmountValueCorrect(totalAmount), string.Format("Interest amount {0} doesn't match with the expected value in the breakdown section on the site", totalAmount));
        }

        [Then(@"the amount per month is updated to '(.*)'")]
        public void ThenTheAmountPerMonthIsUpdatedTo(string perMonthAmount)
        {
            Assert.AreEqual(homePage.IsPerMonthAmountValueCorrect(perMonthAmount), string.Format("Interest amount {0} doesn't match with the expected value in the breakdown section on the site", perMonthAmount));
        }

        [Then(@"'(.*)' icon is enabled on the page")]
        public void ThenIconIsEnabledOnThePage(string availabilityCheck)
        {
            Assert.AreEqual(homePage.IsCheckAvailabilityButtonDisplayed(), string.Format("{0} button is not displayed", availabilityCheck));

        }

        [When(@"I move the slider to select ""(.*)""")]
        public void WhenIMoveTheSliderToSelect(string amount)
        {
            homePage.MoveTheSliderToIncreaseTheLoanAmount(amount);
        }

        [When(@"I select the '(.*)' from the calendar")]
        public void WhenISelectTheFromTheCalendar(string date)
        {
            homePage.ClickOnTheDate(date);
        }

        [Then(@"I expect the First repayment is set to '(.*)' in the repayment date section")]
        public void ThenIExpectTheFirstRepaymentIsSetToInTheRepaymentDateSection(string repaymentDate)
        {
            Assert.AreEqual(homePage.IsFirstRepaymentDateCorrect(repaymentDate), string.Format("{0} repayment date doesn't match with the expected date", repaymentDate));
        }

        [Then(@"the second repayment section set to '(.*)'")]
        public void ThenTheSecondRepaymentSectionSetTo(string paymentDate)
        {
            Assert.AreEqual(homePage.IsSecondRepaymentDateCorrect(paymentDate), string.Format("{0} repayment date doesn't match with the expected date", paymentDate));

        }


    }

}
