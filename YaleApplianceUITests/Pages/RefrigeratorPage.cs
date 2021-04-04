using System;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using TechTalk.SpecFlow;
using YaleApplianceUITests.Factories;
using YaleApplianceUITests.Fixtures;
using YaleApplianceUITests.SharedLibrary.Interfaces;
using YaleApplianceUITests.SharedLibrary.Services;

namespace YaleApplianceUITests.Pages
{
    public class RefrigeratorPage
    {
        private readonly EnvironmentFixture _environmentFixture;
        private readonly WebDriverContext _webDriverContext;
        private readonly IWebActions _webActions;
        private readonly WebDriverWait _wait;
        private readonly ScenarioContext _scenarioContext;

        public RefrigeratorPage(WebDriverContext webDriverContext, EnvironmentFixture environmentFixture)
        {
            _environmentFixture = environmentFixture;
            _webDriverContext = webDriverContext;
            _webActions = new WebActions(_webDriverContext);
            _wait = new WebDriverWait(_webDriverContext.Driver, TimeSpan.FromSeconds(10));

        }

        #region Locators

        private static readonly By _closePopUp = By.CssSelector("#om-z3df03lhtmhoa1j1vtdj-optin > div > button > svg > path");
        private static readonly By _popUpBtn = By.CssSelector("#bakersfield-ButtonElement--9V7TsM2j7LkTgGSHPmpL");
        private readonly By _counterDepthBtn = By.XPath("/html/body/div[1]/div/section/div/div[2]/div[1]/a/div");
        private readonly By _frenchDoorBtn = By.XPath("/html/body/div[1]/div/section/div/div[2]/ul[2]/li[1]/a/b");
        private readonly By _getItNowBtn = By.CssSelector("#products-list-container > div > div:nth-child(1) > div > div.catalogue-item__body > div > p.catalogue-item__info-cta > a");
        private readonly By _getItNow = By.CssSelector("#NormalCheckout");
        private readonly By _refrigeratorType = By.CssSelector("body > div.main-wrapper > div > section > div > div.appliances > div:nth-child(1) > ul > li:nth-child(2) > a");
        private readonly By _viewRefrigeratorForDeliveryOptions = By.CssSelector("body > div.main-wrapper > div > div.trending-product-gall > div.trending-product-gall__wrapper.slick-initialized.slick-slider > div.slick-list.draggable > div > div:nth-child(5) > a");
        private readonly By _personalPickUp = By.CssSelector("#delivery-methods > div > label:nth-child(4) > div > div.deliveryItem_header > div > input[type=radio]");
        private readonly By _sameDay = By.CssSelector("#delivery-methods > div > label:nth-child(4) > div > div.deliveryItem_header > div > input[type=radio]");

        #endregion


        private IWebElement ClosePopUP => _webDriverContext.Driver.FindElement(_closePopUp);

        private IWebElement PopUpBtn => _webDriverContext.Driver.FindElement(_popUpBtn);

        private IWebElement CounterDepthBtn => _webDriverContext.Driver.FindElement(_counterDepthBtn);

        private IWebElement FrenchDoorBtn => _webDriverContext.Driver.FindElement(_frenchDoorBtn);

        private IWebElement GetItNowBtn => _webDriverContext.Driver.FindElement(_getItNowBtn);

        private IWebElement GetItNow => _webDriverContext.Driver.FindElement(_getItNow);

        private IWebElement RefrigeratorType => _webDriverContext.Driver.FindElement(_refrigeratorType);

        private IWebElement ViewRefrigeratorForDeliveryOptions => _webDriverContext.Driver.FindElement(_viewRefrigeratorForDeliveryOptions);

        private IWebElement PersonalPickUp => _webDriverContext.Driver.FindElement(_personalPickUp);

        private IWebElement SameDay => _webDriverContext.Driver.FindElement(_sameDay);


        public RefrigeratorPage GoToRefrigeratorPageUrl()
        {
            _webDriverContext.Driver.Navigate().GoToUrl(_environmentFixture.Environment.RefrigeratorPageUrl);
            return this;
        }


        public RefrigeratorPage ClickAddToCartBtn()
        {

            //((IJavaScriptExecutor)_webDriverContext.Driver).ExecuteScript("window.scrollTo(0, document.body.scrollHeight - 150");
            Thread.Sleep(TimeSpan.FromSeconds(3));
            ((IJavaScriptExecutor)_webDriverContext.Driver).ExecuteScript("arguments[0].scrollIntoView(true);", CounterDepthBtn);
            _webActions.MoveTo(_webDriverContext.Driver,CounterDepthBtn,CounterDepthBtn);
           ((IJavaScriptExecutor)_webDriverContext.Driver).ExecuteScript("arguments[0].scrollIntoView(true);", FrenchDoorBtn);
            FrenchDoorBtn.Click();
            ((IJavaScriptExecutor)_webDriverContext.Driver).ExecuteScript("arguments[0].scrollIntoView(true);", GetItNowBtn);
            GetItNowBtn.Click();
            return this;
        }

        public RefrigeratorPage GoToYalesRefrigeratorPageUrl()
        {
            _webDriverContext.Driver.Navigate().GoToUrl(_environmentFixture.Environment.YaleApplianceHomePageUrl);
            return this;
        }

        public RefrigeratorPage ViewRefrigeratorForMultipleDeliveryOptions()
        {
            ((IJavaScriptExecutor)_webDriverContext.Driver).ExecuteScript("arguments[0].scrollIntoView(true);", ViewRefrigeratorForDeliveryOptions);
            _webActions.MoveTo(_webDriverContext.Driver, ViewRefrigeratorForDeliveryOptions, ViewRefrigeratorForDeliveryOptions);
            return this;
        }


        public RefrigeratorPage AddToCartBtn()
        {
            Thread.Sleep(TimeSpan.FromSeconds(3));
            ((IJavaScriptExecutor)_webDriverContext.Driver).ExecuteScript("arguments[0].scrollIntoView(true);", GetItNow);
            GetItNow.Click();
            return this;
        }


        public RefrigeratorPage SelectPersonalPickupDelivery()
        {
            ((IJavaScriptExecutor)_webDriverContext.Driver).ExecuteScript("arguments[0].scrollIntoView(true);", PersonalPickUp);
            PersonalPickUp.Click();
            return this;
        }

        public RefrigeratorPage SelectSameDayDelivery()
        {
            ((IJavaScriptExecutor)_webDriverContext.Driver).ExecuteScript("arguments[0].scrollIntoView(true);", SameDay);
            SameDay.Click();
            return this;

        }
    }

}



