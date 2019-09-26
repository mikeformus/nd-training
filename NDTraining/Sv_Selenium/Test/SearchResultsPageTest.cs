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
    class SearchResultsPageTest : BaseTest
    {

        private LoginPage LoginPage;
        private SearchResultsPage SearchResultsPage;
        private const string testNdDocId = "4819-5337-4080";

        [Test]
        public void FindDocumentInSearchResultPage()
        {
            LoginPage = new LoginPage(driver);
            LoginPage.LoginToDucot(UserName, Password);

            SearchResultsPage = new SearchResultsPage(driver, waiter);

            // performs simple search
            SearchResultsPage.Search(testNdDocId);

            // checks that needed document appears in search results
            Assert.True(SearchResultsPage.IsListViewItemDisplayed(testNdDocId));
        }
    }
}