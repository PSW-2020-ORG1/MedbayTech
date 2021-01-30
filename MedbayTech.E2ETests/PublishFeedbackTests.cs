using System;
using System.Collections.Generic;
using System.Text;
using MedbayTech.E2ETests.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumEndToEnd.Pages;
using Shouldly;
using Xunit;

namespace MedbayTech.E2ETests
{
    public class PublishFeedbackTests : IDisposable
    {
        private IWebDriver _webDriver;
        private ApprovedFeedback _approvedFeedbackPage;
        private Login _loginPage;
        private AllFedback _allFeedbackPage;

        public PublishFeedbackTests()
        {
            InitializeDriver();
            _approvedFeedbackPage = new ApprovedFeedback(_webDriver);
            _loginPage = new Login(_webDriver);
            Login();

            _allFeedbackPage = new AllFedback(_webDriver);
            Assert.Equal(_webDriver.Url, AllFedback.URI_Local);
            Assert.True(_allFeedbackPage.MaliciousPatientsLinkElementDisplayed());

        }

        public void InitializeDriver()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("start-maximized");
            options.AddArguments("disable-infobars");
            options.AddArguments("--disable-extensions");
            options.AddArguments("--disable-gpu");
            options.AddArguments("--disable-dev-shm-usage");
            options.AddArguments("--no-sandbox");
            options.AddArguments("--disable-notifications");
            _webDriver = new ChromeDriver(options);
        }
        public void Dispose()
        {
            _webDriver.Quit();
            _webDriver.Dispose();
        }

        private void Login()
        {
            _loginPage.Navigate();
            Assert.Equal(_webDriver.Url, Pages.Login.URI_Local);
            Assert.True(_loginPage.UsernameElementDisplayed());
            Assert.True(_loginPage.PasswordElementDisplayed());
            Assert.True(_loginPage.SubmitButtonElementDisplayed());

            _loginPage.InsertUsername("markic");
            _loginPage.InsertPassword("marko1978");
            _loginPage.SubmitForm();
            _loginPage.WaitForAdministratorHomePage();
        }

        [Fact]
        public void Approve_feedback()
        {
            _allFeedbackPage.Navigate();
            _allFeedbackPage.EnsurePageIsDisplayed();
            int buttonsDenyBefore = _allFeedbackPage.GetCountDenyButtons;
            _allFeedbackPage.ApproveFeedback();
            _allFeedbackPage.Navigate();
            _allFeedbackPage.EnsurePageIsDisplayed();
            int buttonsDenyAfter = _allFeedbackPage.GetCountDenyButtons;
            _approvedFeedbackPage.Navigate();
            _approvedFeedbackPage.EnsurePageIsDisplayed();

            buttonsDenyAfter.ShouldBe(buttonsDenyBefore + 1);


        }

        [Fact]
        public void Deny_feedback()
        {
            _allFeedbackPage.Navigate();
            _allFeedbackPage.EnsurePageIsDisplayed();
            int buttonsApproveBefore = _allFeedbackPage.GetCountApproveButtons;
            _allFeedbackPage.DenyFeedback();
            _allFeedbackPage.Navigate();
            _allFeedbackPage.EnsurePageIsDisplayed();
            int buttonsApproveAfter = _allFeedbackPage.GetCountApproveButtons;
            _approvedFeedbackPage.Navigate();
            _approvedFeedbackPage.EnsurePageIsDisplayed();

            buttonsApproveAfter.ShouldBe(buttonsApproveBefore + 1);
        }
    }
}
