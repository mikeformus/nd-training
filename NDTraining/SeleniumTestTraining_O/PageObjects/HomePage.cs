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
    class HomePage
    {
        readonly IWebDriver driver;

        readonly By personalMenuName = By.Id("personalMenuName");
        readonly By searchBar = By.Id("nd-hsCriteria-input");
        readonly By goBtn = By.Id("hsGo");

        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public HomePage EnterSearchCriteria(string criteria)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            wait.Until(x => driver.FindElement(searchBar)).SendKeys(criteria);
            return new HomePage(driver);
        }

        public SearchResultsPage ClickSearchButton()
        {
            driver.FindElement(goBtn).Click();
            return new SearchResultsPage(driver);
        }

        public SearchResultsPage PerformSearch(string criteria)
        {
            EnterSearchCriteria(criteria).ClickSearchButton();

            return new SearchResultsPage(driver);
        }

        public string GetUserName()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(x => driver.FindElement(personalMenuName)).Text;
        }

    }
}