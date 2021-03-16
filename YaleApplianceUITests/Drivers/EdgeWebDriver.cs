using OpenQA.Selenium;
using OpenQA.Selenium.Edge;

namespace YaleApplianceUITests.Drivers
{
    public class EdgeWebDriver : IDrivers
    {

        private IWebDriver Driver { get; set; }

        public EdgeWebDriver Edge()
        {
            var options = new EdgeOptions();
            options.AddAdditionalCapability("intl.accept_languages", "en-Gb");
            options.PageLoadStrategy = PageLoadStrategy.None;
            //var proxy = new Proxy {Kind = ProxyKind.Direct};
            //  var codeBase = Assembly.GetExecutingAssembly().CodeBase;
            //  var uri = new UriBuilder(codeBase);
            // var path = Uri.UnescapeDataString(uri.Path);
            // var directoryPath = Path.GetDirectoryName(path);
            // var executableFileName = Path.GetFileName(path);
            this.Driver = new EdgeDriver(options);
            return this;
        }
    }
}


