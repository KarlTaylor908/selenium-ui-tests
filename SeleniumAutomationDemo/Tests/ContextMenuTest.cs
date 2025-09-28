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
using SeleniumAutomationDemo.Pages;

namespace SeleniumAutomationDemo.Tests
{
    [TestFixture]
    public class ContextMenuTest :TestBase
    {
        private ContextMenu contextMenuPage;

        [SetUp]
        public void SetUp()
        {
            contextMenuPage = new ContextMenu(driver, wait);
            contextMenuPage.GoToContextMenuPage();
        }

        [Test]
        public void AlertShow()
        {
            Actions actions = new Actions(driver);

            IWebElement  box= wait.Until(ExpectedConditions.ElementIsVisible(contextMenuPage.box));
            actions.ContextClick(box).Perform();

            var alert = driver.SwitchTo().Alert().Text;
            
            Assert.That(alert, Is.Not.Null,"Message not showing");
            Assert.That(alert, Is.EqualTo("You selected a context menu"), "Message not correct");

        }

    }
}
