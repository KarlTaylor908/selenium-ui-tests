﻿using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumAutomationDemo.Utilities
{

    public class TestBase
    {
        protected IWebDriver driver;
        protected WebDriverWait wait;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();

            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/");

            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));

        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            driver.Dispose();
            driver.Close();
        }
    }
}

