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
    class CreateSavedSearchPageTest : BaseTest
    {
        private LoginPage objLoginPage;
        private SearchResultsPage objSearchResultsPage;
        private CreateSavedSearchPage objCreateSavedSearchPage;

        [Test]
        public void FindDocumentInSearchResultPage()
        {
            objLoginPage = new LoginPage(driver);
            objLoginPage.LoginToDucot(strUserName, strPassword);

            objSearchResultsPage = new SearchResultsPage(driver, waiter);

            // performs simple search
            objSearchResultsPage.Search("4819-5337-4080");

           //save search

            objCreateSavedSearchPage = new CreateSavedSearchPage(driver, waiter);
            objCreateSavedSearchPage.ClickOnContainerOptionsButton();

            //var docName = objSearchResultsPage.GetSearchResultDocumentName("4819-5337-4080");
            //Assert.That(docName, Is.EqualTo("dehbrde"));


            //var aaa = objCreateSavedSearchPage.SaveSearchMenuItemTitle;


           

            objCreateSavedSearchPage.ClickSaveSearchSubMenu();                       
            objCreateSavedSearchPage.ClickOnOkButton();
            objCreateSavedSearchPage.WaitSaveSearchPage();

            Assert.That(objCreateSavedSearchPage.ContainerOptionsIdTitle, Is.EqualTo("4819-5337-4080"));

            /*var containerOptions = waiter.Until(SeleniumExtras.WaitHelpers
                                                    .ExpectedConditions
                                                    .ElementToBeClickable(By.Id("containerOptions")));
            var SaveSearch = containerOptions.FindElement(By.ClassName("saveSearch"));
            var titleList = SaveSearch.GetAttribute("aria-label");
            Assert.That(titleList, Is.EqualTo("Save search"));
            SaveSearch.Click();

            okBtn = driver.FindElement(By.XPath(".//*[@id='buttonArea']/input[1]"));
            okBtn.Click();*/
        }

    }


}
 