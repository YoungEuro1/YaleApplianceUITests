using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Internal;
using OpenQA.Selenium.Support.UI;
using YaleApplianceUITests.Factories;

namespace YaleApplianceUITests.SharedLibrary.Extensions
{
    public static class WebElementExtensions
    {
        public static IWebElement JSClick(this IWebElement element)
        {
            var driver = ((IWrapsDriver)element).WrappedDriver;
            var executor = (IJavaScriptExecutor)driver;
            executor.ExecuteScript("arguments[0].click();", element);
            return element;
        }

        public static void JSClick(this ReadOnlyCollection<IWebElement> element, int index)
        {
            var driver = ((IWrapsDriver)element).WrappedDriver;
            var executor = (IJavaScriptExecutor)driver;
            executor.ExecuteScript("arguments[0].click();", element[index]);
        }

        public static bool Clicks(this IWebElement element)
        {
            bool result = false;
            int attempts = 0;
            while (attempts <= 2)
            {
                try
                {
                    Thread.Sleep(500);
                    element.Click();
                    result = true;
                    break;
                }
                catch (StaleElementReferenceException)
                {
                }

                attempts++;
            }

            return result;
        }

        public static bool IsElementDisplayed(this IWebElement element)
        {
            try
            {
                bool ele = element.Displayed;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

   
        public static IWebElement FindElementByJs(this IWebDriver driver, string jsCommand)
        {
            return (IWebElement)((IJavaScriptExecutor)driver).ExecuteScript(jsCommand);
        }

        public static IWebElement FindElementByJsWithWait(this IWebDriver driver, string jsCommand, int timeoutInSeconds)
        {
            if (timeoutInSeconds > 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
                wait.Until(d => d.FindElementByJs(jsCommand));
            }
            return driver.FindElementByJs(jsCommand);
        }

        public static void ScrollToElement(this IWebElement element)
        {
            Point p = element.Location;
            var driver = ((IWrapsDriver)element).WrappedDriver;
            var executor = (IJavaScriptExecutor)driver;
            executor.ExecuteScript("window.scrollTo(" + p.X + "," + (p.Y + 150) + ");");
        }

        public static IEnumerable<IWebElement> IsElementsVisible(this IWebDriver driver, By by, int timeout)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
            return wait.Until(d =>
            {
                var elements = d.FindElements(by).Where(i => i.Displayed).ToList();
                return new ReadOnlyCollection<IWebElement>(elements);
            });
        }


        public static Actions Actions(this IWebElement element)
        {
            var driver = ((IWrapsDriver)element).WrappedDriver;
            return new Actions(driver);

        }

    }
}
