using System;
using System.Collections.Generic;
using NUnit.Framework;
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
                throw new Exception(e.StackTrace);
            }
        }


        public bool Clickable(IWebElement element)
        {
            var wait = new WebDriverWait(((IWrapsDriver)element).WrappedDriver, TimeSpan.FromSeconds(10));
            try
            {
                if (element.Displayed.Equals(true))
                {
                    wait.IgnoreExceptionTypes(typeof(StaleElementReferenceException));
                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(element));
                    return true;
                }
            }
            catch (Exception e)
            {

                Console.WriteLine(e.StackTrace);
                throw new Exception(e.StackTrace);
          
            }
            return false;
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
                throw new NoSuchElementException(e.StackTrace);
            }
        }

        public void WaitUntilDocumentIsReady(IWebDriver driver, TimeSpan timeoutInSeconds)
        {
            var javaScriptExecutor = driver as IJavaScriptExecutor;
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds.Seconds));

            try
            {
                Func<IWebDriver, bool> readyCondition = webDriver => (bool)javaScriptExecutor.ExecuteScript("return (document.readyState == 'complete' && jQuery.active == 0)");
                wait.Until(readyCondition);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.InnerException);
                throw new Exception(e.StackTrace);
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
                throw new NoSuchElementException(e.StackTrace);
            }
        }

        public bool ClickElementUsingJs(string element, IWebDriver driver)
        {
            try
            {
                IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
                executor.ExecuteScript(element);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void ScrollToElement(int x, int y, IWebDriver driver)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("window.scrollBy(" + x + ", " + y + ");");
        }
    }
}

   

