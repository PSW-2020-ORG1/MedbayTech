using MedbayTech.E2ETests.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumEndToEnd.Pages;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Shouldly;
using OpenQA.Selenium.Support.UI;

namespace MedbayTech.E2ETests
{
    public class CancelAppointmentTest : IDisposable
    {

        private IWebDriver driver;
        private Login loginPage;
        private Home homePage;
        private MedicalRecord medicalRecordPage;
        private ObserveAppointment observeAppointmentPage;
        private int appointmentsForCancelingCount = 0;
        private int otherAppointmentsCount = 0;

        public CancelAppointmentTest() 
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

            loginPage.InsertUsername("pera");
            loginPage.InsertPassword("pera1978");
            loginPage.SubmitForm();
            loginPage.WaitForPatientHomePage();

            homePage = new Home(driver);
           // if (Home.Stage.Equals("test"))
                Assert.Equal(driver.Url, Home.UriTestEnvFinal);
            // else
               //Assert.Equal(driver.Url, Home.URI);
            Assert.True(homePage.MedicalRecordLinkElementDisplayed());
            homePage.ClickMedicalRecordLink();

            medicalRecordPage = new MedicalRecord(driver);
            //if (MedicalRecord.Stage.Equals("test"))
                Assert.Equal(driver.Url, MedicalRecord.URI);
             // else
                // Assert.Equal(driver.Url, MedicalRecord.URI);

            Assert.True(medicalRecordPage.ObserveAppointmentLinkElementDisplayed());
            medicalRecordPage.ClickObserveAppointmentLink();

            
            observeAppointmentPage = new ObserveAppointment(driver);
            observeAppointmentPage.EnsurePageIsDisplayed();
            // if (ObserveAppointment.Stage.Equals("test"))
                Assert.Equal(driver.Url, ObserveAppointment.URI);
            // else
               // Assert.Equal(driver.Url, ObserveAppointment.URI);
            Assert.True(observeAppointmentPage.CancelAppointmentButtonDisplayed());
        }

        public void Dispose()
        {
            driver.Quit();
            driver.Dispose();
        }

        [Fact]
        public void TestSuccessfulCancelAppointment()
        {
            appointmentsForCancelingCount = observeAppointmentPage.AppointmentsForCancelingCount();
            observeAppointmentPage.ClickCancelAppointmentButton();
            observeAppointmentPage.WaitForAlertDialog();
            observeAppointmentPage.ResolveAlertDialog();

            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 20));
            wait.Until(condition => appointmentsForCancelingCount > observeAppointmentPage.AppointmentsForCancelingCount() && observeAppointmentPage.OtherAppointmentsCount() != 0);
            otherAppointmentsCount = observeAppointmentPage.OtherAppointmentsCount();
            wait.Until(condition => otherAppointmentsCount < observeAppointmentPage.OtherAppointmentsCount());
            Assert.Equal(appointmentsForCancelingCount - 1, observeAppointmentPage.AppointmentsForCancelingCount());
            Assert.Equal(otherAppointmentsCount + 1, observeAppointmentPage.OtherAppointmentsCount());

        }



    }
}
