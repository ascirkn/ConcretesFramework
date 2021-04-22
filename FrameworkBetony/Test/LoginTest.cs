using FrameworkBetony.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace FrameworkBetony.Test
{
    [TestClass]
    [TestCategory("Login")]
    public class LoginTest : BaseTest
    {
        [TestMethod]
        public void LoginCorrectData()
        {

            var loginPage = new LoginPage(driver, wait);
            loginPage.GoTo();
            loginPage.SignUp(myLogin, myPassword);

            Assert.IsTrue(loginPage.isDisplayed, "isn't");
        }
        public void LoginIncorrectData()
        {

        }
    }
}