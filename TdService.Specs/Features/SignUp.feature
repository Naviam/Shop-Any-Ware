@signup
Feature: Sign Up
	In order to start using ShopAnyWare service
	As an anonymous user
	I want to be able to register as a shopper and activate my personal account

Scenario: Shoppers sign up
	Given I have not been authenticated yet
	When I fill sign up form with the following data
	| Email          | Password | Password Confirm | First Name | Last Name |
	| hautama@tut.by | ruinruin | ruinruin         | Vitali     | Hatalski  |
	Then I should have the result as follows
	| Email          | First Name | Last Name | Activated | Message Type |
	| hautama@tut.by | Vitali     | Hatalski  | false     | Success      |
	And activation code should be generated
	And email with activation code should be sent to registration email address

Scenario: Account already exists
	Given there is 'vhatalski@naviam.com' account with 'ruinruin' password in role 'Shopper' with fullname 'Vitali' and 'Hatalski'
	And I have not been authenticated yet
	When I fill sign up form with the following data
	| Email                | Password | Password Confirm | First Name | Last Name |
	| vhatalski@naviam.com | ruinruin | ruinruin         | Vitali     | Hatalski  |
	Then I should have the result as follows
	| Email                | First Name | Last Name | Message Type |
	| vhatalski@naviam.com | Vitali     | Hatalski  | Warning      |
	And the signup view model should have following errors
	| Property | Error Code      |
	| Email    | UserEmailExists |

Scenario: Verify email existence when it should exist
	Given there is 'vhatalski@naviam.com' account with 'ruinruin' password in role 'Shopper' with fullname 'Vitali' and 'Hatalski'
	And I have not been authenticated yet
	When I enter email 'vhatalski@naviam.com' to verify existence
	Then the verify email view model should be as follows
	| EmailExists | Message Type |
	| True        | Warning      |

Scenario: Verify email existence when it should not exist
	Given I have not been authenticated yet
	When I enter email 'nosuchmail@naviam.com' to verify existence
	Then the verify email view model should be as follows
	| EmailExists | Message Type |
	| False       | Success      |

Scenario: Email and password are required
	Given I have not been authenticated yet
	When I fill sign up form with the following data
	| Email | Password | Password Confirm | First Name | Last Name |
	|       |          |                  | Vitali     | Hatalski  |
	Then I should have the result as follows
	| Email | First Name | Last Name | Message Type |
	|       | Vitali     | Hatalski  | Warning      |
	And the signup view model should have following errors
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
	| hautama@tut.by |            |           | Warning      |
	And the signup view model should have following errors
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
	| hautama@tut.by | First name longer than 21 chars | Last name longer than 21 chars | Warning      |
	And the signup view model should have following errors
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
	| hautamatut.by | Vitali     | Hatalski  | Warning      |
	And the signup view model should have following errors
	| Property | Error Code       |
	| Email    | UserEmailInvalid |

Scenario: Password Confirm does not match
	Given I have not been authenticated yet
	When I fill sign up form with the following data
	| Email          | Password | Password Confirm | First Name | Last Name |
	| hautama@tut.by | ruinruin | ruinruin1        | Vitali     | Hatalski  |
	Then I should have the result as follows
	| Email          | First Name | Last Name | Message Type |
	| hautama@tut.by | Vitali     | Hatalski  | Warning      |
	And the signup view model should have following errors
	| Property        | Error Code                  |
	| PasswordConfirm | UserPasswordConfirmNotEqual |

Scenario: Password length cannot be less than 7 chars
	Given I have not been authenticated yet
	When I fill sign up form with the following data
	| Email          | Password | Password Confirm | First Name | Last Name |
	| hautama@tut.by | ruin     | ruin             | Vitali     | Hatalski  |
	Then I should have the result as follows
	| Email          | First Name | Last Name | Message Type |
	| hautama@tut.by | Vitali     | Hatalski  | Warning      |
	And the signup view model should have following errors
	| Property | Error Code            |
	| Password | UserPasswordMinLength |

Scenario: Password length cannot be more than 21 chars
	Given I have not been authenticated yet
	When I fill sign up form with the following data
	| Email          | Password                    | Password Confirm            | First Name | Last Name |
	| hautama@tut.by | passwordwithmorethan21chars | passwordwithmorethan21chars | Vitali     | Hatalski  |
	Then I should have the result as follows
	| Email          | First Name | Last Name | Message Type |
	| hautama@tut.by | Vitali     | Hatalski  | Warning      |
	And the signup view model should have following errors
	| Property | Error Code            |
	| Password | UserPasswordMaxLength |

Scenario: Password is required and Password Confirm does not match
	Given I have not been authenticated yet
	When I fill sign up form with the following data
	| Email          | Password | Password Confirm | First Name | Last Name |
	| hautama@tut.by |          | ruinruin         | Vitali     | Hatalski  |
	Then I should have the result as follows
	| Email          | First Name | Last Name | Message Type |
	| hautama@tut.by | Vitali     | Hatalski  | Warning      |
	And the signup view model should have following errors
	| Property        | Error Code                  |
	| Password        | UserPasswordRequired        |
	| PasswordConfirm | UserPasswordConfirmNotEqual |