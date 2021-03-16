using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;

namespace YaleApplianceUITests.SharedLibrary.Interfaces
{
    public interface IWebActions
    {
        void Click(IWebElement element);
    }
}
