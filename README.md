# YaleApplianceUITests

Extensibility

YaleAppliance UI test framework is designed in a flexible and extensibility manner whereby tests can point to any environment.

The test Framework is created as a dotnet core project  for future proof purposes in case tests will need to be run on a PAAS environment, packages needed to support this will most likely require project to be built in .NetCore.



Browser Configuration

In the EnvironmentData.Json file, set browser configuration of choice 'Chrome' or 'Edge' before running tests locally



Local Configuration

Edge driver version installed is 89.0.774.54, ensure your local edge browser is compatible with this driver version (if running tests locally). https://developer.microsoft.com/en-us/microsoft-edge/tools/webdriver/

Chrome driver version installed  is 89 which supports all Chrome browser 89 versions - ensure your local version is compatible if running test locally http://chromedriver.chromium.org/downloads?



Feature files

Extend business use case coverage using spec flow feature files per feature area. Scenarios created within the feature file should be synonymous to the feature Specflow is a BDD/Cucumber tool that allows one to write business requirements in an readable/ non technical readable manner using Gherkin principals. Specflow enables you to write ATTD tests and serves as a great tool for test case management purposes aswell.

Page Object Model Pages that are transitioned during a user's checkout journey are represented as it's own object/class. Within the classes are various elements required to be captured for the use case journeys. Page elements are identified by using various selenium locator methods i.e By (Id,Css,JsPath and Xpath)

CI

Build agents may need some provisioning to ensure that browsers are compatible with the Web Drivers.

Note : currently only chrome and edge is supported as I'm working on a windows machine. If you would like tests to run against all platforms agnostically i.e (windows/mac supported browsers) I can integrate the test framework to run remotely on a cloud hosted platform whereby you can choose browser and O/S of your choice and. The cloud hosted automated platforms is a paid subscription service which will require a subscription plan with the provider if you

