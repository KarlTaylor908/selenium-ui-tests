using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools.V137.DOM;
using OpenQA.Selenium.Support.UI;

namespace SeleniumAutomationDemo.Utilities
{
    public class TestBase
    {
        protected static ExtentReports _extent;
        [ThreadStatic] protected static ExtentTest test;
        protected IWebDriver driver;
        protected WebDriverWait wait;
        private static readonly object _lock = new();
        private static bool _initialized;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {


            var options = new ChromeOptions();
            options.AddArgument("--headless=new");
            options.AddArgument("--no-sandbox");
            options.AddArgument("--disable-dev-shm-usage");
            options.AddArgument("--window-size=1920,1080");
            driver = new ChromeDriver(options);
            driver.Manage().Window.Maximize();
  
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            if (_initialized) return;
            lock (_lock)
            {
                if (_initialized) return;
                var outDir = Path.Combine(TestContext.CurrentContext.WorkDirectory, "TestResults", "Extent");
                Directory.CreateDirectory(outDir);

                var spark = new ExtentSparkReporter(Path.Combine(outDir, "index.html"));
                _extent = new ExtentReports();
                _extent.AttachReporter(spark);

                var baseUrl = Environment.GetEnvironmentVariable("BASE_URL") ?? "https://the-internet.herokuapp.com/";
                _extent.AddSystemInfo("Base URL", baseUrl);
                _extent.AddSystemInfo("Browser", "Chrome");
                _extent.AddSystemInfo("OS", Environment.OSVersion.ToString());
                _extent.AddSystemInfo("Executed By", Environment.UserName);
                _extent.AddSystemInfo("Machine Name", Environment.MachineName);
                _extent.AddSystemInfo(".NET", Environment.Version.ToString());
                _initialized = true;
            }
       
        }

        [SetUp]
        public void Setup()
        {
            test = _extent.CreateTest(TestContext.CurrentContext.Test.Name);
        }

        [TearDown]
        public void TearDown()
        {
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            var dir = Path.Combine(TestContext.CurrentContext.WorkDirectory, "TestResults", "Extent");
            var screenshotDir = Path.Combine(dir, "Screenshots").Replace("\\", "/");
            Directory.CreateDirectory(screenshotDir);

            if (status ==NUnit.Framework.Interfaces.TestStatus.Failed)
            {
                dir = Path.Combine(dir, $"{TestContext.CurrentContext.Test.Name}_{DateTime.Now:yyyyMMdd_HHmmss}.png");

                var screenshot = ((ITakesScreenshot)driver).GetScreenshot();
                File.WriteAllBytes(dir, screenshot.AsByteArray);

                var b64 = screenshot.AsBase64EncodedString;
                test.Fail("Test Failed",MediaEntityBuilder.CreateScreenCaptureFromBase64String(b64).Build());

                

                test.Log(Status.Fail, "Test Failed").AddScreenCaptureFromPath(dir);
            }
            else if (status == NUnit.Framework.Interfaces.TestStatus.Passed)
            {
                test.Log(Status.Pass, "Test Passed");
            }
            else if (status == NUnit.Framework.Interfaces.TestStatus.Skipped)
            {
                test.Log(Status.Skip, "Test Skipped");
            }
            else
            {
                test.Log(Status.Warning, "Test had unexpected outcome");
            }
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            _extent.Flush();
            driver.Dispose();
            driver.Quit();
           
        }
    }
}

