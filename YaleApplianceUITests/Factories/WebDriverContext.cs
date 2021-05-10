using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using Microsoft.Edge.SeleniumTools;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
//using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Remote;
using TechTalk.SpecFlow;
using YaleApplianceUITests.Steps;
using EdgeDriverService = Microsoft.Edge.SeleniumTools.EdgeDriverService;
using EdgeOptions = Microsoft.Edge.SeleniumTools.EdgeOptions;


namespace YaleApplianceUITests.Factories
{
    [Binding]
 
    public class WebDriverContext:BaseSteps
    {
        public IWebDriver Driver { get; set; }

        public WebDriverContext() : base()
        {
            SwitchToBrowser(EnvironmentFixture.Environment.Browser);
        }

       #region WebDrivers

 
        private WebDriverContext Chrome()
        {

            var options = new ChromeOptions();
            options.AddArgument("--incognito");
            options.AddArgument("--start-maximized");
            options.AddArgument("--lang=en");
            options.AddArgument("--ignore-certificate-errors");
            options.AddArgument("--disable-extensions");
            options.AddArgument("--disable-dev-shm-usage");
            //options.AddArgument("--headless");
            options.AddArgument("--disable-gpu");
            options.AddArgument("--no-sandbox");
            options.AddArgument("--enable-logging");
            var codeBase = Assembly.GetExecutingAssembly().CodeBase;
            var uri = new UriBuilder(codeBase);
            var path = Uri.UnescapeDataString(uri.Path);
            var directoryPath = Path.GetDirectoryName(path);
            this.Driver = new ChromeDriver(directoryPath + "\\drivers", options, TimeSpan.FromSeconds(60));
            Driver.Manage().Cookies.DeleteAllCookies();
            Driver.Manage().Window.Maximize();
            return this;
        }


        private WebDriverContext Edge()
        {
            var options = new EdgeOptions {UseInPrivateBrowsing = true};
            //options.AddArgument("headless");
            var codeBase = Assembly.GetExecutingAssembly().CodeBase;
            var uri = new UriBuilder(codeBase);
            var path = Uri.UnescapeDataString(uri.Path);
            var directoryPath = Path.GetDirectoryName(path);
            var service = EdgeDriverService.CreateDefaultService(directoryPath + "\\drivers", "msedgedriver.exe");
            service.UseVerboseLogging.Equals(true);
            this.Driver = new EdgeDriver(service,options);
            Driver.Manage().Window.Maximize();
            Driver.Manage().Cookies.DeleteAllCookies();
            return this;
        }


        private WebDriverContext Saucelabs()
        {
            var chromeOptions = new ChromeOptions();
            chromeOptions.AddAdditionalCapability("username", "YoungEuro1", true);
            chromeOptions.AddAdditionalCapability("accessKey", "2737fdc8-bc04-4275-8ebe-9bf0f3d623ae", true);
            chromeOptions.AddAdditionalCapability("platform", "Windows 10", true);
            chromeOptions.AddAdditionalCapability("version", "latest", true);
            chromeOptions.AddAdditionalCapability("maxInstances","100", true);
            chromeOptions.AddAdditionalCapability("commandTimeout", "600", true);
            chromeOptions.AddAdditionalCapability("maxDuration", "1200", true);
            chromeOptions.AddAdditionalCapability("name", "UI Regression Test Suite", true);
            chromeOptions.AddAdditionalCapability("idleTimeout", "5", true);
            this.Driver = new RemoteWebDriver(new Uri("https://YoungEuro1:2737fdc8-bc04-4275-8ebe-9bf0f3d623ae@ondemand.eu-central-1.saucelabs.com:443/wd/hub"), chromeOptions.ToCapabilities());

           // { maxInstances: 100, seleniumVersion: "3.5.3", chromedriverVersion: "2.32", commandTimeout: 600, maxDuration: 1200 }
            return this;
        }
        
         #endregion

         private WebDriverContext SwitchToBrowser(string browser)
         {
             Environment.GetEnvironmentVariable("browser", EnvironmentVariableTarget.Process);
             browser = EnvironmentFixture.Environment.Browser;
             switch (browser.ToLower())
             {
                 case "chrome":
                     return Chrome();
                 case "edge":
                     return Edge();
                 case "saucelabs":
                     return Saucelabs();
                default:
                     throw new Exception(
                         $"{browser} browser name is not supported in this test framework");
             }
         }

    }
}






