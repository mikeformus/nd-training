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
using SeleniumExtras.WaitHelpers;

namespace Sv_Selenium.PageObjects
{
    public class LoginPage
    {
        readonly IWebDriver driver;

        public IWebElement UserNameInput => driver.FindElement(By.CssSelector("input[id=username]"));
        public IWebElement PasswordInput => driver.FindElement(By.CssSelector("input[id=password]"));
        public IWebElement LoginBtn => driver.FindElement(By.CssSelector("input[id=loginBtn]"));

        public LoginPage(IWebDriver driver)
        {

            this.driver = driver;

        }

        public void SetEmailTextBox(string UserName)
        {

            UserNameInput.SendKeys(UserName);
        }

        public void SetPassword(string Password)
        {

            PasswordInput.SendKeys(Password);

        }

        public void ClickLoginButton()
        {

            LoginBtn.Click();

        }

        public void LoginToDucot(string UserName, string Password)
        {
            SetEmailTextBox(UserName);
            SetPassword(Password);
            ClickLoginButton();
        }
    }
}

