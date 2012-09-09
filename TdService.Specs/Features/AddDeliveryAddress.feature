Feature: AddDeliveryAddress
	In order to choose delivery address for my packages
	As a shopper
	I want to be able to add my delivery address

@address

Scenario: Adding valid delivery addresses
	Given I have entered the following delivery addresses
	| Id | FirstName | LastName | AddressName | AddressLine1      | AddressLine2 | AddressLine3 | City  | Country | State | Region | ZipCode | Phone         |
	| 0  | Vitali    | Hatalski | My first    | Nekrasova 8       | flat 14      |              | Minsk | Belarus |       |        | 220040  |               |
	| 0  | Vitali    | Hatalski | My second   | Novovilenskaya 10 | flat 41      |              | Minsk | Belarus |       |        | 220053  | +375295067630 |
	When addresses go to conroller
	Then the result should be as the following
	| Id | FirstName | LastName | AddressName | AddressLine1      | AddressLine2 | AddressLine3 | City  | Country | State | Region | ZipCode | Phone         |
	| 1  | Vitali    | Hatalski | My first    | Nekrasova 8       | flat 14      |              | Minsk | Belarus |       |        | 220040  |               |
	| 2  | Vitali    | Hatalski | My second   | Novovilenskaya 10 | flat 41      |              | Minsk | Belarus |       |        | 220053  | +375295067630 |
