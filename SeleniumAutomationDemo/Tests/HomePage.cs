using OpenQA.Selenium;
using SeleniumAutomationDemo.Utilities;
using SeleniumExtras.WaitHelpers;

namespace SeleniumAutomationDemo.Tests
{
    public class Homepage :TestBase
    {

        [Test]
        public void HomepageShowingTest()
        {
            string currentURL = driver.Url;

            IWebElement title = wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("#content > h1")));

            Assert.That(currentURL.Equals("https://the-internet.herokuapp.com/"),"URL is incorrect");
            Assert.That(title.Equals("Welcome to the-internet"), "Title is not correct");

        }
    }
}