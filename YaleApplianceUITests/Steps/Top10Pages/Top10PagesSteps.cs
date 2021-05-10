using System;
using NUnit.Framework;
using TechTalk.SpecFlow;
using YaleApplianceUITests.Pages;

namespace YaleApplianceUITests.Steps.Top10Pages
{
    [Binding, Parallelizable]
    public sealed class Top10PagesSteps
    {
        private readonly Pages.HomePage _homePage;

        public Top10PagesSteps(Pages.HomePage homePage)
        {
            _homePage = homePage;
        }


        [Given(@"User is on the Yale HomePage'(.*)'")]
        public void GivenUserIsOnTheYaleHomePages(Uri url)
        {
            _homePage.GoToYaleHomePage();
        }


        [When(@"Page is fully loaded")]
        public void WhenPageIsFullyLoaded()
        {
            _homePage.PageLoadValidation();
        }

    
        [Then(@"User should be able to interact with page accordingly'(.*)'")]
        public void ThenUserShouldBeAbleToInteractWithPageAccordingly(string page)
        {
            _homePage.PerformHealthCheckActions(page);
        }


    }
}

