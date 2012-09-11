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

Scenario: Email and password are required
	Given I have not been authenticated yet
	When I fill sign up form with the following data
	| Email | Password | Password Confirm | First Name | Last Name |
	|       |          |                  | Vitali     | Hatalski  |
	Then I should have the result as follows
	| Email | First Name | Last Name | Message Type |
	|       | Vitali     | Hatalski  | Error        |
	And I should have the following model errors
	| Property        | Error Code                  |
	| Password        | UserPasswordRequired        |
	| Email           | UserEmailRequired           |
	| PasswordConfirm | UserPasswordConfirmRequired |

Scenario: First and Last names are required
	Given I have not been authenticated yet
	When I fill sign up form with the following data
	| Email          | Password | Password Confirm | First Name | Last Name |
	| hautama@tut.by | ruinruin | ruinruin         |            |           |
	Then I should have the result as follows
	| Email          | First Name | Last Name | Message Type |
	| hautama@tut.by |            |           | Error        |
	And I should have the following model errors
	| Property  | Error Code               |
	| FirstName | ProfileFirstNameRequired |
	| LastName  | ProfileLastNameRequired  |

Scenario: First and Last names should be less than 21 chars
	Given I have not been authenticated yet
	When I fill sign up form with the following data
	| Email          | Password | Password Confirm | First Name                      | Last Name                      |
	| hautama@tut.by | ruinruin | ruinruin         | First name longer than 21 chars | Last name longer than 21 chars |
	Then I should have the result as follows
	| Email          | First Name                      | Last Name                      | Message Type |
	| hautama@tut.by | First name longer than 21 chars | Last name longer than 21 chars | Error        |
	And I should have the following model errors
	| Property  | Error Code                |
	| FirstName | ProfileFirstNameMaxLength |
	| LastName  | ProfileLastNameMaxLength  |

Scenario: Email is invalid
	Given I have not been authenticated yet
	When I fill sign up form with the following data
	| Email         | Password | Password Confirm | First Name | Last Name |
	| hautamatut.by | ruinruin | ruinruin         | Vitali     | Hatalski  |
	Then I should have the result as follows
	| Email         | First Name | Last Name | Message Type |
	| hautamatut.by | Vitali     | Hatalski  | Error        |
	And I should have the following model errors
	| Property | Error Code       |
	| Email    | UserEmailInvalid |

Scenario: Password Confirm does not match
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

Scenario: Password is required and Password Confirm does not match
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