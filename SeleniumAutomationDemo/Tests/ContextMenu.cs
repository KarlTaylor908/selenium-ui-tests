using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeleniumAutomationDemo.Utilities;
using OpenQA.Selenium.Interactions;

namespace SeleniumAutomationDemo.Tests
{
    public class ContextMenu : TestBase
    {
        [SetUp]
        public void SetUp()
        {
            wait.Until(ExpectedConditions.ElementIsVisible(By.LinkText("Context Menu"))).Click();
        }
        [Test]
        public void ContextMenuTest()
        {
            Actions actions = new Actions(driver);

            IWebElement  box= wait.Until(ExpectedConditions.ElementIsVisible(By.Id("hot-spot")));
            actions.ContextClick(box).Perform();

            string alert = driver.SwitchTo().Alert().Text;
            //IWebElement alert = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("#content > script")));

            Assert.That(alert, Is.Not.Null,"Message not showing");
            Assert.That(alert, Is.EqualTo("You selected a context menu"), "Message not correct");

        }

    }
}
