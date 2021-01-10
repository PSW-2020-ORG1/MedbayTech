using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;

namespace SeleniumEndToEnd.Pages
{
    public class HomeLocal
    {
        private IWebDriver _webDriver { get; }
        public const string URI = "http://localhost:53843/index.html#/home";
        public const string URI_HASH = "http://localhost:53843/#/home";
        public HomeLocal(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

//        IWebElement allFeedback => _webDriver.FindElement(By.Name("allFedback"));

        public void Navigate() => _webDriver.Navigate().GoToUrl(URI);

//        public void goToAllFeedback() => allFeedback.Click();


        //public bool AllFeedbackIsDisplayed()
        //{
        //    return allFeedback.Displayed;
        //}


    }
}
