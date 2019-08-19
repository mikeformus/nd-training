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
    class Login_and_checks_that_user_is_logged_in
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

            // checks that user is logged in (users’s name appears in Personal Menu)
            var personalMenuName = waiter.Until(SeleniumExtras.WaitHelpers
                                                              .ExpectedConditions
                                                              .ElementIsVisible(By.Id("personalMenuName")))
                                         .GetAttribute("title");
            Assert.That(personalMenuName, Is.EqualTo("Svitlana"));
        }
        [TearDown]
        public void closeBrowser()
        {
        driver.Close();
        }
    }
}