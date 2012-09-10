@deliveryaddresses
Feature: Delivery Addresses
	In order to choose delivery address for my packages
	As a shopper
	I want to be able to view, add, edit and remove my delivery addresses

@viewdeliveryaddresses
Scenario: View own delivery addresses
	Given I have 'v.hatalski@gmail.com' email address
	And I have the following delivery addresses
	| Id | FirstName | LastName | AddressName            | AddressLine1          | AddressLine2 | City  | Country | State | Region | ZipCode | Phone         |
	| 1  | Vitali    | Hatalski | Minsk - Novovilenskaya | Novovilenskaya street | 10, 41       | Minsk | Belarus |       |        | 220053  | +375295067630 |
	| 2  | Vitali    | Hatalski | Minsk - Nekrasova      | Nekrasova street      | 8, 14        | Minsk | Belarus |       |        | 220040  | +375295067630 |
	| 3  | Patric    | Gutie    | France - Paris         | Elisei                | 14/3, 45     | Paris | France  |       |        | 12040   | +455295067630 |
	When I get my own delivery addresses
	Then I should have the following delivery addresses as a result
	| Id | FirstName | LastName | AddressName            | AddressLine1          | AddressLine2 | City  | Country | State | Region | ZipCode | Phone         |
	| 1  | Vitali    | Hatalski | Minsk - Novovilenskaya | Novovilenskaya street | 10, 41       | Minsk | Belarus |       |        | 220053  | +375295067630 |
	| 2  | Vitali    | Hatalski | Minsk - Nekrasova      | Nekrasova street      | 8, 14        | Minsk | Belarus |       |        | 220040  | +375295067630 |
	| 3  | Patric    | Gutie    | France - Paris         | Elisei                | 14/3, 45     | Paris | France  |       |        | 12040   | +455295067630 |

@adddeliveryaddress
Scenario: Add delivery address
	Given I have 'v.hatalski@gmail.com' email address
	And I have the following delivery addresses
	| Id | FirstName | LastName | AddressName | AddressLine1      | AddressLine2 | City  | Country | State | Region | ZipCode | Phone         | MessageType |
	| 1  | Vitali    | Hatalski | Initial     | Nekrasova 8       | flat 14      | Minsk | Belarus |       |        | 220040  |               |             |
	When I add the following delivery addresses
	| Id | FirstName | LastName | AddressName | AddressLine1      | AddressLine2 | City  | Country | State | Region | ZipCode | Phone         | MessageType |
	|    | Vitali    | Hatalski | My first    | Nekrasova 8       | flat 14      | Minsk | Belarus |       |        | 220040  |               |             |
	|    | Vitali    | Hatalski | My second   | Novovilenskaya 10 | flat 41      | Minsk | Belarus |       |        | 220053  | +375295067630 |             |
	|    |           |          | My second   | Novovilenskaya 10 | flat 41      | Minsk | Belarus |       |        | 220053  | +375295067630 |             |
	Then I should have the following delivery addresses as a result
	| Id | FirstName | LastName | AddressName | AddressLine1      | AddressLine2 | City  | Country | State | Region | ZipCode | Phone         | MessageType |
	| 2  | Vitali    | Hatalski | My first    | Nekrasova 8       | flat 14      | Minsk | Belarus |       |        | 220040  |               | Success     |
	| 3  | Vitali    | Hatalski | My second   | Novovilenskaya 10 | flat 41      | Minsk | Belarus |       |        | 220053  | +375295067630 | Success     |
	| 0  |           |          |             |                   |              |       |         |       |        |         |               | Error       |

@editdeliveryaddress
Scenario: Edit delivery address
	Given I have 'v.hatalski@gmail.com' email address
	And I have the following delivery addresses
	| Id | FirstName | LastName | AddressName  | AddressLine1      | AddressLine2 | City  | Country | State | Region | ZipCode | Phone         | MessageType |
	| 1  | Vitali    | Hatalski | My first     | Nekrasova 8       | flat 14      | Minsk | Belarus |       |        | 220040  |               |             |
	| 2  | Vitali    | Hatalski | My second    | Novovilenskaya 10 | flat 41      | Minsk | Belarus |       |        | 220053  | +375295067630 |             |
	When I edit the following delivery addresses
	| Id | FirstName | LastName | AddressName  | AddressLine1      | AddressLine2 | City  | Country | State | Region | ZipCode | Phone         | MessageType |
	| 1  |           | Hatalski | My first     | Nekrasova 8       | flat 14      | Minsk | Belarus |       |        | 220040  |               |             |
	| 2  | Alex      | Hatalski | Main address | Nekrasova 8       | flat 14      | Minsk | Belarus |       |        | 220040  |               |             |
	Then I should have the following delivery addresses as a result
	| Id | FirstName | LastName | AddressName  | AddressLine1      | AddressLine2 | City  | Country | State | Region | ZipCode | Phone         | MessageType |
	| 1  |           |          |              |                   |              |       |         |       |        |         |               | Error       |
	| 2  | Alex      | Hatalski | Main address | Nekrasova 8       | flat 14      | Minsk | Belarus |       |        | 220040  |               | Success     |

@removedeliveryaddress
Scenario: Remove delivery address
	Given I have 'v.hatalski@gmail.com' email address
	And I have the following delivery addresses
	| Id | FirstName | LastName | AddressName | AddressLine1      | AddressLine2 | City  | Country | State | Region | ZipCode | Phone         | MessageType |
	| 1  | Vitali    | Hatalski | My first    | Nekrasova 8       | flat 14      | Minsk | Belarus |       |        | 220040  |               |             |
	| 2  | Vitali    | Hatalski | My second   | Novovilenskaya 10 | flat 41      | Minsk | Belarus |       |        | 220053  | +375295067630 |             |
	When I remove the following delivery addresses
	| Id |
	| 1  |
	Then I should have the following delivery addresses as a result
	| Id | FirstName | LastName | AddressName | AddressLine1      | AddressLine2 | City  | Country | State | Region | ZipCode | Phone         | MessageType |
	| 1  |           |          |             |                   |              |       |         |       |        |         |               | Success     |