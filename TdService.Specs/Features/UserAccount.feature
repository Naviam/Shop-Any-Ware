Feature: User Account
	In order to start using ShopAnyWare service
	As an anonymous user
	I want to be able to register as a shopper and activate my personal account

@signup
Scenario: Account already exists
	Given I have not been authenticated yet
	When I enter 'v.hatalski@gmail.com' as email address
	Then I should have the following result
	| MessageType |
	| Error       |
	And I should have the following errors appear on the page
	| Property Name | Error Code    |
	| Email         | AccountExists |
