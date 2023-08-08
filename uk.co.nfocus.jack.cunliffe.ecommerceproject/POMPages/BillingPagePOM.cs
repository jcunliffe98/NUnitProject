using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uk.co.nfocus.jack.cunliffe.ecommerceproject.POMPages
{
    internal class BillingPagePOM
    {
        private IWebDriver _driver;

        public BillingPagePOM(IWebDriver driver)
        {
            _driver = driver;
        }

        //Locators
        private IWebElement _firstNameTextBox => _driver.FindElement(By.CssSelector("#billing_first_name"));
        private IWebElement _lastNameTextBox => _driver.FindElement(By.CssSelector("#billing_last_name"));
        private IWebElement _addressTextBox => _driver.FindElement(By.CssSelector("#billing_address_1"));
        private IWebElement _cityTextBox => _driver.FindElement(By.CssSelector("#billing_city"));

        private IWebElement _postcodeTextBox => _driver.FindElement(By.CssSelector("#billing_postcode"));
        private IWebElement _phoneTextBox => _driver.FindElement(By.CssSelector("#billing_phone"));
        private IWebElement _placeOrderTextBox => _driver.FindElement(By.CssSelector("#place_order"));
        private IWebElement _orderNumber => _driver.FindElement(By.CssSelector("#post-6 > div > div > div > ul > li.woocommerce-order-overview__order.order > strong"));

        public void FillBillingInfo()
        {
            var actions = new Actions(_driver);
            actions.MoveToElement(_phoneTextBox);
            actions.Perform();
            FillName();
            FillAddress();
        }

        public void FillName()
        {
            _firstNameTextBox.Clear();
            _firstNameTextBox.SendKeys("Jack");

            _lastNameTextBox.Clear();
            _lastNameTextBox.SendKeys("Cunliffe");

            var actions = new Actions(_driver);
            actions.ScrollByAmount(0, 100);
            actions.Perform();
        }

        public void FillAddress()
        {
            _addressTextBox.Clear();
            _addressTextBox.SendKeys("24 London Street");

            _cityTextBox.Clear();
            _cityTextBox.SendKeys("London");

            _postcodeTextBox.Clear();
            _postcodeTextBox.SendKeys("SW1A 0AA");

            _phoneTextBox.Clear();
            _phoneTextBox.SendKeys("020 7219 4272");

            var actions = new Actions(_driver);
            actions.ScrollByAmount(0, 100);
            actions.Perform();
        }
        public void PlaceOrder()
        {
            _placeOrderTextBox.Click();
        }
    }
}
