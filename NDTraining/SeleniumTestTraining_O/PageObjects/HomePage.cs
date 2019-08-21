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

        public void EnterSearchCriteria(string criteria)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            wait.Until(x => driver.FindElement(searchBar)).SendKeys(criteria);
        }

        public void ClickSearchButton()
        {
            driver.FindElement(goBtn).Click();
        }

        public void PerformSearch(string criteria)
        {
            EnterSearchCriteria(criteria);
            ClickSearchButton();
        }

        public string GetUserName()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(x => driver.FindElement(personalMenuName)).Text;
        }

    }
}
