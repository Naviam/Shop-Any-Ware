@profile
Feature: Profile
	In order to control service behavior
	As a shopper
	I want to be able to change my profile settings

@viewprofile
Scenario: View my profile
	Given there is 'v.hatalski@gmail.com' account with 'ruinruin' password in role 'Shopper' with fullname 'Vitali' and 'Hatalski'
	And I am authenticated as 'v.hatalski@gmail.com'
	When I go to my profile page
	Then the profile view model should be as follows
	| Email                | First Name | Last Name | Notify On Order Status Changed | Notify On Package Status Changed | Message Type |
	| v.hatalski@gmail.com | Vitali     | Hatalski  | False                          | False                            | Success      |

@updateprofile
Scenario: Update my profile
	Given there is 'v.hatalski@gmail.com' account with 'ruinruin' password in role 'Shopper' with fullname 'Vitali' and 'Hatalski'
	And I am authenticated as 'v.hatalski@gmail.com'
	When I fill the profile form with following data
	| First Name | Last Name | Notify On Order Status Changed | Notify On Package Status Changed |
	| Alex       | Ivanov    | True                           | True                             |
	Then the profile view model should be as follows
	| Email                | First Name | Last Name | Notify On Order Status Changed | Notify On Package Status Changed | Message Type |
	| v.hatalski@gmail.com | Alex       | Ivanov    | True                           | True                             | Success      |

@updateprofile
Scenario: Validate required fields when updating my profile
	Given there is 'v.hatalski@gmail.com' account with 'ruinruin' password in role 'Shopper' with fullname 'Vitali' and 'Hatalski'
	And I am authenticated as 'v.hatalski@gmail.com'
	When I fill the profile form with following data
	| First Name | Last Name | Notify On Order Status Changed | Notify On Package Status Changed |
	|            |           | True                           | False                           |
	Then the profile view model should be as follows
	| Email                | First Name | Last Name | Notify On Order Status Changed | Notify On Package Status Changed | Message Type |
	| v.hatalski@gmail.com |            |           | True                           | False                            | Warning      |
	And the profile view model should have following errors
	| Property  | Error Code               |
	| FirstName | ProfileFirstNameRequired |
	| LastName  | ProfileLastNameRequired  |
	
@updateprofile
Scenario: Validate max fields length when updating my profile
	Given there is 'v.hatalski@gmail.com' account with 'ruinruin' password in role 'Shopper' with fullname 'Vitali' and 'Hatalski'
	And I am authenticated as 'v.hatalski@gmail.com'
	When I fill the profile form with following data
	| First Name                                 | Last Name                                 | Notify On Order Status Changed | Notify On Package Status Changed |
	| First name must not exceed 21 chars length | Last name must not exceed 21 chars length | False                          | True                             |
	Then the profile view model should be as follows
	| Email                | First Name                                 | Last Name                                 | Notify On Order Status Changed | Notify On Package Status Changed | Message Type |
	| v.hatalski@gmail.com | First name must not exceed 21 chars length | Last name must not exceed 21 chars length | False                          | True                             | Warning      |
	And the profile view model should have following errors
	| Property  | Error Code                |
	| FirstName | ProfileFirstNameMaxLength |
	| LastName  | ProfileLastNameMaxLength  |