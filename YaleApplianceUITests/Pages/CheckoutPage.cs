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
        private readonly WebDriverContext _webDriverContext;
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

        private static readonly By _addToCartBtn = By.Id("NormalCheckout");

        private readonly By _zipCodeTxt = By.ClassName("zip-code__input");

        private readonly By _zipCodeSubmitBtn = By.CssSelector("#zip-code-form > div.zip-code__submitblock > div");

        private const string ChooseYaleDelivery = "document.querySelector(\"#delivery-methods > div > label:nth-child(2) > div > div.deliveryItem_header > div > input[type=radio]\").click()";

        private const string ChoosePersonalPickup = "document.querySelector(\"#delivery-methods > div > label:nth-child(4) > div > div.deliveryItem_header > div > input[type=radio]\").click()";

        private const string ChooseSameDayDelivery = "document.querySelector(\"#delivery-methods > div > label:nth-child(3) > div > div.deliveryItem_header > div > input[type=radio]\").click()";

        private const string ContinueBtn = "document.querySelector(\"#shopping-cart-items > div.shopping-cart__wrapper > div:nth-child(1) > div.delivery-item__blocks > div > div.shoppCode_form > input\").click()";

        private static readonly By _closePopUp = By.CssSelector("#om-z3df03lhtmhoa1j1vtdj-optin > div > button > svg > path");

        private static readonly By  _popUpBtn = By.CssSelector("#bakersfield-ButtonElement--9V7TsM2j7LkTgGSHPmpL");

        private readonly By _selectInstallation = By.CssSelector("#Product-31540-INST002-YES");

        private readonly By _personalPickupBtn = By.CssSelector("#delivery-methods > div > label:nth-child(4) > div > div.deliveryItem_header > div > input[type=radio]");

        private readonly By _sameDayDeliveryBtn = By.CssSelector("#delivery-methods > div > label:nth-child(3) > div > div.deliveryItem_header > div > input[type=radio]");

        #endregion


        #region PageElements
        private IWebElement ClosePopUP => _webDriverContext.Driver.FindElement(_closePopUp);

        private IWebElement AddToCartBtn => _webDriverContext.Driver.FindElement(_addToCartBtn);

        private IWebElement ZipCodeTxt => _webDriverContext.Driver.FindElement(_zipCodeTxt);

        private IWebElement ZipCodeSubmitBtn => _webDriverContext.Driver.FindElement(_zipCodeSubmitBtn);

        private IWebElement PopUpBtn => _webDriverContext.Driver.FindElement(_popUpBtn);

        private IWebElement SelectInstallation => _webDriverContext.Driver.FindElement(_selectInstallation);

        private IWebElement PersonalPickupBtn => _webDriverContext.Driver.FindElement(_personalPickupBtn);

        private IWebElement SameDayBtn => _webDriverContext.Driver.FindElement(_sameDayDeliveryBtn);


        #endregion


        public CheckoutPage GoToRefrigeratorPageUrl()
        {
            _webDriverContext.Driver.Navigate().GoToUrl(_environmentFixture.Environment.RefrigeratorPageUrl);
            return this;
        }

        public CheckoutPage ClickAddToCartBtn()
        {
            //((IJavaScriptExecutor)_webDriverContext.Driver).ExecuteScript("window.scrollTo(0, document.body.scrollHeight - 150");
            WebDriverWait wait = new WebDriverWait(_webDriverContext.Driver, TimeSpan.FromSeconds(60));
            try
            {
                ClosePopUP.Click();
                _webActions.MoveTo(_webDriverContext.Driver, AddToCartBtn, AddToCartBtn);
                _webActions.Click(AddToCartBtn);
                return this;
            }
            catch (Exception)
            {
                {
                    _webActions.MoveTo(_webDriverContext.Driver, AddToCartBtn, AddToCartBtn);
                    _webActions.Click(AddToCartBtn);
                }
            }

            return this;
        }

        public CheckoutPage ChooseYaleDeliveryOption()
                {

                    Thread.Sleep(TimeSpan.FromSeconds(3));
                    WebDriverWait wait = new WebDriverWait(_webDriverContext.Driver, TimeSpan.FromSeconds(60));

                    try
                    {
                        ClosePopUP.Click();
                        wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.CssSelector("#delivery-methods > div > label:nth-child(2) > div > div.deliveryItem_header > div > input[type=radio]")));
                        _webDriverContext.Driver.ExecuteJavaScript(ChooseYaleDelivery);
                        wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector("#zip-code-form > div.zip-code__submitblock > div > input")));
                        ZipCodeTxt.SendKeys("02122");
                        ZipCodeSubmitBtn.Click();
                        return this;
                    }
                    
                    catch(Exception)

                    {
                        wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.CssSelector("#delivery-methods > div > label:nth-child(2) > div > div.deliveryItem_header > div > input[type=radio]")));
                        _webDriverContext.Driver.ExecuteJavaScript(ChooseYaleDelivery);
                        wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector("#zip-code-form > div.zip-code__submitblock > div > input")));
                        ZipCodeTxt.SendKeys("02122");
                        ZipCodeSubmitBtn.Click();
                    }

                    return this;
        }

        public CheckoutPage ChoosePersonalPickupOption()
        {

            Thread.Sleep(TimeSpan.FromSeconds(3));
            WebDriverWait wait = new WebDriverWait(_webDriverContext.Driver, TimeSpan.FromSeconds(60));

            try
            {
                ClosePopUP.Click();
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.CssSelector("#delivery-methods > div > label:nth-child(4) > div > div.deliveryItem_header > div > input[type=radio]")));
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(_personalPickupBtn));
                ((IJavaScriptExecutor)_webDriverContext.Driver).ExecuteScript("arguments[0].scrollIntoView(true);", PersonalPickupBtn);
                _webDriverContext.Driver.ExecuteJavaScript(ChoosePersonalPickup);
                Thread.Sleep(TimeSpan.FromSeconds(3));
                _webDriverContext.Driver.ExecuteJavaScript(ContinueBtn);
                return this;
            }

            catch (Exception)

            {
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.CssSelector("#delivery-methods > div > label:nth-child(4) > div > div.deliveryItem_header > div > input[type=radio]")));
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(_personalPickupBtn));
                ((IJavaScriptExecutor)_webDriverContext.Driver).ExecuteScript("arguments[0].scrollIntoView(true);", PersonalPickupBtn);
                _webDriverContext.Driver.ExecuteJavaScript(ChoosePersonalPickup);
                Thread.Sleep(TimeSpan.FromSeconds(3));
                _webDriverContext.Driver.ExecuteJavaScript(ContinueBtn);
            }

            return this;
        }

        public CheckoutPage AddDishwasherInstallation()
        {

                   Thread.Sleep(TimeSpan.FromSeconds(3));
                   WebDriverWait wait = new WebDriverWait(_webDriverContext.Driver, TimeSpan.FromSeconds(60));

            try
            {
                     ClosePopUP.Click();
                     ((IJavaScriptExecutor)_webDriverContext.Driver).ExecuteScript("arguments[0].scrollIntoView(true);", SelectInstallation);
                     SelectInstallation.Click();
                     wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector("#zip-code-form > div.zip-code__submitblock > div > input")));
                     ZipCodeTxt.SendKeys("02122");
                     ZipCodeSubmitBtn.Click();
                return this;
            }

            catch (Exception)

            {
                ((IJavaScriptExecutor)_webDriverContext.Driver).ExecuteScript("arguments[0].scrollIntoView(true);", SelectInstallation);
                 SelectInstallation.Click();
                 wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector("#zip-code-form > div.zip-code__submitblock > div > input")));
                ZipCodeTxt.SendKeys("02122");
                ZipCodeSubmitBtn.Click();
                return this;
            }

        }

        public CheckoutPage  SameDayDelivery()
        {

            Thread.Sleep(TimeSpan.FromSeconds(3));
            WebDriverWait wait = new WebDriverWait(_webDriverContext.Driver, TimeSpan.FromSeconds(60));

            try
            {
                ClosePopUP.Click();
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(_sameDayDeliveryBtn));
                ((IJavaScriptExecutor)_webDriverContext.Driver).ExecuteScript("arguments[0].scrollIntoView(true);", SameDayBtn);
                _webDriverContext.Driver.ExecuteJavaScript(ChooseSameDayDelivery);
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector("#zip-code-form > div.zip-code__submitblock > div > input")));
                ZipCodeTxt.SendKeys("02122");
                ZipCodeSubmitBtn.Click();
                return this;
            }

            catch (Exception)

            {
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(_sameDayDeliveryBtn));
                ((IJavaScriptExecutor)_webDriverContext.Driver).ExecuteScript("arguments[0].scrollIntoView(true);", SameDayBtn);
                _webDriverContext.Driver.ExecuteJavaScript(ChooseSameDayDelivery);
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector("#zip-code-form > div.zip-code__submitblock > div > input")));
                ZipCodeTxt.SendKeys("02122");
                ZipCodeSubmitBtn.Click();
            }

            return this;
        }
    }
}