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
    class SearchResultsPage
    {
        readonly IWebDriver driver;
        readonly By searchResults = By.CssSelector(".lvTable tr");
        readonly By searchResultsLoaded = By.Id("lvCheckMaster-input");
        readonly By searchResultsMenu = By.Id("containerOptionsId");
        readonly By searchResultsMenuList = By.CssSelector(".ndMenu-list li");
        readonly By searchResultSavedName = By.Id("containerOptionsId");

        public SearchResultsPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public bool CheckForFoundDoc(string criteria)
        {
            bool result = false;
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));

            try
            {
                wait.Until(x => driver.FindElement(searchResultsLoaded));
            }
            catch (Exception) {/*ignore exceptions*/}

            IReadOnlyCollection<IWebElement> documentList = wait.Until(x => driver.FindElements(searchResults));

            for (int i = 0; i < documentList.Count(); i++)
            {
                IWebElement option = documentList.ElementAt(i);
                if (option.Text.Contains(criteria))
                {
                    result = true;
                    break;
                }
            }

            return result;
        }

        public void OpenSearchResultsMenu()
        {
            driver.FindElement(searchResultsMenu).Click();
        }

        public void SelectFromMenuList(string selectOption)
        {
            IReadOnlyCollection<IWebElement> listMenu = driver.FindElements(searchResultsMenuList);

            for (int i = 0; i < listMenu.Count(); i++)
            {
                IWebElement options = listMenu.ElementAt(i);
                if (options.Text == selectOption)
                {
                    options.Click();
                    break;
                }
            }
        }

        public void SelectMenuOption(string selectOption)
        {
            AreSearchResultsLoaded();
            OpenSearchResultsMenu();
            SelectFromMenuList(selectOption);
        }

        public bool CheckSavedSearchName(string searchName)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));

            try
            {
                return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.TextToBePresentInElementLocated(searchResultSavedName, searchName));
            }
            catch (WebDriverTimeoutException)
            {
                return false;
            }
        }

        public void AreSearchResultsLoaded()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));

            try
            {
                wait.Until(x => driver.FindElement(searchResultsLoaded));
            }
            catch (Exception) {/*ignore exceptions*/}
        }
    }
}
