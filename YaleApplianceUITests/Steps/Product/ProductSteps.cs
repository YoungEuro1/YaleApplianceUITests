using NUnit.Framework;
using TechTalk.SpecFlow;
using YaleApplianceUITests.Pages;

namespace YaleApplianceUITests.Steps.Product
{
    [Binding, Parallelizable]
    public sealed class ProductSteps
    {
        private readonly ProductPage _productPage;
        
            public ProductSteps(ProductPage productPage)
            {
                _productPage = productPage;
            }


            [Given(@"User wants to filter content '(.*)'")]
            public void GivenUserWantsToFilterContent(string productPage)
            {
            _productPage.GotoProductPage(productPage);
            }


            [Given(@"User selects the Dishwasher filter in the list '(.*)'")]
            [When(@"User selects the Dishwasher filter in the list '(.*)'")]
            public void WhenUserSelectsTheDishwasherFilterInTheList(string filterType)
            {
                _productPage.ApplyFilterForDishwasherPage(filterType);
            }

            [Given(@"User selects the Refrigerator filter in the list '(.*)'")]
            [When(@"User selects the Refrigerator filter in the list '(.*)'")]
            public void WhenUserSelectsTheRefrigeratorFilterInTheList(string filterType)
            {
                _productPage.ApplyFilterForRefrigeratorPage(filterType);
            }

            [Given(@"User selects the Cooking appliance filter in the list '(.*)'")]
            [When(@"User selects the Cooking appliance filter in the list '(.*)'")]
            public void WhenUserSelectsTheCookingApplianceFilterInTheList(string filterType)
            {
                _productPage.ApplyFilterForAppliancePage(filterType);
            }


            [Then(@"Dishwasher Catalog should update to show only items with selected filter '(.*)'")]
            public void ThenDishwasherCatalogShouldUpdateToShowOnlyItemsWithSelectedFilter(string filterType)
            {
            _productPage.VerifyDishwasherFilterResults(filterType);
        }

            [Then(@"Refrigerator Catalog should update to show only items with selected filter '(.*)'")]
            public void ThenRefrigeratorCatalogShouldUpdateToShowOnlyItemsWithSelectedFilter(string filterType)
            {
                _productPage.VerifyRefrigeratorFilterResults(filterType);
            }

            [Then(@"Appliance Catalog should update to show only items with selected filter '(.*)'")]
            public void ThenApplianceCatalogShouldUpdateToShowOnlyItemsWithSelectedFilter(string filterType)
            {
                _productPage.VerifyApplianceFilterResults(filterType);
            }


            [Given(@"User wants to filter content by price '(.*)'")]
            public void GivenUserWantsToFilterContentByPrice(string productPage)
            {
                _productPage.GotoProductPage(productPage);
            }

            [Given(@"User wants to filter content by color  '(.*)'")]
            public void GivenUserWantsToFilterContentByColor(string productPage)
            {
                 _productPage.GotoProductPage(productPage);
           }


            [When(@"User clicks on reset filters")]
            public void WhenUserClicksOnResetFilters()
            {
                _productPage.ResetFilterClick();
            }

            [Then(@"Catalog page should show all products without a filter")]
            public void ThenCatalogPageShouldShowAllProductsWithoutAFilter()
            {
                _productPage.VerifyResetFilter();
            }

            [When(@"User selects in stock button")]
            public void WhenUserSelectsInStockButton()
            {
                _productPage.InStockSelection();
            }

            [Then(@"Catalog should update to show only items that are in stock")]
            public void ThenCatalogShouldUpdateToShowOnlyItemsThatAreInStock()
            {
                _productPage.VerifyInStockSelection();
            }

            [Given(@"User wants to sort content by price '(.*)'")]
            public void GivenUserWantsToSortContentByPrice(string productPage)
            {
                _productPage.GotoProductPage(productPage);
            }
            
            [When(@"User selects price button")]
            public void WhenUserSelectsPriceButton()
            {
                _productPage.SortByPriceClick();
            }

            [Then(@"Catalog should update to show products that are least expensive first to highest last")]
            public void ThenCatalogShouldUpdateToShowProductsThatAreLeastExpensiveFirstToHighestLast()
            {
                _productPage.VerifySortByPrice();
            }

            [Given(@"User wants to filter content by most popular '(.*)'")]
            public void GivenUserWantsToFilterContentByMostPopular(string productPage)
            {
               _productPage.GotoProductPage(productPage);
            }

            [When(@"User selects most popular button")]
            public void WhenUserSelectsMostPopularButton()
            {
                _productPage.MostPopularBtnClick();
            }

            [Then(@"Catalog should update to show only products that are most popular")]
            public void ThenCatalogShouldUpdateToShowOnlyProductsThatAreMostPopular()
            {
                _productPage.VerifyMostPopular();
            }

            [Given(@"User wants to compare items '(.*)'")]
            public void GivenUserWantsToCompareItems(string productPage)
            {
               _productPage.GotoProductPage(productPage);
            }



          [Given(@"User adds selected items from the compare button on the top right of the item\.")]
            public void GivenUserAddsSelectedItemsFromTheCompareButtonOnTheTopRightOfTheItem_()
            {
                _productPage.SelectCompareItems();
            }

           [Given(@"Items should be added to the top of the page")]
           public void GivenItemsShouldBeAddedToTheTopOfThePage()
           {
               _productPage.CompareItemsAdded();
           }

           [When(@"User clicks on Compare items")]
           public void WhenUserClicksOnCompareItems()
           {
               _productPage.CompareItemsBtnClick();
           }

           [Then(@"All items should show in a table with related item details")]
           public void ThenAllItemsShouldShowInATableWithRelatedItemDetails()
           {
               _productPage.VerifyCompareItemsInTable();
           }

           [Then(@"Catalog should update to show only items with the selected filter")]
           public void ThenCatalogShouldUpdateToShowOnlyItemsWithTheSelectedFilter()
           {
               _productPage.VerifySelectedFilter();
;           }

           [Then(@"User continues shopping '(.*)'")]
           public void ThenUserContinuesShopping(string productPage)
           {
               _productPage.ContinueShoppingAfterComparing(productPage);
           }

           [Then(@"User unselects items")]
           public void ThenUserUnselectsItems()
           {
               _productPage.UnselectItemsAfterComparing();
           }

           
           [Given(@"User wants to look at reviews '(.*)'")]
           public void GivenUserWantsToLookAtReviews(string productPage)
           {
               _productPage.GotoProductPage(productPage);
           }


           [When(@"User clicks on Review button the left-hand side")]
           public void WhenUserClicksOnReviewButtonTheLeft_HandSide()
           {
               _productPage.ReviewBtnClick();
           }

           [Then(@"Review popup should show up")]
           public void ThenReviewPopupShouldShowUp()
           {
               _productPage.VerifyReviewPopUp();
           }

           [Given(@"User wants to look at more details of a specific product '(.*)'")]
           public void GivenUserWantsToLookAtMoreDetailsOfASpecificProduct(string productPage)
           {
              _productPage.GotoProductPage(productPage);
           }

           [When(@"User clicks on View details")]
           public void WhenUserClicksOnViewDetails()
           {
               _productPage.ViewDetailsClick();
           }

           [Then(@"Product page should show up")]
           public void ThenProductPageShouldShowUp()
           {
               _productPage.VerifyProductPage();
           }

           [Given(@"User wants to navigate back to the previous node '(.*)'")]
           public void GivenUserWantsToNavigateBackToThePreviousNode(string productPage)
           {
               _productPage.GotoProductPage(productPage);
           }

           [When(@"User clicks on the previous node")]
           public void WhenUserClicksOnThePreviousNode()
           {
               _productPage.TopPageNavigationClick();
           }

           
           [Then(@"the previous node page should show up '(.*)'")]
           public void ThenThePreviousNodePageShouldShowUp(string productPage)
           {
              _productPage.VerifyTopPageNavigation(productPage);
           }

           [Given(@"User wants to go the previous/next page '(.*)'")]
           public void GivenUserWantsToGoThePreviousNextPage(string productPage)
           {
               _productPage.GotoProductPage(productPage);
           }

           
           [When(@"User clicks on any of the '(.*)'")]
           public void WhenUserClicksOnAnyOfThe(string navigation)
           {
               _productPage.NavigateBottomClick(navigation);
           }


           [Then(@"The corresponding page should show '(.*)'")]
           public void ThenTheCorrespondingPageShouldShow(string navigation)
           {
            _productPage.VerifyBottomNavigation(navigation);
           }
    }
}
