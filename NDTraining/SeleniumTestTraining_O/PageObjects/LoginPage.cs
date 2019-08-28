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
    class LoginPage
    {
        readonly IWebDriver driver;

        readonly By userName = By.CssSelector("input[id=username]");
        readonly By passWord = By.CssSelector("input[id=password]");
        readonly By loginBtn = By.CssSelector("input[id=loginBtn]");

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public LoginPage SetUserName(string uName)
        {
            driver.FindElement(userName).SendKeys(uName);

            return new LoginPage(driver);
        }

        public LoginPage SetPassword(string pWord)
        {
            driver.FindElement(passWord).SendKeys(pWord);

            return new LoginPage(driver);
        }

        public HomePage ClickLoginButton()
        {
            driver.FindElement(loginBtn).Click();

            return new HomePage(driver);
        }

        public HomePage LoginToWebsite(string uName, string pWord)
        {
            SetUserName(uName).SetPassword(pWord).ClickLoginButton();

            return new HomePage(driver);
        }

    }
}