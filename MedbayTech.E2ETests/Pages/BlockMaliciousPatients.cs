using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace MedbayTech.E2ETests.Pages
{
    public class BlockMaliciousPatients
    {
        private readonly IWebDriver driver;
        //public const string URI = "http://localhost:4200/#/blockMaliciousUsers";
        public static string PORT = Environment.GetEnvironmentVariable("PORT") ?? "53843";

        public static string URI = $"http://localhost:{PORT}/#/blockMaliciousUsers";

        private IWebElement BlockMaliciousPatientButton => driver.FindElement(By.ClassName("block-button"));
        private ReadOnlyCollection<IWebElement> PatientsForBlocking => driver.FindElements(By.ClassName("block-button-td"));

        public BlockMaliciousPatients(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void EnsurePageIsDisplayed()
        {
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 20));
            wait.Until(condition =>
            {
                try
                {
                    return BlockMaliciousPatientButtonDisplayed();
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

        public bool BlockMaliciousPatientButtonDisplayed()
        {
            return BlockMaliciousPatientButton.Displayed;
        }
 

        public void ClickBlockMaliciousPatientButton()
        {
            BlockMaliciousPatientButton.Click();
        }

        public int PatientsForBlockingCount()
        {
            return PatientsForBlocking.Count;
        }

        public void WaitForAlertDialog()
        {
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 20));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.AlertIsPresent());
        }

        public void ResolveAlertDialog()
        {
            driver.SwitchTo().Alert().Accept();
        }

        public void Navigate() => driver.Navigate().GoToUrl(URI);
    }
}
