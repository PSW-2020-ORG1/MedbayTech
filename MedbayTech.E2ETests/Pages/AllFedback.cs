using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SeleniumEndToEnd.Pages
{
    public class AllFedback
    {
        private IWebDriver driver;
        //public const string URI_local = "http://localhost:4200/#/allFeedback";
//        public static string PORT = Environment.GetEnvironmentVariable("PORT") ?? "4200";

        public static string PORT = Environment.GetEnvironmentVariable("PORT") ?? "4200";
        public static string STAGE = Environment.GetEnvironmentVariable("STAGE") ?? "";

        public static string URI = $"http://localhost:{PORT}/{STAGE}#/allFeedback";
        public static string URI_Local = $"http://localhost:{PORT}/#/allFeedback";

        private IWebElement CountFeedback => driver.FindElement(By.Name("all_feedback_len"));
        private IWebElement TitleFeedbacks => driver.FindElement(By.Name("feedbacks"));
        private IWebElement BlockPatientsButton => driver.FindElement(By.Name("block-malicious-users"));

        private IReadOnlyCollection<IWebElement> AllowButtons =>
            driver.FindElements(By.XPath("//div[@id='allFeedback']/mat-card/mat-card-actions/button"));


        private IReadOnlyCollection<IWebElement> Buttons =>
            driver.FindElements(By.XPath("//div[@id='allFeedback']/mat-card/mat-card-actions/button"));

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

        public int GetCountApproveButtons => Buttons.Count(b => b.Text.Equals("Approve"));
        public int GetCountDenyButtons => Buttons.Count(b => b.Text.Equals("Deny"));
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

        public IWebElement GetApproveButton => Buttons.FirstOrDefault(b => b.Text.Equals("Approve"));
        public IWebElement GetDenyButton => Buttons.FirstOrDefault(b => b.Text.Equals("Deny"));
        public bool TitleDisplayed()
        {
            return TitleFeedbacks.Displayed;
        }

        public void ApproveFeedback() => GetApproveButton.Click();
        public void DenyFeedback() => GetDenyButton.Click();
        public void Navigate() => driver.Navigate().GoToUrl(URI);
    }
}
