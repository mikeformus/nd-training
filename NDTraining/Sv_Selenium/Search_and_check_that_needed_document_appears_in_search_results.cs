using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Sv_Selenium
{
    class Search_and_check_that_needed_document_appears_in_search_results
    {
        private const string chromeDriverPath = @"C:\Users\snovy\source\repos\nd-training\NDTraining\packages\Selenium.WebDriver.ChromeDriver.76.0.3809.6801\driver\win32";
        IWebDriver driver;
        WebDriverWait waiter;

        [SetUp]
        public void CssDemo()
        {
            driver = new ChromeDriver(chromeDriverPath);
            waiter = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
        }

        [Test]
        public void test()
        {
            driver.Url = "https://ducot.netdocuments.com/neWeb2/login.aspx";
            driver.Manage().Window.Maximize();

            // Store locator values of login and password text boxes and Login button				
            var emailTextBox = driver.FindElement(By.CssSelector("input[id=username]"));
            var password = driver.FindElement(By.CssSelector("input[id=password]"));
            var loginBtn = driver.FindElement(By.CssSelector("input[id=loginBtn]"));

            emailTextBox.SendKeys("snovy");
            password.SendKeys("test12345!");
            loginBtn.Click();

            // performs simple search
            var search = waiter.Until(SeleniumExtras.WaitHelpers
                                                    .ExpectedConditions
                                                    .ElementToBeClickable(By.Id("nd-hsCriteria-input")));

            var executeSearch = driver.FindElement(By.Id("hsGo"));
            search.SendKeys("4819-5337-4080");
            executeSearch.Click();

            // checks that needed document appears in search results
            var documentRow = waiter.Until(SeleniumExtras.WaitHelpers
                                                              .ExpectedConditions
                                                              .ElementIsVisible(By.ClassName("id_4819-5337-4080")));
            var documentNameSpan = documentRow.FindElement(By.ClassName("lvName-span"));
            var docName = documentNameSpan.GetAttribute("title");
            Assert.That(docName, Is.EqualTo("dehbrde"));
        }

            

        [TearDown]
        public void closeBrowser()
        {
         driver.Close();
        }
    }

   
    }