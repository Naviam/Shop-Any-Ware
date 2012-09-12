@signin
Feature: Sign In
	In order to start using service
	As a shopper
	I want to be able to sign in with my credentials

@shopper
Scenario: Shopper sign in
	Given I have not been authenticated yet
	And The 'vhatalski@naviam.com' account already exists
	When I fill sign in form with the following data
	| Email                | Password | Remember Me |
	| vhatalski@naviam.com | ruinruin | false       |
	Then I should be redirected to shopper dashbord page

@shopper
Scenario: Shopper invalid credentials
	Given I have not been authenticated yet
	And The 'vhatalski@naviam.com' account already exists
	When I fill sign in form with the following data
	| Email                | Password  | Remember Me |
	| vhatalski@naviam.com | ruinruin3 | false       |
	Then the signin result should be as follows
	| Email                | Password  | Remember Me |
	| vhatalski@naviam.com |           | false       |
	And the signin view model should have following errors
	| Property | Error Code      |
	| Email    | UserNotValid    |

@operator
Scenario: Operator sign in
	Given I have not been authenticated yet
	And The 'vhatalski@naviam.com' account already exists
	When I fill sign in form with the following data
	| Email                | Password | Remember Me |
	| vhatalski@naviam.com | ruinruin | false       |
	Then I should be redirected to operator dashbord page
