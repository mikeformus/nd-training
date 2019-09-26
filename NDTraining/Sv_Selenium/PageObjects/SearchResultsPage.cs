using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeleniumExtras.WaitHelpers;

namespace Sv_Selenium.PageObjects
{
    class SearchResultsPage
    {
        readonly IWebDriver driver;
        readonly WebDriverWait waiter;

        public IWebElement SearchInput => waiter.Until(SeleniumExtras.WaitHelpers
                                             .ExpectedConditions
                                             .ElementToBeClickable(By.Id("nd-hsCriteria-input")));

        public IWebElement SearchButton => driver.FindElement(By.Id("hsGo"));

        public SearchResultsPage(IWebDriver driver, WebDriverWait waiter)
        {

            this.driver = driver;
            this.waiter = waiter;

        }

        public void Search(string searchText)
        {
            SearchInput.SendKeys(searchText);
            SearchButton.Click();
        }

        public string GetSearchResultDocumentName(string searchText)
        {
            var documentRow = waiter.Until(SeleniumExtras.WaitHelpers
                                                         .ExpectedConditions
                                                         .ElementIsVisible(By.ClassName("id_"+ searchText)));
            var documentNameSpan = documentRow.FindElement(By.ClassName("lvName-span"));
            return documentNameSpan.GetAttribute("title");
        }

        public bool IsListViewItemDisplayed(string documentName)
        {
            var documentRow = waiter.Until(SeleniumExtras.WaitHelpers
                                             .ExpectedConditions
                                             .ElementIsVisible(By.ClassName("id_" + documentName)));

            return documentRow != null;
        }
    }
}
