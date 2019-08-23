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
        readonly By searchResultsLoaded = By.Id("lvCheckMaster-input");
        readonly By searchResultsMenu = By.Id("containerOptionsId");
        readonly By menuOptionsItem = By.XPath($"//li[contains(@class,'saveSearch')]");
        private By ListViewItem(string itemName) => By.XPath($"//span[contains(@class,'lvName-span')][@title='{itemName}']");

        public SearchResultsPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public bool CheckForFoundItem(string criteria)
        {
            bool result = false;
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));

            try
            {
                wait.Until(x => driver.FindElement(ListViewItem(criteria)));
                result = true;
            }
            catch (Exception) {/*ignore exceptions*/}

            return result;
        }

        public void OpenSearchResultsMenu()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));

            try
            {
                wait.Until(x => driver.FindElement(searchResultsLoaded));
            }
            catch (Exception) {/*ignore exceptions*/}

            driver.FindElement(searchResultsMenu).Click();
        }

        public void SelectFromMenuList()
        {
            driver.FindElement(menuOptionsItem).Click();
        }

        public void SelectMenuOption()
        {
            OpenSearchResultsMenu();
            SelectFromMenuList();
        }
    }
}
