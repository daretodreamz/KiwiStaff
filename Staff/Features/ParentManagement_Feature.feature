Feature: ParentManagement_Feature
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@mytag
Scenario: Archive a parent
	Given Goto Parent management Page
	And get the parent name
	| ParentName |
	| Nakkala, Ravito |
	When I have clicked on Archive button
	And Parent is moved to Archive tab
	Then Parent cannot log in to Aimy by the following credentials
	| Username   | Password |
	| ravito@yahoo.co.in | 123123 |
