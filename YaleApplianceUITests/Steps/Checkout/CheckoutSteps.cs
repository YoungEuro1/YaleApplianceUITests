using NUnit.Framework;
using TechTalk.SpecFlow;
using YaleApplianceUITests.Pages;

namespace YaleApplianceUITests.Steps.Checkout
{
    [Binding, Parallelizable]
    public sealed class CheckoutSteps
    {
        
        private readonly ScenarioContext _scenarioContext;
        private readonly CheckoutPage _checkoutPage;

        public CheckoutSteps(ScenarioContext scenarioContext, CheckoutPage checkoutPage)
        {
            _scenarioContext = scenarioContext;
            _checkoutPage = checkoutPage;
        }

        [Given(@"User is on a product page")]
        public void GivenUserIsOnAProductPage()
        {
           // ScenarioContext.Current.Pending();
           _checkoutPage.GoToCheckoutPage();
        }

        [Given(@"Product is added to cart")]
        public void GivenProductIsAddedToCart()
        {
            _checkoutPage.ClickGetItNowBtn();
        }

        [Given(@"Delivery details are added")]
        public void GivenDeliveryDetailsAreAdded()
        {
           // ScenarioContext.Current.Pending();
        }

        [Given(@"Billing details visa are added")]
        public void GivenBillingDetailsVisaAreAdded()
        {
            //ScenarioContext.Current.Pending();
        }

        [Given(@"Payment detils are added")]
        public void GivenPaymentDetilsAreAdded()
        {
            //ScenarioContext.Current.Pending();
        }

        [When(@"Placing Order")]
        public void WhenPlacingOrder()
        {
            //ScenarioContext.Current.Pending();
        }

        [Then(@"Order should be placed sucessfully")]
        public void ThenOrderShouldBePlacedSucessfully()
        {
           // ScenarioContext.Current.Pending();
        }

    }
}
