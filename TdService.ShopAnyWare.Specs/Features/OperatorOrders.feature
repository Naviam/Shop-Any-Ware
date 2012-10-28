@orders
Feature: Operator Orders
	In order to let shopper know about received orders
	As an operator
	I want to be able to update new orders with order number and tracking number

@vieworders
Scenario: View all orders in status New in a separate tab
	Given there is 'v.hatalski@gmail.com' account with 'ruinruin' password in role 'Operator' with fullname 'Vitali' and 'Hatalski'
	And I am authenticated as 'v.hatalski@gmail.com'
	And there are following orders in database
	| Id | Retailer   | Order Number | Tracking Number | Status          |
	| 1  | amazon.com |              | 773456789012345 | New             |
	| 2  | 6pm.com    | 123453453455 | 673456789012345 | Received        |
	| 3  | zazzle.com | 125675575445 | 344567895675664 | Returned        |
	| 4  | yoox.com   | 455367456655 | 34567893442345  | Disposed        |
	| 5  | zappos.com | 234345454433 | 123456789012345 | Received        |
	| 6  | zappos.com | 453656457544 | 245763453445463 | ReturnRequested |
	When I go to new orders tab on operator dashboard page
	Then the order view models should be as follows
	| Id | Retailer Url | Order Number | Tracking Number | Status | Message Type |
	| 1  | amazon.com   |              | 773456789012345 | New    | Success      |

@vieworders
Scenario: View all orders in status Received in a separate tab
	Given there is 'v.hatalski@gmail.com' account with 'ruinruin' password in role 'Operator' with fullname 'Vitali' and 'Hatalski'
	And I am authenticated as 'v.hatalski@gmail.com'
	And there are following orders in database
	| Id | Retailer   | Order Number | Tracking Number | Status          |
	| 1  | amazon.com |              | 773456789012345 | New             |
	| 2  | 6pm.com    | 123453453455 | 673456789012345 | Received        |
	| 3  | zazzle.com | 125675575445 | 344567895675664 | Returned        |
	| 4  | yoox.com   | 455367456655 | 34567893442345  | Disposed        |
	| 5  | zappos.com | 234345454433 | 123456789012345 | Received        |
	| 6  | zappos.com | 453656457544 | 245763453445463 | ReturnRequested |
	When I go to received orders tab on operator dashboard page
	Then the order view models should be as follows
	| Id | Retailer Url | Order Number | Tracking Number | Status   | Message Type |
	| 2  | 6pm.com      | 123453453455 | 673456789012345 | Received | Success      |
	| 5  | zappos.com   | 234345454433 | 123456789012345 | Received | Success      |

@vieworders
Scenario: View all orders in status ReturnRequested in a separate tab
	Given there is 'v.hatalski@gmail.com' account with 'ruinruin' password in role 'Operator' with fullname 'Vitali' and 'Hatalski'
	And I am authenticated as 'v.hatalski@gmail.com'
	And there are following orders in database
	| Id | Retailer   | Order Number | Tracking Number | Status          |
	| 1  | amazon.com |              | 773456789012345 | New             |
	| 2  | 6pm.com    | 123453453455 | 673456789012345 | Received        |
	| 3  | zazzle.com | 125675575445 | 344567895675664 | Returned        |
	| 4  | yoox.com   | 455367456655 | 34567893442345  | Disposed        |
	| 5  | zappos.com | 234345454433 | 123456789012345 | Received        |
	| 6  | zappos.com | 453656457544 | 245763453445463 | ReturnRequested |
	When I go to return requested orders tab on operator dashboard page
	Then the order view models should be as follows
	| Id | Retailer Url | Order Number | Tracking Number | Status          | Message Type |
	| 6  | zappos.com   | 453656457544 | 245763453445463 | ReturnRequested | Success      |

@addorder
Scenario: Add new order should not be possible by operator
	Given there is 'v.hatalski@gmail.com' account with 'ruinruin' password in role 'Operator' with fullname 'Vitali' and 'Hatalski'
	And I am authenticated as 'v.hatalski@gmail.com'
	When I set retailer url as 'amazon.com' and press add order button on shopper dashboard page
	Then the order view model should be as follows
	| Id | Retailer Url | Order Number | Tracking Number | Received Date | Status | Message Type | Error Code              |
	| 0  |              |              |                 |               |        | Error        | OrderCannotBeAddedByYou |

@updateorder
Scenario: Update order in new status should be possible by operator
	Given there is 'v.hatalski@gmail.com' account with 'ruinruin' password in role 'Operator' with fullname 'Vitali' and 'Hatalski'
	And I am authenticated as 'v.hatalski@gmail.com'
	And I have the following orders
	| Id | Retailer   | Order Number | Tracking Number | Status |
	| 1  | amazon.com |              | 123456789012345 | New    |
	When I update order as follows
	| Id | Order Number | Tracking Number | Status |
	| 1  | 098765432109 | 1234            | New    |
	Then the order view model should be as follows
	| Id | Order Number | Tracking Number | Status | Message Type |
	| 1  | 098765432109 | 1234            | New    | Success      |

@removeorder
Scenario: Remove order should not be possible by operator
	Given there is 'v.hatalski@gmail.com' account with 'ruinruin' password in role 'Operator' with fullname 'Vitali' and 'Hatalski'
	And I am authenticated as 'v.hatalski@gmail.com'
	And I have the following orders
	| Id | Retailer   | Order Number | Tracking Number | Received Date | Status |
	| 1  | amazon.com |              |                 |               | New    |
	When I remove order with id '1'
	Then the order view model should be as follows
	| Id | Retailer Url | Order Number | Tracking Number | Received Date | Status | Message Type | Error Code           |
	| 1  |              |              |                 |               |        | Error        | OrderCannotBeRemoved |
