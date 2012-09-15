@orders
Feature: Shopper Orders
	In order to let operator know about incoming orders
	As a shopper
	I want to be able to add new orders, remove them and update with tracking number and order number

@viewrecentorders
Scenario: View my recent orders
	Given there is 'v.hatalski@gmail.com' account with 'ruinruin' password in role 'Shopper' with fullname 'Vitali' and 'Hatalski'
	And I am authenticated as 'v.hatalski@gmail.com'
	And I have the following orders
	| Id | Retailer   | Order Number | Tracking Number | Status   |
	| 1  | amazon.com |              | 773456789012345 | New      |
	| 2  | 6pm.com    | 123453453455 | 673456789012345 | Received |
	| 3  | zazzle.com | 125675575445 | 344567895675664 | Returned |
	| 4  | yoox.com   | 455367456655 | 34567893442345  | Disposed |
	| 5  | zappos.com | 234345454433 | 123456789012345 | Received |
	| 6  | zappos.com | 453656457544 | 245763453445463 | ReturnRequested |
	When I go to my recent orders tab
	Then the order view models should be as follows
	| Id | Retailer Url | Order Number | Tracking Number | Status          | Can Be Modified | Can Be Removed | Can Be Requested For Return | Can Items Be Modified | Message Type |
	| 1  | amazon.com   |              | 773456789012345 | New             | True            | True           | False                       | True                  | Success      |
	| 2  | 6pm.com      | 123453453455 | 673456789012345 | Received        | False           | False          | True                        | False                 | Success      |
	| 5  | zappos.com   | 234345454433 | 123456789012345 | Received        | False           | False          | True                        | False                 | Success      |
	| 6  | zappos.com   | 453656457544 | 245763453445463 | ReturnRequested | False           | False          | False                       | False                 | Success      |

@viewhistoryorders
Scenario: View my history orders
	Given there is 'v.hatalski@gmail.com' account with 'ruinruin' password in role 'Shopper' with fullname 'Vitali' and 'Hatalski'
	And I am authenticated as 'v.hatalski@gmail.com'
	And I have the following orders
	| Id | Retailer   | Order Number | Tracking Number | Status   |
	| 1  | amazon.com |              | 773456789012345 | New      |
	| 2  | 6pm.com    | 123453453455 | 673456789012345 | Received |
	| 3  | zazzle.com | 125675575445 | 344567895675664 | Returned |
	| 4  | yoox.com   | 455367456655 | 34567893442345  | Disposed |
	| 5  | zappos.com | 234345454433 | 123456789012345 | Received |
	| 6  | zappos.com | 453656457544 | 245763453445463 | ReturnRequested |
	When I go to my history orders tab
	Then the order view models should be as follows
	| Id | Retailer Url | Order Number | Tracking Number | Status          | Can Be Modified | Can Be Removed | Can Be Requested For Return | Can Items Be Modified | Message Type |
	| 3  | zazzle.com   | 125675575445 | 344567895675664 | Returned        | False           | False          | False                       | False                 | Success      |
	| 4  | yoox.com     | 455367456655 | 34567893442345  | Disposed        | False           | False          | False                       | False                 | Success      |

@addorder
Scenario: Add new order should be possible by shopper
	Given there is 'v.hatalski@gmail.com' account with 'ruinruin' password in role 'Shopper' with fullname 'Vitali' and 'Hatalski'
	And I am authenticated as 'v.hatalski@gmail.com'
	When I set retailer url as 'amazon.com' and press add order button on shopper dashboard page
	Then the order view model should be as follows
	| Id | Retailer Url | Order Number | Tracking Number | Received Date | Status | Can Be Modified | Can Be Removed | Can Be Requested For Return | Can Items Be Modified | Message Type |
	| 1  | amazon.com   |              |                 |               | New    | True            | True           | False                       | True                  | Success      |
	And the order view model should have Created Date that is earlier than UTC Now

@addorder
Scenario: Add new order should not be possible by operator
	Given there is 'v.hatalski@gmail.com' account with 'ruinruin' password in role 'Operator' with fullname 'Vitali' and 'Hatalski'
	And I am authenticated as 'v.hatalski@gmail.com'
	When I set retailer url as 'amazon.com' and press add order button on shopper dashboard page
	Then the order view model should be as follows
	| Id | Retailer Url | Order Number | Tracking Number | Received Date | Status | Message Type | Error Code              |
	| 0  |              |              |                 |               |        | Error        | OrderCannotBeAddedByYou |

@addorder
Scenario: Add new order should not be possible by consultant
	Given there is 'v.hatalski@gmail.com' account with 'ruinruin' password in role 'Consultant' with fullname 'Vitali' and 'Hatalski'
	And I am authenticated as 'v.hatalski@gmail.com'
	When I set retailer url as 'amazon.com' and press add order button on shopper dashboard page
	Then the order view model should be as follows
	| Id | Retailer Url | Order Number | Tracking Number | Received Date | Status | Message Type | Error Code              |
	| 0  |              |              |                 |               |        | Error        | OrderCannotBeAddedByYou |

@addorder
Scenario: Add new order should not be possible by admin
	Given there is 'v.hatalski@gmail.com' account with 'ruinruin' password in role 'Admin' with fullname 'Vitali' and 'Hatalski'
	And I am authenticated as 'v.hatalski@gmail.com'
	When I set retailer url as 'amazon.com' and press add order button on shopper dashboard page
	Then the order view model should be as follows
	| Id | Retailer Url | Order Number | Tracking Number | Received Date | Status | Message Type | Error Code              |
	| 0  |              |              |                 |               |        | Error        | OrderCannotBeAddedByYou |

@addorder
Scenario: Add new order reusing existent retailer instead of creating new one
	Given there is 'v.hatalski@gmail.com' account with 'ruinruin' password in role 'Shopper' with fullname 'Vitali' and 'Hatalski'
	And I am authenticated as 'v.hatalski@gmail.com'
	And I have the following orders
	| Id | Retailer   | Order Number | Tracking Number | Status   |
	| 1  | amazon.com |              | 773456789012345 | New      |
	When I set retailer url as 'amazon.com' and press add order button on shopper dashboard page
	Then the order view model should be as follows
	| Id | Retailer Url | Order Number | Tracking Number | Received Date | Status | Can Be Modified | Can Be Removed | Can Be Requested For Return | Can Items Be Modified | Message Type |
	| 2  | amazon.com   |              |                 |               | New    | True            | True           | False                       | True                  | Success      |
	And there must be only one db record with 'amazon.com' retailer url

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

@addorder
Scenario: Add new order validate retailer max length
	Given there is 'v.hatalski@gmail.com' account with 'ruinruin' password in role 'Shopper' with fullname 'Vitali' and 'Hatalski'
	And I am authenticated as 'v.hatalski@gmail.com'
	When I set retailer url as 'this is the very long an unusual retailer url that is not actually a url but a long text that exceeds the maximum allowed length for url addresses this is the very long an unusual retailer url that is not actually a url but a long text that exceeds the maximum allowed length for url addresses' and press add order button on shopper dashboard page
	Then the order view model should be as follows
	| Id | Retailer Url                                                                                                                                                                                                                                                                                          | Order Number | Tracking Number | Received Date | Status | Can Be Modified | Can Be Removed | Can Be Requested For Return | Can Items Be Modified | Message Type |
	| 0  | this is the very long an unusual retailer url that is not actually a url but a long text that exceeds the maximum allowed length for url addresses this is the very long an unusual retailer url that is not actually a url but a long text that exceeds the maximum allowed length for url addresses |              |                 |               | New    | False           | False          | False                       | False                 | Warning      |
	And the order view model should have the following errors
	| Property    | Error Code           |
	| RetailerUrl | RetailerUrlMaxLength |

@updateorder
Scenario: Update order in new status should be possible by shopper
	Given there is 'v.hatalski@gmail.com' account with 'ruinruin' password in role 'Shopper' with fullname 'Vitali' and 'Hatalski'
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

@updateorder
Scenario: Update order in any other status than New should not be possible
	Given there is 'v.hatalski@gmail.com' account with 'ruinruin' password in role 'Shopper' with fullname 'Vitali' and 'Hatalski'
	And I am authenticated as 'v.hatalski@gmail.com'
	And I have the following orders
	| Id | Retailer   | Order Number | Tracking Number | Status          |
	| 1  | amazon.com |              | 123456789012345 | Received        |
	| 2  | amazon.com |              | 123456789012345 | Disposed        |
	| 3  | amazon.com |              | 123456789012345 | Returned        |
	| 4  | amazon.com |              | 123456789012345 | ReturnRequested |
	When I update orders as follows
	| Id | Order Number | Tracking Number | Status          |
	| 1  | 098765432109 | 1234            | Received        |
	| 2  | 098765432109 | 1234            | Disposed        |
	| 3  | 098765432109 | 1234            | Returned        |
	| 4  | 098765432109 | 1234            | ReturnRequested |
	Then the order view models should be as follows
	| Id | Order Number | Tracking Number | Status          | Message Type | Error Code           |
	| 1  | 098765432109 | 1234            | Received        | Error        | OrderCannotBeUpdated |
	| 2  | 098765432109 | 1234            | Disposed        | Error        | OrderCannotBeUpdated |
	| 3  | 098765432109 | 1234            | Returned        | Error        | OrderCannotBeUpdated |
	| 4  | 098765432109 | 1234            | ReturnRequested | Error        | OrderCannotBeUpdated |

@updateorder
Scenario: Update order in new status validate fields max length
	Given there is 'v.hatalski@gmail.com' account with 'ruinruin' password in role 'Shopper' with fullname 'Vitali' and 'Hatalski'
	And I am authenticated as 'v.hatalski@gmail.com'
	And I have the following orders
	| Id | Retailer   | Order Number | Tracking Number | Status |
	| 1  | amazon.com |              | 123456789012345 | New    |
	When I update order as follows
	| Id | Order Number                                     | Tracking Number                                              | Status |
	| 1  | 098765432109098765432109098765432109098765432109 | 123456789012345123456789012345123456789012345123456789012345 | New    |
	Then the order view model should be as follows
	| Id | Order Number                                     | Tracking Number                                              | Status | Message Type |
	| 1  | 098765432109098765432109098765432109098765432109 | 123456789012345123456789012345123456789012345123456789012345 | New    | Warning      |
	And the order view model should have the following errors
	| Property       | Error Code                   |
	| OrderNumber    | OrderOrderNumberMaxLength    |
	| TrackingNumber | OrderTrackingNumberMaxLength |

@removeorder
Scenario: Remove order in new status should be possible by shopper
	Given there is 'v.hatalski@gmail.com' account with 'ruinruin' password in role 'Shopper' with fullname 'Vitali' and 'Hatalski'
	And I am authenticated as 'v.hatalski@gmail.com'
	And I have the following orders
	| Id | Retailer   | Order Number | Tracking Number | Received Date | Status |
	| 1  | amazon.com |              |                 |               | New    |
	When I remove order with id '1'
	Then the order view model should be as follows
	| Id | Retailer Url | Order Number | Tracking Number | Received Date | Status | Message Type |
	| 1  |              |              |                 |               |        | Success      |

@removeorder
Scenario: Remove order in new status should be possible by admin
	Given there is 'v.hatalski@gmail.com' account with 'ruinruin' password in role 'Admin' with fullname 'Vitali' and 'Hatalski'
	And I am authenticated as 'v.hatalski@gmail.com'
	And I have the following orders
	| Id | Retailer   | Order Number | Tracking Number | Received Date | Status |
	| 1  | amazon.com |              |                 |               | New    |
	When I remove order with id '1'
	Then the order view model should be as follows
	| Id | Retailer Url | Order Number | Tracking Number | Received Date | Status | Message Type |
	| 1  |              |              |                 |               |        | Success      |

@removeorder
Scenario: Remove order in other status than new should not be possible
	Given there is 'v.hatalski@gmail.com' account with 'ruinruin' password in role 'Shopper' with fullname 'Vitali' and 'Hatalski'
	And I am authenticated as 'v.hatalski@gmail.com'
	And I have the following orders
	| Id | Retailer   | Order Number | Tracking Number | Received Date | Status          |
	| 1  | amazon.com |              |                 |               | Received        |
	| 2  | 6pm.com    |              |                 |               | Returned        |
	| 3  | apple.com  |              |                 |               | ReturnRequested |
	| 4  | zappos.com |              |                 |               | Disposed        |
	When I remove the following orders
	| Id |
	| 1  |
	| 2  |
	| 3  |
	| 4  |
	Then the order view models should be as follows
	| Id | Retailer Url | Order Number | Tracking Number | Received Date | Status | Message Type | Error Code           |
	| 1  |              |              |                 |               |        | Error        | OrderCannotBeRemoved |
	| 2  |              |              |                 |               |        | Error        | OrderCannotBeRemoved |
	| 3  |              |              |                 |               |        | Error        | OrderCannotBeRemoved |
	| 4  |              |              |                 |               |        | Error        | OrderCannotBeRemoved |

@removeorder
Scenario: Remove order that does not exist
	Given there is 'v.hatalski@gmail.com' account with 'ruinruin' password in role 'Shopper' with fullname 'Vitali' and 'Hatalski'
	And I am authenticated as 'v.hatalski@gmail.com'
	And I have the following orders
	| Id | Retailer   | Order Number | Tracking Number | Received Date | Status |
	| 1  | amazon.com |              |                 |               | New    |
	When I remove order with id '2'
	Then the order view model should be as follows
	| Id | Retailer Url | Order Number | Tracking Number | Received Date | Status | Message Type | Error Code           |
	| 2  |              |              |                 |               |        | Error        | OrderNotFoundForUser |

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

@requestorderreturn
Scenario: Request for order return
	Given there is 'v.hatalski@gmail.com' account with 'ruinruin' password in role 'Shopper' with fullname 'Vitali' and 'Hatalski'
	And I am authenticated as 'v.hatalski@gmail.com'
	And I have the following orders
	| Id | Retailer   | Order Number | Tracking Number | Received Date | Status   |
	| 1  | amazon.com |              |                 |               | Received |
	When I request for following orders return
	| Id |
	| 1  |
	Then the order view models should be as follows
	| Id | Retailer Url | Order Number | Tracking Number | Received Date | Status | Message Type |
	| 1  |              |              |                 |               |        | Success      |