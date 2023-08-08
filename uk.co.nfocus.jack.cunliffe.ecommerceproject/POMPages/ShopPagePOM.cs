﻿using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using uk.co.nfocus.jack.cunliffe.ecommerceproject.Utilities;

namespace uk.co.nfocus.jack.cunliffe.ecommerceproject.POMPages
{
    internal class ShopPagePOM
    {
        private IWebDriver _driver;

        public ShopPagePOM(IWebDriver driver)
        {
            _driver = driver;
        }

        //Locators
        private IWebElement _addHatToCart => _driver.FindElement(By.CssSelector("#main > ul > li.product.type-product.post-27.status-publish.first.instock.product_cat-accessories.has-post-thumbnail.sale.shipping-taxable.purchasable.product-type-simple > a.button.product_type_simple.add_to_cart_button.ajax_add_to_cart"));
        private IWebElement _viewCart
        {
            get
            {
                StaticHelpers.WaitForElement(_driver, By.CssSelector("a[title='View cart']"), 5);
                return _driver.FindElement(By.CssSelector("a[title='View cart']"));
            }
        }

        private IWebElement _demoBanner => _driver.FindElement(By.CssSelector("body > p > a"));

        public void AddItem()
        {
            var actions = new Actions(_driver);
            actions.MoveToElement(_addHatToCart);
            actions.Perform();
            _addHatToCart.Click();
            Thread.Sleep(1000);
            //Crashes without the sleep, can't get explicit wait for viewcart working
        }

        public void ViewCart()
        {
            _viewCart.Click();
        }

        public void DismissBanner()
        {
            _demoBanner.Click();
        }
    }
}
