@shopper @orders @items
Feature: Shopper Order Items
	In order to consolidate and send packages
	As a shopper
	I want to be able to move items to packages and change the customs declaration

@moveitemtopackage
Scenario: Move item to package
	Given there is 'v.hatalski@gmail.com' account with 'ruinruin' password in role 'Shopper' with fullname 'Vitali' and 'Hatalski'
	And I have the following delivery addresses
    | Id | FirstName | LastName | AddressName            | AddressLine1          | AddressLine2 | City  | Country | State | Region | ZipCode | Phone         |
	| 1  | Vitali    | Hatalski | Minsk - Novovilenskaya | Novovilenskaya street | 10, 41       | Minsk | Belarus |       |        | 220053  | +375295067630 |
	| 2  | Vitali    | Hatalski | Minsk - Nekrasova      | Nekrasova street      | 8, 14        | Minsk | Belarus |       |        | 220040  | +375295067630 |
	| 3  | Patric    | Gutie    | France - Paris         | Elisei                | 14/3, 45     | Paris | France  |       |        | 12040   | +455295067630 |
	And I am authenticated as 'v.hatalski@gmail.com'
	And there are following packages in database
	| Id | Name             | Status | Delivery Address | Delivery Method |
	| 1  | My first package | New    | 1                | Express         |
	And there are following orders in database
    | Id | Retailer   | Order Number | Tracking Number | Status   |
    | 1  | amazon.com | 1234567890   | 1234567890      | New      |
    | 2  | macys.com  | 1234567891   | 1234567891      | Received |
    And there are following items for order '1' in database
    | Id | Name   | Quantity | Price  | Weight |
    | 1  | IPAD3  | 1        | 780.40 | 600    |
    | 2  | Kindle | 5        | 130.95 | 200    |