using System;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Support.UI;
using YaleApplianceUITests.Factories;
using YaleApplianceUITests.Fixtures;
using YaleApplianceUITests.SharedLibrary.Interfaces;
using YaleApplianceUITests.SharedLibrary.Services;


namespace YaleApplianceUITests.Pages
{
    public class CheckoutPage
    {
        private readonly EnvironmentFixture _environmentFixture;
        private static WebDriverContext _webDriverContext;
        private static IWebActions _webActions;
        private WebDriverWait _wait;


        public CheckoutPage(WebDriverContext webDriverContext, EnvironmentFixture environmentFixture)
        {
            _environmentFixture = environmentFixture;
            _webDriverContext = webDriverContext;
            _webActions = new WebActions(_webDriverContext);
            _wait = new WebDriverWait(_webDriverContext.Driver, TimeSpan.FromSeconds(10));
        }

        #region Locators

        private static readonly By _getItNowBtn = By.Id("NormalCheckout");

        private readonly By _zipCodeTxt = By.ClassName("zip-code__input");

        private readonly By _zipCodeSubmitBtn = By.CssSelector("#zip-code-form > div.zip-code__submitblock > div");


        private const string ChooseProfessionalDeliveryBtnClick =
            "document.querySelector(\"#delivery-methods > div > label:nth-child(3) > div > div.deliveryItem_header > div > input[type=radio]\").click()";

        private readonly By _popUp = By.CssSelector("#bakersfield-ButtonElement--9V7TsM2j7LkTgGSHPmpL");

        private static readonly By _closePopUp = By.CssSelector("#om-z3df03lhtmhoa1j1vtdj-optin > div > button > svg > path");

        private IWebElement PopUP => _webDriverContext.Driver.FindElement(_popUp);

        private static IWebElement ClosePopUP => _webDriverContext.Driver.FindElement(_closePopUp);


        #endregion

        public static IWebElement GetItNowBtn => _webDriverContext.Driver.FindElement(_getItNowBtn);

        public IWebElement ZipCodeTxt => _webDriverContext.Driver.FindElement(_zipCodeTxt);

        public IWebElement ZipCodeSubmitBtn => _webDriverContext.Driver.FindElement(_zipCodeSubmitBtn);



        public CheckoutPage GoToCheckoutPage()
        {
            _webDriverContext.Driver.Navigate().GoToUrl(_environmentFixture.Environment.CheckoutUrl);
            return this;
        }

        public CheckoutPage ClickGetItNowBtn()
        {
            try
            {
                //((IJavaScriptExecutor)_webDriverContext.Driver).ExecuteScript("window.scrollTo(0, document.body.scrollHeight - 150");
                _webActions.MoveTo(_webDriverContext.Driver,GetItNowBtn,GetItNowBtn);
                WebDriverWait wait = new WebDriverWait(_webDriverContext.Driver, TimeSpan.FromSeconds(60));
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector("#bakersfield-ButtonElement--9V7TsM2j7LkTgGSHPmpL")));
                ClosePopUP.Click();
                _webActions.Click(GetItNowBtn);
                return this;

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return this;
        }

        
            public void ChooseProfessionalDelivery()
        {

            Thread.Sleep(TimeSpan.FromSeconds(3));
            _webDriverContext.Driver.ExecuteJavaScript(ChooseProfessionalDeliveryBtnClick);

            try
            {
                if (ZipCodeTxt.Displayed)
                {
                    ZipCodeTxt.SendKeys("02122");
                    ZipCodeSubmitBtn.Click();
                }
            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
    }

}
   

