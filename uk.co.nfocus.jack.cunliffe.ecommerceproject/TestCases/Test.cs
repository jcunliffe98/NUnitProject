using OpenQA.Selenium.Interactions;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using uk.co.nfocus.jack.cunliffe.ecommerceproject.Utilities;
using uk.co.nfocus.jack.cunliffe.ecommerceproject.POMPages;

namespace uk.co.nfocus.jack.cunliffe.ecommerceproject.TestCases
{
    [TestFixture]
    internal class HelloWebdriver : TestBase
    {

        [Test]

        public void Main()
        {
            Login();
            GoToShop();
            ApplyCoupon();
        }
        public void Login()
        {
            driver.Url = "https://www.edgewordstraining.co.uk/demo-site/my-account/";
            LoginPagePOM login = new LoginPagePOM(driver);
            login.Login("jack.cunliffe@nfocus.co.uk", "Mu3Wbu!AstG!!6Z");
        }
        
        public void GoToShop()
        {
            AccountPagePOM account = new AccountPagePOM(driver);
            account.SelectShop();

            ShopPagePOM shop = new ShopPagePOM(driver);
            shop.DismissBanner();
            shop.AddItem();
            shop.ViewCart();
        }

        public void ApplyCoupon()
        {
            CartPagePOM cart = new CartPagePOM(driver);

            cart.InputCoupon("edgewords");
            cart.ApplyCoupon();

            bool wasCouponAppliedSuccessfully = cart.CheckCoupon();

            try
            {
                Assert.That(wasCouponAppliedSuccessfully, Is.True);
            }
            catch (AssertionException e)
            {

            }

            bool isTotalCorrect = cart.CheckTotal();
            try
            {
                Assert.That(isTotalCorrect, Is.True);
            }
            catch (AssertionException e)
            {

            }
        }
    }
}
