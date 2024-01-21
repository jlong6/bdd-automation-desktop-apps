Feature: Calculator

@mytag
Scenario: Add two numbers
	Given I start application Calculator
	And I click button "Two"
	And I click button "Plus"
	And I click button "Three"
	And I click button "Equals"
