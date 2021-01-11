using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading;
using Xamarin.Essentials;

namespace MedbayTech.E2ETests.Pages
{
    public class ObserveAppointment
    {
        private readonly IWebDriver driver;
        //public const string URI = "http://localhost:4200/#/observeAppointment";
        public static string PORT = Environment.GetEnvironmentVariable("PORT") ?? "4200";

        public static string URI = $"http://localhost:{PORT}/#/observeAppointment";

        private IWebElement CancelAppointmentButton => driver.FindElement(By.XPath("//div[@id='cancel-appointment']/mat-card/mat-card-actions/button[@id='cancel-appointment-button']"));
        private ReadOnlyCollection<IWebElement> AppointmentsForCanceling  => driver.FindElements(By.XPath("//div[@id='cancel-appointment']/mat-card"));
        private ReadOnlyCollection<IWebElement> OtherAppointments => driver.FindElements(By.XPath("//div[@id='other-appointment']/mat-card"));

        public ObserveAppointment(IWebDriver driver)
        {
            this.driver = driver;
        }
        public void EnsurePageIsDisplayed()
        {
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 30));
            wait.Until(condition =>
            {
                try
                {
                    return AppointmentsForCancelingCount() > 0;
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

        public bool CancelAppointmentButtonDisplayed()
        {
            return CancelAppointmentButton.Displayed;
        }

        public void ClickCancelAppointmentButton()
        {
            CancelAppointmentButton.Click();
        }

        public int AppointmentsForCancelingCount() 
        {
            return AppointmentsForCanceling.Count;
        }
      
        public int OtherAppointmentsCount()
        {
            return OtherAppointments.Count;
        }

        public void WaitForAlertDialog()
        {
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 20));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.AlertIsPresent());
        }
        public void Wait()
        {
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 20));
            wait.Until(condition => AppointmentsForCanceling.Count > 0);
        }

        public void ResolveAlertDialog()
        {
            driver.SwitchTo().Alert().Accept();
        }

        public void Navigate() => driver.Navigate().GoToUrl(URI);
    }
}
