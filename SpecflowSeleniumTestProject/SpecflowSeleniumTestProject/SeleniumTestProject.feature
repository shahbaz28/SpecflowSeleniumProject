Feature: SeleniumTestProject
	

@mytag
Scenario: Access this weeks Recipes Page
	Given I have navigated to webpage

Scenario: : Access the about delivery section from this weeks recipes page
    Given I have navigated to webpage
	When I select the About Delivery Link
	Then I can view the delivery information

	Scenario: Select the New Reccipe of the week
	Given I have navigated to webpage
	When I select the new recipe of the week
	Then I could view the recipe
	
	Scenario: Select recipes and add them to basket
	Given I have navigated to webpage
	When I Select Set Delivery date
	Then I could enter a postcode
	And I could add the recipes

	Scenario: Show the Vegitarian options
	Given I have navigated to webpage
	When I select the Vegetarian options icon
	Then I see a list of the Vegitarian recipes