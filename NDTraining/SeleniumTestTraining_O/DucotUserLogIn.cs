using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTestTraining_O
{
    class DucotUserLogIn
    {
        IWebDriver driver;

        [SetUp]
        public void startBrowser()
        {
            driver = new ChromeDriver("C:\\Program Files (x86)\\Google\\Chrome\\Application");
            driver.Manage().Window.Maximize();
        }

        [TestCase("Oleksandr")]
        public void ducotLoginTest(string result)
        {
            driver.Url = "https://ducot.netdocuments.com/neWeb2/docCent.aspx";

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));

            SeleniumTestTraining_O actions = new SeleniumTestTraining_O();

            actions.UserLogin(driver, "opovsh", "rewards4!");

            IWebElement userName = wait.Until(x => driver.FindElement(By.Id("personalMenuName")));

            Assert.That(userName.Text, Is.EqualTo(result));
        }

        [TearDown]
        public void closeBrowser()
        {
            driver.Close();
        }
    }
}
