using HospitalAppTests.EndToEndTest.Pages;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;

namespace HospitalAppTests.EndToEndTest.Tests
{
    public class LoginTest : IDisposable
    {
        private IWebDriver driver;
        private LoginPage loginPage;

        public LoginTest()
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


            loginPage = new LoginPage(driver);      // create ProductsPage
            loginPage.Navigate();
        }


        public void Dispose()
        {
            driver.Quit();
            driver.Dispose();
        }

       
    }
}
