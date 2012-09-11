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
	|    | Vitali    | Hatalski | My second   | Novovilenskaya 10 | flat 41      | Minsk | Belarus | Minsk | Minsk  | 220053  | +375295067630 |             |
	|    |           |          | My second   | Novovilenskaya 10 | flat 41      | Minsk | Belarus |       |        | 220053  | +375295067630 |             |
	Then I should have the following delivery addresses as a result
	| Id | FirstName | LastName | AddressName | AddressLine1      | AddressLine2 | City  | Country | State | Region | ZipCode | Phone         | MessageType |
	| 2  | Vitali    | Hatalski | My first    | Nekrasova 8       | flat 14      | Minsk | Belarus |       |        | 220040  |               | Success     |
	| 3  | Vitali    | Hatalski | My second   | Novovilenskaya 10 | flat 41      | Minsk | Belarus | Minsk | Minsk  | 220053  | +375295067630 | Success     |
	| 0  |           |          | My second   | Novovilenskaya 10 | flat 41      | Minsk | Belarus |       |        | 220053  | +375295067630 | Error       |

@adddeliveryaddress
Scenario: Validate required fields when adding delivery address
	Given I have 'v.hatalski@gmail.com' email address
	And I have the following delivery addresses
	| Id | FirstName | LastName | AddressName | AddressLine1      | AddressLine2 | City  | Country | State | Region | ZipCode | Phone         |
	| 1  | Vitali    | Hatalski | Initial     | Nekrasova 8       | flat 14      | Minsk | Belarus |       |        | 220040  |               |
	When I add the following delivery address
	| Id | FirstName | LastName | AddressName | AddressLine1      | AddressLine2 | City  | Country | State | Region | ZipCode | Phone         |
	|    |           |          |             |                   |              |       |         |       |        |         |               |
	Then I should have the following delivery address as a result
	| Id | FirstName | LastName | AddressName | AddressLine1      | AddressLine2 | City  | Country | State | Region | ZipCode | Phone         | MessageType |
	| 0  |           |          |             |                   |              |       |         |       |        |         |               | Error       |
	And the delivery address view model should have following errors
	| Property     | Error Code                         |
	| FirstName    | DeliveryAddressFirstNameRequired   |
	| LastName     | DeliveryAddressLastNameRequired    |
	| AddressName  | DeliveryAddressAddressNameRequired |
	| AddressLine1 | AddressAddressLine1Required        |
	| City         | AddressCityRequired                |
	| Country      | AddressCountryRequired             |
	| ZipCode      | AddressZipCodeRequired             |

@adddeliveryaddress
Scenario: Validate max char length of fields when adding delivery address
	Given I have 'v.hatalski@gmail.com' email address
	And I have the following delivery addresses
	| Id | FirstName | LastName | AddressName | AddressLine1      | AddressLine2 | City  | Country | State | Region | ZipCode | Phone         |
	| 1  | Vitali    | Hatalski | Initial     | Nekrasova 8       | flat 14      | Minsk | Belarus |       |        | 220040  |               |
	When I add the following delivery address
	| Id | FirstName                          | LastName                          | AddressName                                             | AddressLine1                                                                                                                                                                                                                                                                                                         | AddressLine2                                                                                                                                                                                                                                                                                                         | City                                                                      | Country                                                                   | State                                                                     | Region                                                                    | ZipCode      | Phone                              |
	|    | first name that is longer 21 chars | last name that is longer 21 chars | The maximum allowed length of address name is 40 chars. | This is an optional credential that allows you to increase the level of your account security. To add this security option to your account, you will need to purchase a compatible authentication device from Gemalto, a third-party provider. Click the button below to purchase a device from the Gemalto website. | This is an optional credential that allows you to increase the level of your account security. To add this security option to your account, you will need to purchase a compatible authentication device from Gemalto, a third-party provider. Click the button below to purchase a device from the Gemalto website. | Taumatawhakatangihangakoauauotamateapokaiwhenuakitanatahuwhenuakitanatahu | Taumatawhakatangihangakoauauotamateapokaiwhenuakitanatahuwhenuakitanatahu | Taumatawhakatangihangakoauauotamateapokaiwhenuakitanatahuwhenuakitanatahu | Taumatawhakatangihangakoauauotamateapokaiwhenuakitanatahuwhenuakitanatahu | 123456789012 | +375295067630506763050676305067630 |
	Then I should have the following delivery address as a result
	| Id | FirstName                          | LastName                          | AddressName                                             | AddressLine1                                                                                                                                                                                                                                                                                                         | AddressLine2                                                                                                                                                                                                                                                                                                         | City                                                                      | Country                                                                   | State                                                                     | Region                                                                    | ZipCode      | Phone                              | MessageType |
	| 0  | first name that is longer 21 chars | last name that is longer 21 chars | The maximum allowed length of address name is 40 chars. | This is an optional credential that allows you to increase the level of your account security. To add this security option to your account, you will need to purchase a compatible authentication device from Gemalto, a third-party provider. Click the button below to purchase a device from the Gemalto website. | This is an optional credential that allows you to increase the level of your account security. To add this security option to your account, you will need to purchase a compatible authentication device from Gemalto, a third-party provider. Click the button below to purchase a device from the Gemalto website. | Taumatawhakatangihangakoauauotamateapokaiwhenuakitanatahuwhenuakitanatahu | Taumatawhakatangihangakoauauotamateapokaiwhenuakitanatahuwhenuakitanatahu | Taumatawhakatangihangakoauauotamateapokaiwhenuakitanatahuwhenuakitanatahu | Taumatawhakatangihangakoauauotamateapokaiwhenuakitanatahuwhenuakitanatahu | 123456789012 | +375295067630506763050676305067630 | Error       |
	And the delivery address view model should have following errors
	| Property     | Error Code                          |
	| FirstName    | DeliveryAddressFirstNameMaxLength   |
	| LastName     | DeliveryAddressLastNameMaxLength    |
	| AddressName  | DeliveryAddressAddressNameMaxLength |
	| AddressLine1 | AddressAddressLine1MaxLength        |
	| AddressLine2 | AddressAddressLine2MaxLength        |
	| City         | AddressCityMaxLength                |
	| Country      | AddressCountryMaxLength             |
	| State        | AddressStateMaxLength               |
	| Region       | AddressRegionMaxLength              |
	| ZipCode      | AddressZipCodeMaxLength             |
	| Phone        | AddressPhoneMaxLength               |

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
	| 1  |           | Hatalski | My first     | Nekrasova 8       | flat 14      | Minsk | Belarus |       |        | 220040  |               | Error       |
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