@signup
Feature: Shopper Account Creation
	In order to start using ShopAnyWare service
	As an anonymous user
	I want to be able to register as a shopper and activate my personal account

Scenario: Create new account
	Given I have not been authenticated yet
	When I fill sign up form with the following data
	| Email          | Password | Password Confirm | First Name | Last Name |
	| hautama@tut.by | ruinruin | ruinruin         | Vitali     | Hatalski  |
	Then I should have the result as follows
	| Email          | First Name | Last Name | Activated | Message Type |
	| hautama@tut.by | Vitali     | Hatalski  | false     | Success      |
	And activation code should be generated

Scenario: Account already exists
	Given I have not been authenticated yet
	And The 'vhatalski@naviam.com' account already exists
	When I fill sign up form with the following data
	| Email                | Password | Password Confirm | First Name | Last Name |
	| vhatalski@naviam.com | ruinruin | ruinruin         | Vitali     | Hatalski  |
	Then I should have the result as follows
	| Email                | First Name | Last Name | Message Type |
	| vhatalski@naviam.com | Vitali     | Hatalski  | Error        |
	And I should have the following model errors
	| Property | Error Code      |
	| Email    | UserEmailExists |

Scenario: Password and confirm password do not match
	Given I have not been authenticated yet
	When I fill sign up form with the following data
	| Email          | Password | Password Confirm | First Name | Last Name |
	| hautama@tut.by | ruinruin | ruinruin1        | Vitali     | Hatalski  |
	Then I should have the result as follows
	| Email          | First Name | Last Name | Message Type |
	| hautama@tut.by | Vitali     | Hatalski  | Error        |
	And I should have the following model errors
	| Property        | Error Code                  |
	| PasswordConfirm | UserPasswordConfirmNotEqual |

Scenario: Password length cannot be less than 7 chars
	Given I have not been authenticated yet
	When I fill sign up form with the following data
	| Email          | Password | Password Confirm | First Name | Last Name |
	| hautama@tut.by | ruin     | ruin             | Vitali     | Hatalski  |
	Then I should have the result as follows
	| Email          | First Name | Last Name | Message Type |
	| hautama@tut.by | Vitali     | Hatalski  | Error        |
	And I should have the following model errors
	| Property | Error Code            |
	| Password | UserPasswordMinLength |

Scenario: Password length cannot be more than 21 chars
	Given I have not been authenticated yet
	When I fill sign up form with the following data
	| Email          | Password                    | Password Confirm            | First Name | Last Name |
	| hautama@tut.by | passwordwithmorethan21chars | passwordwithmorethan21chars | Vitali     | Hatalski  |
	Then I should have the result as follows
	| Email          | First Name | Last Name | Message Type |
	| hautama@tut.by | Vitali     | Hatalski  | Error        |
	And I should have the following model errors
	| Property | Error Code            |
	| Password | UserPasswordMaxLength |

Scenario: Password is required
	Given I have not been authenticated yet
	When I fill sign up form with the following data
	| Email          | Password | Password Confirm | First Name | Last Name |
	| hautama@tut.by |          | ruinruin         | Vitali     | Hatalski  |
	Then I should have the result as follows
	| Email          | First Name | Last Name | Message Type |
	| hautama@tut.by | Vitali     | Hatalski  | Error        |
	And I should have the following model errors
	| Property        | Error Code                  |
	| Password        | UserPasswordRequired        |
	| PasswordConfirm | UserPasswordConfirmNotEqual |