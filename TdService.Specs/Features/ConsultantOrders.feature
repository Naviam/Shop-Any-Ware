@orders
Feature: Consultant Orders
	In order to solve issues with orders
	As a consultant
	I want to be able to view all orders

@addorder
Scenario: Add new order should not be possible by consultant
	Given there is 'v.hatalski@gmail.com' account with 'ruinruin' password in role 'Consultant' with fullname 'Vitali' and 'Hatalski'
	And I am authenticated as 'v.hatalski@gmail.com'
	When I set retailer url as 'amazon.com' and press add order button on shopper dashboard page
	Then the order view model should be as follows
	| Id | Retailer Url | Order Number | Tracking Number | Received Date | Status | Message Type | Error Code              |
	| 0  |              |              |                 |               |        | Error        | OrderCannotBeAddedByYou |

@removeorder
Scenario: Remove order should not be possible by consultant
	Given there is 'v.hatalski@gmail.com' account with 'ruinruin' password in role 'Consultant' with fullname 'Vitali' and 'Hatalski'
	And I am authenticated as 'v.hatalski@gmail.com'
	And I have the following orders
	| Id | Retailer   | Order Number | Tracking Number | Received Date | Status |
	| 1  | amazon.com |              |                 |               | New    |
	When I remove order with id '1'
	Then the order view model should be as follows
	| Id | Retailer Url | Order Number | Tracking Number | Received Date | Status | Message Type | Error Code           |
	| 1  |              |              |                 |               |        | Error        | OrderCannotBeRemoved |
