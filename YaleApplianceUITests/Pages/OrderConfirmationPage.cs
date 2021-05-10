using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
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
       
        public OrderConfirmationPage(WebDriverContext webDriverContext, EnvironmentFixture environmentFixture)
        {
            _environmentFixture = environmentFixture;
            _webDriverContext = webDriverContext;
            _webActions = new WebActions(_webDriverContext);
            _wait = new WebDriverWait(_webDriverContext.Driver, TimeSpan.FromSeconds(10));
        }

        #region Locators
        private readonly By _orderConfirmationMsg = By.CssSelector("body>div.main-wrapper>div>div.cart>div>div>div.page-thanks__mainTitle");
        private readonly  By _deliveryConfirmation = By.CssSelector("body>div.main-wrapper>div>div.cart>div>div>div.page-thanks__wrapp>div.page-thanks__advantages > div:nth-child(2)>div>p");
        #endregion

        #region PageElements

        #endregion

        public IWebElement OrderConfirmationMsg => _webDriverContext.Driver.FindElement(_orderConfirmationMsg);

        public IWebElement DeliveryConfirmation => _webDriverContext.Driver.FindElement(_deliveryConfirmation);


        public OrderConfirmationPage OrderConfirmationMessage()
        {
            _webActions.WaitForUrlToContains(_webDriverContext.Driver, "thank-you",_wait);
            Assert.That(OrderConfirmationMsg.Displayed.Equals(true));
           // _webDriverContext.Driver.Close();
            return this;
        }
    }
}