Feature: Checkout
	Upon landing on a product page 
	As a customer 
	I should be able to add products to my cart
	And go through the checkout process successfully. 

@checkout
Scenario Outline: Place an Order 
	Given User is on a product page
	And   Product is added to cart
	And   Delivery details are added
	And   Billing details are added
	And   Payment details are added '<paymenttype>'
	When  Placing Order
	Then  Order should be placed successfully
	Examples: 
	| paymenttype      |
	| Visa             |
	| Mastercard       |
	| American Express |
	| Yale Card        |
	| Discover        |
