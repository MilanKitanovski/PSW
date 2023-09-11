using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Collections.ObjectModel;

namespace HospitalAppTests.EndToEndTest.Pages
{
    public class SuspiciousUsersPage
    {
        
        private readonly IWebDriver driver;
        public const string URI = @"http://localhost:4200/suspiciousUsers";

        public void Navigate() => driver.Navigate().GoToUrl(URI);

        private IWebElement Table => driver.FindElement(By.Id("table"));

        private ReadOnlyCollection<IWebElement> Rows =>
         Table.FindElements(By.TagName("tr"));


        private IWebElement BlockButton;
        private IWebElement UnblockButton;


        public SuspiciousUsersPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void EnsurePageIsDisplayed()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(3));
            wait.Until(condition =>
            {
                try
                {
                    return Rows.Count > 1;
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

        public void WaitingPeriod()
        {
            Thread.Sleep(2000);
        }

        public void UserBlocking(string userToBlock)
        {
            EnsurePageIsDisplayed();
            var Row = -1;
            for (int i = 1; i < Rows.Count; i++)
            {
                var td = Rows[i].FindElements(By.TagName("td"))[0];
                var text = td.Text;
                if (!text.Equals(userToBlock)) continue;
                Row = i;
                break;
            }
            if (Row == -1) return;
            var blockButton = Rows[Row].FindElements(By.Id("block"))[0];
            blockButton.Click();
        }

        public bool IsUserBlocked(string userToBlock)
        {
            EnsurePageIsDisplayed();
            for (var i = 1; i < Rows.Count; i++)
            {
                var td = Rows[i].FindElements(By.TagName("td"))[0];
                var text = td.Text;
                if (!text.Equals(userToBlock)) continue;

                var blockField = Rows[i].FindElements(By.TagName("td"))[2];
                var textBlocked = blockField.Text;
                var nesto = textBlocked.Equals("true");
                return nesto;


            }
            return false;
        }

        public void UnblockUser(string userToUnblock)
        {
            EnsurePageIsDisplayed();
            var Row = -1;
            for (int i = 1; i < Rows.Count; i++)
            {
                var td = Rows[i].FindElements(By.TagName("td"))[0];
                var text = td.Text;
                if (!text.Equals(userToUnblock)) continue;
                Row = i;
                break;
            }
            if (Row == -1) return;
            var unblockButton = Rows[Row].FindElements(By.Id("unblock"))[0];
            unblockButton.Click();
        }

    }
}
