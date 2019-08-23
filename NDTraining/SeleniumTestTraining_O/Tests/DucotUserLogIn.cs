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
            ui.LoginPage.Value.LoginToWebsite(userName, passWord);

            Assert.That(ui.HomePage.Value.GetUserName(), Is.EqualTo(nameCheck));
        }
    }
}
