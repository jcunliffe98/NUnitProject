﻿using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace uk.co.nfocus.jack.cunliffe.ecommerceproject.Utilities
{
    internal static class StaticHelpers
    {

        public static void WaitForElement(IWebDriver driver, By Locator, int TimeInSeconds = 5)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(TimeInSeconds));
            wait.Until(waitForElement => waitForElement.FindElement(Locator).Enabled);
        }

        public static void TakeScreenshot(IWebDriver driver, IWebElement element, string fileName)
        {
            var ssdriver = element as ITakesScreenshot;
            var screenshot = ssdriver.GetScreenshot();
            screenshot.SaveAsFile(fileName);
            TestContext.AddTestAttachment(fileName);
        }
    }
}
