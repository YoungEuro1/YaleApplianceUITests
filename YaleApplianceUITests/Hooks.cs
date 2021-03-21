using BoDi;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using YaleApplianceUITests.Factories;
using YaleApplianceUITests.Fixtures;


namespace YaleApplianceUITests
{
    [Binding]
    public sealed class Hooks
    {
        
        private static IObjectContainer _objectContainer;
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
            _objectContainer.RegisterInstanceAs<WebDriverContext>(_webDriverContext,"",true);
            
        }


        [BeforeTestRun]
        public static void RunBeforeAllTests()
        {
            _webDriverContext = new WebDriverContext();
        }



        [AfterScenario()]
        public static void AfterScenario()
        {
            var driver = _objectContainer.Resolve<WebDriverContext>();
            driver?.Driver.Close();
            driver?.Driver.Quit();
            driver?.Driver.Dispose();
        }


    }
}
