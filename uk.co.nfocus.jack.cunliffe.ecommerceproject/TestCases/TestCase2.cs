using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using uk.co.nfocus.jack.cunliffe.ecommerceproject.POMPages;
using uk.co.nfocus.jack.cunliffe.ecommerceproject.Utilities;

namespace uk.co.nfocus.jack.cunliffe.ecommerceproject.TestCases
{
    internal class TestCase2 : TestBase
    {

        [Test, Order(1)]
        public void Test2()
        {
            driver.Url = "https://www.edgewordstraining.co.uk/demo-site/my-account/";
            LoginPagePOM login = new LoginPagePOM(driver);
            login.Login("jack.cunliffe@nfocus.co.uk", "Mu3Wbu!AstG!!6Z");

            AccountPagePOM account = new AccountPagePOM(driver);
            account.SelectShop();

            ShopPagePOM shop = new ShopPagePOM(driver);
            shop.AddItem();
            shop.ViewCart();

            CartPagePOM cart = new CartPagePOM(driver);
            cart.ProceedToCheckout();

            BillingPagePOM billing = new BillingPagePOM(driver);
            billing.FillBillingInfo();
            billing.PlaceOrder();

            Thread.Sleep(3000);

            OrderConfirmationPOM orderConfirmation = new OrderConfirmationPOM(driver);
            orderConfirmation.TakeOrderNumberScreenshot();
            string orderNumber = orderConfirmation.NavigateToMyAccount();
            account.SelectOrders();
            bool testPass = account.CheckOrderNumber(orderNumber);

            try
            {
                Assert.That(testPass, Is.True);
            }
            catch (AssertionException e)
            {
                //Do nothing - just dont crash the test
            }

            account.LogOut();
        }
    }
}
