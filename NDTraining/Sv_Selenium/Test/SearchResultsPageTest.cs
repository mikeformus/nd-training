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

        private LoginPage objLoginPage;
        private SearchResultsPage objSearchResultsPage;

        [Test]
        public void FindDocumentInSearchResultPage()
        {
            objLoginPage = new LoginPage(driver);
            objLoginPage.LoginToDucot(strUserName, strPassword);

            objSearchResultsPage = new SearchResultsPage(driver, waiter);

            // performs simple search
            objSearchResultsPage.Search("4819-5337-4080");

            // checks that needed document appears in search results
            var docName = objSearchResultsPage.GetSearchResultDocumentName("4819-5337-4080");                     
            Assert.That(docName, Is.EqualTo("dehbrde"));
        }
    }
}