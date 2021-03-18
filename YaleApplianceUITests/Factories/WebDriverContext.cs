using System;
using System.IO;
using System.Reflection;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using YaleApplianceUITests.Fixtures;


namespace YaleApplianceUITests.Factories
{

    public class WebDriverContext
    {
        private readonly EnvironmentFixture _environmentFixture;
        public IWebDriver Driver { get; set; }

        public WebDriverContext(EnvironmentFixture environmentFixture)
        {
            _environmentFixture = environmentFixture;

            SwitchToBrowser(_environmentFixture.Environment.Browser);
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
            this.Driver = new ChromeDriver(directoryPath + "\\drivers", options);
            return this;
        }


        private WebDriverContext Edge()
        {

            return this;
        }
    
    
         #endregion



    private WebDriverContext SwitchToBrowser(string browser)
        {
            browser = _environmentFixture.Environment.Browser;
            switch (browser)
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



