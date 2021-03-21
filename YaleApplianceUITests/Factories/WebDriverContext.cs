using System;
using System.IO;
using System.Reflection;
using Microsoft.Edge.SeleniumTools;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using YaleApplianceUITests.Steps;


namespace YaleApplianceUITests.Factories
{
 
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
           // options.AddArgument("--incognito");
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
            return this;
        }


        private WebDriverContext Edge()
        {
            var options = new EdgeOptions();
            options.AddAdditionalCapability("InPrivate", true);
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
        
         #endregion

         private WebDriverContext SwitchToBrowser(string browser)
         {
            Environment.GetEnvironmentVariable("browser", EnvironmentVariableTarget.Process);
            browser = EnvironmentFixture.Environment.Browser;
            switch (browser.ToLower())
            {
                case "chrome":
                    return  Chrome();
                case "edge":
                    return Edge();
                default:
                    throw new Exception(
                        $"{browser} browser name is not supported in this test framework");

            }
        }
    }

}




