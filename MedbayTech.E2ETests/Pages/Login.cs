﻿using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumEndToEnd.Pages;
using System;
using System.Collections.Generic;
using System.Text;

namespace MedbayTech.E2ETests.Pages
{
    public class Login
    {
        private readonly IWebDriver driver;
        //public static string PORT = Environment.GetEnvironmentVariable("PORT") ?? "4200";
        public static string PORT = Environment.GetEnvironmentVariable("PORT") ?? "4200";
        public static string STAGE = Environment.GetEnvironmentVariable("STAGE") ?? "";

        public static string URI = $"http://localhost:{PORT}/{STAGE}#/login";
        public static string URI_Local = $"http://localhost:{PORT}/#/login";

        //public const string URI = "http://localhost:4200/#/login";
        private IWebElement Username => driver.FindElement(By.Name("username-ff"));
        private IWebElement Password => driver.FindElement(By.Name("password-ff"));
        private IWebElement LoginButton => driver.FindElement(By.Name("button-ff"));

        public Login(IWebDriver webDriver)
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

        public void WaitForAdministratorHomePage()
        {
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.UrlToBe(AllFedback.URI_Local));
        }
        public void Navigate() => driver.Navigate().GoToUrl(URI);

        public void WaitForPatientHomePage()
        {
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.UrlToBe(Home.URI_Local));
        }
    
    }
}