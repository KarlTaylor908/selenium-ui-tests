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
    public class CheckBox : HomePage
    {
        public CheckBox(IWebDriver _driver, WebDriverWait _wait) : base(_driver, _wait) { }

        private By checkBoxButton = By.LinkText("Checkboxes");

        public By checkBox1 = By.CssSelector("#checkboxes > input[type=checkbox]:nth-child(1)");

        public By checkBox2 = By.CssSelector("#checkboxes > input[type=checkbox]:nth-child(3)");

        public void GotoCheckBoxPage()
        {
            HomePage home = new HomePage(driver, wait);
            home.OpenHomePage();
            wait.Until(ExpectedConditions.ElementIsVisible(checkBoxButton)).Click();
        }


    }


}
