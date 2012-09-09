Feature: Delivery Addresses
	In order to choose delivery address for my packages
	As a shopper
	I want to be able to add, edit and remove my delivery addresses

@address

Scenario: Get delivery addresses
	Given I am a shopper with 'v.hatalski@gmail.com' email address
	And I have the following delivery addresses
	| Id | FirstName | LastName | AddressName | AddressLine1      | AddressLine2 | AddressLine3 | City  | Country | State | Region | ZipCode | Phone         | MessageType |
	When I open the delivery addresses web page
	Then I should see my delivery addresses on it
	| Id | FirstName | LastName | AddressName | AddressLine1      | AddressLine2 | AddressLine3 | City  | Country | State | Region | ZipCode | Phone         | MessageType |

Scenario: Add delivery address
	Given I am a shopper with 'v.hatalski@gmail.com' email address
	And I have the following delivery addresses
	| Id | FirstName | LastName | AddressName | AddressLine1      | AddressLine2 | AddressLine3 | City  | Country | State | Region | ZipCode | Phone         | MessageType |
	When I add the following delivery addresses
	| Id | FirstName | LastName | AddressName | AddressLine1      | AddressLine2 | AddressLine3 | City  | Country | State | Region | ZipCode | Phone         | MessageType |
	|    | Vitali    | Hatalski | My first    | Nekrasova 8       | flat 14      |              | Minsk | Belarus |       |        | 220040  |               |             |
	|    | Vitali    | Hatalski | My second   | Novovilenskaya 10 | flat 41      |              | Minsk | Belarus |       |        | 220053  | +375295067630 |             |
	|    |           |          | My second   | Novovilenskaya 10 | flat 41      |              | Minsk | Belarus |       |        | 220053  | +375295067630 |             |
	Then I should have the following delivery addresses as a result
	| Id | FirstName | LastName | AddressName | AddressLine1      | AddressLine2 | AddressLine3 | City  | Country | State | Region | ZipCode | Phone         | MessageType |
	|    | Vitali    | Hatalski | My first    | Nekrasova 8       | flat 14      |              | Minsk | Belarus |       |        | 220040  |               | Success     |
	|    | Vitali    | Hatalski | My second   | Novovilenskaya 10 | flat 41      |              | Minsk | Belarus |       |        | 220053  | +375295067630 | Success     |
	| 0  |           |          | My second   | Novovilenskaya 10 | flat 41      |              | Minsk | Belarus |       |        | 220053  | +375295067630 | Error       |

Scenario: Update delivery address
	Given I am a shopper with 'v.hatalski@gmail.com' email address
	And I have the following delivery addresses
	| Id | FirstName | LastName | AddressName | AddressLine1      | AddressLine2 | AddressLine3 | City  | Country | State | Region | ZipCode | Phone         | MessageType |
	| 2  | Vitali    | Hatalski | My first    | Nekrasova 8       | flat 14      |              | Minsk | Belarus |       |        | 220040  |               |             |
	| 3  | Vitali    | Hatalski | My second   | Novovilenskaya 10 | flat 41      |              | Minsk | Belarus |       |        | 220053  | +375295067630 |             |
	When I edit the following delivery addresses
	| Id | FirstName | LastName | AddressName  | AddressLine1      | AddressLine2 | AddressLine3 | City  | Country | State | Region | ZipCode | Phone         | MessageType |
	| 2  | Alex      | Hatalski | Main address | Nekrasova 8       | flat 14      |              | Minsk | Belarus |       |        | 220040  |               |             |
	Then I should have the following delivery addresses as a result
	| Id | FirstName | LastName | AddressName  | AddressLine1      | AddressLine2 | AddressLine3 | City  | Country | State | Region | ZipCode | Phone         | MessageType |
	| 2  | Alex      | Hatalski | Main address | Nekrasova 8       | flat 14      |              | Minsk | Belarus |       |        | 220040  |               |             |
	| 3  | Vitali    | Hatalski | My second    | Novovilenskaya 10 | flat 41      |              | Minsk | Belarus |       |        | 220053  | +375295067630 |             |

Scenario: Remove delivery address
	Given I am a shopper with 'v.hatalski@gmail.com' email address
	And I have the following delivery addresses
	| Id | FirstName | LastName | AddressName | AddressLine1      | AddressLine2 | AddressLine3 | City  | Country | State | Region | ZipCode | Phone         | MessageType |
	| 2  | Vitali    | Hatalski | My first    | Nekrasova 8       | flat 14      |              | Minsk | Belarus |       |        | 220040  |               |             |
	| 3  | Vitali    | Hatalski | My second   | Novovilenskaya 10 | flat 41      |              | Minsk | Belarus |       |        | 220053  | +375295067630 |             |
	When I click to remove the following delivery addresses ids
	| Id |
	| 2  |
	| 5  |
	Then I should have the following delivery addresses as a result
	| Id | FirstName | LastName | AddressName | AddressLine1      | AddressLine2 | AddressLine3 | City  | Country | State | Region | ZipCode | Phone         | MessageType |
	| 2  | Vitali    | Hatalski | My first    | Nekrasova 8       | flat 14      |              | Minsk | Belarus |       |        | 220040  |               |             |
	| 5  |           |          |             |                   |              |              |       |         |       |        |         |               | Error       |