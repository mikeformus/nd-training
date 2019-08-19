using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTestTraining_O
{
    class SeleniumTestTraining_O
    {
        public void UserLogin(IWebDriver driver, string userName, string passWord)
        {
            IWebElement userNameT = driver.FindElement(By.CssSelector("input[id=username]"));
            IWebElement passwordT = driver.FindElement(By.CssSelector("input[id=password]"));
            IWebElement loginB = driver.FindElement(By.CssSelector("input[id=loginBtn]"));

            userNameT.SendKeys(userName);
            passwordT.SendKeys(passWord);
            loginB.Click();
        }

        public void PerformSimpleSearch(IWebDriver driver, WebDriverWait wait, string criteria)
        {
            IWebElement searchBar = wait.Until(x => driver.FindElement(By.Id("nd-hsCriteria-input")));

            searchBar.SendKeys(criteria);

            driver.FindElement(By.Id("hsGo")).Click();

            try
            {
                wait.Until(x => driver.FindElement(By.Id("lvCheckMaster-input")));
            }
            catch (Exception) {/*ignore exceptions*/}
        }
    }
}
