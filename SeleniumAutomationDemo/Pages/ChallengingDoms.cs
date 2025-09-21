using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeleniumExtras.WaitHelpers;

namespace SeleniumAutomationDemo.Pages
{
    public class ChallengingDoms : HomePage
    {
        public ChallengingDoms(IWebDriver _driver, WebDriverWait _wait) : base(_driver, _wait) { }

        private By challengingDomsButton = By.LinkText("Challenging DOM");

        public By blueButton = By.CssSelector(".button");


        public void GoToChallengingDomPage()
        {
            HomePage home = new HomePage(driver, wait);
            home.OpenHomePage();
            wait.Until(ExpectedConditions.ElementIsVisible(challengingDomsButton)).Click();
        }



    }
}
