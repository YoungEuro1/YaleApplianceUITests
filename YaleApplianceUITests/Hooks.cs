using BoDi;
using TechTalk.SpecFlow;
using YaleApplianceUITests.Factories;
using YaleApplianceUITests.Fixtures;


namespace YaleApplianceUITests
{
    [Binding]
    public sealed class Hooks
    {
        
        private readonly IObjectContainer _objectContainer;
        private static  ScenarioContext _scenarioContext;
        private static EnvironmentFixture _environmentFixture;
        private static WebDriverContext _webDriverContext;



        public Hooks(IObjectContainer objectContainer, EnvironmentFixture environmentFixture, ScenarioContext scenarioContext)
        {
            _objectContainer = objectContainer;
            _scenarioContext = scenarioContext;
            _environmentFixture = environmentFixture;
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
