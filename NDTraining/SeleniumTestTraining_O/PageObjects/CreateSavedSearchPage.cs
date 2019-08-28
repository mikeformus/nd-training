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
    class CreateSavedSearchPage
    {
        readonly IWebDriver driver;
        readonly By savedSearchName = By.CssSelector("input[id=docName]");
        readonly By savedSearchOKBtn = By.Name("okButton");

        public CreateSavedSearchPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public CreateSavedSearchPage EnterSavedSearchName(string searchName)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));

            wait.Until(x => driver.FindElement(savedSearchName)).SendKeys(searchName);

            return new CreateSavedSearchPage(driver);
        }

        public SearchResultsPage ClickOKButton()
        {
            driver.FindElement(savedSearchOKBtn).Click();

            return new SearchResultsPage(driver);
        }

        public SearchResultsPage SaveSeach(string searchName)
        {
            EnterSavedSearchName(searchName).ClickOKButton();

            return new SearchResultsPage(driver);
        }
    }
}