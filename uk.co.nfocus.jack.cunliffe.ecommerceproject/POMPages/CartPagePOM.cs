using OpenQA.Selenium.Interactions;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Diagnostics;

namespace uk.co.nfocus.jack.cunliffe.ecommerceproject.POMPages
{
    internal class CartPagePOM
    {
        private IWebDriver _driver;

        public CartPagePOM(IWebDriver driver)
        {
            _driver = driver;
        }

        //Locators
        private IWebElement _couponTextBox => _driver.FindElement(By.CssSelector("#coupon_code"));
        private IWebElement _applyCoupon => _driver.FindElement(By.CssSelector("#post-5 > div > div > form > table > tbody > tr:nth-child(2) > td > div > button"));
        private IWebElement _couponDiscountText;
        private IWebElement _subTotalText;
        private IWebElement _shippingCostText;
        private IWebElement _totalText;
        private IWebElement _proceedToCheckout => _driver.FindElement(By.CssSelector("#post-5 > div > div > div.cart-collaterals > div > div > a"));
        private IWebElement _myAccountbutton => _driver.FindElement(By.CssSelector("#menu-item-46 > a"));

        private decimal couponAmount;
        private decimal subTotalAmount;
        private decimal shippingCostAmount;
        private decimal totalAmount;

        public void InputCoupon(string coupon)
        {
            _couponTextBox.Click();
            _couponTextBox.Clear();
            _couponTextBox.SendKeys(coupon);
        }

        public void ApplyCoupon()
        {
            _applyCoupon.Click();
            Thread.Sleep(3000);
        }

        public bool CheckCoupon()
        {
            _couponDiscountText = _driver.FindElement(By.CssSelector("#post-5 > div > div > div.cart-collaterals > div > table > tbody > tr.cart-discount.coupon-edgewords > td > span"));
            _subTotalText = _driver.FindElement(By.CssSelector("#post-5 > div > div > div.cart-collaterals > div > table > tbody > tr.cart-subtotal > td > span"));

            couponAmount = ToDecimal(_couponDiscountText.Text.ToString());
            subTotalAmount = ToDecimal(_subTotalText.Text.ToString());
            if(couponAmount / subTotalAmount * 100 == 15)
            {
                return true;
            }
            return false;
        }

        public decimal ToDecimal(string input)
        {
            return decimal.Parse(input, NumberStyles.Currency);
        }

        public bool CheckTotal()
        {
            _shippingCostText = _driver.FindElement(By.CssSelector("#shipping_method > li > label > span"));
            _totalText = _driver.FindElement(By.CssSelector("#post-5 > div > div > div.cart-collaterals > div > table > tbody > tr.order-total > td > strong > span"));

            shippingCostAmount = ToDecimal(_shippingCostText.Text.ToString());
            totalAmount = ToDecimal(_totalText.Text.ToString());

            decimal expectedAmount = subTotalAmount - couponAmount;
            expectedAmount = expectedAmount + shippingCostAmount;
            ScrollToTop();
            if (expectedAmount == totalAmount)
            {
                return true;
            }
            return false;
        }

        public void ProceedToCheckout()
        {
            var actions = new Actions(_driver);
            actions.MoveToElement(_proceedToCheckout);
            actions.ScrollByAmount(0, 50);
            actions.Perform();
            _proceedToCheckout.Click();
        }

        public void ScrollToTop()
        {
            var actions = new Actions(_driver);
            actions.ScrollByAmount(0, -500);
            actions.Perform();
        }

        public void SelectMyAccount()
        {
            _myAccountbutton.Click();
        }
    }
}

