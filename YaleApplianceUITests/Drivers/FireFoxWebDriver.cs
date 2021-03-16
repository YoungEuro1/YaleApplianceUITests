using System;
using System.IO;
using System.Reflection;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace YaleApplianceUITests.Drivers
{
    public class FireFoxWebDriver : IDrivers
    {
        public IWebDriver Driver { get; set; }

        public FireFoxWebDriver()
        {
            var options = new FirefoxOptions();
            options.AddArguments("--headless");

            options.AcceptInsecureCertificates.GetValueOrDefault(true);
            var codeBase = Assembly.GetExecutingAssembly().CodeBase;
            var uri = new UriBuilder(codeBase);
            var path = Uri.UnescapeDataString(uri.Path);
            var directoryPath = Path.GetDirectoryName(path);
            var service = FirefoxDriverService.CreateDefaultService(directoryPath, "geckodriver.exe");

            try
            {
                service.Start();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
      
            this.Driver = new FirefoxDriver(service, options);

        }
    }
}

