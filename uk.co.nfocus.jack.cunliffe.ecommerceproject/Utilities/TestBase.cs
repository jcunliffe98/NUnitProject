using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using uk.co.nfocus.jack.cunliffe.ecommerceproject.POMPages;
using OpenQA.Selenium.DevTools.V112.Page;

namespace uk.co.nfocus.jack.cunliffe.ecommerceproject.Utilities
{
    internal class TestBase
    {
        private protected static IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            string Browser = Environment.GetEnvironmentVariable("BROWSER");

            switch (Browser)
            {
                case "firefox":
                    driver = new FirefoxDriver();
                    break;
                case "chrome":
                    driver = new ChromeDriver();
                    break;
                case "edge":
                    driver = new EdgeDriver();
                    break;
                case "ie":
                    driver = new InternetExplorerDriver();
                    break;
                case "remotechrome":
                    ChromeOptions options = new ChromeOptions();
                    driver = new RemoteWebDriver(new Uri("http://172.30.190.244:4444/wd/hub"), options);
                    break;
                default:
                    Console.WriteLine("No browser set - launching chrome");
                    driver = new ChromeDriver();
                    break;
            };



            driver.Manage().Window.Maximize();
        }

        [TearDown]
        public void TearDown()
        {
            NavPOM nav = new NavPOM(driver);

            nav.NavigateToMyAccount();
            nav.LogOut();

            Thread.Sleep(5000);
            driver.Quit();
        }
    }
}

