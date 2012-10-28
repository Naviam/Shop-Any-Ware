Feature: USPS Shipping Service Integration
	In order to know where is my package now
	As a shopper
	I want to be able to track the package

@tracking
Scenario: Get package delivery info by tracking number
	Given I have the USPS account with the user id '852TRADE0543' and password '743ZJ30GH765'
	When I request the USPS tracking service with the '23445345345' tracking number
	Then I should get the following USPS tracking response
	| | | |
