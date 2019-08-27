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

        readonly By emailTextBox = By.CssSelector("input[id=username]");
        readonly By password = By.CssSelector("input[id=password]");
        readonly By loginBtn = By.CssSelector("input[id=loginBtn]");

        public LoginPage(IWebDriver driver)
        {

            this.driver = driver;

        }

        public void SetEmailTextBox(string strUserName)
        {

            driver.FindElement(emailTextBox).SendKeys(strUserName);

        }

        public void SetPassword(string strPassword)
        {

            driver.FindElement(password).SendKeys(strPassword);

        }

        public void ClickLoginButton()
        {

            driver.FindElement(loginBtn).Click();

        }

        public void LoginToDucot(string strUserName, string strPasword)
        {
            SetEmailTextBox(strUserName);
            SetPassword(strPasword);
            ClickLoginButton();
        }
    }
}

