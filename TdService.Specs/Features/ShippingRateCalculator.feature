Feature: Shipping Rate Calculator
	In order to know the cost of delivery
	As a shopper
	I want to be able to calculate rate base on delivery method and package weight

@mytag
Scenario: Add two numbers
	Given I have entered 50 into the calculator
	And I have entered 70 into the calculator
	When I press add
	Then the result should be 120 on the screen
