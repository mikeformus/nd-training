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
        protected readonly string savedSearchName = "Saved with Auto Test";
        protected readonly string searchCriteria = "=11(docx) =10([NG-868ZJAEQ])";

        [Test]
        public void DucotSaveSavedSearch()
        {
            ui.LoginPage.Value.LoginToWebsite(userName, passWord);
            ui.HomePage.Value.PerformSearch(searchCriteria);
            ui.SearchResultsPage.Value.SelectMenuOption();
            ui.CreateSavedSearchPage.Value.SaveSeach(savedSearchName);

            Assert.IsTrue(ui.SearchResultsPage.Value.CheckForFoundItem(savedSearchName));
        }
    }
}
