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

namespace uk.co.nfocus.jack.cunliffe.ecommerceproject.Utilities
{
    internal class TestBase
    {
        private protected static IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            //ChromeOptions options = new ChromeOptions(); //Create a browser specific options object
            //options.AddArguments("--start-maximized"); //Chrome specific option
            //driver = new ChromeDriver(options); //Pass the options to the browser on instantiation
            //driver = new InternetExplorerDriver();

            //FirefoxOptions options = new FirefoxOptions();
            ////options.EnableMobileEmulation("Pixel 5");
            ////options.AddArgument("--headless=new");
            ////driver = new ChromeDriver(options);
            //driver = new RemoteWebDriver(new Uri("http://172.30.190.244:4444/wd/hub"), options);


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
            //XBrowser friendly
            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        [TearDown]
        public void TearDown()
        {
            //Pause so we can see test effect
            Thread.Sleep(5000); //Time in ms to wait
            //Close the web browser
            //driver.Close(); //Closes current tab (and browser if only one tab)
            driver.Quit(); //Close browser, end driver server connectionas well - most common
        }
    }
}

