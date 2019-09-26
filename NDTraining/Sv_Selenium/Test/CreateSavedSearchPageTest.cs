using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using Sv_Selenium.PageObjects;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sv_Selenium.Test
{
    class CreateSavedSearchPageTest : BaseTest
    {
        private LoginPage LoginPage;
        private SearchResultsPage SearchResultsPage;
        private CreateSavedSearchPage CreateSavedSearchPage;
        private const string testNdDocId = "4819-5337-4080";

        [Test]
        public void FindDocumentInSearchResultPage()
        {
            LoginPage = new LoginPage(driver);
            LoginPage.LoginToDucot(UserName, Password);

            SearchResultsPage = new SearchResultsPage(driver, waiter);

            // performs simple search
            SearchResultsPage.Search(testNdDocId);

            //save search
            CreateSavedSearchPage = new CreateSavedSearchPage(driver, waiter);
            CreateSavedSearchPage.ClickOnContainerOptionsButton();
            CreateSavedSearchPage.ClickSaveSearchSubMenu();
            CreateSavedSearchPage.ClickOnOkButton();
            CreateSavedSearchPage.WaitSaveSearchPage();

            Assert.True(SearchResultsPage.IsListViewItemDisplayed(testNdDocId));

        }
    }
}
 