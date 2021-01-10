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
        public const string URI = "https://medbaytech.herokuapp.com/index.html#/allFeedback";

        private IWebElement CountFeedback => driver.FindElement(By.Name("all_feedback_len"));
        private IWebElement TitleFeedbacks => driver.FindElement(By.Name("feedbacks"));
        private IWebElement BlockPatientsButton => driver.FindElement(By.Name("block-malicious-users"));

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
