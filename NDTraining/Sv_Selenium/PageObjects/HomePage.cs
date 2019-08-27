using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeleniumExtras.WaitHelpers;

namespace Sv_Selenium.PageObjects
{
    public class HomePage
    {
        readonly IWebDriver driver;
        readonly WebDriverWait waiter;
  
        public HomePage(IWebDriver driver, WebDriverWait waiter)
        {

            this.driver = driver;
            this.waiter = waiter;

        }

        public string GetPersonalMenuName()
        {

            return waiter.Until(SeleniumExtras.WaitHelpers
                                                             .ExpectedConditions
                                                            .ElementIsVisible(By.Id("personalMenuName")))
                                        .GetAttribute("title");
        }
    }
}

