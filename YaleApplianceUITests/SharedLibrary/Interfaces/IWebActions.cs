using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace YaleApplianceUITests.SharedLibrary.Interfaces
{
    public interface IWebActions
    {
        void Click(IWebElement element);
        bool Clickable(IWebElement element);
        IEnumerable<IWebElement> WaitForPresenceOfAllElementsLocatedBy(IWebElement element, By locator);
        IEnumerable<IWebElement> WaitForPresenceOfAllElementsLocatedBy(IWebDriver driver, By locator);
        bool WaitForUrlToContains(IWebDriver driver, string url, WebDriverWait wait);
        void MoveTo(IWebDriver driver, IWebElement source, IWebElement target);
        void MoveToAndHold(IWebDriver driver, IWebElement target);
        void WaitUntilDocumentIsReady(IWebDriver driver, TimeSpan timeoutInSeconds);
    }
}



