using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTestTraining_O
{
    class BaseTest
    {
        protected IWebDriver driver;
        protected UI ui;

        protected readonly string userName = "opovsh";
        protected readonly string passWord = "rewards4!";

        [SetUp]
        public void StartBrowser()
        {
            driver = new ChromeDriver(ConfigurationManager.AppSettings["ChromeDriver"]);
            driver.Manage().Window.Maximize();
            driver.Url = ConfigurationManager.AppSettings["BaseUrl"];
            ui = new UI(driver);
        }

        [TearDown]
        public void CloseBrowser()
        {
            driver.Close();
        }
    }
}
