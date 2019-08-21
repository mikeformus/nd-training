using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTestTraining_O.Tests
{
    class DucotUserLogIn : BaseTest
    {
        protected readonly string nameCheck = "Oleksandr";

        LoginPage objLogin;
        HomePage objHome;

        [Test]
        public void DucotLoginTest()
        {
            objLogin = new LoginPage(driver);
            objHome = new HomePage(driver);

            objLogin.LoginToWebsite(userName, passWord);

            Assert.That(objHome.GetUserName(), Is.EqualTo(nameCheck));
        }
    }
}
