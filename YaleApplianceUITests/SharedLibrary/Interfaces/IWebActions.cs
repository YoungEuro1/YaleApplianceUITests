using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace YaleApplianceUITests.SharedLibrary.Interfaces
{
    public interface IWebActions
    {
        void Click(IWebElement element);
        IEnumerable<IWebElement> WaitForPresenceOfAllElementsLocatedBy(IWebElement element, By locator);
        IEnumerable<IWebElement> WaitForPresenceOfAllElementsLocatedBy(IWebDriver driver, By locator);
        IWebElement WaitForPresenceOfElementLocatedBy(IWebElement element, By locator);
        bool WaitForUrlToContains(IWebDriver driver, string url, WebDriverWait wait);
        void MoveTo(IWebDriver driver, IWebElement source, IWebElement target);
    }
}



