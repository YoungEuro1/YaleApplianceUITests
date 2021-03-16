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
	And   Billing details <paymenttype> are added
	And   Payment detils are added
	When  Placing Order
	Then  Order should be placed sucessfully
	Examples: 
	| paymenttype      |
	| visa             |
	| mastercard       |
	| american express |
	| yale card        |
	| discouver        |
