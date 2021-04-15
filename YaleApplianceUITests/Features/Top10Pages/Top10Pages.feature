Feature: Top10Pages
	Smoke Test pack 
	As a Yale user
	I want to ensure that the top10 pages are online and functional 

@smoke
Scenario Outline: Perform Health Check On HomePage
	Given User is on the Yale HomePage'<page>'
	When Page is fully loaded 
	Then User should be able to interact with page accordingly'<page>'
	Examples:
	|page                       |
	| http://www.yaleappliance.com/ |