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
    public class BrokenImage : HomePage
    {
        public BrokenImage(IWebDriver _driver, WebDriverWait _wait) : base(_driver, _wait) { }

        private By brokenImageButton = By.LinkText("Broken Images");

        public By brokenImage1 = By.CssSelector("#content > div > img:nth-child(2)");
        public By brokenImage2 = By.CssSelector("#content > div > img:nth-child(3)");

        public By emptyImage = By.CssSelector("#content > div > img:nth-child(4)");


        public void GoToBrokenImagePage()
        {
            HomePage home = new HomePage(driver, wait);
            home.OpenHomePage();
            wait.Until(ExpectedConditions.ElementIsVisible(brokenImageButton)).Click();
        }

    }
}
