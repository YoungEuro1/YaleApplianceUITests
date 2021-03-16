using YaleApplianceUITests.Fixtures;
using YaleApplianceUITests.Helpers;

namespace YaleApplianceUITests.Pages
{
    public class CheckoutPage
    {
        private readonly EnvironmentFixture _environmentFixture;
        private readonly BrowserHelper _browserHelper;
    

        public CheckoutPage(BrowserHelper browserHelper, EnvironmentFixture environmentFixture)
        {
            _environmentFixture = environmentFixture;
            _browserHelper = browserHelper;
        }


        public CheckoutPage GoToCheckoutPage()
        {
            _browserHelper.Driver.Navigate().GoToUrl(_environmentFixture.Environment.CheckoutUrl);
            return this;
        }

        public CheckoutPage EnterBillingAddress()
        {
            return this;
        }
    }

}

   

