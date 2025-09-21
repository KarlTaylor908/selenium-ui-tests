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
    public class BrokenImagesTest : TestBase
    {
        private BrokenImage brokenImagePage;

        [SetUp]
        public void SetUp()
        {
            brokenImagePage = new BrokenImage(driver, wait);
            brokenImagePage.GoToBrokenImagePage();
        }


        [Test]
        public async Task ImageIsBroken()
        {
            using var client = new HttpClient();
            var imageList = driver.FindElements(By.TagName("img"));

            var brokenImage1 = wait.Until(ExpectedConditions.ElementIsVisible(brokenImagePage.brokenImage1));
            var brokenImage2 = wait.Until(ExpectedConditions.ElementIsVisible(brokenImagePage.brokenImage2));

            HttpResponseMessage httpResponse = await client.GetAsync(brokenImage1.GetAttribute("src"));

            Assert.That(httpResponse.IsSuccessStatusCode == false, "Image is not broken");

            httpResponse = await client.GetAsync(brokenImage2.GetAttribute("src"));

            Assert.That(httpResponse.IsSuccessStatusCode == false, "Image is not broken");
        }

        [Test]
        public async Task BlankImage()
        {
            using var client = new HttpClient();

            var emptyImage = wait.Until(ExpectedConditions.ElementIsVisible(brokenImagePage.emptyImage));
            HttpResponseMessage httpResponse = await client.GetAsync(emptyImage.GetAttribute("src"));

            httpResponse = await client.GetAsync(emptyImage.GetAttribute("src"));

            var srcEmptyImage = emptyImage.GetAttribute("src");
            Assert.That(httpResponse.IsSuccessStatusCode == true, "Image is broken");
            Assert.That(srcEmptyImage, Does.Contain("img/avatar-blank.jpg"), "Image is not blank");

        }
    }
}

