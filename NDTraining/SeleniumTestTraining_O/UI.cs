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

        public Lazy<LoginPage> LoginPage => new Lazy<LoginPage>(() => new LoginPage(driver));
        public Lazy<HomePage> HomePage => new Lazy<HomePage>(() => new HomePage(driver));
        public Lazy<SearchResultsPage> SearchResultsPage => new Lazy<SearchResultsPage>(() => new SearchResultsPage(driver));
        public Lazy<CreateSavedSearchPage> CreateSavedSearchPage => new Lazy<CreateSavedSearchPage>(() => new CreateSavedSearchPage(driver));
    }
}
