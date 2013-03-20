@packages
Feature: Package Items
	In order to consolidate package and calculate total package cost
	As a shopper
	I want to be able to put and remove items from package

Scenario: Move order items in bulk to existing package
	Given there is 'v.hatalski@gmail.com' account with 'ruinruin' password in role 'Shopper' with fullname 'Vitali' and 'Hatalski'
	And I am authenticated as 'v.hatalski@gmail.com'
	And I have the following orders
	| Retailer   | Order Number | Tracking Number | Status   |
	| amazon.com | 1234567890   | 773456789012345 | Received |
	And there are following items for order '1234567890' in database
    | Name  | Quantity | Price  |
    | IPAD3 | 1        | 780.40 |
    | Kindle | 5        | 130.95 | 
	And I have the following packages
	| Name | Delivery Address Id | Status |
	| my first package  | 1      | New    |
	When I move all items in order '1234567890' to package 'my first package'
	Then there should be following items for this package 
	| Name   | Quantity | Price  | 
    | IPAD3  | 1        | 780.40 | 
    | Kindle | 5        | 130.95 | 


Scenario: Move order items in bulk to non-existent package
	Given there is 'v.hatalski@gmail.com' account with 'ruinruin' password in role 'Shopper' with fullname 'Vitali' and 'Hatalski'
	And I am authenticated as 'v.hatalski@gmail.com'
	And I have the following orders
	| Retailer   | Order Number | Tracking Number | Status   |
	| amazon.com | 1234567890   | 773456789012345 | Received |
	And there are following items for order '1234567890' in database
    | Name   | Quantity | Price  | 
    | IPAD3  | 1        | 780.40 | 
    | Kindle | 5        | 130.95 | 
	When I move all items in order '1234567890' to new package 'new package 1'
	Then There should  be a package with following data
	| Name          | Status |
	| new package 1 | New    |
	And there should be following items for this package
	| Name   | Quantity | Price  | 
    | IPAD3  | 1        | 780.40 | 
    | Kindle | 5        | 130.95 | 

Scenario: Move package items in bulk back to their original order
	Given there is 'v.hatalski@gmail.com' account with 'ruinruin' password in role 'Shopper' with fullname 'Vitali' and 'Hatalski'
	And I am authenticated as 'v.hatalski@gmail.com'
	And I have the following orders
	| Retailer   | Order Number | Tracking Number | Status     |
	| amazon.com | 1234567890   | 773456789012345 | Received   |
	And I have the following packages
	| Name | Delivery Address Id | Status |
	| my first package  | 1      | New    |
	And there are following items for package 'my first package' in database
    | Name   | Quantity | Price  | 
    | IPAD3  | 1        | 780.40 | 
    | Kindle | 5        | 130.95 | 
	When I move all items from package 'my first package' back to their original order
	Then there should be following items for order '1234567890'
	| Name   | Quantity | Price  |
	| IPAD3  | 1        | 780.40 |
	| Kindle | 5        | 130.95 |

