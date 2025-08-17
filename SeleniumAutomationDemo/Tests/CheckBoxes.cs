using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeleniumAutomationDemo.Utilities;

namespace SeleniumAutomationDemo.Tests
{
    public class CheckBoxes : TestBase
    {
        [SetUp]
        public void SetUp()
        {
            wait.Until(ExpectedConditions.ElementIsVisible(By.LinkText("Checkboxes"))).Click();
        }

        [Test]
       public void CheckBoxTest()
        {
          IWebElement checkBox1 =  wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("#checkboxes > input[type=checkbox]:nth-child(1)")));
            //IWebElement checkBox2 = wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("#checkboxes > input[type=checkbox]:nth-child(2)")));

            checkBox1.Click();

            Assert.That(checkBox1.Selected, Is.True);
    

        }

        [Test]
        public void UnCheckBox2Test()
        {      
            IWebElement checkBox2 = wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("#checkboxes > input[type=checkbox]:nth-child(3)")));

           checkBox2.Click(); 
            

          
            Assert.That(checkBox2.Selected, Is.False);



        }
    }
}
