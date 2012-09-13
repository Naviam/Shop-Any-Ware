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
	| Identity Token       | First Name | Last Name | Notify On Order Status Changed | Notify On Package Status Changed | Message Type |
	| v.hatalski@gmail.com | Vitali     | Hatalski  | False                          | False                            | Success      |

@updateprofile
Scenario: Update my profile
	Given there is 'v.hatalski@gmail.com' account with 'ruinruin' password in role 'Shopper' with fullname 'Vitali' and 'Hatalski'
	And I am authenticated as 'v.hatalski@gmail.com'
	When I fill the profile form with following data
	| First Name | Last Name | Notify On Order Status Changed | Notify On Package Status Changed |
	| Alex       | Ivanov    | True                           | True                             |
	Then the profile view model should be as follows
	| Identity Token       | First Name | Last Name | Notify On Order Status Changed | Notify On Package Status Changed | Message Type |
	| v.hatalski@gmail.com | Alex       | Ivanov    | True                           | True                             | Success      |

@updateprofile
Scenario: Validate required fields when updating my profile
	Given there is 'v.hatalski@gmail.com' account with 'ruinruin' password in role 'Shopper' with fullname 'Vitali' and 'Hatalski'
	And I am authenticated as 'v.hatalski@gmail.com'
	When I fill the profile form with following data
	| First Name | Last Name | Notify On Order Status Changed | Notify On Package Status Changed |
	|            |           | False                         | False                           |
	Then the profile view model should be as follows
	| Identity Token       | First Name | Last Name | Notify On Order Status Changed | Notify On Package Status Changed | Message Type |
	| v.hatalski@gmail.com |            |           | False                          | False                            | Warning      |
	And the profile view model should have following errors
	| Property         | Error Code               |
	| ProfileFirstName | ProfileFirstNameRequired |
	| ProfileLastName  | ProfileLastNameRequired  |