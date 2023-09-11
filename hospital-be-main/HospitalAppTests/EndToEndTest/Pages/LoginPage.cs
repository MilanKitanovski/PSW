using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalAppTests.EndToEndTest.Pages
{
    public class LoginPage
    {
        private readonly IWebDriver driver;
        public readonly string URI = @"http://localhost:4200/login";

        private IWebElement EmailInput => driver.FindElement(By.Id("email"));
        private IWebElement PasswordInput => driver.FindElement(By.Id("password"));
        private IWebElement LoginButton => driver.FindElement(By.Id("loginButton"));

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void EnterEmailAndPassword(string email, string password)
        {
            EmailInput.SendKeys(email);
            PasswordInput.SendKeys(password);
        }

        public void PressLoginButton()
        {
            LoginButton.Click();
        }

        public void Navigate() => driver.Navigate().GoToUrl(URI);

    }
}
