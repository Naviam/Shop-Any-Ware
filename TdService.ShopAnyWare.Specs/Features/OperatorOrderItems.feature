@orders @items
Feature: Operator Order Items
	In order to let shopper know about received orders
	As an operator
	I want to be able to add, update and remove items for shopper orders in new status

@addorderitem
Scenario: Add item to an order
	Given there is 'v.hatalski@gmail.com' account with 'ruinruin' password in role 'Operator' with fullname 'Vitali' and 'Hatalski'
	And I am authenticated as 'v.hatalski@gmail.com'
	And there are following orders in database
    | Id | Retailer   | Order Number | Tracking Number | Status   |
    | 1  | amazon.com | 1234567890   | 1234567890      | New      |
    | 2  | macys.com  | 1234567891   | 1234567891      | Received |
	When I add the following items to order '1'
	| Name   | Quantity | Price  | Weight Pounds | Weight Ounces |
	| IPAD3  | 1        | 780.40 | 600           | 20            |
	| Kindle | 5        | 130.95 | 200           | 10            |
	Then the order item view model should be as follows
	| Order Id | Id | Name   | Quantity | Price  | Weight Pounds | Weight Ounces | Message Type |
	| 1        | 1  | IPAD3  | 1        | 780.40 | 600           | 20            | Success      |
	| 1        | 2  | Kindle | 5        | 130.95 | 200           | 10            | Success      |

@removeorderitem
Scenario: Remove item from an order
    Given there is 'v.hatalski@gmail.com' account with 'ruinruin' password in role 'Operator' with fullname 'Vitali' and 'Hatalski'
    And I am authenticated as 'v.hatalski@gmail.com'
    And there are following orders in database
    | Id | Retailer   | Order Number | Tracking Number | Status   |
    | 1  | amazon.com | 1234567890   | 1234567890      | New      |
    | 2  | macys.com  | 1234567891   | 1234567891      | Received |
    And there are following items for order '1' in database
    | Id | Name   | Quantity | Price  | Weight Pounds | Weight Ounces |
    | 1  | IPAD3  | 1        | 780.40 | 600           | 10            |
    | 2  | Kindle | 5        | 130.95 | 200           | 12            |
    When I remove the following order items
    | Order Id | Id |
    | 1        | 1  |
    Then the order item view model should be as follows
    | Order Id | Name  | Quantity | Price  | Weight Pounds | Weight Ounces | Message Type |
    | 1        | IPAD3 | 1        | 780.40 | 600           | 10            | Success      |

@updateorderitem
Scenario: Update order item
    Given there is 'v.hatalski@gmail.com' account with 'ruinruin' password in role 'Operator' with fullname 'Vitali' and 'Hatalski'
    And I am authenticated as 'v.hatalski@gmail.com'
    And there are following orders in database
    | Id | Retailer   | Order Number | Tracking Number | Status   |
    | 1  | amazon.com | 1234567890   | 1234567890      | New      |
    | 2  | macys.com  | 1234567891   | 1234567891      | Received |
    And there are following items for order '1' in database
    | Id | Name   | Quantity | Price  | Weight |
    | 1  | IPAD3  | 1        | 780.40 | 600    |
    | 2  | Kindle | 5        | 130.95 | 200    |
    When I update items of order '1' as follows
    | Id | Name    | Quantity | Price  | Weight |
    | 1  | IPAD2   | 2        | 780.00 | 670    |
    | 2  | Kindle3 | 1        | 100.00 | 320    |
    Then the order item view model should be as follows
    | Order Id | Id | Name    | Quantity | Price  | Weight | Message Type |
    | 1        | 1  | IPAD2   | 2        | 780.00 | 670    | Success      |
    | 1        | 2  | Kindle3 | 1        | 100.00 | 320    | Success      |