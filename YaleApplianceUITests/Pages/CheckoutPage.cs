using YaleApplianceUITests.Factories;
using YaleApplianceUITests.Fixtures;


namespace YaleApplianceUITests.Pages
{
    public class CheckoutPage
    {
        private readonly EnvironmentFixture _environmentFixture;
        private readonly WebDriverContext _webDriverContext;
        

        public CheckoutPage(WebDriverContext webDriverContext, EnvironmentFixture environmentFixture)
        {
            _environmentFixture = environmentFixture;
            _webDriverContext = webDriverContext;
        }


        public CheckoutPage GoToCheckoutPage()
        {
            _webDriverContext.Driver.Navigate().GoToUrl(_environmentFixture.Environment.CheckoutUrl);
            return this;
        }

        public CheckoutPage EnterBillingAddress()
        {
            return this;
        }
    }

}

   

