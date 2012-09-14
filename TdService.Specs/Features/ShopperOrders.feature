@orders
Feature: Shopper Orders
	In order to let operator know about incoming orders
	As a shopper
	I want to be able to add new orders, remove them and update with tracking number and order number

@addorder
Scenario: Add new order
	Given there is 'v.hatalski@gmail.com' account with 'ruinruin' password in role 'Shopper' with fullname 'Vitali' and 'Hatalski'
	And I am authenticated as 'v.hatalski@gmail.com'
	When I set retailer url as 'amazon.com' and press add order button on shopper dashboard page
	Then the order view model should be as follows
	| Id | Retailer Url | Order Number | Tracking Number | Received Date | Status | Can Be Modified | Can Be Removed | Can Be Requested For Return | Can Items Be Modified | Message Type |
	| 1  | amazon.com   |              |                 |               | New    | True            | True           | False                       | True                  | Success      |
	And the order view model should have Created Date that is earlier than UTC Now

@addorder
Scenario: Add new order validate retailer url is required
	Given there is 'v.hatalski@gmail.com' account with 'ruinruin' password in role 'Shopper' with fullname 'Vitali' and 'Hatalski'
	And I am authenticated as 'v.hatalski@gmail.com'
	When I set retailer url as '' and press add order button on shopper dashboard page
	Then the order view model should be as follows
	| Id | Retailer Url | Order Number | Tracking Number | Received Date | Status | Can Be Modified | Can Be Removed | Can Be Requested For Return | Can Items Be Modified | Message Type |
	| 0  |              |              |                 |               | New    | False           | False          | False                       | False                 | Warning      |
	And the order view model should have the following errors
	| Property    | Error Code            |
	| RetailerUrl | OrderRetailerRequired |

@updateorder
Scenario: Update order in new status
	Given there is 'v.hatalski@gmail.com' account with 'ruinruin' password in role 'Shopper' with fullname 'Vitali' and 'Hatalski'
	And I am authenticated as 'v.hatalski@gmail.com'
	And I have the following orders
	| Id | Order Number | Tracking Number | Status |
	| 1  |              | 123456789012345 | New    |
	When I update order as follows
	| Id | Order Number | Tracking Number | Status |
	| 1  | 098765432109 | 1234            | New    |
	Then the order view model should be as follows
	| Id | Order Number | Tracking Number | Status | Message Type |
	| 1  | 098765432109 | 1234            | New    | Success      |

@removeorder
Scenario: Remove order in new status
	Given there is 'v.hatalski@gmail.com' account with 'ruinruin' password in role 'Shopper' with fullname 'Vitali' and 'Hatalski'
	And I am authenticated as 'v.hatalski@gmail.com'
	And I have the following orders
	| Id | Retailer Url | Order Number | Tracking Number | Received Date | Status |
	| 1  | amazon.com   |              |                 |               | New    |
	When I remove order with id '1'
	Then the order view model should be as follows
	| Id | Retailer Url | Order Number | Tracking Number | Received Date | Status | Message Type |
	| 1  |              |              |                 |               |        | Success      |

@removeorder
Scenario: Remove order that does not exist
	Given there is 'v.hatalski@gmail.com' account with 'ruinruin' password in role 'Shopper' with fullname 'Vitali' and 'Hatalski'
	And I am authenticated as 'v.hatalski@gmail.com'
	And I have the following orders
	| Id | Retailer Url | Order Number | Tracking Number | Received Date | Status |
	| 1  | amazon.com   |              |                 |               | New    |
	When I remove order with id '2'
	Then the order view model should be as follows
	| Id | Retailer Url | Order Number | Tracking Number | Received Date | Status | Message Type | Error Code           |
	| 2  |              |              |                 |               |        | Error        | OrderNotBelongToUser |