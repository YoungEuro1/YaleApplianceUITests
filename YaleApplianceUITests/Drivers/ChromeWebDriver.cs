using System;
using System.IO;
using System.Reflection;
using Dynamitey;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace YaleApplianceUITests.Drivers
{
    public class ChromeWebDriver : IDrivers
    {
        private static IWebDriver Driver { get; set; }

        public ChromeWebDriver()
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
            Driver = new ChromeDriver(directoryPath + "\\drivers", options);
  

        }
    }
}
