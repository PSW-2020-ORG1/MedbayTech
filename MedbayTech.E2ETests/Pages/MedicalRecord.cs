using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace MedbayTech.E2ETests.Pages
{
    class MedicalRecord
    {
        private IWebDriver driver;
        public static string PORT = Environment.GetEnvironmentVariable("PORT") ?? "4200";
        public static string URI = $"http://localhost:{PORT}/#/medicalRecord";
        public static string UriTestEnv = "http://localhost:53843/#/medicalRecord";
        public static string Stage = Environment.GetEnvironmentVariable("STAGE") ?? "development";

        private IWebElement ObserveAppointment => driver.FindElement(By.Name("observe-appointment"));

        public MedicalRecord(IWebDriver webdriver)
        {
            driver = webdriver;
        }

        public void EnsurePageIsDisplayed()
        {
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 20));
            wait.Until(condition =>
            {
                try
                {
                    return ObserveAppointmentLinkElementDisplayed();
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

        public bool ObserveAppointmentLinkElementDisplayed()
        {
            return ObserveAppointment.Displayed;
        }

        public void ClickObserveAppointmentLink()
        {
            ObserveAppointment.Click();
        }

        public void Navigate() => driver.Navigate().GoToUrl(URI);
    }
}
