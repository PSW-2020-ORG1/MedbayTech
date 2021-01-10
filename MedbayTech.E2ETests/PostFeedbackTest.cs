using System;
using System.Collections.Generic;
using System.Text;
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
        private Index indexPage;

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

            indexPage = new Index(driver);
            indexPage.Navigate();
            
            Assert.True(indexPage.AllFeedbackIsDisplayed());
            Assert.True(indexPage.CreateFeedbackIsDisplayed());


            allFeedbackPage = new AllFedback(driver); 
            indexPage.goToAllFeedback();

            allFeedbackPage.EnsurePageIsDisplayed();

            feedbackCount = allFeedbackPage.GetFeedbackCount();       // get number of table rows - after create successful sheck if number increased
            Console.Write(feedbackCount);

            createFeedbackPage = new CreateFeedback(driver);
            indexPage.goToCreateFeedback();


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

            AllFedback newAllFedbackPage = new AllFedback(driver);
            indexPage.goToAllFeedback();

            newAllFedbackPage.EnsurePageIsDisplayed();                                    // wait for table to populate
            Assert.True(newAllFedbackPage.TitleDisplayed());

            Assert.Equal(feedbackCount + 1, newAllFedbackPage.GetFeedbackCount());           // check if number of rows increased       
            Console.Write(newAllFedbackPage.GetFeedbackCount());

            Dispose();
        }
    }
}

