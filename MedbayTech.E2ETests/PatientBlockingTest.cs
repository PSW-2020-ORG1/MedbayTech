using System;
using System.Collections.Generic;
using System.Text;
using MedbayTech.E2ETests.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools.V84.Target;
using SeleniumEndToEnd.Pages;
using Xunit;

namespace MedbayTech.E2ETests
{
    public class PatientBlockingTest : IDisposable
    {

        private IWebDriver driver;
        private AllFedback allFeedbackPage;
        private BlockMaliciousPatients blockMaliciousPatientsPage;
        private Login loginPage;
        private int patientsForBlockingCount = 0;

        public PatientBlockingTest()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("start-maximized");
            options.AddArguments("disable-infobars");
            options.AddArguments("--disable-extensions");
            options.AddArguments("--disable-gpu");
            options.AddArguments("--disable-dev-shm-usage");
            options.AddArguments("--no-sandbox");
            options.AddArguments("--disable-notifications");

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
            Assert.True(allFeedbackPage.MaliciousPatientsLinkElementDisplayed());
            allFeedbackPage.ClickMaliciousPatientsLink();

            blockMaliciousPatientsPage = new BlockMaliciousPatients(driver);
            blockMaliciousPatientsPage.EnsurePageIsDisplayed();
            patientsForBlockingCount = blockMaliciousPatientsPage.PatientsForBlockingCount();
            Assert.Equal(driver.Url, BlockMaliciousPatients.URI);
            Assert.True(blockMaliciousPatientsPage.BlockMaliciousPatientButtonDisplayed());
        }

        public void Dispose()
        {
            driver.Quit();
            driver.Dispose();
        }

        [Fact]
        public void TestSuccessfulBlockingMaliciousPatient()
        {
            blockMaliciousPatientsPage.ClickBlockMaliciousPatientButton();
            blockMaliciousPatientsPage.WaitForAlertDialog();
            blockMaliciousPatientsPage.ResolveAlertDialog();

           
            Assert.Equal(patientsForBlockingCount, blockMaliciousPatientsPage.PatientsForBlockingCount());
        }

        
    }
}
