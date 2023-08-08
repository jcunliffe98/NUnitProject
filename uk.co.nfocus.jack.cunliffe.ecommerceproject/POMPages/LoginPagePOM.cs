﻿using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using uk.co.nfocus.jack.cunliffe.ecommerceproject.Utilities;

namespace uk.co.nfocus.jack.cunliffe.ecommerceproject.POMPages
{
    internal class LoginPagePOM
    {
        private IWebDriver _driver;

        public LoginPagePOM(IWebDriver driver)
        {
            _driver = driver;
        }

        //Locators
        private IWebElement _usernameField => _driver.FindElement(By.Id("username"));
        private IWebElement _passwordField
        {
            get
            {
                StaticHelpers.WaitForElement(_driver, By.Id("password"), 2);
                return _driver.FindElement(By.Id("password"));
            }
        }

        private IWebElement _submitButton => _driver.FindElement(By.Name("login"));
        //Service methods
        public void SetUsername(string username)
        {
            _usernameField.Clear();
            _usernameField.SendKeys(username);
        }

        public void SetPasssword(string password)
        {
            _passwordField.Clear();
            _passwordField.SendKeys(password);
        }

        public void SubmitForm()
        {
            _submitButton.Click();
        }

        //Higher level service methods
        public void Login(string username, string password)
        {
            SetUsername(username);
            SetPasssword(password);
            SubmitForm();
        }
    }
}

