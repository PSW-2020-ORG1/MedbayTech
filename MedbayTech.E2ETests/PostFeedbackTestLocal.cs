using System;
using System.Collections.Generic;
using System.Text;
using MedbayTech.E2ETests.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools.V84.Target;
using SeleniumEndToEnd.Pages;
using Xunit;
using Index = SeleniumEndToEnd.Pages.Index;

namespace SeleniumEndToEnd
{
    public class PostFeedbackTestLocal : IDisposable
    {
        private IWebDriver driver;
        private CreateFeedbackLocal createFeedbackPage;
        private LoginLocal loginPage;
        private HomeLocal homePage;
        private int feedbackCount = 0;

        public PostFeedbackTestLocal()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("start-maximized");            // open Browser in maximized mode
            options.AddArguments("disable-infobars");           // disabling infobars
            options.AddArguments("--disable-extensions");       // disabling extensions
            options.AddArguments("--disable-gpu");              // applicable to windows os only
            options.AddArguments("--disable-dev-shm-usage");    // overcome limited resource problems
            options.AddArguments("--no-sandbox");               // Bypass OS security model
            options.AddArguments("--disable-notifications");    // disable notifications

            driver = new ChromeDriver(options);
            homePage = new HomeLocal(driver);
            homePage.Navigate();

            loginPage = new LoginLocal(driver);
            loginPage.Navigate();

            Assert.Equal(driver.Url, LoginLocal.URI);
            Assert.True(loginPage.UsernameElementDisplayed());
            Assert.True(loginPage.PasswordElementDisplayed());
            Assert.True(loginPage.SubmitButtonElementDisplayed());

            loginPage.InsertUsername("pera");
            loginPage.InsertPassword("pera1978");
            loginPage.SubmitForm();
            loginPage.WaitForHomePage();


            Console.Write(feedbackCount);

            createFeedbackPage = new CreateFeedbackLocal(driver);
            createFeedbackPage.Navigate();

            Assert.True(createFeedbackPage.FeedbackTextboxDisplayed());          // check if form input elements are displayed
            Assert.True(createFeedbackPage.RadioButtonAllowedDisplayed());
            Assert.True(createFeedbackPage.RadioButtonAnonymousDisplayed());
            Assert.True(createFeedbackPage.SubmitButtonDisplayed());
        }

        public void Dispose()
        {
            driver.Quit();
            driver.Dispose();
        }
        [Fact]
        public void PostFeedback()
        {
            createFeedbackPage.AddFeedback("End 2 End testing test");
            createFeedbackPage.SelectAllowed();
            createFeedbackPage.SelectAnonymous();
            createFeedbackPage.SubmitFeedback();
            createFeedbackPage.WaitForFormSubmit();
            createFeedbackPage.ResolveAlertDialog();


            Dispose();
        }
    }
}

