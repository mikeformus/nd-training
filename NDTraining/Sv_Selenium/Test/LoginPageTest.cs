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
        private LoginPage LoginPage;
        private HomePage HomePage;

        [Test]
        public void LoginAndChecksThatUserIsLoggedIn()
        {
            LoginPage = new LoginPage(driver);
            LoginPage.LoginToDucot(UserName, Password);
            
            //checks that user is logged in (users’s name appears in Personal Menu)
            HomePage = new HomePage(driver, waiter);
            string personalMenuName = HomePage.GetPersonalMenuName();

            Assert.That(personalMenuName, Is.EqualTo("Svitlana"));
        }
    }
}