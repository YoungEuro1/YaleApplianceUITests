using System;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Support.UI;
using TechTalk.SpecFlow;
using YaleApplianceUITests.Factories;
using YaleApplianceUITests.Fixtures;
using YaleApplianceUITests.SharedLibrary.Interfaces;
using YaleApplianceUITests.SharedLibrary.Services;

namespace YaleApplianceUITests.Pages
{
    public class PaymentPage
    {
        private readonly EnvironmentFixture _environmentFixture;
        private readonly WebDriverContext _webDriverContext;
        private readonly IWebActions _webActions;
        private readonly WebDriverWait _wait;
        private readonly ScenarioContext _scenarioContext;

        public PaymentPage(WebDriverContext webDriverContext, EnvironmentFixture environmentFixture)
        {
            _environmentFixture = environmentFixture;
            _webDriverContext = webDriverContext;
            _webActions = new WebActions(_webDriverContext);
            _wait = new WebDriverWait(_webDriverContext.Driver, TimeSpan.FromSeconds(10));
        }

        #region Locators
        private readonly By _firstName = By.CssSelector("#CheckoutViewModel_BillingAddress_FirstName");
        private readonly By _lastName = By.CssSelector("#CheckoutViewModel_BillingAddress_LastName");
        private readonly By _email = By.CssSelector("#CheckoutViewModel_BillingAddress_Email");
        private readonly By _phone = By.CssSelector("#CheckoutViewModel_BillingAddress_Phone");
        private readonly By _state = By.CssSelector("#CheckoutViewModel_BillingAddress_Province");
        private readonly By _city = By.CssSelector("#CheckoutViewModel_BillingAddress_City");
        private readonly By _streetAddress1 = By.CssSelector("#CheckoutViewModel_BillingAddress_Address1");
        private readonly By _streetAddress2 = By.CssSelector("#CheckoutViewModel_BillingAddress_Address2");
        private readonly By _paymentType = By.CssSelector("#CheckoutViewModel_CardInfo_CardProvider");
        private readonly By _cardholderName = By.CssSelector("#CheckoutViewModel_CardInfo_CardHolder");
        private readonly By _cardNumber = By.CssSelector("#CheckoutViewModel_CardInfo_CardNumber");
        private readonly By _cvv = By.CssSelector("#CheckoutViewModel_CardInfo_Cvv");
        private readonly By _yaleName = By.CssSelector("#CheckoutViewModel_CardInfo_CardHolder");
        private readonly By _zipcode = By.CssSelector("#CheckoutViewModel_BillingAddress_ZipCode");
        private const string PlaceOrderBtn = "document.querySelector(\"#form > div > div:nth-child(1) > div.shopping-cart__total > div:nth-child(2) > input\").click()";
        private readonly By _popUp = By.CssSelector("#om-z3df03lhtmhoa1j1vtdj-optin>div>div>div>div>div.bakersfield-row.bakersfield-row-1.Row>div>div>div.bakersfield-column.bakersfield-col-1.Column>div>div>div>div>div");
       // private readonly By _closePopUp = By.CssSelector("#om-z3df03lhtmhoa1j1vtdj-optin>div>button>svg>path");
        private readonly By _expiryDate = By.CssSelector("#CheckoutViewModel_CardInfo_Year");
        private readonly By _placeOrderBtn = By.CssSelector("#form>div>div:nth-child(1)>div.shopping-cart__total>div:nth-child(2)>input");
        #endregion Locator

        #region PageElements

        private IWebElement FirstName => _webDriverContext.Driver.FindElement(_firstName);
        private IWebElement LastName => _webDriverContext.Driver.FindElement(_lastName);
        private IWebElement Email => _webDriverContext.Driver.FindElement(_email);
        private IWebElement Phone => _webDriverContext.Driver.FindElement(_phone);
        private IWebElement State => _webDriverContext.Driver.FindElement(_state);
        private IWebElement City => _webDriverContext.Driver.FindElement(_city);

        private IWebElement ZipCode => _webDriverContext.Driver.FindElement(_zipcode);

        private IWebElement StreetAddress1 => _webDriverContext.Driver.FindElement(_streetAddress1);

        private IWebElement StreetAddress2 => _webDriverContext.Driver.FindElement(_streetAddress2);

        private IWebElement CardholderName => _webDriverContext.Driver.FindElement(_cardholderName);

        private IWebElement CardNumber => _webDriverContext.Driver.FindElement(_cardNumber);

        private IWebElement PaymentType => _webDriverContext.Driver.FindElement(_paymentType);

        private IWebElement ExpiryDate => _webDriverContext.Driver.FindElement(_expiryDate);

        private IWebElement Cvv => _webDriverContext.Driver.FindElement(_cvv);

        private IWebElement PopUo => _webDriverContext.Driver.FindElement(_popUp);

       // private IWebElement ClosePopUo => _webDriverContext.Driver.FindElement(_closePopUp);

        private IWebElement YaleName => _webDriverContext.Driver.FindElement(_yaleName);

        #endregion


        public PaymentPage EnterBillingAddress()
        {
            Thread.Sleep(TimeSpan.FromSeconds(3));
            WebDriverWait wait = new WebDriverWait(_webDriverContext.Driver, TimeSpan.FromSeconds(60));
            var select = new SelectElement(State);
            _webActions.WaitForUrlToContains(_webDriverContext.Driver, "shopping-cart/payment", _wait);
            _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(_state));
            _webActions.MoveToAndHold(_webDriverContext.Driver, State);
            State.Click();
            select.SelectByText("Rhode Island");
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector("#CheckoutViewModel_BillingAddress_FirstName")));
            FirstName.SendKeys(_environmentFixture.Environment.User.FirstName);
            LastName.SendKeys(_environmentFixture.Environment.User.LastName);
            Email.SendKeys(_environmentFixture.Environment.User.Email);
            Phone.SendKeys(_environmentFixture.Environment.User.Phone);
            City.SendKeys(_environmentFixture.Environment.User.City);
            ZipCode.SendKeys("02122");
            StreetAddress1.SendKeys(_environmentFixture.Environment.User.Address);
            StreetAddress2.SendKeys(_environmentFixture.Environment.User.Address);
            return this;
        }


        public PaymentPage PaymentMethodHelper(string paymentType)
        {

            switch (paymentType)
            {
                case "Yale Card":
                    return EnterPaymentDetailsForYaleCard(paymentType);
                default:
                    return EnterPaymentDetails(paymentType);
            }
        }
        

      public PaymentPage EnterPaymentDetails(string paymentType)
      {
          WebDriverWait wait = new WebDriverWait(_webDriverContext.Driver, TimeSpan.FromSeconds(60));
            _webActions.Clickable(CardholderName); 
          CardholderName.SendKeys(_environmentFixture.Environment.User.FirstName);
          wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector("#CheckoutViewModel_CardInfo_CardProvider")));
          PaymentType.SendKeys(paymentType); 
          ExpiryDate.SendKeys("2023"); 
          CardNumber.SendKeys("4444333322221111"); 
          Cvv.SendKeys("123");
          return this;
      }


      public PaymentPage EnterPaymentDetailsForYaleCard(string paymentType)
        {
            Thread.Sleep(TimeSpan.FromSeconds(3));
            PaymentType.SendKeys(paymentType);
            YaleName.SendKeys(_environmentFixture.Environment.User.FirstName);
            CardNumber.SendKeys("4444333322221111");
            return this;
        }

        public PaymentPage PlaceOrder()
        {
            _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(_placeOrderBtn));
            _webDriverContext.Driver.ExecuteJavaScript(PlaceOrderBtn);
           return this;
        }

    }
    }