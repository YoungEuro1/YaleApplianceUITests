using BoDi;
using OpenQA.Selenium.Support.UI;
using TechTalk.SpecFlow;
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
            _objectContainer.RegisterInstanceAs<BrowserHelper>(_browserHelper);
        }



        [BeforeTestRun]
        public static void RunBeforeAllTests(string browser)
        {
            browser = _environmentFixture.Environment.Browser;
            _browserHelper = new BrowserHelper(_environmentFixture);
        }



        [AfterScenario]
        public void AfterScenario()
        {
            var driver = _objectContainer.Resolve<BrowserHelper>();
            driver?.Driver.Quit();
            driver?.Driver.Dispose();
        }

    }
}
