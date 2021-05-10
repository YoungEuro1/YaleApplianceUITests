using System;
using System.Buffers;
using System.Drawing;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Support.UI;
using YaleApplianceUITests.Factories;
using YaleApplianceUITests.Fixtures;
using YaleApplianceUITests.SharedLibrary.Extensions;
using YaleApplianceUITests.SharedLibrary.Interfaces;
using YaleApplianceUITests.SharedLibrary.Services;

namespace YaleApplianceUITests.Pages
{
    public class HomePage
    {
        private readonly EnvironmentFixture _environmentFixture;
        private readonly WebDriverContext _webDriverContext;
        private readonly IWebActions _webActions;
        private readonly WebDriverWait _wait;

        public HomePage(WebDriverContext webDriverContext, EnvironmentFixture environmentFixture)
        {
            _webDriverContext = webDriverContext;
            _webActions = new WebActions(_webDriverContext);
            _wait = new WebDriverWait(_webDriverContext.Driver, TimeSpan.FromSeconds(20));
            _environmentFixture = environmentFixture;
        }

        public void GoToYaleHomePage()
        {
            _webDriverContext.Driver.Navigate().GoToUrl(_environmentFixture.Environment.YaleApplianceHomePageUrl);
            _webDriverContext.Driver.Navigate().Refresh();
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
        private readonly By _moreInformationVideo = By.ClassName("w-vulcan--background w-css-reset");
        private readonly By _moreInformationBtn = By.CssSelector("#wistia_41\\.thumb_container > a > svg");
        private readonly By _shopOnlineBtn = By.CssSelector("body > div.main-wrapper > div > section.main-hero > div > div > div > section > div.main-hero__item-inner > div > div > div.covid-19__items > div:nth-child(5) > a");
        private const string CovidBanner = "document.querySelector(\"body > div.main-wrapper > div > section.main-hero > div > div > div > section > div.main-hero__item-inner > div > div > div.covid-19__click-here > a\").click()";
        private readonly By _kitchenCategoryBtn = By.CssSelector("#catalog > div:nth-child(1)>a>div.cat-tile__info >span");
        private readonly By _kitchenCategoryPicture = By.CssSelector("#catalog>div:nth-child(1)>a");
        private readonly By _lightingCategoryBtn = By.CssSelector("#catalog>div:nth-child(1)>div>a:nth-child(1)>div.cat-tile__info > span");
        private readonly By _lightingCategoryPicture = By.CssSelector("#catalog>div:nth-child(1)>div>a:nth-child(1)>div.cat-tile__info>h3");
        private readonly By _laundryCategoryBtn = By.CssSelector("#catalog>div:nth-child(1)>div>a:nth-child(2)>div.cat-tile__info>span");
        private readonly By _laundryCategoryPicture = By.CssSelector("#catalog>div:nth-child(1)>div>a:nth-child(2)>div.cat-tile__info>h3");
        private readonly By _bbqCategoryBtn = By.CssSelector("#catalog > div:nth-child(2)>a:nth-child(1)>div.cat-tile__info>span");
        private readonly By _bbqCategoryPicture = By.CssSelector("#catalog > div:nth-child(2)>a:nth-child(1)>div.cat-tile__info >h3");
        private readonly By _plumbingCategoryBtn = By.CssSelector("#catalog > div:nth-child(2)>a:nth-child(2)>div.cat-tile__info > span");
        private readonly By _plumbingCategoryPicture = By.CssSelector("#catalog>div:nth-child(2)>a:nth-child(2)>div.cat-tile__info>h3");
        private readonly By _packagesCategoryBtn = By.CssSelector("#catalog > div:nth-child(2)>a:nth-child(3)>div.cat-tile__info > span");
        private readonly By _packagesCategoryPicture = By.CssSelector("#catalog>div:nth-child(2)>a:nth-child(3)>div.cat-tile__info>h3");
        private readonly By _exploreProduct = By.XPath("/html/body/div[1]/div/div[3]/div[3]/div[2]/div/div[3]/a");
        private readonly By _rightArrowShopInStock = By.CssSelector("body > div.main-wrapper > div > div.trending-product-gall > div.trending-product-gall__wrapper.slick-initialized.slick-slider > div.slick-arrow-right.slick-arrow > svg");
        private readonly By _leftArrowShopInStock = By.CssSelector("body > div.main-wrapper > div > div.trending-product-gall > div.trending-product-gall__wrapper.slick-initialized.slick-slider > div.slick-arrow-left.slick-arrow > svg > path");
        private readonly By _visitOutletyBtn = By.CssSelector("body > div.main-wrapper > div > div.info-box > div.info-box__body > div > a");
        private readonly By _serviceLearnMoreBtn = By.CssSelector("body > div.main-wrapper > div > section.article-list__inline > div > div > div:nth-child(1) > a > div.article-list__cta > span");
        private readonly By _installLearnMoreBtn = By.CssSelector("body > div.main-wrapper > div > section.article-list__inline > div > div > div:nth-child(2) > a > div.article-list__cta > span");
        private readonly By _sameDayLearnMoreBtn = By.CssSelector("body > div.main-wrapper > div > section.article-list__inline > div > div > div:nth-child(3) > a > div.article-list__cta > span");
        private readonly By _scheduleApptFarmingham = By.CssSelector("body > div.main-wrapper > div > div.showrooms-box > div > div > div:nth-child(1) > p.showrooms-box__item-cta > a");
        private readonly By _scheduleApptHanover = By.CssSelector("body > div.main-wrapper > div > div.showrooms-box > div > div > div:nth-child(2) > p.showrooms-box__item-cta > a");
        private readonly By _scheduleApptDorchester = By.CssSelector("body > div.main-wrapper > div > div.showrooms-box > div > div > div:nth-child(3) > p.showrooms-box__item-cta > a");
        private readonly By _mapPopUp = By.CssSelector("#map>div>div>div:nth-child(1)>div:nth-child(3)>div>div:nth-child(4)>div>div>div>div");
        private readonly By _pinpointMapIcon = By.CssSelector("# map > div > div > div:nth-child(1) > div:nth-child(3)");
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
        public IWebElement ShopOnlineBtn => _webDriverContext.Driver.FindElement(_shopOnlineBtn);
        public IWebElement KitchenCategoryBtn => _webDriverContext.Driver.FindElement(_kitchenCategoryBtn);
        public IWebElement LightingCategoryBtn => _webDriverContext.Driver.FindElement(_lightingCategoryBtn);
        public IWebElement LaundryCategoryBtn => _webDriverContext.Driver.FindElement(_laundryCategoryBtn);
        public IWebElement BbqCategoryBtn => _webDriverContext.Driver.FindElement(_bbqCategoryBtn);
        public IWebElement PlumbingCategoryBtn => _webDriverContext.Driver.FindElement(_plumbingCategoryBtn);
        public IWebElement PackagesCategoryBtn => _webDriverContext.Driver.FindElement(_packagesCategoryBtn);
        public IWebElement KitchenCategoryPicture => _webDriverContext.Driver.FindElement(_kitchenCategoryPicture);
        public IWebElement LightingCategoryPicture => _webDriverContext.Driver.FindElement(_lightingCategoryPicture);
        public IWebElement LaundryCategoryPicture => _webDriverContext.Driver.FindElement(_laundryCategoryPicture);
        public IWebElement BbqCategoryPicture => _webDriverContext.Driver.FindElement(_bbqCategoryPicture);
        public IWebElement PlumbingCategoryPicture => _webDriverContext.Driver.FindElement(_plumbingCategoryPicture);
        public IWebElement PackagesCategoryPicture => _webDriverContext.Driver.FindElement(_packagesCategoryPicture);
        private IWebElement ExploreProduct => _webDriverContext.Driver.FindElement(_exploreProduct);
        public IWebElement RightArrowShopInStock => _webDriverContext.Driver.FindElement(_rightArrowShopInStock);
        private IWebElement LeftArrowShopInStock => _webDriverContext.Driver.FindElement(_leftArrowShopInStock);
        private IWebElement VisitOutletBtn => _webDriverContext.Driver.FindElement(_visitOutletyBtn);
        public IWebElement ServiceLearnMoreBtn => _webDriverContext.Driver.FindElement(_serviceLearnMoreBtn);
        private IWebElement InstallLearnMoreBtn => _webDriverContext.Driver.FindElement(_installLearnMoreBtn);
        private IWebElement SameDayLearnMoreBtn => _webDriverContext.Driver.FindElement(_sameDayLearnMoreBtn);
        public IWebElement ScheduleApptFarminghamBtn => _webDriverContext.Driver.FindElement(_scheduleApptFarmingham);
        private IWebElement ScheduleApptHanoverBtn => _webDriverContext.Driver.FindElement(_scheduleApptHanover);
        private IWebElement ScheduleApptDorchesterBtn => _webDriverContext.Driver.FindElement(_scheduleApptDorchester);
        private IWebElement MapPopUp => _webDriverContext.Driver.FindElement(_mapPopUp);
        private IWebElement PinpointMapIcon => _webDriverContext.Driver.FindElement(_pinpointMapIcon);
        #endregion

        public void PageLoadValidation()
        {
            _webActions.WaitUntilDocumentIsReady(_webDriverContext.Driver, TimeSpan.FromSeconds(30));
        }

        public void ScheduleAVisit()
        {
            ScheduleAVisitBtn.Clicks();
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
            _webDriverContext.Driver.Close();
        }

        public void ScheduleAVideoCall()
        {
            _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(_scheduleAVideoCallBtn));
            _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(_scheduleAVideoCallBtn));

            var location = ScheduleAVideoBtn.Location;
            int scheduleAVideoBtnX = location.X;
            int scheduleAVideoBtnY = location.Y;
            _webActions.ScrollToElement(scheduleAVideoBtnX, scheduleAVideoBtnY, _webDriverContext.Driver);

            ScheduleAVideoBtn.Clicks();
        }

        public void MoreInformationVideoPopUp()
        {
            {
                _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(_moreInformationVideo));
            }
        }

        public void MoreVideoInformationBtn()
        {
            _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(_moreInformationBtn));
            _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(_moreInformationBtn));
        }

        public void VerifyChatNowBtn()
        {
            _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(_chatNowBtn));
            _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(_chatNowBtn));
            ChatNowBtn.Clicks();
        }

        public void ClickOnShopOnlineBtn()
        {
            _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(_shopOnlineBtn));
            _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(_shopOnlineBtn));

            var location = ShopOnlineBtn.Location;
            int shopOnlineBtnX = location.X;
            int shopOnlineBtnY = location.Y;
            _webActions.ScrollToElement(shopOnlineBtnX, shopOnlineBtnY, _webDriverContext.Driver);

            ShopOnlineBtn.Clicks();
        }

        public void VerifyShopOnlineBtn()
        {
            _webActions.WaitUntilDocumentIsReady(_webDriverContext.Driver, TimeSpan.FromSeconds(10));
            _webActions.WaitForUrlToContains(_webDriverContext.Driver, "https://www.yaleappliance.com/#catalog", _wait);
        }


        public void ClickCovidLink()
        {
            ((IJavaScriptExecutor) _webDriverContext.Driver).ExecuteScript(CovidBanner);
        }


        public void VerifyCovidLink()
        {
            _webActions.WaitUntilDocumentIsReady(_webDriverContext.Driver, TimeSpan.FromSeconds(10));
            _webActions.WaitForUrlToContains(_webDriverContext.Driver,
                "  https://blog.yaleappliance.com/our-commitment-to-keeping-you-and-our-employees-safe-during-the-coronavirus-outbreak",
                _wait);
        }

        public void ViewProductCategoryClick(string category)
        {
            var location = KitchenCategoryPicture.Location;
            int kitchenCategoryPictureX = location.X;
            int kitchenCategoryPictureY = location.Y;

            _webActions.ScrollToElement(kitchenCategoryPictureX, kitchenCategoryPictureY, _webDriverContext.Driver);

            switch (category.ToLower())
            {
                case "kitchen":
                    _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(_kitchenCategoryBtn));
                    _wait.Until(
                        SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(_kitchenCategoryBtn));
                    KitchenCategoryBtn.Clicks();
                    return;
                case "laundry":
                    _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(_laundryCategoryBtn));
                    _wait.Until(
                        SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(_laundryCategoryBtn));
                    LaundryCategoryBtn.Clicks();
                    return;
                case "lighting":
                    _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(_lightingCategoryBtn));
                    _wait.Until(
                        SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(_lightingCategoryBtn));
                    LightingCategoryBtn.Clicks();
                    return;
                case "bbq":
                    _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(_bbqCategoryBtn));
                    _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(_bbqCategoryBtn));
                    BbqCategoryBtn.Clicks();
                    return;
                case "plumbing":
                    _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(_plumbingCategoryBtn));
                    _wait.Until(
                        SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(_plumbingCategoryBtn));
                    PlumbingCategoryBtn.Clicks();
                    return;
                case "packages":
                    _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(_packagesCategoryBtn));
                    _wait.Until(
                        SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(_packagesCategoryBtn));
                    PackagesCategoryBtn.Clicks();
                    return;
            }
        }

        public void ProductPictureClick(string category)
        {
            var location = KitchenCategoryPicture.Location;
            int kitchenCategoryPictureX = location.X;
            int kitchenCategoryPictureY = location.Y;

            _webActions.ScrollToElement(kitchenCategoryPictureX, kitchenCategoryPictureY, _webDriverContext.Driver);

            switch (category.ToLower())
            {
                case "kitchen":
                    _wait.Until(
                        SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(_kitchenCategoryPicture));
                    _wait.Until(
                        SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(_kitchenCategoryPicture));
                    KitchenCategoryPicture.Clicks();
                    return;

                case "laundry":
                    _wait.Until(
                        SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(_laundryCategoryPicture));
                    _wait.Until(
                        SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(_laundryCategoryPicture));
                    LaundryCategoryPicture.Clicks();
                    return;

                case "lighting":
                    _wait.Until(
                        SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(_lightingCategoryPicture));
                    _wait.Until(
                        SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(_lightingCategoryPicture));
                    LightingCategoryPicture.Clicks();
                    return;

                case "bbq":
                    _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(_bbqCategoryPicture));
                    _wait.Until(
                        SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(_bbqCategoryPicture));
                    BbqCategoryPicture.Clicks();
                    return;

                case "plumbing":
                    _wait.Until(
                        SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(_plumbingCategoryPicture));
                    _wait.Until(
                        SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(_plumbingCategoryPicture));
                    PlumbingCategoryPicture.Clicks();
                    return;

                case "packages":
                    _wait.Until(
                        SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(_packagesCategoryPicture));
                    _wait.Until(
                        SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(_packagesCategoryPicture));
                    PackagesCategoryPicture.Clicks();
                    return;
            }
        }


        public void VerifyCategoryPage(string category)
        {
            _webActions.WaitUntilDocumentIsReady(_webDriverContext.Driver, TimeSpan.FromSeconds(10));
            _webActions.WaitForUrlToContains(_webDriverContext.Driver, category, _wait);
        }

        public void ClickExploreProduct()
        {
            _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(_exploreProduct));
            _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(_exploreProduct));
            var location = ExploreProduct.Location;
            int exploreProductX = location.X;
            int exploreProductY = location.Y;
            _webActions.ScrollToElement(exploreProductX,exploreProductY,_webDriverContext.Driver);
            ExploreProduct.Clicks();
        }

        public void VerifyExploreProductLink()
        {
            _webActions.WaitUntilDocumentIsReady(_webDriverContext.Driver, TimeSpan.FromSeconds(10));
        }


        public void VerifyArrows()
        {
            _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(_rightArrowShopInStock));
            _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(_leftArrowShopInStock));
        }

        public void VerifyArrowClick()
        {
            IWebElement element = _webDriverContext.Driver.FindElement(_rightArrowShopInStock);
            Point point = element.Location;
            Console.WriteLine("Right Arrow Element's Position from left side is: " + point.X + " pixels.");
            Console.WriteLine("Element's Position from top is: " + point.Y + " pixels.");
            _webActions.ScrollToElement(1554, 1448, _webDriverContext.Driver);
            RightArrowShopInStock.Clicks();
            LeftArrowShopInStock.Clicks();

        }

        public void VisitOutletClick()
        {
            var location = VisitOutletBtn.Location;
            int visitOutletBtnX = location.X;
            int visitOutletBtnY = location.Y;

            _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(_visitOutletyBtn));
            _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(_visitOutletyBtn));
            Console.WriteLine("Right Arrow Element's Position from left side is: " + visitOutletBtnX + " pixels.");
            Console.WriteLine("Element's Position from top is: " + visitOutletBtnY + " pixels.");
            _webActions.ScrollToElement(visitOutletBtnX, visitOutletBtnY, _webDriverContext.Driver);
            VisitOutletBtn.Clicks();
        }


        public void VerifyVisitOuletBtn()
        {
            _webActions.WaitUntilDocumentIsReady(_webDriverContext.Driver, TimeSpan.FromSeconds(10));
            _webActions.WaitForUrlToContains(_webDriverContext.Driver, "https://www.yaleappliance.com/outlet-store",
                _wait);
        }

        public void LearnMoreClick(string learnMore)
        {
            var location = ServiceLearnMoreBtn.Location;
            int serviceLearnMoreBtnX = location.X;
            int serviceLearnMoreBtnY = location.Y;
            _webActions.ScrollToElement(serviceLearnMoreBtnX, serviceLearnMoreBtnY, _webDriverContext.Driver);


            switch (learnMore.ToLower())
            {
                case "service":
                    _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(_serviceLearnMoreBtn));
                    _wait.Until(
                        SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(_serviceLearnMoreBtn));
                    ServiceLearnMoreBtn.Clicks();
                    return;

                case "install":
                    _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(_installLearnMoreBtn));
                    _wait.Until(
                        SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(_installLearnMoreBtn));
                    InstallLearnMoreBtn.Clicks();
                    return;

                case "sameday":
                    _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(_sameDayLearnMoreBtn));
                    _wait.Until(
                        SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(_sameDayLearnMoreBtn));
                    SameDayLearnMoreBtn.Clicks();
                    return;
            }
        }

        public void VerifyLearnMorePage(string page)
        {
            _webActions.WaitUntilDocumentIsReady(_webDriverContext.Driver, TimeSpan.FromSeconds(10));
            _webActions.WaitForUrlToContains(_webDriverContext.Driver, page, _wait);
        }

        public void ScheduleApptClick(string showroom)
        {
            var location = ScheduleApptFarminghamBtn.Location;
            int scheduleApptBtntX = location.X;
            int scheduleApptBtnY = location.Y;
            _webActions.ScrollToElement(scheduleApptBtntX, scheduleApptBtnY, _webDriverContext.Driver);



            switch (showroom.ToLower())
            {
                case "farmingham":
                    _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(_scheduleApptFarmingham));
                    _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(_scheduleApptFarmingham));
                    ScheduleApptFarminghamBtn.Clicks();
                    return;

                case "hanover":
                    _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(_scheduleApptHanover));
                    _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(_scheduleApptHanover));
                    ScheduleApptHanoverBtn.Clicks();
                    return;

                case "dorchester":
                    _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(_scheduleApptDorchester));
                    _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(_scheduleApptDorchester));
                    ScheduleApptDorchesterBtn.Clicks();
                    return;
            }
        }


        public void VerifyScheduleApptPage(string page)
        {
            _webActions.WaitUntilDocumentIsReady(_webDriverContext.Driver, TimeSpan.FromSeconds(10));
            _webActions.WaitForUrlToContains(_webDriverContext.Driver, page, _wait);
        }

        public void PinpointIconMapClick()
        {
            var location = PinpointMapIcon.Location;
            int mapX = location.X;
            int mapY = location.Y;

            _webActions.ScrollToElement(mapX, mapY, _webDriverContext.Driver);
            PinpointMapIcon.Clicks();
        }

        public void VerifyAddressMap()
        {
            _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(_mapPopUp));

        }
    }
}