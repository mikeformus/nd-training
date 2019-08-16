using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTestTraining_O.Tests
{
    class DucotSaveSavedSearchTest
    {
        IWebDriver driver;
        bool result = false;

        [SetUp]
        public void StartBrowser()
        {
            driver = new ChromeDriver("C:\\Program Files (x86)\\Google\\Chrome\\Application");
            driver.Manage().Window.Maximize();
        }

        [TestCase("=11(docx) =10([NG-868ZJAEQ])", "Saved with Auto Test")]
        public void DucotSaveSavedSearch(string criteria, string searchName)
        {
            driver.Url = "https://ducot.netdocuments.com/neWeb2/docCent.aspx";

            SeleniumTestTraining_O actions = new SeleniumTestTraining_O();

            actions.UserLogin(driver, "opovsh", "rewards4!");

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));

            actions.PerformSimpleSearch(driver, wait, criteria);

            driver.FindElement(By.Id("containerOptionsId")).Click();

            IReadOnlyCollection<IWebElement> listMenu = driver.FindElements(By.CssSelector(".ndMenu-list li"));

            for (int i = 0; i < listMenu.Count(); i++)
            {
                IWebElement option = listMenu.ElementAt(i);
                if (option.Text == "Save search")
                {
                    option.Click();
                    break;
                }
            }

            wait.Until(x => driver.FindElement(By.CssSelector("input[id=docName]"))).SendKeys(searchName);

            driver.FindElement(By.Name("okButton")).Click();

            try
            {
                result = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.TextToBePresentInElementLocated(By.Id("containerOptionsId"), searchName));
            }
            catch (WebDriverTimeoutException)
            {
                result = false;
            }

            Assert.IsTrue(result);
        }

        [TearDown]
        public void CloseBrowser()
        {
            driver.Close();
        }
    }
}
