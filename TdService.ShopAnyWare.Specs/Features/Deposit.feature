@paypal
Feature: Deposit
	In order to buy services from SAW
	As a shopper
	I want to be able to make a deposit via PayPal web interface

@PPExpressCheckout 
Scenario: Make a deposit via PP web UI
	Given there is 'pptest@gmail.com' account with 'ruinruin' password in role 'Shopper' with fullname 'Vitali' and 'Hatalski'
	Given I am authenticated as 'pptest@gmail.com'
	And I enter the following amount '3141' int the deposit textbox and press Add funds button
	Then the PP URL in the AddTransaction responce should start with '_express-checkout&token='	
	And there should be a transaction for me as follows
	| Operation Amount | Transaction Status |
	| 3141             | InProgress         |
