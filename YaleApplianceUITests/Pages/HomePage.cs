using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using TechTalk.SpecFlow;
using YaleApplianceUITests.Factories;
using YaleApplianceUITests.SharedLibrary.Interfaces;
using YaleApplianceUITests.SharedLibrary.Services;

namespace YaleApplianceUITests.Pages
{
    public class HomePage
    {
        private readonly WebDriverContext _webDriverContext;
        private readonly IWebActions _webActions;
        private readonly WebDriverWait _wait;

        public HomePage(WebDriverContext webDriverContext)
        {
            _webDriverContext = webDriverContext;
            _webActions = new WebActions(_webDriverContext);
            _wait = new WebDriverWait(_webDriverContext.Driver, TimeSpan.FromSeconds(10));
        }

        public void GoToYaleHomePage(Uri url)
        {
            _webDriverContext.Driver.Navigate().GoToUrl(url);
        }

        #region Locators
        private readonly By _scheduleAVisitBtn = By.CssSelector("body>div.main-wrapper>div>section.main-hero>div>div>div>section>div.main-hero__item-inner>div>div>div.covid-19__items >div:nth-child(1)>a");
        private readonly By _scheduleAVideoCallBtn = By.CssSelector("body>div.main-wrapper>div>section.main-hero>div>div>div>section>div.main-hero__item-inner>div>div>div.covid-19__items>div:nth-child(3)>a");
        private readonly By _chatNowBtn = By.CssSelector("body>div.main-wrapper>div>section.main-hero>div>div>div>section>div.main-hero__item-inner>div>div>div.covid-19__items>div:nth-child(4)>a");
        private readonly By _emailSubscribeBox = By.CssSelector("#Subscribe_Email");
        private readonly By _nameSubscribeBox = By.CssSelector("#Subscribe_Name");
        private readonly By _subscribeBtn = By.CssSelector("#SubmitEmail");
        private readonly By _kitchenIcon = By.CssSelector("body>div.main-wrapper>div>div:nth-child(5)>nav>ul>li:nth-child(1)>a");
        private readonly By _laundryIcon = By.CssSelector("body>div.main-wrapper>div>div:nth-child(5)>nav>ul>li:nth-child(2)>a");
        private readonly By _lightingIcon = By.CssSelector("body>div.main-wrapper>div>div:nth-child(5)>nav>ul>li:nth-child(3)>a");
        private readonly By _bbqIcon = By.CssSelector("body>div.main-wrapper>div>div:nth-child(5)>nav>ul>li:nth-child(4)>a");
        private readonly By _vaccumIcon = By.CssSelector("body>div.main-wrapper>div>div:nth-child(5)>nav>ul>li:nth-child(5)>a");
        private readonly By _sinksIcon = By.CssSelector("body>div.main-wrapper>div>div:nth-child(5)>nav>ul>li:nth-child(6)>a");
        private readonly By _packagesIcon = By.CssSelector("body>div.main-wrapper>div>div:nth-child(5)>nav>ul>li:nth-child(7)>a");
        private readonly By _outletIcon = By.CssSelector("body>div.main-wrapper>div>div:nth-child(5)>nav>ul>li:nth-child(8)>a");
        private readonly By _directions = By.CssSelector("body>div.main-wrapper>div>footer.footer.font-roboto>div.footerLast>div>ul>li:nth-child(1)>a");
        private readonly By _careers = By.CssSelector("body>div.main-wrapper>div>footer.footer.font-roboto>div.footerLast>div>ul>li:nth-child(2)>a");
        private readonly By _termsOfUse = By.CssSelector("body>div.main-wrapper>div>footer.footer.font-roboto>div.footerLast>div>ul>li:nth-child(3)>a");
        private readonly By _privacyPolicy = By.CssSelector("body>div.main-wrapper>div>footer.footer.font-roboto>div.footerLast>div>ul>li:nth-child(4)>a");
        private readonly By _returnPolicy = By.CssSelector("body>div.main-wrapper>div>footer.footer.font-roboto>div.footerLast>div>ul>li:nth-child(5)>a");
        private readonly By _priceGuarantee = By.CssSelector("body>div.main-wrapper>div>footer.footer.font-roboto>div.footerLast>div>ul>li:nth-child(6)>a");
        private readonly By _deliveryPolicy = By.CssSelector("body>div.main-wrapper>div>footer.footer.font-roboto>div.footerLast>div>ul>li:nth-child(7)>a");
        #endregion

        #region PageElements

        public IWebElement ScheduleAVisitBtn => _webDriverContext.Driver.FindElement(_scheduleAVisitBtn);

        public IWebElement ScheduleAVideoBtn => _webDriverContext.Driver.FindElement(_scheduleAVideoCallBtn);

        public IWebElement ChatNowBtn => _webDriverContext.Driver.FindElement(_chatNowBtn);

        public IWebElement EmailSubcribeBox => _webDriverContext.Driver.FindElement(_emailSubscribeBox);

        public IWebElement NameSubscribeBox => _webDriverContext.Driver.FindElement(_nameSubscribeBox);

        public IWebElement SubscribeBtn => _webDriverContext.Driver.FindElement(_subscribeBtn);

        public IWebElement KitchenIcon => _webDriverContext.Driver.FindElement(_kitchenIcon);

        public IWebElement LaundryIcon => _webDriverContext.Driver.FindElement(_laundryIcon);

        public IWebElement LightingIcon => _webDriverContext.Driver.FindElement(_lightingIcon);

        public IWebElement BbqIcon => _webDriverContext.Driver.FindElement(_bbqIcon);

        public IWebElement VaccumIcon => _webDriverContext.Driver.FindElement(_vaccumIcon);

        public IWebElement SinksIcon => _webDriverContext.Driver.FindElement(_sinksIcon);

        public IWebElement PackagesIcon => _webDriverContext.Driver.FindElement(_packagesIcon);

        public IWebElement OutletIcon => _webDriverContext.Driver.FindElement(_outletIcon);


        public IWebElement Directions => _webDriverContext.Driver.FindElement(_directions);


        public IWebElement Careers => _webDriverContext.Driver.FindElement(_careers);


        public IWebElement TermsOfUse => _webDriverContext.Driver.FindElement(_termsOfUse);


        public IWebElement PrivacyPolicy => _webDriverContext.Driver.FindElement(_privacyPolicy);

        public IWebElement ReturnPolicy => _webDriverContext.Driver.FindElement(_returnPolicy);


        public IWebElement PriceGuarantee => _webDriverContext.Driver.FindElement(_priceGuarantee);


        public IWebElement DeliveryPolicy => _webDriverContext.Driver.FindElement(_deliveryPolicy);

        #endregion

        public void PageLoadValidation()
        {
            _webActions.WaitUntilDocumentIsReady(_webDriverContext.Driver, TimeSpan.FromSeconds(30));
        }

        public void PerformHealthCheckActions(string page)
        {
            _webActions.WaitForUrlToContains(_webDriverContext.Driver, page, _wait);
            _webActions.MoveToAndHold(_webDriverContext.Driver, ScheduleAVisitBtn);
             Assert.True(_webActions.Clickable(ScheduleAVisitBtn));
            Assert.True(_webActions.Clickable(ScheduleAVideoBtn));
            Assert.True(_webActions.Clickable(ChatNowBtn));
            Assert.True(_webActions.Clickable(EmailSubcribeBox));
            Assert.True(_webActions.Clickable(NameSubscribeBox));
            Assert.True(_webActions.Clickable(SubscribeBtn));
            Assert.True(_webActions.Clickable(KitchenIcon));
            Assert.True(_webActions.Clickable(LaundryIcon));
            Assert.True(_webActions.Clickable(LightingIcon));
            Assert.True(_webActions.Clickable(BbqIcon));
            Assert.True(_webActions.Clickable(VaccumIcon));
            Assert.True(_webActions.Clickable(SinksIcon));
            Assert.True(_webActions.Clickable(PackagesIcon));
            Assert.True(_webActions.Clickable(OutletIcon));
            Assert.True(_webActions.Clickable(Directions));
            Assert.True(_webActions.Clickable(Careers));
            Assert.True(_webActions.Clickable(TermsOfUse));
            Assert.True(_webActions.Clickable(PrivacyPolicy));
            Assert.True(_webActions.Clickable(ReturnPolicy));
            Assert.True(_webActions.Clickable(PriceGuarantee));
            Assert.True(_webActions.Clickable(DeliveryPolicy));

            //((IJavaScriptExecutor)_webDriverContext.Driver).ExecuteScript("window.scrollTo(0, document.body.scrollHeight - 150)");
            //IJavaScriptExecutor js = (IJavaScriptExecutor)_webDriverContext.Driver; js.ExecuteScript("window.scrollTo(0, 0)");
        }

        }
    }




