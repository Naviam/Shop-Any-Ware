@usps
Feature: USPS Shipping Service Integration
	In order to know the cost of delivery and track my packages
	As a shopper
	I want to be able to calculate rate base on delivery method and package weight

@trackpackage
Scenario: Get package delivery info by tracking number
	When I request the USPS tracking service with the '23445345345' tracking number
	Then I should get the following trac

Scenario: 
