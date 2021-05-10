﻿using System;
using OpenQA.Selenium.Support.UI;
using YaleApplianceUITests.Factories;
using YaleApplianceUITests.Fixtures;
using YaleApplianceUITests.SharedLibrary.Interfaces;
using YaleApplianceUITests.SharedLibrary.Services;

namespace YaleApplianceUITests.Pages
{
    public class ScheduleAVideoCallPage
    {
        private readonly EnvironmentFixture _environmentFixture;
        private readonly WebDriverContext _webDriverContext;
        private readonly IWebActions _webActions;
        private readonly WebDriverWait _wait;


        public ScheduleAVideoCallPage(WebDriverContext webDriverContext, EnvironmentFixture environmentFixture)
        {
            _environmentFixture = environmentFixture;
            _webDriverContext = webDriverContext;
            _webActions = new WebActions(_webDriverContext);
            _wait = new WebDriverWait(_webDriverContext.Driver, TimeSpan.FromSeconds(10));
        }


        #region Locators
        #endregion

        #region PageElements
        #endregion


        public ScheduleAVideoCallPage PageValidation()
        {
            _webActions.WaitUntilDocumentIsReady(_webDriverContext.Driver, TimeSpan.FromSeconds(10));
            _webActions.WaitForUrlToContains(_webDriverContext.Driver, "https://www.yaleappliance.com/Schedule/Time?appointmentId", _wait);
            return this;
        }
    }
}