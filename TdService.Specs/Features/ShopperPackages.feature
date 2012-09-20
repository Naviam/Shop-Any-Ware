@packages
Feature: Shopper Packages
	In order to send packages to my delivery address
	As a shopper
	I want to be able to consolidate my items in packages and specify delivery address

@addpackage
Scenario: Add new package
	Given there is 'v.hatalski@gmail.com' account with 'ruinruin' password in role 'Shopper' with fullname 'Vitali' and 'Hatalski'
	And I am authenticated as 'v.hatalski@gmail.com'
	When I set package name as 'my first package'
	Then I should have the following packages as a result
	| Id | Name             | Status |
	| 1  | my first package | New    |

