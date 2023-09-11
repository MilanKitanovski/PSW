using HospitalAppTests.EndToEndTest.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalAppTests.EndToEndTest.Tests
{
    public class SuspiciousUserTest
    {
        private IWebDriver driver;

        private LoginPage loginPage;
        private SuspiciousUsersPage suspiciousUserPage;

        public SuspiciousUserTest()
        {
            Login();
            suspiciousUserPage = new SuspiciousUsersPage(driver);
            suspiciousUserPage.Navigate();
            suspiciousUserPage.EnsurePageIsDisplayed();
            Assert.Equal(driver.Url, SuspiciousUsersPage.URI);

        }
        private ChromeOptions GetOptions()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("start-maximized");
            options.AddArguments("disable-infobars");
            options.AddArguments("--disable-extensions");
            options.AddArguments("--disable-gpu");
            options.AddArguments("--disable-dev-shm-usage");
            options.AddArguments("--no-sandbox");
            options.AddArguments("--disable-notifications");

            return options;
        }

        private void Login()
        {
            driver = new ChromeDriver(GetOptions());
            loginPage = new LoginPage(driver);
            loginPage.Navigate();
            loginPage.EnterEmailAndPassword("admin@gmail.com", "Admin");
            loginPage.PressLoginButton();
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(driver => driver.Url != loginPage.URI);
        }


        [Fact]
        public void BlockingUser()
        {
            suspiciousUserPage.UserBlocking("blockUser");
            suspiciousUserPage.WaitingPeriod();
            var isBlocked = suspiciousUserPage.IsUserBlocked("blockUser");
            isBlocked.ShouldBe(false);
        }

        [Fact]
        public void UnblockingUser()
        {
            suspiciousUserPage.UnblockUser("unblockUser");
            suspiciousUserPage.WaitingPeriod();
            var isBlocked = suspiciousUserPage.IsUserBlocked("unblockUser");
            isBlocked.ShouldBe(false);
        }

    }
}
