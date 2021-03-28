using System;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using YaleApplianceUITests.Factories;
using YaleApplianceUITests.Fixtures;
using YaleApplianceUITests.SharedLibrary.Interfaces;
using YaleApplianceUITests.SharedLibrary.Services;

namespace YaleApplianceUITests.Pages
{
    public class DishwasherPage
    {
        private readonly EnvironmentFixture _environmentFixture;
        private readonly WebDriverContext _webDriverContext;
        private readonly IWebActions _webActions;
        private readonly WebDriverWait _wait;


        public DishwasherPage(WebDriverContext webDriverContext, EnvironmentFixture environmentFixture)
        {
            _environmentFixture = environmentFixture;
            _webDriverContext = webDriverContext;
            _webActions = new WebActions(_webDriverContext);
            _wait = new WebDriverWait(_webDriverContext.Driver, TimeSpan.FromSeconds(10));
        }

        #region Locators

        private readonly By _compactorsBtn = By.CssSelector("body > div.main-wrapper > div > section > div > div.appliances > div:nth-child(2) > a > div");
        private readonly By _dishwasherBtn = By.CssSelector("body > div.main-wrapper > div > section > div > div.appliances > div:nth-child(1) > a > div");
        private readonly By _dishwasherViewDetailsBtn = By.CssSelector("#products-list-container > div > div:nth-child(5) > div > div.catalogue-item__descr > div.catalogue-item__descr-view > a");
        private readonly By _addToCartBtn = By.Id("NormalCheckout");
        #endregion

        private IWebElement CompactorBtn => _webDriverContext.Driver.FindElement(_compactorsBtn);
        private IWebElement DishwasherBtn => _webDriverContext.Driver.FindElement(_dishwasherBtn);

        private IWebElement DishwasherViewDetailsBtn => _webDriverContext.Driver.FindElement(_dishwasherViewDetailsBtn);

        private IWebElement AddToCartBtn => _webDriverContext.Driver.FindElement(_addToCartBtn);



        public DishwasherPage GoToDishwasherPage()
        {
           _webDriverContext.Driver.Navigate().GoToUrl(_environmentFixture.Environment.DishwasherPageUrl);
           return this;
        }

        public void AddDishwasherToCart()
        {
            _wait.Until(x => x.FindElement(_dishwasherBtn).Displayed);
            DishwasherBtn.Click();
            Thread.Sleep(TimeSpan.FromSeconds(3));
            _webActions.MoveTo(_webDriverContext.Driver, DishwasherViewDetailsBtn, DishwasherViewDetailsBtn);
            _wait.Until(x => x.FindElement(_addToCartBtn).Displayed);
            ((IJavaScriptExecutor)_webDriverContext.Driver).ExecuteScript("arguments[0].scrollIntoView(true);", AddToCartBtn);
            AddToCartBtn.Click();
        }
    }
}
