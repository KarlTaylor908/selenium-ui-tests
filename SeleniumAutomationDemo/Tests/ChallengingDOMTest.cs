using OpenQA.Selenium;
using SeleniumAutomationDemo.Pages;
using SeleniumAutomationDemo.Utilities;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumAutomationDemo.Tests
{
    public class ChallengingDOMTest : TestBase
    {
        private ChallengingDoms challengingDOMPage;

        [SetUp]
        public void SetUp()
        {
           challengingDOMPage = new ChallengingDoms(driver,wait);
           challengingDOMPage.GoToChallengingDomPage();
        }
        [Test]
        public void ChallengingDomTest()
        {
            var blueButton = challengingDOMPage.blueButton;


            var before = driver.PageSource;


            driver.FindElement(blueButton).Click();


            bool changed = wait.Until(d => d.PageSource != before);
            Assert.That(changed, Is.True, "Page did not change.");
        }

    }
}
