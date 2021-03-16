using BoDi;
using OpenQA.Selenium.Support.UI;
using TechTalk.SpecFlow;
using YaleApplianceUITests.Factories;
using YaleApplianceUITests.Fixtures;
using YaleApplianceUITests.Helpers;


namespace YaleApplianceUITests
{
    [Binding]
    public sealed class Hooks
    {
        
        private readonly IObjectContainer _objectContainer;
        // private readonly ScenarioContext _scenarioContext;
        private static EnvironmentFixture _environmentFixture;
        private static WebDriverWait _wait;
        private static WebDriverContext _webDriverContext;
        private static BrowserHelper _browserHelper;



        public Hooks(IObjectContainer objectContainer, EnvironmentFixture environmentFixture)
        {
            _objectContainer = objectContainer;
            // _scenarioContext = scenarioContext;
            _environmentFixture = environmentFixture;
            _browserHelper = new BrowserHelper(_environmentFixture);

        }


        [BeforeScenario]
        public void BeforeScenario()
        {
            _objectContainer.RegisterInstanceAs<WebDriverContext>(_webDriverContext);
        }


        [BeforeTestRun]
        public static void RunBeforeAllTests()
        {
            _webDriverContext = new WebDriverContext();
        }



        [AfterScenario]
        public void AfterScenario()
        {
            var driver = _objectContainer.Resolve<WebDriverContext>();
            driver?.Driver.Quit();
            driver?.Driver.Dispose();
        }

    }
}
