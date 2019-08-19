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
    class Save_results_as_a_new_Saved_Search
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

            //save search
            var containerOptionsButton = waiter.Until(SeleniumExtras.WaitHelpers
                                                    .ExpectedConditions
                                                    .ElementToBeClickable(By.Id("containerOptionsButton")));
            containerOptionsButton.Click();
            var containerOptions = waiter.Until(SeleniumExtras.WaitHelpers
                                                    .ExpectedConditions
                                                    .ElementToBeClickable(By.Id("containerOptions")));
            var SaveSearch = containerOptions.FindElement(By.ClassName("saveSearch"));
            var titleList = SaveSearch.GetAttribute("aria-label");
            Assert.That(titleList, Is.EqualTo("Save search"));
            SaveSearch.Click();



            //var containerOptionsButton = driver.FindElement(By.XPath("//*[@id='Layer_2']"));
            //var selectTest = new SelectElement(containerOptionsButton);		
            //selectTest.SelectByValue("Save search");

            var okBtn = driver.FindElement(By.XPath(".//*[@id='buttonArea']/input[1]"));
            okBtn.Click();
        }
        [TearDown]
        public void closeBrowser()
        {
            driver.Close();
        }
    }


}