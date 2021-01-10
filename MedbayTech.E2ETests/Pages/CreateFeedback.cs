using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SeleniumEndToEnd.Pages
{
    public class CreateFeedback
    {
        private IWebDriver _webDriver { get; }
        public static string PORT = Environment.GetEnvironmentVariable("PORT") ?? "4200";
        public static string URI = $"http://localhost:{PORT}/#/createFeedback";
        public static string UriTestEnv = $"http://localhost:{PORT}/#/createFeedback";

        public CreateFeedback(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        IWebElement txtFeedback => _webDriver.FindElement(By.Name("additionalNotes"));

        IWebElement radioAllowed => _webDriver.FindElement(By.Id("allowedNo"));

        IWebElement radioAnonymous => _webDriver.FindElement(By.Id("anonymousNo"));

        private IWebElement submitButton => _webDriver.FindElement(By.XPath("//button[@value='submit']"));

        public void EnsurePageIsDisplayed()
        {
            var wait = new WebDriverWait(_webDriver, new TimeSpan(0, 0, 20));
            wait.Until(condition =>
            {
                try
                {
                    return txtFeedback.Displayed &&
                           radioAllowed.Displayed &&
                           radioAnonymous.Displayed &&
                           submitButton.Displayed;
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
            var wait = new WebDriverWait(_webDriver, new TimeSpan(0, 0, 40));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.AlertIsPresent());
        }
        public void ResolveAlertDialog()
            => _webDriver.SwitchTo().Alert().Accept();
    }
}
