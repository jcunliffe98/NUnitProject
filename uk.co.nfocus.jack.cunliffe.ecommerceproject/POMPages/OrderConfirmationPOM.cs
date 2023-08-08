using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uk.co.nfocus.jack.cunliffe.ecommerceproject.POMPages
{
    internal class OrderConfirmationPOM
    {
        private IWebDriver _driver;

        public OrderConfirmationPOM(IWebDriver driver)
        {
            _driver = driver;
        }

        //Locators
        private IWebElement _orderNumber => _driver.FindElement(By.CssSelector("#post-6 > div > div > div > ul > li.woocommerce-order-overview__order.order > strong"));
        private IWebElement _myAccountButton => _driver.FindElement(By.CssSelector("#menu-item-46 > a"));

        public void TakeOrderNumberScreenshot()
        {
            var ssdriver = _orderNumber as ITakesScreenshot;
            var orderNumberScreenshot = ssdriver.GetScreenshot();
            orderNumberScreenshot.SaveAsFile("orderNumber.png");
            TestContext.AddTestAttachment("orderNumber.png");
        }

        public string NavigateToMyAccount()
        {
            string orderNumberText = _orderNumber.Text;
            _myAccountButton.Click();
            return orderNumberText;
        }
    }
}
