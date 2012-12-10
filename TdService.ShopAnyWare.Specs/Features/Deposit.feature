@paypal
Feature: Deposit
	In order to buy services from SAW
	As a shopper
	I want to be able to make a deposit via my credit card

@DoDirectPayment @sandbox
Scenario: Make a deposit witch a CC via PayPal sandbox
	Given there is 'kotg@bk.ru' account with '123456' password in role 'Shoper' with fullname 'kotg' and 'kotg'
	And I am authenticated as 'kotg@bk.ru'
	And my current wallet  amount is 0
	And I enter the following CC info on the deposit page
	| First Name | Last Name | Credit Card Number | CVV2 | Exp Year | Exp Month | Amount |
	| Test       | Test      | 4534674555592087   | 111  | 2017     | 11        | 1      |
	Then the DoDirectPayment responce should be as follows
	| Result  |
	| Success |
	And my current wallet  amount should be 0
	And there should be a transaction for me as follows
	| Operation Amount | Transaction Status |
	| 1                | Success            |

@DoDirectPayment @sandbox
Scenario: Make a deposit witch a CC via PayPal sandbox with incorrect payment data
	Given there is 'kotg@bk.ru' account with '123456' password in role 'Shoper' with fullname 'kotg' and 'kotg'
	And I am authenticated as 'kotg@bk.ru'
	And my current wallet  amount is 0
	And I enter the following CC info on the deposit page
	| First Name | Last Name | Credit Card Number | CVV2 | Exp Year | Exp Month | Amount |
	| Test       | Test      | 4534674555591111   | 111  | 2011     | 12        | 1      |
	Then the DoDirectPayment responce should be as follows
	| Result |
	| Error  |
	And my current wallet  amount should be 0
	And there should be a transaction for me as follows
	| Operation Amount | Transaction Status |
	| 1                | Error              |