using Allure.NUnit;
using OpenQA.Selenium;
using SeleniumAutomationDemo.Pages;
using SeleniumAutomationDemo.Utilities;
using SeleniumExtras.WaitHelpers;

namespace SeleniumAutomationDemo.Tests
{
    [AllureNUnit]
    [TestFixture]
    public class HomePageTest :TestBase
    {
        private HomePage homePage;

        [SetUp]
        public void SetUp()
        {
            homePage = new HomePage(driver,wait);
            homePage.OpenHomePage();
        }
        [Test]
        public void HomepageShowingTest()
        {
            string currentURL = driver.Url;

            IWebElement title = wait.Until(ExpectedConditions.ElementIsVisible(By.TagName("h1")));

            Assert.That(currentURL.Equals("https://the-internet.herokuapp.com/"),"URL is incorrect");
            Assert.That(title.Text.Equals("Welcome to the-internet"), "Title is not correct");


        }
    }
}