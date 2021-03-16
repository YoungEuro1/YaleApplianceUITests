using System.Collections.Generic;
using OpenQA.Selenium;
using YaleApplianceUITests.Factories;
using YaleApplianceUITests.Fixtures;
using YaleApplianceUITests.SharedLibrary.Interfaces;
using YaleApplianceUITests.SharedLibrary.Services;


namespace YaleApplianceUITests.Pages
{
    public class CheckoutPage
    {
        private readonly EnvironmentFixture _environmentFixture;
        private readonly WebDriverContext _webDriverContext;
        private readonly IWebActions _webActions;
        

        public CheckoutPage(WebDriverContext webDriverContext, EnvironmentFixture environmentFixture)
        {
            _environmentFixture = environmentFixture;
            _webDriverContext = webDriverContext;
            _webActions = new WebActions();
        }

        #region Locator
        private readonly By _getItNowBtn = By.Id("NormalCheckout");

        #endregion

        public IWebElement GetItNowBtn => _webDriverContext.Driver.FindElement(_getItNowBtn);
     

        public CheckoutPage GoToCheckoutPage()
        {
            _webDriverContext.Driver.Navigate().GoToUrl(_environmentFixture.Environment.CheckoutUrl);
            return this;
        }

        public CheckoutPage ClickGetItNowBtn()
        {
            _webActions.Click(GetItNowBtn);
            return this;
        }


        public CheckoutPage EnterBillingAddress()
        {
            return this;
        }

      

       


    }

}

   

