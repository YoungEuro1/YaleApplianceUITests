using System;
using System.Security.Cryptography.X509Certificates;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using YaleApplianceUITests.Factories;
using YaleApplianceUITests.Fixtures;
using YaleApplianceUITests.SharedLibrary.Extensions;
using YaleApplianceUITests.SharedLibrary.Interfaces;
using YaleApplianceUITests.SharedLibrary.Services;


namespace YaleApplianceUITests.Pages
{
    public class ProductPage
    {
        private readonly EnvironmentFixture _environmentFixture;
        private readonly WebDriverContext _webDriverContext;
        private static IWebActions _webActions;
        private WebDriverWait _wait;


        public ProductPage(WebDriverContext webDriverContext, EnvironmentFixture environmentFixture)
        {
            _environmentFixture = environmentFixture;
            _webDriverContext = webDriverContext;
            _webActions = new WebActions(_webDriverContext);
            _wait = new WebDriverWait(_webDriverContext.Driver, TimeSpan.FromSeconds(10));
        }

        #region Locators

        /// <summary>
        /// global locators
        /// </summary>
        private readonly By _continueShoppingBtn = By.Id("HideCompareDetails");
        private readonly By _resetFilterBtn = By.CssSelector("#ResetFilters>span");
        private readonly By _getItNowBtn = By.CssSelector("#products-list-container>div>div:nth-child(1)>div>div.catalogue-item__body>div>p.catalogue-item__info-cta >a");
        private readonly By _sortByInStockBtn = By.CssSelector("body>div.main-wrapper>div>div.products-list > div.products-list__header > div > span.products-list__sort-item._active");
        private readonly By _sortByPriceBtn = By.CssSelector("body>div.main-wrapper>div>div.products-list>div.products-list__header>div>span:nth-child(3)");
        private readonly By _sortByMostPopularBtn = By.CssSelector("body>div.main-wrapper>div>div.products-list>div.products-list__header>div>span:nth-child(4)");
        private readonly By _compareItemsBtn = By.CssSelector("#ShowCompareDetails");
        private readonly By _mostPopularTag = By.CssSelector("#products-list-container>div>div:nth-child(1)>div>div.catalogue-item__header>div.catalogue-item__label._top");
        private readonly By _reviewBtn = By.CssSelector("#yotpo_testimonials_btn>span");
        private readonly By _reviewCommentModal = By.CssSelector("#yotpo-testimonials-site-reviews > div:nth-child(4)");
        private readonly By _writeAReviewBtn = By.CssSelector("#yotpo-testimonials>div.yotpo-modal-dialog > div.yotpo-modal-content>div.yotpo-popup-box-medium.yotpo-modal-bottom-line >input");
        private readonly By _viewDetailsBtn = By.CssSelector("#products-list-container>div>div:nth-child(1)>div >div.catalogue-item__descr>div.catalogue-item__descr-view>a");
        private readonly By _rightArrowBottomNvg = By.CssSelector("#products-list-container>p>a.pagination__item.next");
        private readonly By _leftArrowBottomNvg = By.CssSelector("#products-list-container > p > a.pagination__item.prev");
        private readonly By _page2BottomNvgBtn = By.CssSelector("#products-list-container>p>a.pagination__item._active");
        private readonly By _page3BottomNvgBtn = By.CssSelector("# products-list-container > p > a:nth-child(4)");

        /// <summary>
        /// Dishwasher Product page Top Filter locators
        /// </summary>
        private readonly By _dishFilterByBrand = By.CssSelector("#Brand-5");
        private readonly By _dishFilterByColor = By.CssSelector("#Color-2");
        private readonly By _dishFilterByPrice = By.CssSelector("#Price-13");
        /// <summary>
        /// Refrigerator Product Page Top Filter locators 
        /// </summary>
        private readonly By _refFilterByBrand = By.CssSelector("#Brand-120");
        private readonly By _refFilterByColor = By.CssSelector("#Color-2");
        private readonly By _refFilterByPrice = By.CssSelector("#Price-13");
        /// <summary>
        /// Cooking Appliances Product Page Top Filter locators 
        /// </summary>
        private readonly By _appFilterByBrand = By.CssSelector("#Brand-120");
        private readonly By _appFilterByColor = By.CssSelector("#Color-2");
        private readonly By _appFilterByPrice = By.CssSelector("#Price-13");
        /// <summary>
        /// Counter Depth Refrigerator Product Page Top Page locators 
        /// </summary>
        private readonly By _counterDepthNode = By.CssSelector("body>div.main-wrapper>div>div.products-list>div.products-list__header>section>p>a:nth-child(5)");
        /// <summary>
        /// Cooking Appliances-ranges/gas-ranges/ Product Page locators 
        /// </summary>

        private readonly By _compareItem1Tag = By.XPath("/html/body/div[1]/div/div[3]/div[3]/div[2]/div[4]/div/div/div[1]/div/div[1]/div[2]/div");
        private readonly By _compareItem2Tag = By.XPath("/html/body/div[1]/div/div[3]/div[3]/div[2]/div[4]/div/div/div[2]/div/div[1]/div[2]/div");
        private readonly By _compareItem3Tag = By.XPath("/html/body/div[1]/div/div[3]/div[3]/div[2]/div[4]/div/div/div[3]/div/div[1]/div[2]/div");
        private readonly By _compareItem4Tag = By.XPath("/html/body/div[1]/div/div[3]/div[3]/div[2]/div[4]/div/div/div[4]/div/div[1]/div[2]/div");
        private readonly By _compareItemsImg1Exists = By.XPath("/html/body/div[1]/div/div[3]/div[3]/div[2]/div[1]/div[2]/div[1]/a/div[1]/img");
        private readonly By _compareItemsImg2Exists = By.XPath("/html/body/div[1]/div/div[3]/div[3]/div[2]/div[1]/div[2]/div[2]/a/div[1]/img");
        private readonly By _compareItemsImg3Exists = By.XPath("/html/body/div[1]/div/div[3]/div[3]/div[2]/div[1]/div[2]/div[3]/a/div[1]/img");
        private readonly By _compareItemsImg4Exists = By.XPath("/html/body/div[1]/div/div[3]/div[3]/div[2]/div[1]/div[2]/div[4]/a/div[1]/img");
        private readonly By _compareItemsTblImg1Exists = By.XPath("/html/body/div[1]/div/div[3]/div[3]/div[2]/div[2]/div[2]/div[1]/div[1]/a/img");
        private readonly By _compareItemsTblImg2Exists = By.XPath("/html/body/div[1]/div/div[3]/div[3]/div[2]/div[2]/div[2]/div[2]/div[1]/a/img");
        private readonly By _compareItemsTblImg3Exists = By.XPath("/html/body/div[1]/div/div[3]/div[3]/div[2]/div[2]/div[2]/div[3]/div[1]/a/img");
        private readonly By _compareItemsTblImg4Exists = By.XPath("/html/body/div[1]/div/div[3]/div[3]/div[2]/div[2]/div[2]/div[4]/div[1]/a/img");
        private readonly By _unSelectCompareItems = By.CssSelector("#CatalogMainContent>div.products-list__main-content>div.products-catalogue__compare>div.products-catalogue__compare-list>div:nth-child(1)>svg>path");
        private readonly By _productComparisonLbl = By.CssSelector("#CatalogMainContent>div.products-list__main-content>div.products-compare>div.products-catalogue__compare-header>h3");
        #endregion

        #region PageElements
        private IWebElement ResetFilterBtn => _webDriverContext.Driver.FindElement(_resetFilterBtn);
        private IWebElement GetItNowBtn => _webDriverContext.Driver.FindElement(_getItNowBtn);
        private IWebElement SortByInStockBtn => _webDriverContext.Driver.FindElement(_sortByInStockBtn);
        private IWebElement SortByMostPopular => _webDriverContext.Driver.FindElement(_sortByMostPopularBtn);
        private IWebElement CompareItemsBtn => _webDriverContext.Driver.FindElement(_compareItemsBtn);
        private IWebElement SortByPriceBtn => _webDriverContext.Driver.FindElement(_sortByPriceBtn);
        private IWebElement DishFilterByBrandBox => _webDriverContext.Driver.FindElement(_dishFilterByBrand);
        private IWebElement DishFilterByColorBox => _webDriverContext.Driver.FindElement(_dishFilterByColor);
        private IWebElement DishFilterByPriceBox => _webDriverContext.Driver.FindElement(_dishFilterByPrice);
        private IWebElement RefFilterByBrandBox => _webDriverContext.Driver.FindElement(_refFilterByBrand);
        private IWebElement RefFilterByColorBox => _webDriverContext.Driver.FindElement(_refFilterByColor);
        private IWebElement RefFilterByPriceBox => _webDriverContext.Driver.FindElement(_refFilterByPrice);
        private IWebElement AppFilterByBrandBox => _webDriverContext.Driver.FindElement(_appFilterByBrand);
        private IWebElement AppFilterByColorBox => _webDriverContext.Driver.FindElement(_appFilterByColor);
        private IWebElement AppFilterByPriceBox => _webDriverContext.Driver.FindElement(_appFilterByPrice);
        private IWebElement CompareItemBtn => _webDriverContext.Driver.FindElement(_compareItemsBtn);
        private IWebElement CompareItemTag1 => _webDriverContext.Driver.FindElement(_compareItem1Tag);
        private IWebElement CompareItemTag2 => _webDriverContext.Driver.FindElement(_compareItem2Tag);
        private IWebElement CompareItemTag3 => _webDriverContext.Driver.FindElement(_compareItem3Tag);
        private IWebElement CompareItemTag4 => _webDriverContext.Driver.FindElement(_compareItem4Tag);
        private IWebElement UnSelectCompareItem => _webDriverContext.Driver.FindElement(_unSelectCompareItems);
        private IWebElement MostPopularTag => _webDriverContext.Driver.FindElement(_mostPopularTag);
        private IWebElement ProductComparisonLbl => _webDriverContext.Driver.FindElement(_productComparisonLbl);
        private IWebElement ContinueShoppingBtn => _webDriverContext.Driver.FindElement(_continueShoppingBtn);
        private IWebElement ReviewBtn => _webDriverContext.Driver.FindElement(_reviewBtn);
        private IWebElement ViewDetailsBtn => _webDriverContext.Driver.FindElement(_viewDetailsBtn);
        private IWebElement CounterDepthNodeLink => _webDriverContext.Driver.FindElement(_counterDepthNode);
        private IWebElement Page2BottomNvgBtn => _webDriverContext.Driver.FindElement(_page2BottomNvgBtn);
        private IWebElement RightArrowBottomNvgBtn => _webDriverContext.Driver.FindElement(_rightArrowBottomNvg);
        private IWebElement LeftArrowBottomNvgBtn => _webDriverContext.Driver.FindElement(_leftArrowBottomNvg);
        #endregion

        public void GotoProductPage(string page)
        {
            _webDriverContext.Driver.Navigate().GoToUrl(page);
        }

        public void ApplyFilterForDishwasherPage(string filterType)
        {

            switch (filterType.ToLower())
            {

                case "brand":
                    _wait.Until(
                        SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(_dishFilterByBrand));
                    _wait.Until(
                        SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(_dishFilterByBrand));
                    DishFilterByBrandBox.Clicks();
                    return;

                case "price":
                    _wait.Until(
                        SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(_dishFilterByPrice));
                    _wait.Until(
                        SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(_dishFilterByPrice));
                    DishFilterByPriceBox.Clicks();
                    return;


                case "color":
                    _wait.Until(
                        SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(_dishFilterByColor));
                    _wait.Until(
                        SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(_dishFilterByColor));
                    DishFilterByColorBox.Clicks();
                    return;
            }

        }

        public void ApplyFilterForRefrigeratorPage(string filterType)
        {
            switch (filterType.ToLower())
            {

                case "brand":
                    _wait.Until(
                        SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(_refFilterByBrand));
                    _wait.Until(
                        SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(_refFilterByBrand));
                    RefFilterByBrandBox.Clicks();
                    return;

                case "price":
                    _wait.Until(
                        SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(_refFilterByPrice));
                    _wait.Until(
                        SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(_refFilterByPrice));
                    RefFilterByPriceBox.Clicks();
                    return;


                case "color":
                    _wait.Until(
                        SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(_refFilterByColor));
                    _wait.Until(
                        SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(_refFilterByColor));
                    RefFilterByColorBox.Clicks();
                    return;
            }
        }

        public void ApplyFilterForAppliancePage(string filterType)
        {
            switch (filterType.ToLower())
            {

                case "brand":
                    _wait.Until(
                        SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(_appFilterByBrand));
                    _wait.Until(
                        SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(_appFilterByBrand));
                    AppFilterByBrandBox.Clicks();
                    return;

                case "price":
                    _wait.Until(
                        SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(_appFilterByPrice));
                    _wait.Until(
                        SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(_appFilterByPrice));
                    AppFilterByPriceBox.Clicks();
                    return;


                case "color":
                    _wait.Until(
                        SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(_appFilterByColor));
                    _wait.Until(
                        SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(_appFilterByColor));
                    AppFilterByColorBox.Clicks();
                    return;
            }
        }

        public void NavigateBottomClick(string navigation)
        {
            int x;
            int y;
            switch (navigation.ToLower())
            {

                case "previous":
                    _wait.Until(
                        SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(_rightArrowBottomNvg));
                    var previousLocation = RightArrowBottomNvgBtn.Location;
                    x = previousLocation.X;
                    y = previousLocation.Y;
                    _webActions.ScrollToElement(x,y,_webDriverContext.Driver);
                    RightArrowBottomNvgBtn.Clicks();
                    _wait.Until(
                        SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(_leftArrowBottomNvg));
                    LeftArrowBottomNvgBtn.Clicks();
                    return;

                case "number":
                    _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(_page2BottomNvgBtn));
                    var numberLocation = Page2BottomNvgBtn.Location;
                    x = numberLocation.X;
                    y = numberLocation.Y;
                    _webActions.ScrollToElement(x, y, _webDriverContext.Driver);
                    Page2BottomNvgBtn.Clicks();
                    return;

                case "next":
                    _wait.Until(
                        SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(_rightArrowBottomNvg));
                    var nextLocation = RightArrowBottomNvgBtn.Location;
                    x = nextLocation.X;
                    y = nextLocation.Y;
                    _webActions.ScrollToElement(x, y, _webDriverContext.Driver);
                    RightArrowBottomNvgBtn.Clicks();
                    return;
            }
        }

        public void VerifyBottomNavigation(string navigation)
        {
            if (navigation == "Previous")
            {
                _webActions.WaitUntilDocumentIsReady(_webDriverContext.Driver, TimeSpan.FromSeconds(30));
                _webActions.WaitForUrlToContains(_webDriverContext.Driver, "?page=1&category=12&sort=4", _wait);

            }

            if (navigation == "Number")
            {
                _webActions.WaitUntilDocumentIsReady(_webDriverContext.Driver, TimeSpan.FromSeconds(30));
                _webActions.WaitForUrlToContains(_webDriverContext.Driver, "?page=2&category=12&sort=4", _wait);

            }

            if (navigation == "Next")
            {
                _webActions.WaitUntilDocumentIsReady(_webDriverContext.Driver, TimeSpan.FromSeconds(30));
                _webActions.WaitForUrlToContains(_webDriverContext.Driver, "?page=2&category=12&sort=4", _wait);

            }
        }


        public void VerifyDishwasherFilterResults(string filterType)
        {
            if (filterType == "Brand")
            {
                _webActions.WaitUntilDocumentIsReady(_webDriverContext.Driver, TimeSpan.FromSeconds(30));
                _webActions.WaitForUrlToContains(_webDriverContext.Driver, "Brand-5", _wait);
                Assert.IsTrue(IsDishwasherBrandDisplayed());
            }

            if (filterType == "Price")
            {
                _webActions.WaitUntilDocumentIsReady(_webDriverContext.Driver, TimeSpan.FromSeconds(30));
                _webActions.WaitForUrlToContains(_webDriverContext.Driver, "Price-1", _wait);
                Assert.IsTrue(IsDishwasherPriceRangeDisplayed());
            }

            if (filterType == "Color")
            {
                _webActions.WaitUntilDocumentIsReady(_webDriverContext.Driver, TimeSpan.FromSeconds(30));
                _webActions.WaitForUrlToContains(_webDriverContext.Driver, "Color-2", _wait);
                Assert.IsTrue(IsDishwasherColorDisplayed());
            }
        }

        public void VerifyRefrigeratorFilterResults(string filterType)
        {
            if (filterType == "Brand")
            {
                _webActions.WaitUntilDocumentIsReady(_webDriverContext.Driver, TimeSpan.FromSeconds(30));
                _webActions.WaitForUrlToContains(_webDriverContext.Driver, "Brand-120", _wait);
                Assert.IsTrue(IsRefrigeratorBrandDisplayed());
            }

            if (filterType == "Price")
            {
                _webActions.WaitUntilDocumentIsReady(_webDriverContext.Driver, TimeSpan.FromSeconds(30));
                _webActions.WaitForUrlToContains(_webDriverContext.Driver, "Price-1", _wait);
                Assert.IsTrue(IsRefrigeratorPriceRangeDisplayed());
            }

            if (filterType == "Color")
            {
                _webActions.WaitUntilDocumentIsReady(_webDriverContext.Driver, TimeSpan.FromSeconds(30));
                _webActions.WaitForUrlToContains(_webDriverContext.Driver, "Color-2", _wait);
                Assert.IsTrue(IsRefrigeratorColorDisplayed());
            }
        }

        public void VerifyApplianceFilterResults(string filterType)
        {
            if (filterType == "Brand")
            {
                _webActions.WaitUntilDocumentIsReady(_webDriverContext.Driver, TimeSpan.FromSeconds(30));
                _webActions.WaitForUrlToContains(_webDriverContext.Driver, "Brand-120", _wait);
                Assert.IsTrue(IsApplianceBrandDisplayed());
            }

            if (filterType == "Price")
            {
                _webActions.WaitUntilDocumentIsReady(_webDriverContext.Driver, TimeSpan.FromSeconds(30));
                _webActions.WaitForUrlToContains(_webDriverContext.Driver, "Price-1", _wait);
                Assert.IsTrue(IsAppliancePriceRangeDisplayed());
            }

            if (filterType == "Color")
            {
                _webActions.WaitUntilDocumentIsReady(_webDriverContext.Driver, TimeSpan.FromSeconds(30));
                _webActions.WaitForUrlToContains(_webDriverContext.Driver, "Color-2", _wait);
                Assert.IsTrue(IsApplianceColorDisplayed());
            }
        }

        public void ResetFilterClick()
        {
            _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(_resetFilterBtn));
            _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(_resetFilterBtn));
            ResetFilterBtn.Clicks();
        }

        public void VerifyResetFilter()
        {
            _webActions.WaitUntilDocumentIsReady(_webDriverContext.Driver, TimeSpan.FromSeconds(30));
            _webActions.WaitForUrlToContains(_webDriverContext.Driver, "?page=1&sort=4", _wait);
        }


        public void InStockSelection()
        {

            _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(_sortByInStockBtn));
            _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(_sortByInStockBtn));

        }

        public void VerifyInStockSelection()
        {

            _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(_getItNowBtn));
            _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(_getItNowBtn));
        }

        public void SortByPriceClick()
        {
            _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(_sortByPriceBtn));
            _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(_sortByPriceBtn));
            SortByPriceBtn.Clicks();
        }

        public void VerifySortByPrice()
        {
            _webActions.WaitUntilDocumentIsReady(_webDriverContext.Driver, TimeSpan.FromSeconds(30));
            _webActions.WaitForUrlToContains(_webDriverContext.Driver, "?page=1&sort=1", _wait); //sort=1 == ascending to descending
        }


        public void MostPopularBtnClick()
        {
            _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(_sortByMostPopularBtn));
            _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(_sortByMostPopularBtn));
            SortByMostPopular.Clicks();
        }

        public void SelectCompareItems()
        {
            CompareItemTag1.Clicks();
            CompareItemTag2.Clicks();
            CompareItemTag3.Clicks();
            CompareItemTag4.Clicks();
        }


        public void VerifyMostPopular()
        {
            _webActions.WaitUntilDocumentIsReady(_webDriverContext.Driver, TimeSpan.FromSeconds(30));
            _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(_mostPopularTag));
            _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(_mostPopularTag));
        }


        public void CompareItemsBtnClick()
        {
            _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(_compareItemsBtn));
            _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(_compareItemsBtn));
            CompareItemBtn.Clicks();
        }

        public void CompareItemsAdded()
        {
            _webActions.WaitUntilDocumentIsReady(_webDriverContext.Driver, TimeSpan.FromSeconds(30));
            _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(_compareItemsImg1Exists));
            _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(_compareItemsImg2Exists));
            _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(_compareItemsImg3Exists));
            _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(_compareItemsImg4Exists));
        }



        public void VerifyCompareItemsInTable()
        {
            _webActions.WaitUntilDocumentIsReady(_webDriverContext.Driver, TimeSpan.FromSeconds(30));
            _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(_compareItemsTblImg1Exists));
            _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(_compareItemsTblImg2Exists));
            _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(_compareItemsTblImg3Exists));
            _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(_compareItemsTblImg4Exists));
            Assert.AreEqual(ProductComparisonLbl.Displayed, true);
        }


        public void ContinueShoppingAfterComparing(string productPage)
        {
            _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(_continueShoppingBtn));
            ContinueShoppingBtn.Clicks();
            _webActions.WaitForUrlToContains(_webDriverContext.Driver, productPage, _wait);

        }

        public void UnselectItemsAfterComparing()
        {
            UnSelectCompareItem.Clicks();
            UnSelectCompareItem.Clicks();
            UnSelectCompareItem.Clicks();
            UnSelectCompareItem.Clicks();
        }

        public void ReviewBtnClick()
        {
            _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(_reviewBtn));
            _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(_reviewBtn));
            ReviewBtn.Clicks();
        }

        public void VerifyReviewPopUp()
        {
            var writeReviewBtn = _webDriverContext.Driver.FindElement(_writeAReviewBtn);
            _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(_writeAReviewBtn));
            _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(_reviewCommentModal));
        }


        public void ViewDetailsClick()
        {
            var location = ViewDetailsBtn.Location;
            int viewDetailsX = location.X;
            int viewDetailsY = location.Y;
            _webActions.ScrollToElement(viewDetailsX,viewDetailsY,_webDriverContext.Driver);
            _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(_viewDetailsBtn));
            _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(_viewDetailsBtn));
            ViewDetailsBtn.Clicks();
        }

        public void TopPageNavigationClick()
        {
            _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(_counterDepthNode));
            _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(_counterDepthNode));
            CounterDepthNodeLink.Clicks();
        }


        public void VerifyTopPageNavigation(string productPage)
        {
            _webActions.WaitUntilDocumentIsReady(_webDriverContext.Driver, TimeSpan.FromSeconds(30));
                _webActions.WaitForUrlToContains(_webDriverContext.Driver, productPage, _wait);
        }

        public void VerifyProductPage()
        {
            _webActions.WaitUntilDocumentIsReady(_webDriverContext.Driver, TimeSpan.FromSeconds(30));
        }
    
    private bool IsApplianceColorDisplayed()
        {
            var brand = _webDriverContext.Driver.FindElement(By.LinkText("LG ELECTRONICS LSG4513ST")); //Stainless steel
            if (brand.Displayed)
            {
                return true;
            }

            return false;
        }


        private bool IsDishwasherBrandDisplayed()
        {
            var brand = _webDriverContext.Driver.FindElement(By.LinkText("ASKO DFI663")); //Brand name
            if (brand.Displayed)
            {
                return true;
            }

            return false;
        }

        private bool IsRefrigeratorBrandDisplayed()
        {
            var brand = _webDriverContext.Driver.FindElement(By.LinkText("BEKO BFFD3624SS")); //Brand name
            if (brand.Displayed)
            {
                return true;
            }

            return false;
        }


        private bool IsApplianceBrandDisplayed()
        {
            var brand = _webDriverContext.Driver.FindElement(By.LinkText("BEKO SLGR24410SS")); //Brand name
            if (brand.Displayed)
            {
                return true;
            }

            return false;
        }

        private bool IsDishwasherPriceRangeDisplayed()
        {
            var brand = _webDriverContext.Driver.FindElement(By.LinkText("MIELE G7566SCVISF")); // $2000-2999
            if (brand.Displayed)
            {
                return true;
            }

            return false;
        }


        private bool IsRefrigeratorPriceRangeDisplayed()
        {
            var brand = _webDriverContext.Driver.FindElement(By.LinkText("WHIRLPOOL WRQA59CNKZ")); // $2000-2999
            if (brand.Displayed)
            {
                return true;
            }

            return false;
        }

        private bool IsAppliancePriceRangeDisplayed()
        {
            var brand = _webDriverContext.Driver.FindElement(By.LinkText("CAFÉ APPLIANCES CGS700P2MS1")); // $2000-2999
            if (brand.Displayed)
            {
                return true;
            }

            return false;
        }

        private bool IsDishwasherColorDisplayed()
        {
            var brand = _webDriverContext.Driver.FindElement(By.LinkText("BEKO DUT25401X")); //Stainless steel
            if (brand.Displayed)
            {
                return true;
            }

            return false;
        }

        private bool IsRefrigeratorColorDisplayed()
        {
            var brand = _webDriverContext.Driver.FindElement(By.LinkText("SAMSUNG RF18HFENBSR")); //Stainless steel
            if (brand.Displayed)
            {
                return true;
            }

            return false;
        }

        public void VerifySelectedFilter()
        {
            throw new NotImplementedException();
        }

    }
}