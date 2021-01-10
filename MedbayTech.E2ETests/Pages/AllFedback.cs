﻿using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SeleniumEndToEnd.Pages
{
    public class AllFedback
    {
        private IWebDriver driver;
        //public const string URI = "http://localhost:4200/#/allFeedback";
        public static string PORT = Environment.GetEnvironmentVariable("PORT") ?? "53843";

        public static string URI = $"http://localhost:{PORT}/#/allFeedback";

        private IWebElement CountFeedback => driver.FindElement(By.Name("all_feedback_len"));
        private IWebElement TitleFeedbacks => driver.FindElement(By.Name("feedbacks"));
        private IWebElement BlockPatientsButton => driver.FindElement(By.Name("block-malicious-users"));
        public AllFedback(IWebDriver webdriver)
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
                    return GetFeedbackCount() > 0;
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

        public bool MaliciousPatientsLinkElementDisplayed()
        {
            return BlockPatientsButton.Displayed;
        }

        public void ClickMaliciousPatientsLink()
        {
            BlockPatientsButton.Click();
        }

        public int GetFeedbackCount()
        {
            string[] str = CountFeedback.Text.Split(':');
            string number = str[1].Trim().Split(' ')[0];
            return int.Parse(number);
        }


        public bool TitleDisplayed()
        {
            return TitleFeedbacks.Displayed;
        }

        public void Navigate() => driver.Navigate().GoToUrl(URI);
    }
}
