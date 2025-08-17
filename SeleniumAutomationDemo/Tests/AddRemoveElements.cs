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
    public class AddRemoveElements :TestBase
    {
        [SetUp]
        public void SetUp()
        {
            wait.Until(ExpectedConditions.ElementIsVisible(By.LinkText("Add/Remove Elements"))).Click();
        }
        
        [Test]
        public void AddElementTest()
        {
            for (int i = 0; i < 10; i++)
            {
                wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("#content > div > button"))).Click();
            }
           int elementCount = driver.FindElements(By.ClassName("added-manually")).Count;


            Assert.That(elementCount == 10, "There are not 10 elements");

        }
    }
}
