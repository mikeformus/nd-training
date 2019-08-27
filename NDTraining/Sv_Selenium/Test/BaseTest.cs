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

namespace Sv_Selenium.Test
{
    public class BaseTest
    {

        protected readonly string strUserName = "snovy";
        protected readonly string strPassword = "test12345!";
        protected IWebDriver driver;
        protected WebDriverWait waiter;
       
        [SetUp]
        public void CssDemo()
        {
            driver = new ChromeDriver(ConfigurationManager.AppSettings["ChromeURL"]);
            driver.Manage().Window.Maximize();
            driver.Url = ConfigurationManager.AppSettings["BaseUrl"];
            waiter = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
        }

        [TearDown]
        public void CloseBrowser()
        {
           driver.Close();
        }
    }
}
