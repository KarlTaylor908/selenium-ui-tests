using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumAutomationDemo.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumAutomationDemo.Pages
{
    public class HomePage : BasePage
    {
        protected string url = "https://the-internet.herokuapp.com/";

        public HomePage(IWebDriver driver, WebDriverWait wait) : base(driver,wait){ }

        public void OpenHomePage()
        {
            driver.Navigate().GoToUrl(url);

          
        }

    }
}
