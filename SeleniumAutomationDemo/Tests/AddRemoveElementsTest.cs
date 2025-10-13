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
   
    [TestFixture]

    public class AddRemoveElementsTest :TestBase
    {
        AddRemoveElement addRemoveElement;

        [SetUp]
        public void SetUp()
        {
            addRemoveElement = new AddRemoveElement(driver,wait);
            addRemoveElement.GoToAddRemoveElementPage();
        }
        
        [Test]
        public void AddElementTest()
        {
            addRemoveElement.Add10Elements();

           int elementCount = driver.FindElements(addRemoveElement.element).Count;

            Assert.That(elementCount == 10, "There are not 10 elements");
        }
    }
}
