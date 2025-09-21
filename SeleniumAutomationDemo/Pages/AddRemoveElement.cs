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
    public class AddRemoveElement : HomePage
    {
        public AddRemoveElement(IWebDriver _driver, WebDriverWait _wait) : base(_driver, _wait) { }

        private By addRemoveButton = By.LinkText("Add/Remove Elements");

        private By AddElement = By.CssSelector("#content > div > button");

        public By element = By.ClassName("added-manually");

        public void GoToAddRemoveElementPage()
        {
            HomePage home = new HomePage(driver, wait);
            home.OpenHomePage();
            wait.Until(ExpectedConditions.ElementIsVisible(addRemoveButton)).Click();

        }
        public void Add10Elements()
        {
            for (int i = 0; i < 10; i++)
            {
                wait.Until(ExpectedConditions.ElementIsVisible(AddElement)).Click();
            }
        }

    }
}
