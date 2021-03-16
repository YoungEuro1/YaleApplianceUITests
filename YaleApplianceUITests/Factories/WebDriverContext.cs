using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace YaleApplianceUITests.Factories
{

    public class WebDriverContext
    {
        public IWebDriver Driver { get; set; }

        public WebDriverContext()
        {

            //Chrome must be in system path to run
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

            // this.Driver = new ChromeDriver(uri, options, TimeSpan.FromSeconds(200));
            //return ChromeWebDriver(uri);
            // return Driver;
            // return new ChromeDriver();
        }
    }
}


