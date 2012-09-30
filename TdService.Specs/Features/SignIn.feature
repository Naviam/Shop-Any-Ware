@signin
Feature: Sign In
	In order to start using service
	As a shopper
	I want to be able to sign in with my credentials

@shopper
Scenario: Sign in shopper
	Given there is 'v.hatalski@gmail.com' account with 'ruinruin' password in role 'Shopper' with fullname 'Vitali' and 'Hatalski'
	And I have not been authenticated yet
	When I fill sign in form with the following data
	| Email                | Password | Remember Me |
	| v.hatalski@gmail.com | ruinruin | false       |
	Then I should be redirected to controller 'Member' and action 'Dashboard'

@shopper
Scenario: Shopper invalid password
	Given there is 'v.hatalski@gmail.com' account with 'ruinruin' password in role 'Shopper' with fullname 'Vitali' and 'Hatalski'
	And I have not been authenticated yet
	When I fill sign in form with the following data
	| Email                | Password | Remember Me |
	| v.hatalski@gmail.com | ruin3    | false       |
	Then the signin result should be as follows
	| Email                | Password | Remember Me | Message Type | Error Code   |
	| v.hatalski@gmail.com |          | false       | Error        | UserNotValid |

@shopper
Scenario: Shopper invalid email
	Given there is 'v.hatalski@gmail.com' account with 'ruinruin' password in role 'Shopper' with fullname 'Vitali' and 'Hatalski'
	And I have not been authenticated yet
	When I fill sign in form with the following data
	| Email               | Password                         | Remember Me |
	| vhatalski@gmail.com | ruinruinruinruinruinruinruinruin | false       |
	Then the signin result should be as follows
	| Email               | Password | Remember Me | Message Type | Error Code   |
	| vhatalski@gmail.com |          | false       | Error        | UserNotValid |

@shopper
Scenario: Shopper validate required fields
	Given there is 'v.hatalski@gmail.com' account with 'ruinruin' password in role 'Shopper' with fullname 'Vitali' and 'Hatalski'
	And I have not been authenticated yet
	When I fill sign in form with the following data
	| Email | Password | Remember Me |
	|       |          | false       |
	Then the signin result should be as follows
	| Email | Password | Remember Me | Message Type |
	|       |          | false       | Warning      |
	And the signin view model should have following errors
	| Property | Error Code           | Rule |
	| Email    | UserEmailRequired    |      |
	| Password | UserPasswordRequired |      |

@operator
Scenario: Sign in operator
	Given there is 'v.hatalski@gmail.com' account with 'ruinruin' password in role 'Operator' with fullname 'Vitali' and 'Hatalski'
	And I have not been authenticated yet
	When I fill sign in form with the following data
	| Email                | Password | Remember Me |
	| v.hatalski@gmail.com | ruinruin | false       |
	Then I should be redirected to controller 'Operator' and action 'Dashboard'

@consultant
Scenario: Sign in consultant
	Given there is 'v.hatalski@gmail.com' account with 'ruinruin' password in role 'Consultant' with fullname 'Vitali' and 'Hatalski'
	And I have not been authenticated yet
	When I fill sign in form with the following data
	| Email                | Password | Remember Me |
	| v.hatalski@gmail.com | ruinruin | false       |
	Then I should be redirected to controller 'Operator' and action 'Dashboard'
	
@admin
Scenario: Sign in admin
	Given there is 'v.hatalski@gmail.com' account with 'ruinruin' password in role 'Admin' with fullname 'Vitali' and 'Hatalski'
	And I have not been authenticated yet
	When I fill sign in form with the following data
	| Email                | Password | Remember Me |
	| v.hatalski@gmail.com | ruinruin | false       |
	Then I should be redirected to controller 'Admin' and action 'Dashboard'
