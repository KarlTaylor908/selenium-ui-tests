using OpenQA.Selenium;
using SeleniumAutomationDemo.Utilities;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumAutomationDemo.Tests
{
    public class ChallengingDOM : TestBase
    {
        [SetUp]
        public void SetUp()
        {
            wait.Until(ExpectedConditions.ElementIsVisible(By.LinkText("Challenging DOM"))).Click();
        }
        [Test]
        public void ChallengingDomTest()
        {
            var before = ((ITakesScreenshot)driver).GetScreenshot();

            IWebElement blueButton = wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".button")));
            blueButton.Click();

                      
            var after = ((ITakesScreenshot)driver).GetScreenshot();

            // Compare image bytes or just assert they're not identical
            Assert.That(after.AsByteArray!=before.AsByteArray, "Page has not changed");

         }

    }
}
