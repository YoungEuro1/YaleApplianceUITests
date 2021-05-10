using NUnit.Framework;
using TechTalk.SpecFlow;
using YaleApplianceUITests.Pages;


namespace YaleApplianceUITests.Steps.HomePage
{
    [Binding, Parallelizable]
    public sealed class HomePageSteps
    {

        private readonly Pages.HomePage _homePage;
        private readonly ScheduleShowRoomVisitPage _scheduleShowRoomVisitPage;
        private readonly ScheduleAVideoCallPage _scheduleAVideoCallPage;

        public HomePageSteps(Pages.HomePage homePage, ScheduleShowRoomVisitPage scheduleShowRoomVisitPage, ScheduleAVideoCallPage scheduleAVideoCallPage)
        {
            _homePage = homePage;
            _scheduleShowRoomVisitPage = scheduleShowRoomVisitPage;
            _scheduleAVideoCallPage = scheduleAVideoCallPage;
        }


        [Given(@"User is on the homepage")]
        public void GivenUserIsOnTheHomepage()
        {
            _homePage.GoToYaleHomePage();
        }

        [When(@"User clicks on schedule a showroom visit")]
        public void WhenUserClicksOnScheduleAShowroomVisit()
        {
            _homePage.ScheduleAVisit();
        }

        [Then(@"User should be directed to schedule a showroom visit page")]
        public void ThenUserShouldBeDirectedToScheduleAShowroomVisitPage()
        {
            _scheduleShowRoomVisitPage.PageValidation();
        }


        [When(@"User clicks on schedule a video call")]
        public void WhenUserClicksOnScheduleAVideoCall()
        {
            _homePage.ScheduleAVideoCall();
        }

        [Then(@"User should be directed to schedule a video call page")]
        public void ThenUserShouldBeDirectedToScheduleAVideoCallPage()
        {
            _scheduleAVideoCallPage.PageValidation();
        }


        [Then(@"User should be able to click the chat now button")]
        public void ThenUserShouldBeAbleToClickTheChatNowButton()
        {
            _homePage.VerifyChatNowBtn();
        }

     

        [Then(@"User should be directed to a popup video ")]
        public void ThenUserShouldBeDirectedToAPopupVideo()
        {
            _homePage.MoreInformationVideoPopUp();
        }

        
        [Then(@"User should be able to click on question mark under video call  ")]
        public void ThenUserShouldBeAbleToClickOnQuestionMarkUnderVideoCall()
        {
            _homePage.MoreVideoInformationBtn();
        }


        [When(@"User clicks on the Shop Online button")]
        public void WhenUserClicksOnTheShopOnlineButton()
        {
            _homePage.ClickOnShopOnlineBtn();
        }

        [Then(@"User should be directed to the catalog page")]
        public void ThenUserShouldBeDirectedToTheCatalogPage()
        {
            _homePage.VerifyShopOnlineBtn();
        }

        [When(@"User clicks on covid banner")]
        public void WhenUserClicksOnCovidBanner()
        {
            _homePage.ClickCovidLink();
        }

        [Then(@"Page should direct user to covid safety page")]
        public void ThenPageShouldDirectUserToCovidSafetyPage()
        {
            _homePage.VerifyCovidLink();
        }

        [When(@"User clicks on a picture '(.*)'")]
        public void WhenUserClicksOnAPicture(string categoryType)
        {
            _homePage.ProductPictureClick(categoryType);
        }

        [When(@"User clicks on view products '(.*)'")]
        public void WhenUserClicksOnViewProducts(string categoryType)
        {

            _homePage.ViewProductCategoryClick(categoryType);
        }


        [Then(@"Page should direct user to category page '(.*)'")]
        public void ThenPageShouldDirectUserToCategoryPage(string categoryPage)
        {
            _homePage.VerifyCategoryPage(categoryPage);
        }

        [When(@"User clicks on explore product")]
        public void WhenUserClicksOnExploreProduct()
        {
            _homePage.ClickExploreProduct();
        }

        [Then(@"Page should direct user to product item")]
        public void ThenPageShouldDirectUserToProductItem()
        {
            _homePage.VerifyExploreProductLink();
        }

        [When(@"User clicks on arrows to navigate next/previous")]
        public void WhenUserClicksOnArrowsToNavigateNextPrevious()
        {
            _homePage.VerifyArrows();
        }

        [Then(@"Page should go the next or previous item")]
        public void ThenPageShouldGoTheNextOrPreviousItem()
        {
                _homePage.VerifyArrowClick();
        }


        [When(@"User clicks on on visit outlet")]
        public void WhenUserClicksOnOnVisitOutlet()
        {
            _homePage.VisitOutletClick();
        }

        [Then(@"Page should direct user to the outlet page")]
        public void ThenPageShouldDirectUserToTheOutletPage()
        {
            _homePage.VerifyVisitOuletBtn();
        }


        [When(@"User clicks on Learn more '(.*)'")]
        public void WhenUserClicksOnLearnMore(string learnMore)
        {
            _homePage.LearnMoreClick(learnMore);
        }

        [Then(@"Page should direct user to clicked linked '(.*)'")]
        public void ThenPageShouldDirectUserToClickedLinked(string page)
        {
            _homePage.VerifyLearnMorePage(page);
        }


        [When(@"User clicks on Schedule appointment '(.*)'")]
        public void WhenUserClicksOnScheduleAppointment(string showroom)
        {
        
            _homePage.ScheduleApptClick(showroom);
        }


        [Then(@"Page should direct user to the appointment page '(.*)'")]
        public void ThenPageShouldDirectUserToTheAppointmentPage(string page)
        {
            _homePage.VerifyScheduleApptPage(page);
        }

        [When(@"User clicks on pinpoint icon on map")]
        public void WhenUserClicksOnPinpointIconOnMap()
        {
            _homePage.PinpointIconMapClick();
        }

        [Then(@"Address popup should appear")]
        public void ThenAddressPopupShouldAppear()
        {
            _homePage.VerifyAddressMap();
        }


    }
}
