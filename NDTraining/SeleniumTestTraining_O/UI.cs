using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTestTraining_O
{
    class UI
    {
        readonly IWebDriver driver;

        public UI(IWebDriver driver)
        {
            this.driver = driver;
        }

        private HomePage _homePage;
        public HomePage HomePage => _homePage ?? (_homePage = new HomePage(driver));

        private LoginPage _loginPage;
        public LoginPage LoginPage => _loginPage ?? (_loginPage = new LoginPage(driver));

        private SearchResultsPage _searchResultsPage;
        public SearchResultsPage SearchResultsPage => _searchResultsPage ?? (_searchResultsPage = new SearchResultsPage(driver));

        private CreateSavedSearchPage _createSavedSearchPage;
        public CreateSavedSearchPage CreateSavedSearchPage => _createSavedSearchPage ?? (_createSavedSearchPage = new CreateSavedSearchPage(driver));
    }
}