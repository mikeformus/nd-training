﻿using NUnit.Framework;
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
    class CreateSavedSearchPage
    {
        private readonly IWebDriver driver;
        private readonly WebDriverWait waiter;

        public IWebElement ContainerOptionsButton => waiter.Until(SeleniumExtras.WaitHelpers
                                                           .ExpectedConditions
                                                           .ElementToBeClickable(By.Id("containerOptionsButton")));

        public IWebElement SaveSearchMenuItem => ContainerOptions.FindElement(By.ClassName("saveSearch"));

        public IWebElement ContainerOptions => waiter.Until(SeleniumExtras.WaitHelpers
                                                     .ExpectedConditions
                                                     .ElementToBeClickable(By.Id("containerOptions")));
        public IWebElement ContainerOptionsId => waiter.Until(SeleniumExtras.WaitHelpers
                                                     .ExpectedConditions
                                                     .ElementToBeClickable(By.Id("containerOptionsId")));

        public IWebElement OkButton => driver.FindElement(By.Name("okButton"));

        public string ContainerOptionsIdTitle => ContainerOptionsId.GetAttribute("title");

        public CreateSavedSearchPage(IWebDriver driver, WebDriverWait waiter)
        {

            this.driver = driver;
            this.waiter = waiter;

        }

        public void ClickOnContainerOptionsButton()
        {
            ContainerOptionsButton.Click();

        }

        public void ClickSaveSearchSubMenu()
        {
            SaveSearchMenuItem.Click();
        }

        public void ClickOnOkButton()
        {
            OkButton.Click();
        }

        public void WaitSaveSearchPage()
        {

            waiter.Until(SeleniumExtras.WaitHelpers
                                       .ExpectedConditions
                                       .UrlContains("/savedSearch"));

        }
    }
}


