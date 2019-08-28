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
        protected readonly string menuOption = "saveSearch";

        [Test]
        public void DucotSaveSavedSearch()
        {
            UI.LoginPage.LoginToWebsite(userName, passWord)
                        .PerformSearch(searchCriteria)
                        .SelectMenuOption(menuOption)
                        .SaveSeach(savedSearchName);

            Assert.IsTrue(UI.SearchResultsPage.CheckForFoundItem(savedSearchName));
        }
    }
}