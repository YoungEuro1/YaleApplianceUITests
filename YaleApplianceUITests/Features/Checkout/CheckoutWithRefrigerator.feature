@checkout @refrigerator
Feature: CheckoutWithRefrigerator
	Upon landing on the refrigerator product page 
	As a customer 
	I should be able to add a product(s) to my cart
	And select any delivery add ons to my cart
	And go through the checkout process successfully. 


Scenario Outline: Place an Order
	Given User is on a refrigerator page
	And   Refrigerator is added to cart
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
	| Discover         |



	

Scenario Outline: Place an Order For Same Day Delivery  
	Given User is on the yale's refrigerator page
	And   Refrigerator available for same day delivery is added to cart
	And   Billing details are added
	And   Payment details are added '<paymenttype>'
	When  Placing Order
	Then  Order should be placed successfully
	Examples: 
	| paymenttype      |
	| Visa             |


		

Scenario Outline: Place an Order For Personal Pickup
	Given User is on the yale's refrigerator page
	And   Refrigerator available for personal pickup is added to cart
	And   Billing details are added
	And   Payment details are added '<paymenttype>'
	When  Placing Order
	Then  Order should be placed successfully
	Examples: 
	| paymenttype      |
	| Visa             |



