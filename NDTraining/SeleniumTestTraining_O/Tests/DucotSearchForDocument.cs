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
        protected readonly string searchCriteria = "=3(Ducot Selenium Test Search)";
        protected readonly string foundDocID = "4814-5575-9744";

        LoginPage objLogin;
        HomePage objHome;
        SearchResultsPage objSearch;

        [Test]
        public void DucotDocumentSearch()
        {
            objLogin = new LoginPage(driver);
            objHome = new HomePage(driver);
            objSearch = new SearchResultsPage(driver);

            objLogin.LoginToWebsite(userName, passWord);

            objHome.PerformSearch(searchCriteria);

            Assert.IsTrue(objSearch.CheckForFoundDoc(foundDocID));
        }
    }
}
