@signup
Feature: Shopper Account Creation
	In order to start using ShopAnyWare service
	As an anonymous user
	I want to be able to register as a shopper and activate my personal account

Scenario: Create new account
	Given I have not been authenticated yet
	When I fill sign up form with the following data
	| Email          | Password | Confirm Password | First Name | Last Name |
	| hautama@tut.by | ruinruin | ruinruin         | Vitali     | Hatalski  |
	Then I should have the result as follows
	| Email          | Password | Confirm Password | First Name | Last Name | MessageType |
	| hautama@tut.by | ruinruin | ruinruin         | Vitali     | Hatalski  | Success     |

Scenario: Account already exists
	Given The 'vhatalski@naviam.com' account already exists
	And I have not been authenticated yet
	When I fill sign up form with the following data
	| Email                | Password | Confirm Password | First Name | Last Name |
	| vhatalski@naviam.com | ruinruin | ruinruin         | Vitali     | Hatalski  |
	Then I should have the result as follows
	| Email | Password | Confirm Password | First Name | Last Name | Message Type |
	|       |          |                  |            |           | Error        |
	And I should have the following model errors
	| Property Name | Error Code    |
	| Email         | AccountExists |

Scenario: Password and confirm password do not match
	Given I have not been authenticated yet
	When I fill sign up form with the following data
	| Email          | Password | Confirm Password | First Name | Last Name |
	| hautama@tut.by | ruinruin | ruinruin1        | Vitali     | Hatalski  |
	Then I should have the result as follows
	| Email          | Password | Confirm Password | First Name | Last Name | Message Type |
	|                |          |                  |            |           | Error        |
	And I should have the following model errors
	| Property Name    | Error Code    |
	| Confirm Password | AccountExists |