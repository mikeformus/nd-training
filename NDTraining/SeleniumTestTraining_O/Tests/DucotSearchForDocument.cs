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
    class DucotSearchForDocument
    {
        IWebDriver driver;
        string result = "";

        [SetUp]
        public void StartBrowser()
        {
            driver = new ChromeDriver("C:\\Program Files (x86)\\Google\\Chrome\\Application");
            driver.Manage().Window.Maximize();
        }

        [TestCase("4814-5575-9744")]
        public void DucotDocumentSearch(string docid)
        {
            driver.Url = "https://ducot.netdocuments.com/neWeb2/docCent.aspx";
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));

            SeleniumTestTraining_O actions = new SeleniumTestTraining_O();

            actions.UserLogin(driver, "opovsh", "rewards4!");

            actions.PerformSimpleSearch(driver, wait, docid);

            try
            {
                result = wait.Until(x => driver.FindElement(By.XPath(".//*[text()='" + docid + "']/..")).Text);
            }
            catch (WebDriverTimeoutException)
            {
                result = "Document was not found!";
            }

            Assert.That(result, Is.EqualTo(docid));
        }

        [TearDown]
        public void CloseBrowser()
        {
            driver.Close();
        }
    }
}
