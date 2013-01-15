Feature: NlogDynamoDbTarget
	In order to have more information about system work
	As a project developer
	I want to be able to log everything to Amazon Dynamo DB

@unit
Scenario: Logs writer should have no locks
	Given I have '5' users that work with a system simulteneously
	| User Id                      |
	| vhatalski@naviam.com         |
	| v.hatalski@gmail.com         |
	| hautama@tut.com              |
	| vhatalski@servicechannel.com |
	| natallia@naviam.com          |
	When I add '1000' simulteneous logs into dynamo db
	Then the result should be '1000' logs in dynamo db

Scenario: Logs should be asynchronious


