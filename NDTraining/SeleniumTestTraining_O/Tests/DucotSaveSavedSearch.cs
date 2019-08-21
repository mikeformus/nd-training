using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTestTraining_O.Tests
{
    class DucotSaveSavedSearchTest : BaseTest
    {
        protected readonly string menuOption = "Save search";
        protected readonly string savedSearchName = "Saved with Auto Test";
        protected readonly string searchCriteria = "=11(docx) =10([NG-868ZJAEQ])";

        LoginPage objLogin;
        HomePage objHome;
        SearchResultsPage objSearch;
        CreateSavedSearchPage objSaveSearch;

        [Test]
        public void DucotSaveSavedSearch()
        {
            objLogin = new LoginPage(driver);
            objHome = new HomePage(driver);
            objSearch = new SearchResultsPage(driver);
            objSaveSearch = new CreateSavedSearchPage(driver);

            objLogin.LoginToWebsite(userName, passWord);
            objHome.PerformSearch(searchCriteria);
            objSearch.SelectMenuOption(menuOption);
            objSaveSearch.SaveSeach(savedSearchName);

            Assert.IsTrue(objSearch.CheckSavedSearchName(savedSearchName));
        }
    }
}
