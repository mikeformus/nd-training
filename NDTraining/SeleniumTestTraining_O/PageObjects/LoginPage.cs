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

        public void SetUserName(string uName)
        {
            driver.FindElement(userName).SendKeys(uName);
        }

        public void SetPassword(string pWord)
        {
            driver.FindElement(passWord).SendKeys(pWord);
        }

        public void ClickLoginButton()
        {
            driver.FindElement(loginBtn).Click();
        }

        public void LoginToWebsite(string uName, string pWord)
        {
            this.SetUserName(uName);
            this.SetPassword(pWord);
            this.ClickLoginButton();
        }

    }
}
