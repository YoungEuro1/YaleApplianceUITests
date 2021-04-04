@checkout @dishwasher
Feature: CheckoutWithDishwasher
	Upon landing on the dishwasher product page 
	As a customer 
	I should be able to add a product(s) to my cart
	And select any delivery add ons to my cart
	And go through the checkout process successfully. 


Scenario Outline: Place an Order for Dishwasher and Installation 
Given User is on the dishwasher product page
And Dishwasher is added to cart
And Installation is added to cart
And Billing details are added
And Payment details are added '{paymentType}'
When Placing Order
Then Order should be placed successfully
Examples: 
| paymenttype      |
| Visa             |




