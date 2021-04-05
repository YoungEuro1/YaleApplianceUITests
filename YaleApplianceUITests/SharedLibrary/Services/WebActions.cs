using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Internal;
using OpenQA.Selenium.Support.UI;
using YaleApplianceUITests.Factories;
using YaleApplianceUITests.SharedLibrary.Extensions;
using YaleApplianceUITests.SharedLibrary.Interfaces;

namespace YaleApplianceUITests.SharedLibrary.Services
{
    public class WebActions : IWebActions
    {

        private IWebDriver Driver { get; set; }

        
        public WebActions(WebDriverContext webDriverContext)
        {
            Driver = webDriverContext.Driver;
        }


        public void Click(IWebElement element)
        {
            var wait = new WebDriverWait(((IWrapsDriver) element).WrappedDriver, TimeSpan.FromSeconds(10));
            try
            {
                if (element.Displayed.Equals(true))
                {
                    wait.IgnoreExceptionTypes(typeof(StaleElementReferenceException));
                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(element)).Click();

                }
            }
            catch (Exception e)
            {

                Console.WriteLine(e.StackTrace);
            }
        }

        public IEnumerable<IWebElement> WaitForPresenceOfAllElementsLocatedBy(IWebDriver driver, By locator)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
            try
            {
                wait.IgnoreExceptionTypes(typeof(StaleElementReferenceException));
                return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.PresenceOfAllElementsLocatedBy(locator));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw new NoSuchElementException($"elements with Locator <{locator}> are not found");
            }
        }

        public IEnumerable<IWebElement> WaitForPresenceOfAllElementsLocatedBy(IWebElement element, By locator)
        {
            var wait = new WebDriverWait(((IWrapsDriver)element).WrappedDriver, TimeSpan.FromSeconds(10));
            try
            {
                wait.IgnoreExceptionTypes(typeof(StaleElementReferenceException));
                return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.PresenceOfAllElementsLocatedBy(locator));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw new NoSuchElementException($"elements with Locator <{locator}> are not found");
            }
        }

        public IWebElement WaitForPresenceOfElementLocatedBy(IWebElement element, By locator)
        {
            var wait = new WebDriverWait(((IWrapsDriver)element).WrappedDriver, TimeSpan.FromSeconds(10));
            try
            {
                wait.IgnoreExceptionTypes(typeof(StaleElementReferenceException));
                return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(locator));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw new NoSuchElementException($"elements with Locator <{locator}> are not found");
            }
        }

        public bool WaitForUrlToContains(IWebDriver driver, string url, WebDriverWait wait)
        {
            if (wait == null)
            {
                wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            }

            try
            {
                wait.IgnoreExceptionTypes(typeof(StaleElementReferenceException));
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.UrlContains(url));
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }


        public void MoveTo(IWebDriver driver, IWebElement source, IWebElement target)
        {
            try
            {
                if (source.IsElementDisplayed())
                {
                    source.Actions()
                        .ClickAndHold(source)
                        .MoveToElement(target)
                        .Click()
                        .Release()
                        .Perform();
                }
            }
            catch (NoSuchElementException e)
            {
                Console.WriteLine(e.Message);
            }
        }


        public void MoveToAndHold(IWebDriver driver, IWebElement target)
        {
            try
            {
                if (target.IsElementDisplayed())
                {
                    target.Actions()
                        .MoveToElement(target)
                        .ClickAndHold()
                        .Perform();
                }
            }
            catch (NoSuchElementException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}

   

