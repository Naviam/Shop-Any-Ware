@signin
Feature: Sign In
	In order to start using service
	As a shopper
	I want to be able to sign in with my credentials

@shopper
Scenario: Sign in shopper
	Given I have not been authenticated yet
	And The 'vhatalski@naviam.com' account already exists
	And I am in 'Shopper' role
	When I fill sign in form with the following data
	| Email                | Password | Remember Me |
	| vhatalski@naviam.com | ruinruin | false       |
	Then I should be redirected to controller 'Member' and action 'Dashboard'

@shopper
Scenario: Shopper invalid credentials
	Given I have not been authenticated yet
	And The 'vhatalski@naviam.com' account already exists
	And I am in 'Shopper' role
	When I fill sign in form with the following data
	| Email                | Password  | Remember Me |
	| vhatalski@naviam.com | ruinruin3 | false       |
	Then the signin result should be as follows
	| Email                | Password | Remember Me | Message Type | Error Code   |
	| vhatalski@naviam.com |          | false       | Error        | UserNotValid |

@shopper
Scenario: Shopper validate required fields
	Given I have not been authenticated yet
	And The 'vhatalski@naviam.com' account already exists
	And I am in 'Shopper' role
	When I fill sign in form with the following data
	| Email | Password | Remember Me |
	|       |          | false       |
	Then the signin result should be as follows
	| Email | Password | Remember Me | Message Type |
	|       |          | false       | Warning      |
	And the signin view model should have following errors
	| Property | Error Code           |
	| Email    | UserEmailRequired    |
	| Password | UserPasswordRequired |

@operator
Scenario: Sign in operator
	Given I have not been authenticated yet
	And The 'vhatalski@naviam.com' account already exists
	And I am in 'Operator' role
	When I fill sign in form with the following data
	| Email                | Password | Remember Me |
	| vhatalski@naviam.com | ruinruin | false       |
	Then I should be redirected to controller 'Admin' and action 'Dashboard'

@consultant
Scenario: Sign in conslutant
	Given I have not been authenticated yet
	And The 'vhatalski@naviam.com' account already exists
	And I am in 'Consultant' role
	When I fill sign in form with the following data
	| Email                | Password | Remember Me |
	| vhatalski@naviam.com | ruinruin | false       |
	Then I should be redirected to controller 'Admin' and action 'Dashboard'
	
@admin
Scenario: Sign in admin
	Given I have not been authenticated yet
	And The 'vhatalski@naviam.com' account already exists
	And I am in 'Admin' role
	When I fill sign in form with the following data
	| Email                | Password | Remember Me |
	| vhatalski@naviam.com | ruinruin | false       |
	Then I should be redirected to controller 'Admin' and action 'Dashboard'
