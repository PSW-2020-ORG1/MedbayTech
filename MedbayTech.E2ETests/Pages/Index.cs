using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;

namespace SeleniumEndToEnd.Pages
{
    public class Index
    {
        private IWebDriver _webDriver { get; }

        public static string STAGE = Environment.GetEnvironmentVariable("STAGE") ?? "";

        public static string PORT = Environment.GetEnvironmentVariable("PORT") ?? "4200";

        public static string URI = $"http://localhost:{PORT}/{STAGE}#/home";
        public static string URI_Local = $"http://localhost:{PORT}/#/home";

        public Index(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        IWebElement createFeedback => _webDriver.FindElement(By.Name("createFeedback"));
        IWebElement allFeedback => _webDriver.FindElement(By.Name("allFedback"));

        public void Navigate() => _webDriver.Navigate().GoToUrl(URI);

        public void goToCreateFeedback() => createFeedback.Click();
        public void goToAllFeedback() => allFeedback.Click();


        public bool CreateFeedbackIsDisplayed()
        {
            return createFeedback.Displayed;
        }
        public bool AllFeedbackIsDisplayed()
        {
            return allFeedback.Displayed;
        }


    }
}
