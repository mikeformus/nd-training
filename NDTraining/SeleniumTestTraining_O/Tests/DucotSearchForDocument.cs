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
    class DucotSearchForDocument : BaseTest
    {
        protected readonly string docName = "Ducot Selenium Test Search";
        protected string SearchCriteria => "=3(" + docName + ")";

        [Test]
        public void DucotDocumentSearch()
        {
            ui.LoginPage.Value.LoginToWebsite(userName, passWord);

            ui.HomePage.Value.PerformSearch(SearchCriteria);

            Assert.IsTrue(ui.SearchResultsPage.Value.CheckForFoundItem(docName));
        }
    }
}
