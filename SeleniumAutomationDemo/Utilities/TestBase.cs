using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumAutomationDemo.Utilities
{

    public class TestBase
    {
        protected IWebDriver driver;
        protected WebDriverWait wait;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            var options = new ChromeOptions();
            options.AddArgument("--headless=new");
            options.AddArgument("--no-sandbox");
            options.AddArgument("--disable-dev-shm-usage");
            options.AddArgument("--window-size=1920,1080");
            driver = new ChromeDriver(options);
            driver.Manage().Window.Maximize();
  ;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            driver.Dispose();
            driver.Close();
        }
    }
}

