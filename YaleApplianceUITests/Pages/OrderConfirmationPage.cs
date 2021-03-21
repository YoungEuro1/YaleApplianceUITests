using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using TechTalk.SpecFlow;
using YaleApplianceUITests.Factories;
using YaleApplianceUITests.Fixtures;
using YaleApplianceUITests.SharedLibrary.Interfaces;
using YaleApplianceUITests.SharedLibrary.Services;

namespace YaleApplianceUITests.Pages
{
    public class OrderConfirmationPage
    {
        private readonly EnvironmentFixture _environmentFixture;
        private readonly WebDriverContext _webDriverContext;
        private readonly IWebActions _webActions;
        private readonly WebDriverWait _wait;
        private readonly ScenarioContext _scenarioContext;

        public OrderConfirmationPage(WebDriverContext webDriverContext, EnvironmentFixture environmentFixture)
        {
            _environmentFixture = environmentFixture;
            _webDriverContext = webDriverContext;
            _webActions = new WebActions(_webDriverContext);
            _wait = new WebDriverWait(_webDriverContext.Driver, TimeSpan.FromSeconds(10));

        }

        #region Locator

        private readonly By _orderConfirmationMsg = By.CssSelector("body > div.main-wrapper > div > div.cart > div > div > div.page-thanks__mainTitle");

        #endregion


        public IWebElement OrderConfirmationMsg => _webDriverContext.Driver.FindElement(_orderConfirmationMsg);



        public OrderConfirmationPage OrderConfirmationMessage()
        {
            Assert.That(OrderConfirmationMsg.Displayed.Equals(true));
            Assert.That(_webDriverContext.Driver.Url.Contains("https://www.yaleappliance.com/shopping-cart/thank-you"));
            return this;
        }
    }
}
