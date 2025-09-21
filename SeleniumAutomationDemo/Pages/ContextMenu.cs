using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumAutomationDemo.Utilities;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumAutomationDemo.Pages
{
    public class ContextMenu : HomePage
    {
        public ContextMenu(IWebDriver _driver, WebDriverWait _wait) : base(_driver, _wait){}

        private By contextMenuButton = By.LinkText("Context Menu");

        public By box = By.Id("hot-spot");

        public void GoToContextMenuPage()
        {
            HomePage home = new HomePage(driver,wait);
            home.OpenHomePage();
            wait.Until(ExpectedConditions.ElementIsVisible(contextMenuButton)).Click();
        }

    }
}
