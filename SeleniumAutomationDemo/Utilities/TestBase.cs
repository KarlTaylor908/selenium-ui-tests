using Allure.Net.Commons;
using Allure.NUnit;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

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
  
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
        }

        [TearDown]
        public void TearDown()
        {
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            if(status ==NUnit.Framework.Interfaces.TestStatus.Failed)
            {
                var file = ((ITakesScreenshot)driver).GetScreenshot();
                byte[] screenshotAsByteArray = file.AsByteArray;

                    AllureApi.AddAttachment("Failure screenshot", "image/png", screenshotAsByteArray, ".png");
            }
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            driver.Dispose();
            driver.Quit();
        }
    }
}

