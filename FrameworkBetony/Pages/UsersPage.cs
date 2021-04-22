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
    class UsersPage : BasePage
    {
        internal UsersPage(IWebDriver driver, WebDriverWait wait) : base(driver, wait) { }
        private IWebElement Users => wait.Until(ElementToBeClickable(By.XPath("//a[@href='#/authorised/employees/catalog']")));
        private IWebElement AddUser => wait.Until(ElementToBeClickable(By.XPath("//*[@class='btn btn-primary']")));

        internal void GoToAddUser()
        {
            Users.Click();
            AddUser.Click();
        }


    }
}