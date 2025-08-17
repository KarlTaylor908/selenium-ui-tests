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
    public class BrokenImages : TestBase
    {
        [SetUp]
        public void SetUp()
        {
            wait.Until(ExpectedConditions.ElementIsVisible(By.LinkText("Broken Images"))).Click();
        }


        [Test]
        public async Task BrokenImagesTest()
        {
            using var client = new HttpClient();
            var imageList = driver.FindElements(By.TagName("img"));

            var brokenImage1 = wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("#content > div > img:nth-child(2)")));
            var brokenImage2 = wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("#content > div > img:nth-child(3)")));

            var emptyImage = wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("#content > div > img:nth-child(4)")));



            //foreach (var image in imageList)
            //{
            //    try
            //    {
            HttpResponseMessage httpResponse = await client.GetAsync(brokenImage1.GetAttribute("src"));

            Assert.That(httpResponse.IsSuccessStatusCode == false, "Image is not broken");

            httpResponse = await client.GetAsync(brokenImage2.GetAttribute("src"));

            Assert.That(httpResponse.IsSuccessStatusCode == false, "Image is not broken");

            httpResponse = await client.GetAsync(emptyImage.GetAttribute("src"));

            var srcEmptyImage = emptyImage.GetAttribute("src");

            Assert.That(httpResponse.IsSuccessStatusCode == true, "Image is broken");
            Assert.That(srcEmptyImage, Does.Contain("img/avatar-blank.jpg"), "Image is not blank");




            //        if (httpResponse.IsSuccessStatusCode)
            //        {
            //            TestContext.Out.WriteLine($"Image at the link {image.GetAttribute("src")} is successful, status is {httpResponse.StatusCode}");
            //        }
            //        else
            //        {
            //            TestContext.Out.WriteLine($"Image at the link {image.GetAttribute("src")} is broken, status is {httpResponse.StatusCode}");

            //        }
            //    }
            //    catch (Exception ex)
            //    {

            //        if ((ex is ArgumentNullException) || ( ex is NotSupportedException))
            //        {
            //            TestContext.Out.WriteLine($"Error occured: {ex.Message}");

            //        }
            //    }
        }
    }
}

