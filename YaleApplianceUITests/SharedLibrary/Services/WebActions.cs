using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Internal;
using OpenQA.Selenium.Support.UI;
using YaleApplianceUITests.SharedLibrary.Interfaces;

namespace YaleApplianceUITests.SharedLibrary.Services
{
    public class WebActions : IWebActions
    {
        public void Click(IWebElement element)
        {
            var wait = new WebDriverWait(((IWrapsDriver) element).WrappedDriver, TimeSpan.FromSeconds(10));
            try
            {
                if (element.Displayed.Equals(true))
                {
                    wait.IgnoreExceptionTypes(typeof(StaleElementReferenceException));
                    wait.Until(ExpectedConditions.ElementToBeClickable(element)).Click();

                }
            }
            catch (Exception e)
            {

                Console.WriteLine(e.StackTrace);
            }
        }

        public IEnumerable<IWebElement> WaitForPresenceOfAllElementsLocatedBy(IWebElement element, By locator)
        {
            var wait = new WebDriverWait(((IWrapsDriver)element).WrappedDriver, TimeSpan.FromSeconds(10));
            try
            {
                wait.IgnoreExceptionTypes(typeof(StaleElementReferenceException));
                return wait.Until(ExpectedConditions
                    .PresenceOfAllElementsLocatedBy(locator));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw new NoSuchElementException($"elements with Locator <{locator}> are not found");
            }
        }
    }
}

   

