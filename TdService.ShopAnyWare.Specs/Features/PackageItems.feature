@packages
Feature: Package Items
	In order to consolidate package and calculate total package cost
	As a shopper
	I want to be able to put and remove items from package

Scenario: Add item to the package
	Given there is 'v.hatalski@gmail.com' account with 'ruinruin' password in role 'Shopper' with fullname 'Vitali' and 'Hatalski'
	And I am authenticated as 'v.hatalski@gmail.com'
	When I add item to package with the following data
	| Name        | Quantity | Color | Size | Weight | Price |
	| IPAD3       | 1        | Black |      |        | 800   |
	| Kindle Fire | 2        | White |      |        | 350   |
	Then I should have the following package items
	| Id | Name        | Quantity | Color | Size | Weight | Price |
	| 1  | IPAD3       | 1        | Black |      |        | 800   |
	| 2  | Kindle Fire | 2        | White |      |        | 350   |