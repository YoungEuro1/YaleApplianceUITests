using System;
using System.IO;
using System.Reflection;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace YaleApplianceUITests.Drivers
{
    public class ChromeWebDriver : IDrivers
    {
        private IWebDriver Driver { get; set; }

        public ChromeWebDriver Chrome()
        {

            var options = new ChromeOptions();
            options.AddArgument("--lang=en");
            options.AddArgument("--ignore-certificate-errors");
            options.AddArgument("--disable-extensions");
            options.AddArgument("--disable-dev-shm-usage");
            //options.AddArgument("--headless");
            options.AddArgument("--disable-gpu");
            options.AddArgument("--no-sandbox");
            options.AddArgument("--enable-logging");
            //var proxy = new Proxy {Kind = ProxyKind.Direct};
            //var codeBase = Assembly.GetExecutingAssembly().CodeBase;
            //var uri = new UriBuilder(codeBase);
            //var path = Uri.UnescapeDataString(uri.Path);
            //var directoryPath = Path.GetDirectoryName(path);
            // this.Driver = new RemoteWebDriver(service.ServiceUrl, capOptions);

            var codeBase = Assembly.GetExecutingAssembly().CodeBase;
            var uri = new UriBuilder(codeBase);
            var path = Uri.UnescapeDataString(uri.Path);
            var directoryPath = Path.GetDirectoryName(path);
            this.Driver = new ChromeDriver(directoryPath + "\\drivers", options);
            return this;

        }
    }
}
