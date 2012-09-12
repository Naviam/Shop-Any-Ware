@signin
Feature: Sign In
	In order to start using service
	As a shopper
	I want to be able to sign in with my credentials

@shopper
Scenario: Shoppers sign in
	Given I have not been authenticated yet
	And The 'vhatalski@naviam.com' account already exists
	When I fill sign in form with the following data
	| Email                | Password | Remember Me |
	| vhatalski@naviam.com | ruinruin | false       |
	Then I should be redirected to shopper dashbord page
