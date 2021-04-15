using NUnit.Framework;
using TechTalk.SpecFlow;
using YaleApplianceUITests.Pages;

namespace YaleApplianceUITests.Steps.Checkout
{
    [Binding, Parallelizable]
    public sealed class CheckoutSteps
    {
        private readonly CheckoutPage _checkoutPage;
        private readonly PaymentPage _paymentPage;
        private readonly OrderConfirmationPage _orderConfirmationPage;
        private readonly DishwasherPage _dishwasherPage;
        private readonly RefrigeratorPage _refrigeratorPage;


        public CheckoutSteps(CheckoutPage checkoutPage, PaymentPage paymentPage, OrderConfirmationPage orderConfirmationPage, DishwasherPage dishwasherPage, RefrigeratorPage refrigeratorPage)
        {
            _checkoutPage = checkoutPage;
            _paymentPage = paymentPage;
            _orderConfirmationPage = orderConfirmationPage;
            _dishwasherPage = dishwasherPage;
            _refrigeratorPage = refrigeratorPage;
        }

    
        [Given(@"User is on a refrigerator page")]
        public void GivenUserIsOnARefrigeratorPage()
        {
            _checkoutPage.GoToRefrigeratorPageUrl();
        }

        [Given(@"User is on the yale's refrigerator page")]
        public void GivenUserIsOnTheYaleSRefrigeratorPage()
        {
            _refrigeratorPage.GoToYalesRefrigeratorPageUrl();
        }


        [Given(@"Refrigerator available for personal pickup is added to cart")]
        public void GivenRefrigeratorAvailableForPersonalPickupIsAddedToCart()
        {
            _refrigeratorPage.ViewRefrigeratorForMultipleDeliveryOptions();
            _refrigeratorPage.AddToCartBtn();
            _checkoutPage.ChoosePersonalPickupOption();
        }

        [Given(@"User is on the dishwasher product page")]
        public void GivenUserIsOnTheDishwasherProductPage()
        {
            _dishwasherPage.GoToDishwasherPage();
        }

        [Given(@"Dishwasher is added to cart")]
        public void GivenDishwasherIsAddedToCart()
        {
            _dishwasherPage.AddDishwasherToCart();
        }

        [Given(@"Installation is added to cart")]
        public void GivenInstallationIsAddedToCart()
        {
            _checkoutPage.AddDishwasherInstallation();
        }


        [Given(@"Next day delivery is added to cart")]
        public void GivenNextDayDeliveryIsAddedToCart()
        {
            _checkoutPage.SameDayDelivery();
        }


        [Given(@"Product is added to cart")]
        public void GivenProductIsAddedToCart()
        {
            _checkoutPage.ClickAddToCartBtn();
        }

        [Given(@"Refrigerator is added to cart")]
        public void GivenRefrigeratorIsAddedToCart()
        {
            _refrigeratorPage.ClickAddToCartBtn();
        }


        [Given(@"Delivery details are added")]
        public void GivenDeliveryDetailsAreAdded()
        {
            _checkoutPage.ChooseYaleDeliveryOption();
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


        [Given(@"Refrigerator available for same day delivery is added to cart")]
        public void GivenRefrigeratorAvailableForSameDayDeliveryIsAddedToCart()
        {
            _refrigeratorPage.ViewRefrigeratorForMultipleDeliveryOptions();
            _refrigeratorPage.AddToCartBtn();
            _checkoutPage.SameDayDelivery();
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
