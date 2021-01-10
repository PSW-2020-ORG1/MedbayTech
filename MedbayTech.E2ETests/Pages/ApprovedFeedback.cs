using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace MedbayTech.E2ETests.Pages
{
    public class ApprovedFeedback
    {
        private IWebDriver _webDriver;

        public static string PORT = Environment.GetEnvironmentVariable("PORT") ?? "4200";

        public static string URI = $"http://localhost:{PORT}/#/feedback";
        public const string URI_local = "http://localhost:4200/#/feedback";


        private ReadOnlyCollection<IWebElement> Rows => _webDriver.FindElements(By.XPath("//div[@id='approvedFeedbackDiv']/mat-card"));
       
        public ApprovedFeedback(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public void EnsurePageIsDisplayed()
        {
            var wait = new WebDriverWait(_webDriver, new TimeSpan(0, 0, 20));
            wait.Until(condition =>
            {
                try
                {
                    return FeedbackCount() > 0;
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
        
        public int FeedbackCount() => Rows.Count;
        public void Navigate() => _webDriver.Navigate().GoToUrl(URI);
    }
}
