# YaleApplianceUITests

Extensibility

YaleApplianceUI test framework is designed in a flexible and exensibility manner whereby tests can point to any environment within your toplogy. Also
test data can easily be native to an environemnt by using the Environment model. 


Framework is created in dotnet core for future proof purposes in case tests will need to be run on a PAAS environment, packages needed to support this will most likely 
require project to be built in .NetCore.  


Browser Configuration

In the EnvironmentData.Json file, set browser configuration of choice 'Chrome' or 'Edge' before runing tests locally 


Local Configuration

Edge driver version is 89.0.774.54, ensure your local edge browser is compatible with this driver version (if running tests locally).
https://developer.microsoft.com/en-us/microsoft-edge/tools/webdriver/


Chrome driver version is 89 which supports all Chrome browser 89 versions - ensure your local version is compatiable if running test locally 
http://chromedriver.chromium.org/downloads?


Feature files 


Extend business use case coverage using specflow feature files per feature area. 


CI 

Build agents may need some provisisoning to ensure that browsers are compatiable with the webdrivers.



Note : currently only chrome and edge is supported as im working on a windows machine. If you would like tests to run against all platforms agnostically 
i.e (windows/mac supported browsers) I can integrate the test framework to run remotely on a cloud hosted platform whereby you can choose browser and O/S of your choice and. 
The cloud hosted automated platforms is a paid subscription service which will require a subscription plan with the provider if you choose to go down this route. 


