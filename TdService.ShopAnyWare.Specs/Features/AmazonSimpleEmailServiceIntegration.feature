@notification
Feature: Amazon Simple Email Service (SES) Integration
	In order to send emails to service users
	As an automatic notification system
	I want to be able to send wide variety of emails to end users

Scenario: Send sample test email
	Given I have Amazon SES SMTP credentials with user name 'AKIAJXICDWFKLGRXRYQQ' and password 'At68h2AeX8hAkKxfjW2Mq+iPzrzFYPZjRR0SJXoZwnek'
	And I created sample email
	When I send sample email to 'vhatalski@naviam.com' from 'vhatalski@naviam.com'
	Then the 'vhatalski@naviam.com' address should receive sample email
