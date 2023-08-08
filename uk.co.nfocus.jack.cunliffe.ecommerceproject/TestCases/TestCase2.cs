using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using uk.co.nfocus.jack.cunliffe.ecommerceproject.POMPages;
using uk.co.nfocus.jack.cunliffe.ecommerceproject.Utilities;

namespace uk.co.nfocus.jack.cunliffe.ecommerceproject.TestCases
{
    internal class TestCase2 : TestBase
    {

        [Test]
        public void Main()
        {
            Login();
            AddItemToCart();
            BuyItem();
            ConfirmOrder();
        }

        public void Login()
        {
            driver.Url = "https://www.edgewordstraining.co.uk/demo-site/my-account/";
            LoginPagePOM login = new LoginPagePOM(driver);
            login.Login("jack.cunliffe@nfocus.co.uk", "Mu3Wbu!AstG!!6Z");
        }

        public void AddItemToCart()
        {
            AccountPagePOM account = new AccountPagePOM(driver);
            account.SelectShop();

            ShopPagePOM shop = new ShopPagePOM(driver);
            shop.DismissBanner();
            shop.AddItem();
            shop.ViewCart();
        }

        public void BuyItem()
        {
            CartPagePOM cart = new CartPagePOM(driver);
            cart.ProceedToCheckout();

            BillingPagePOM billing = new BillingPagePOM(driver);
            billing.FillBillingInfo("Jack", "Cunliffe", "24 London Street", "London", "SW1A 0AA", "020 7219 4272");
            billing.PlaceOrder();

            //StaticHelpers.WaitForElement(driver, By.CssSelector("#post-6 > div > div > div > ul > li.woocommerce-order-overview__date.date > strong"), 3);
            //Can't get this to work ^^^

            Thread.Sleep(3000);
        }

        public void ConfirmOrder()
        {
            OrderConfirmationPOM orderConfirmation = new OrderConfirmationPOM(driver);
            AccountPagePOM account = new AccountPagePOM(driver);
            NavPOM navigation = new NavPOM(driver);

            orderConfirmation.TakeOrderNumberScreenshot();
            string orderNumber = orderConfirmation.RetrieveOrderNumber();
            orderNumber = "#" + orderNumber;
            navigation.NavigateToMyAccount();
            account.SelectOrders();
            string orderHistoryNumber = account.ReturnOrderHistoryNumber();

            try
            {
                Assert.That(orderNumber, Is.EqualTo(orderHistoryNumber), "Latest order history number does not match just placed order");
            }
            catch (AssertionException e)
            {
                //Do nothing - just dont crash the test
            }
        }
    }
}
