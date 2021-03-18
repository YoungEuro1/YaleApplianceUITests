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
        private readonly PaymentPage _paymentPage;
        private readonly OrderConfirmationPage _orderConfirmationPage;



        public CheckoutSteps(ScenarioContext scenarioContext, CheckoutPage checkoutPage, PaymentPage paymentPage, OrderConfirmationPage orderConfirmationPage)
        {
            _scenarioContext = scenarioContext;
            _checkoutPage = checkoutPage;
            _paymentPage = paymentPage;
            _orderConfirmationPage = orderConfirmationPage;
        }

        [Given(@"User is on a product page")]
        public void GivenUserIsOnAProductPage()
        {
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
            _checkoutPage.ChooseProfessionalDelivery();
        }


        [Given(@"Billing details are added")]
        public void GivenBillingDetailsAreAdded()
        {
            _paymentPage.EnterBillingAddress();
        }

        [Given(@"Payment details are added '(.*)'")]
        public void GivenPaymentDetailsAreAdded(string paymentType)
        {
            _paymentPage.PaymentMethodHelper(paymentType);
        }


        [When(@"Placing Order")]
        public void WhenPlacingOrder()
        {
            _paymentPage.PlaceOrder();
        }

        [Then(@"Order should be placed successfully")]
        public void ThenOrderShouldBePlacedSuccessfully()
        {
            _orderConfirmationPage.OrderConfirmationMessage();
        }

    }
}
