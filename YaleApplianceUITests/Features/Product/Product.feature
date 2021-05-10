@Filter @Product
Feature: Product
	  As a user on the Yale product page
	  I would like to be able to filter product resutlts by Brand, Price, and Color 
	  So that i can customise my browsing experience
	  

Scenario Outline: Top filters - Dishwashers
	Given User wants to filter content '<Page>'
	When User selects the Dishwasher filter in the list '<Filter>'
	Then Dishwasher Catalog should update to show only items with selected filter '<Filter>'
	Examples: 
	| Filter | Page                                                                          |
	| Brand  | https://www.yaleappliance.com/kitchen/dishwasher-compactors/dishwashers/      |
	| Color  | https://www.yaleappliance.com/kitchen/dishwasher-compactors/dishwashers/      |
	| Price  | https://www.yaleappliance.com/kitchen/dishwasher-compactors/dishwashers/      |

	

Scenario Outline: Top filters - Refrigerators 
	Given User wants to filter content '<Page>'
	When User selects the Refrigerator filter in the list '<Filter>'
	Then Refrigerator Catalog should update to show only items with selected filter '<Filter>'
	Examples: 
	| Filter      | Page                                                                                          |
	| Brand       | https://www.yaleappliance.com/kitchen/refrigeration-appliances/counter-depth/french-door/     |
	| Color       | https://www.yaleappliance.com/kitchen/refrigeration-appliances/counter-depth/french-door/     |
	| Price      | https://www.yaleappliance.com/kitchen/refrigeration-appliances/counter-depth/french-door/      |


	
Scenario Outline: Top filters - Cooking-appliances
	Given User wants to filter content '<Page>'
	When User selects the Cooking appliance filter in the list '<Filter>'
	Then Appliance Catalog should update to show only items with selected filter '<Filter>'
	Examples: 
	| Filter        | Page                                                                            |
	| Brand         | https://www.yaleappliance.com/kitchen/cooking-appliances/ranges/gas-ranges/     |
	| Color         | https://www.yaleappliance.com/kitchen/cooking-appliances/ranges/gas-ranges/     |
	| Price         | https://www.yaleappliance.com/kitchen/cooking-appliances/ranges/gas-ranges/     |


Scenario Outline: Resetting Top filters - Dishwashers
     Given User wants to filter content '<Page>'
     And User selects the Dishwasher filter in the list '<Filter>'
     When User clicks on reset filters
     Then Catalog page should show all products without a filter

	Examples: 
	| Filter | Page                                                                       |
	| Brand  | https://www.yaleappliance.com/kitchen/dishwasher-compactors/dishwashers/   |
	| Color  | https://www.yaleappliance.com/kitchen/dishwasher-compactors/dishwashers/   |
	| Price  | https://www.yaleappliance.com/kitchen/dishwasher-compactors/dishwashers/   |



Scenario Outline: Resseting Top filters - Refrigerators 
	Given User wants to filter content '<Page>'
	And User selects the Refrigerator filter in the list '<Filter>'
	When User clicks on reset filters
    Then Catalog page should show all products without a filter
	Examples: 
	| Filter      | Page                                                                                       |
	| Brand       | https://www.yaleappliance.com/kitchen/refrigeration-appliances/counter-depth/french-door/  |
	| Color       | https://www.yaleappliance.com/kitchen/refrigeration-appliances/counter-depth/french-door/  |
	| Price      | https://www.yaleappliance.com/kitchen/refrigeration-appliances/counter-depth/french-door/   |


Scenario Outline: Resseting Top filters - Appliances
	Given User wants to filter content '<Page>'
	And User selects the Cooking appliance filter in the list '<Filter>'
	When User clicks on reset filters
    Then Catalog page should show all products without a filter
	Examples: 
	| Filter        | Page                                                                            |
	| Brand         | https://www.yaleappliance.com/kitchen/cooking-appliances/ranges/gas-ranges/     |
	| Color         | https://www.yaleappliance.com/kitchen/cooking-appliances/ranges/gas-ranges/     |
	| Price         | https://www.yaleappliance.com/kitchen/cooking-appliances/ranges/gas-ranges/     |



Scenario Outline: In stock filter
Given User wants to filter content '<Page>'
When User selects in stock button 
Then Catalog should update to show only items that are in stock
	Examples: 
	 | Page                                                                                        |
	 | https://www.yaleappliance.com/kitchen/cooking-appliances/ranges/gas-ranges/                 |
	 | https://www.yaleappliance.com/kitchen/refrigeration-appliances/counter-depth/french-door/   |
	 |  https://www.yaleappliance.com/kitchen/dishwasher-compactors/dishwashers/                   |



Scenario Outline: Price sorter - lowest to highest
Given User wants to sort content by price '<Page>'
When User selects price button
Then Catalog should update to show products that are least expensive first to highest last
	Examples: 
	 | Page                                                                                        |
	 | https://www.yaleappliance.com/kitchen/cooking-appliances/ranges/gas-ranges/                 |
	 | https://www.yaleappliance.com/kitchen/refrigeration-appliances/counter-depth/french-door/   |
	 |  https://www.yaleappliance.com/kitchen/dishwasher-compactors/dishwashers/                   |



Scenario Outline: Most popular filter

Given User wants to filter content by most popular '<Page>'
When User selects most popular button
Then Catalog should update to show only products that are most popular 
	Examples: 
	 | Page                                                                                        |
	 | https://www.yaleappliance.com/kitchen/cooking-appliances/ranges/gas-ranges/                 |
	 | https://www.yaleappliance.com/kitchen/refrigeration-appliances/counter-depth/french-door/   |
	 |  https://www.yaleappliance.com/kitchen/dishwasher-compactors/dishwashers/                   |


Scenario Outline: Compare items

Given User wants to compare items '<Page>'
And  User adds selected items from the compare button on the top right of the item.
And Items should be added to the top of the page 
When User clicks on Compare items
Then All items should show in a table with related item details 
And User continues shopping '<Page>'
And User unselects items
	Examples: 
	 | Page                                                                           |
	 | https://www.yaleappliance.com/kitchen/cooking-appliances/ranges/gas-ranges/    |


Scenario Outline: Review

Given User wants to look at reviews '<Page>'
When User clicks on Review button the left-hand side
Then Review popup should show up
	Examples: 
	 | Page                                                                         |
	 | https://www.yaleappliance.com/kitchen/cooking-appliances/ranges/gas-ranges/  |


Scenario Outline: View details 

Given User wants to look at more details of a specific product '<Page>'
When User clicks on View details 
Then Product page should show up 
	Examples: 
	 | Page                                                                         |
	 | https://www.yaleappliance.com/kitchen/cooking-appliances/ranges/gas-ranges/  |




@ignore
Scenario Outline: Left-sided filters - Dishwasher

	Given User wants to filter content '<Page>'
	When User selects the Dishwasher filter in the list '<LeftFilter>' '<TopFilters>'
	Then Catalog should update to show only items with the selected filter
	Examples: 
	| TopFilter | LeftFilter1 | LeftFilter2 | Page                                                                                       |
	| Color     | Category    | OnDisplay   | https://www.yaleappliance.com/kitchen/dishwasher-compactors/dishwashers/                   |
	| Color     | OnDisplay   | Dimensions  | https://www.yaleappliance.com/kitchen/cooking-appliances/ranges/gas-ranges/                |
	|           | Category    | Features    | https://www.yaleappliance.com/kitchen/refrigeration-appliances/counter-depth/side-by-side/ |



Scenario Outline: Top Page Navigation 

Given User wants to navigate back to the previous node '<Page>'
When User clicks on the previous node
Then the previous node page should show up '<Page>'
	Examples: 
	| Page                                                                                        |
	| https://www.yaleappliance.com/kitchen/refrigeration-appliances/counter-depth/french-door/   |


Scenario Outline: Bottom Navigation 
Given User wants to go the previous/next page '<Page>'
When User clicks on any of the '<Navigation>'
Then The corresponding page should show '<Navigation>'
	Examples: 
	| Page                                                                                      | Navigation |
	| https://www.yaleappliance.com/kitchen/refrigeration-appliances/counter-depth/french-door/ | Previous   |
    | https://www.yaleappliance.com/kitchen/refrigeration-appliances/counter-depth/french-door/ | Number    |
    | https://www.yaleappliance.com/kitchen/refrigeration-appliances/counter-depth/french-door/ | Next      |

