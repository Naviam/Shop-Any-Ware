@packages
Feature: Shopper Packages
	In order to send packages to my delivery address
	As a shopper
	I want to be able to consolidate my items in packages and specify delivery address

@addpackage
Scenario: Add new package
	Given there is 'v.hatalski@gmail.com' account with 'ruinruin' password in role 'Shopper' with fullname 'Vitali' and 'Hatalski'
	And I am authenticated as 'v.hatalski@gmail.com'
	When I set package name as 'my first package'
	Then I should have the following packages as a result
	| Id | Name             | Status |
	| 1  | my first package | New    |

Scenario: Update package delivery address
	Given there is 'v.hatalski@gmail.com' account with 'ruinruin' password in role 'Shopper' with fullname 'Vitali' and 'Hatalski'
	And I am authenticated as 'v.hatalski@gmail.com'
	And I have the following delivery addresses
    | Id | FirstName | LastName | AddressName       | AddressLine1      | AddressLine2 | City  | Country | State | Region | ZipCode | Phone         |
    | 1  | Vitali    | Hatalski | my first address  | Nekrasova 8       | 14           | Minsk | Belarus |       |        | 220040  | +375295067630 |
    | 2  | Vitali    | Hatalski | my second address | Novovilenskaya 10 | 41           | Minsk | Belarus |       |        | 220053  | +375295067630 |
	And I have the following packages
	| Name              | Delivery Address Id | Status |
	| my first package  | 1                   | New    |
	When I update delivery address to '2' of package '1'
	Then I should have the following packages as a result
    | Id | Name             | Delivery Address Id | Status | Message Type |
    | 1  | my first package | 2                   | New    | Success      |

Scenario: Remove package in New status
	Given there is 'v.hatalski@gmail.com' account with 'ruinruin' password in role 'Shopper' with fullname 'Vitali' and 'Hatalski'
	And I am authenticated as 'v.hatalski@gmail.com'
	And I have the following delivery addresses
    | Id | FirstName | LastName | AddressName      | AddressLine1 | AddressLine2 | City  | Country | State | Region | ZipCode | Phone         |
    | 1  | Vitali    | Hatalski | my first address | Nekrasova 8  | 14           | Minsk | Belarus |       |        | 220040  | +375295067630 |
	And I have the following packages
	| Name              | Delivery Address Id | Dispatch Method | Status |
	| my first package  | 0                   | ExpressMail     | New    |
	| my second package | 1                   | ExpressMail     | New    |
	When I remove packages with the ids as follows
	| Id |
	| 1  |
	| 2  |
	| 3  |
	Then I should have the following packages as a result
    | Id | Name | Delivery Address Id | Status | Message Type |
    | 1  |      |                     |        |              |
    | 2  |      |                     |        |              |
    | 3  |      |                     |        |              |