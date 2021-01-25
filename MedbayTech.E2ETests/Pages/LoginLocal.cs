using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumEndToEnd.Pages;
using System;
using System.Collections.Generic;
using System.Text;

namespace MedbayTech.E2ETests.Pages
{
    public class LoginLocal
    {
        private readonly IWebDriver driver;
        public const string URI = "http://localhost:53843/index.html#/login";
        public const string URI_Local = "http://localhost:53843/#/login";
        private IWebElement Username => driver.FindElement(By.Name("username-ff"));
        private IWebElement Password => driver.FindElement(By.Name("password-ff"));
        private IWebElement LoginButton => driver.FindElement(By.Name("button-ff"));

        public LoginLocal(IWebDriver webDriver)
        {
            driver = webDriver;
        }

        public bool UsernameElementDisplayed()
        {
            return Username.Displayed;
        }

        public bool PasswordElementDisplayed()
        {
            return Password.Displayed;
        }

        public bool SubmitButtonElementDisplayed()
        {
            return LoginButton.Displayed;
        }

        public void InsertUsername(string username)
        {
            Username.SendKeys(username);
        }

        public void InsertPassword(string password)
        {
            Password.SendKeys(password);
        }

        public void SubmitForm()
        {
            LoginButton.Click();
        }

        public void WaitForHomePage()
        {
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.UrlToBe(HomeLocal.URI_HASH));
        }

        public void Navigate() => driver.Navigate().GoToUrl(URI);
    }
}
