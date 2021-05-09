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
        [Description("Checks if user has logged in.")]
        public void LoginCorrectData()
        {
          
            var loginPage = new LoginPage(driver, wait);
            loginPage.GoTo();
            loginPage.SignUp(myLogin, myPassword);

            Assert.IsTrue(loginPage.isDisplayed, "isn't");
        }
        [TestMethod]
        [Description("Checks if user has not logged in.")]
        public void LoginIncorrectData()
        {

            var loginPage = new LoginPage(driver, wait);
            loginPage.GoTo();
            loginPage.SignUp("zxcv.vcxz", myPassword);
            var Error = loginPage.IsErrorDisplayed();

            Assert.IsTrue(Error, "Logged In with invalid data.");
        }

    }
}
