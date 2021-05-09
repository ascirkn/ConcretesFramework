using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace FrameworkBetony.Pages
{
    internal class LoginPage : BasePage
    {
         
        public LoginPage(IWebDriver driver, WebDriverWait wait) : base(driver, wait) { }
         
        private IWebElement UsernameField => wait.Until(ElementIsVisible(By.Id("Username")));
        private IWebElement PasswordField => wait.Until(ElementIsVisible(By.Id("Password")));
        private IWebElement Error => wait.Until(ElementIsVisible(By.XPath("//*[@class='alert alert-danger']")));
        internal void SignUp(object myLogin, object myPassword)
        {
            throw new NotImplementedException();
        }

        private IWebElement Button => driver.FindElement(By.Name("button"));

        public IWebElement logOut => wait.Until(ElementIsVisible(By.XPath("//*[@class='mr-2 align-middle' and contains(text(),'i.arabas@itmcode.pl')]")));

        public bool isDisplayed => logOut.Displayed;
        internal void SignUp(string username, string password)
        {
            UsernameField.SendKeys(username);
            PasswordField.SendKeys(password);
            Button.Click();
        }
        internal void GoTo()
        {
            driver.Navigate().GoToUrl("http://orders.devitmcode.pl");
        }
        internal bool IsErrorDisplayed()
        {
            if(Error.Displayed)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
