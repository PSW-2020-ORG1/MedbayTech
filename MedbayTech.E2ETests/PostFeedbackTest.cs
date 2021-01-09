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
    public class PostFeedbackTest : IDisposable
    {
        private IWebDriver driver;
        private AllFedback allFeedbackPage;
        private CreateFeedback createFeedbackPage;
        private Login loginPage;
        private Home homePage;

        private int feedbackCount = 0;

        public PostFeedbackTest()
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

            loginPage = new Login(driver);
            loginPage.Navigate();
            Assert.Equal(driver.Url, Login.URI);
            Assert.True(loginPage.UsernameElementDisplayed());
            Assert.True(loginPage.PasswordElementDisplayed());
            Assert.True(loginPage.SubmitButtonElementDisplayed());

            loginPage.InsertUsername("markic");
            loginPage.InsertPassword("marko1978");
            loginPage.SubmitForm();
            loginPage.WaitForAdministratorHomePage();

            allFeedbackPage = new AllFedback(driver);
            Assert.Equal(driver.Url, AllFedback.URI);
            allFeedbackPage.EnsurePageIsDisplayed();

            feedbackCount = allFeedbackPage.GetFeedbackCount();

            loginPage.Navigate();
            Assert.Equal(driver.Url, Login.URI);
            Assert.True(loginPage.UsernameElementDisplayed());
            Assert.True(loginPage.PasswordElementDisplayed());
            Assert.True(loginPage.SubmitButtonElementDisplayed());

            loginPage.InsertUsername("pera");
            loginPage.InsertPassword("pera1978");
            loginPage.SubmitForm();
            loginPage.WaitForPatientHomePage();

            homePage = new Home(driver);
            Assert.Equal(driver.Url, Home.URI);
            Assert.True(homePage.CreateFeedbackLinkElementDisplayed());
            homePage.ClickCreateFeedbackLink();

            createFeedbackPage = new CreateFeedback(driver);
            createFeedbackPage.EnsurePageIsDisplayed();
            Assert.Equal(driver.Url, CreateFeedback.URI);
            Assert.True(createFeedbackPage.FeedbackTextboxDisplayed());
            Assert.True(createFeedbackPage.RadioButtonAllowedDisplayed());
            Assert.True(createFeedbackPage.RadioButtonAnonymousDisplayed());
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

            loginPage.Navigate();
            Assert.Equal(driver.Url, Login.URI);
            Assert.True(loginPage.UsernameElementDisplayed());
            Assert.True(loginPage.PasswordElementDisplayed());
            Assert.True(loginPage.SubmitButtonElementDisplayed());

            loginPage.InsertUsername("markic");
            loginPage.InsertPassword("marko1978");
            loginPage.SubmitForm();
            loginPage.WaitForAdministratorHomePage();

            AllFedback newAllFeedbackPage = new AllFedback(driver);
            Assert.Equal(driver.Url, AllFedback.URI);
            newAllFeedbackPage.EnsurePageIsDisplayed();

            Assert.Equal(feedbackCount + 1, newAllFeedbackPage.GetFeedbackCount());

            Dispose();
        }
    }
}

