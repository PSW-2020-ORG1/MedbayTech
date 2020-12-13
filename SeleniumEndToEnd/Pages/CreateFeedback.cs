using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SeleniumEndToEnd.Pages
{
    public class CreateFeedback
    {
        private IWebDriver _webDriver { get; }
        public const string URI = "http://localhost:4200/createFeedback";

        public CreateFeedback(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        IWebElement txtFeedback => _webDriver.FindElement(By.Name("additionalNotes"));

        IWebElement radioAllowed => _webDriver.FindElement(By.Id("allowedYes"));

        IWebElement radioAnonymous => _webDriver.FindElement(By.Id("anonymousNo"));

        private IWebElement submitButton => _webDriver.FindElement(By.XPath("//button[@value='submit']"));

        public void PostFeedback(string feedbackText)
        {
            txtFeedback.SendKeys(feedbackText);
            radioAllowed.Click();
            radioAnonymous.Click();

            submitButton.Submit();
        }
        public void Navigate() => _webDriver.Navigate().GoToUrl(URI);

        public void SelectAllowed() => radioAllowed.Click();
        
        public void SelectAnonymous() => radioAnonymous.Click();

        public void AddFeedback(string feedback) => txtFeedback.SendKeys(feedback);

        public void SubmitFeedback() => submitButton.Submit();

        public bool FeedbackTextboxDisplayed()
        {
            return txtFeedback.Displayed;
        }

        public bool RadioButtonAllowedDisplayed()
        {
            return radioAllowed.Displayed;
        }
        public bool RadioButtonAnonymousDisplayed()
        {
            return radioAnonymous.Displayed;
        }
        public bool SubmitButtonDisplayed()
        {
            return submitButton.Displayed;
        }

        public void WaitForFormSubmit()
        {
            _webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);

        }
    }
}
