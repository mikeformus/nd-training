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

        [Test]
        public void DucotLoginTest()
        {            
            UI.LoginPage.LoginToWebsite(userName, passWord);

            Assert.That(UI.HomePage.GetUserName(), Is.EqualTo(nameCheck));
        }
    }
}