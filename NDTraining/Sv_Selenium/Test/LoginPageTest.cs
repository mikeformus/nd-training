using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using Sv_Selenium.PageObjects;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sv_Selenium.Test
{
    public class LoginPageTest : BaseTest
    {
        private LoginPage objLoginPage;
        private HomePage objHomePage;

        [Test]
        public void LoginAndChecksThatUserIsLoggedIn()
        {
            objLoginPage = new LoginPage(driver);
            objLoginPage.LoginToDucot(strUserName, strPassword);
            //checks that user is logged in (users’s name appears in Personal Menu)

            objHomePage = new HomePage(driver, waiter);

            string personalMenuName = objHomePage.GetPersonalMenuName();

            Assert.That(personalMenuName, Is.EqualTo("Svitlana"));
        }
    }
}