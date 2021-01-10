﻿using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace MedbayTech.E2ETests.Pages
{
    public class Home
    {
        private IWebDriver driver;
        public static string PORT = Environment.GetEnvironmentVariable("PORT") ?? "4200";
        public static string URI = $"http://localhost:{PORT}/#/home";
        public static string UriTestEnv = "http://localhost:53843/index.html#/home";
        public static string UriTestEnvFinal = "http://localhost:53843/#/home";
        public static string Stage = Environment.GetEnvironmentVariable("STAGE") ?? "development";

        private IWebElement MedicalRecord => driver.FindElement(By.Name("medical-record"));
        private IWebElement CreateFeedback => driver.FindElement(By.Name("create-feedback"));

        public Home(IWebDriver webdriver) 
        {
            driver = webdriver;
        }

        public void EnsurePageIsDisplayed() 
        {
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 20));
            wait.Until(condition =>
            {
                try
                {
                    return MedicalRecordLinkElementDisplayed();
                }
                catch (StaleElementReferenceException)
                {
                    return false;
                }
                catch (NoSuchElementException)
                {
                    return false;
                }
            });
        }

        public bool MedicalRecordLinkElementDisplayed()
        {
            return MedicalRecord.Displayed;
        }

        public void ClickMedicalRecordLink()
        {
            MedicalRecord.Click();
        }

        public bool CreateFeedbackLinkElementDisplayed()
        {
            return CreateFeedback.Displayed;
        }

        public void ClickCreateFeedbackLink()
        {
            CreateFeedback.Click();
        }

        public void Navigate() => driver.Navigate().GoToUrl(URI);

    }
}
