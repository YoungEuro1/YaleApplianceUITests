using System;
using System.IO;
using System.Reflection;
using OpenQA.Selenium;
using YaleApplianceUITests.Drivers;
using YaleApplianceUITests.Fixtures;


namespace YaleApplianceUITests.Helpers
{
   public  class BrowserHelper
    {
        private readonly EnvironmentFixture _environmentFixture;
        public IWebDriver Driver { get; set; }

        public BrowserHelper(EnvironmentFixture environmentFixture) 
        {
            _environmentFixture = environmentFixture;

        }

        public static IDrivers GetDriver()
        {
            var browser = Environment.GetEnvironmentVariable(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));

            switch (browser.ToLower())
            {
                case "chrome":
                    return new ChromeWebDriver();
                case "firefox":
                    return new FireFoxWebDriver();
                case "edge":
                    return new EdgeWebDriver();
                default:
                    throw new Exception(
                        $"{browser} browser is not supported");
            }
        }
    }
}
