using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace uk.co.nfocus.jack.cunliffe.ecommerceproject.Utilities
{
    internal static class StaticHelpers
    {

        public static void WaitForElement(IWebDriver driver, By Locator, int TimeInSeconds = 5)
        {
            WebDriverWait myWait2 = new WebDriverWait(driver, TimeSpan.FromSeconds(TimeInSeconds));
            myWait2.Until(anythingatall => anythingatall.FindElement(Locator).Enabled);
        }
    }
}
