﻿using System;
using System.Diagnostics;
using System.Threading;
using BoDi;
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
            _objectContainer.RegisterInstanceAs(_webDriverContext);
        }


        [BeforeTestRun]
        public static void RunBeforeAllTests()
        {
            _webDriverContext = new WebDriverContext();
        }


        [AfterTestRun()]
        private static void KillProcess()
        {
            var driver = _objectContainer.Resolve<WebDriverContext>();
            driver?.Driver.Close();
            driver?.Driver.Dispose();
            driver?.Driver.Quit();

            String taskKill = "taskkill.exe";
            string chrome = "/F /IM chrome.exe*";
            string chromeDriver = "/F /IM chromedriver.exe*";
            string msedgeDriver = "/F /IM msedgedriver.exe*";
            string edge = "/F /IM  msedge.exe*";
           // Process.Start(taskKill, chrome);
            Process.Start(taskKill, chromeDriver);
            Process.Start(taskKill, msedgeDriver);
            Process.Start(taskKill, edge);
            Thread.Sleep(5000); //Allow OS to kill the process 
        }
    }
}
