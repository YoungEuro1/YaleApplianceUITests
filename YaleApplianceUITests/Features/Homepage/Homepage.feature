@homepage
Feature: Homepage
	As a yale user 
	I expect all links and buttons to work and to redirect me accordingly 


Scenario: Go To Schedule A Showroom Visit Page
	Given User is on the homepage
	When User clicks on schedule a showroom visit 
	Then User should be directed to schedule a showroom visit page 


Scenario: Go To Schedule A Video Call Page
	Given User is on the homepage
	When User clicks on schedule a video call
	Then User should be directed to schedule a video call page 
	
Scenario: More Information about video calling
    Given User is on the homepage
    Then  User should be able to click on question mark under video call  

Scenario: Chat Now
    Given User is on the homepage
    Then  User should be able to click the chat now button

Scenario: User Wants To Shop Online
	Given User is on the homepage
	When User clicks on the Shop Online button 
	Then User should be directed to the catalog page


Scenario: COVID safety banner 
	Given User is on the homepage
	When  User clicks on covid banner
	Then Page should direct user to covid safety page


Scenario Outline: Product categories 
	Given User is on the homepage
	When User clicks on view products '<picture>'
    Then Page should direct user to category page '<category>'
	Examples: 
	| picture  | category |
	| Kitchen  | Kitchen  |
	| Laundry  | Laundry  |
	| Lighting | Lighting |
	| Bbq      | Bbq      |
	| Plumbing | Plumbing |
	| Packages | Packages |

	
Scenario: Shop in stock
	Given User is on the homepage
	When User clicks on explore product 
	Then Page should direct user to product item 

	
Scenario: Navigate Shop in stock using arrows
	Given User is on the homepage
	When  User clicks on arrows to navigate next/previous  
	Then Page should go the next or previous item


Scenario: Visit Oulet
	Given User is on the homepage
	When  User clicks on on visit outlet   
	Then Page should direct user to the outlet page

Scenario Outline: Product categories picture
	Given User is on the homepage
	When User clicks on a picture '<picture>'
    Then Page should direct user to category page '<category>'
	Examples: 
	| picture  | category |
	| Kitchen  | Kitchen  |
	| Laundry  | Laundry  |
	| Lighting | Lighting |
	| Bbq      | Bbq      |
	| Plumbing | Plumbing |
	| Packages | Packages |

 
 Scenario Outline: Learn more about the services Yale offers
 Given User is on the homepage 
 When User clicks on Learn more '<LearnMore>'
 Then Page should direct user to clicked linked '<Page>'
	Examples: 
	| LearnMore         | Page                                          |
	| Service           | https://www.yaleappliance.com/service         |
	| Install           | https://www.yaleappliance.com/installation    |
	| Same Day Delivery | https://www.yaleappliance.com/delivery-policy |


Scenario Outline: Schedule a showroom visit 

Given User is on the homepage  
When User clicks on Schedule appointment '<ScheduleAppointment>'
Then Page should direct user to the appointment page '<Page>'

	Examples: 
	| ScheduleAppointment        | Page                                          |
	| Framingham Showroom        | https://www.yaleappliance.com/schedule        |
	| Hanover Showroom           | https://www.yaleappliance.com/schedule        |
	| Dorchester Showroom        | https://www.yaleappliance.com/schedule        |


@ignore ///Blocked by YALEDEV-2115
Scenario: Yale map
	Given User is on the homepage
	When  User clicks on pinpoint icon on map 
	Then  Address popup should appear 