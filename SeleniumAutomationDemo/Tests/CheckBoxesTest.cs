using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeleniumAutomationDemo.Utilities;
using SeleniumAutomationDemo.Pages;

namespace SeleniumAutomationDemo.Tests
{
    [TestFixture]
    public class CheckBoxesTest : TestBase
    {
        private CheckBox checkBoxPage;

        [SetUp]
        public void SetUp()
        {
            checkBoxPage = new CheckBox(driver,wait);
            checkBoxPage.GotoCheckBoxPage();
        }

        [Test]
       public void CheckBoxTest()
        {
          IWebElement checkBox1 =  wait.Until(ExpectedConditions.ElementIsVisible(checkBoxPage.checkBox1));

            checkBox1.Click();

            Assert.That(checkBox1.Selected, Is.True);
    

        }

        [Test]
        public void UnCheckBox2Test()
        {      
            IWebElement checkBox2 = wait.Until(ExpectedConditions.ElementIsVisible(checkBoxPage.checkBox2));

           checkBox2.Click(); 
            

          
            Assert.That(checkBox2.Selected, Is.False);



        }
    }
}
