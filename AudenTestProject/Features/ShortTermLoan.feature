Feature: ShortTermLoan
   As a User
   I want to view payment instalments for a monthly loan
   so that I can apply for a short term loan
	

@regression
@smoke
Scenario: Validate default values setup on short term loan page  
	Given I navigate to the Auden home page
	When I view the loan amount slider window
	Then I expect the loan amount on the slider is set to '£200' by default
	And the repayment day is set to 'Last working day'
	When I view the instalment amount breakdown for default loan amount
	Then I expect the loan amount is set to '£200.00'
    And the interest amount is updated to '£26.44'
	And the Total amount is updated to '£226.44'
	And the amount per month is updated to '£75.49'
	And 'Check Eligibility' icon is enabled on the page


Scenario Outline: Validate monthly loan with a few instalments
	Given I navigate to the Auden home page
	When I move the slider to select "<Loan Amount>"
	And I select the '<Repayment Date>' from the calendar
	Then I expect the First repayment is set to '<Updated Repayment Date>' in the repayment date section
	And the second repayment section set to '<Updated Second Repayment Date>'
	And I expect the loan amount is set to '<Updated Loan Amount>'
	And the interest amount is updated to '<Interest Amount>'
	And the Total amount is updated to '<Total Amount>'
	And the amount per month is updated to '<Per Month>'
    And 'Check Eligibility' icon is enabled on the page
	Examples:
	| Loan Amount | Repayment Date | Updated Repayment Date | Updated Second Repayment Date | Updated Loan Amount | Interest Amount | Total Amount | Per Month |
	| 300         | 3              | Thursday 1 Apr 2021    | Friday 30 Apr 2021            | £300.00             | £39.66          | £339.66      | £113.23   |
	| 400         | 11             | Friday 9 Apr 2021      | Tuesday 11 May 2021           | £400.00             | £52.88          | £452.88      | £150.97   |
	| 500         | 10             | Friday 9 Apr 2021      | Monday 10 May 2021            | £500.00              | £66.10          | £566.10      | £188.71   |