using FrameworkBetony.Model;
using FrameworkBetony.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;

namespace FrameworkBetony.Test
{
    [TestClass]
    [TestCategory("User")]
    public class UserTest : BaseTest
    {
        internal static User ania = new User
        {
            nameField = "ania",
            FirstNameField = "ania Bas",
            secondNameField = "zxcvz",
            email = "ania@gmail.pl",
            number = "642932123",
            NodeType = Node.BETONIARNIA,
            RoleType = Role.Węzłowy,
            password = "I.zcxv123!",
            rePassword = "I.zcxv123!"
        };

        internal static User Jan = new User
        {
            nameField = "Jan",
            FirstNameField = "Janek",
            secondNameField = "Zz",
            email = "jan@gmail.pl",
            number = "633421323",
            password = "I.zcxv123!",
            rePassword = "I.zcxv123!"
        };
        internal static User del = new User
        {
            delQuery = "ania@gmail.pl"
        };
        internal static User passwordUser = new User
        {
            password = "Zxcv123!",
            rePassword = "Zxcv123!"
        };
        [TestMethod]
        [Description("Checks if new user is added.")]
        public void AddUser()
        {
            var loginPage = new LoginPage(driver, wait);
            loginPage.GoTo();
            loginPage.SignUp(myLogin, myPassword);


            var usersPage = new AddUserForm(driver, wait);
            usersPage.GoToAddUser();
            usersPage.FillOutForm(ania);
            usersPage.search("ania@gmail.pl");

            // show 100 records and after assert areequal
            //usersPage.expandRecords();

            bool isAdded = usersPage.isAdded(ania.email);
            Assert.IsTrue(isAdded, "User isn't avaliable.");
        }
        [TestMethod]
        [Description("Checks if user is deleted.")]
        public void deleteUser()
        {
            var loginPage = new LoginPage(driver, wait);
            loginPage.GoTo();
            loginPage.SignUp(myLogin, myPassword);

            var usersPage = new AddUserForm(driver, wait);
            usersPage.GoToUsers();

            usersPage.search(ania.email);
            //usersPage.expandRecords();

            usersPage.deleteUser("ania@gmail.pl");

            bool isDeleted = usersPage.IsUserDeleted("ania@gmail.pl");
            Assert.IsTrue(isDeleted, "User is still avaliable.");
        }
        [TestMethod]
        [Description("Checks if user has been edited.")]
        public void editUser()
        {
            var loginPage = new LoginPage(driver, wait);
            loginPage.GoTo();
            loginPage.SignUp(myLogin, myPassword);

            var usersPage = new EditUserForm(driver, wait);
            usersPage.GoToUsers();
            usersPage.expandRecords();
            usersPage.editUserr(ania.email);
            usersPage.reFillOutForm(Jan);

            bool isEdited = usersPage.isUserEdited(ania.email);
            Assert.IsTrue(isEdited, "User isn't edited.");
            // assert if Jan is same as user in table

        }

        [TestMethod]
        [Description("Checks if changed password is valid.")]
        public void newPassword()
        {
            var loginPage = new LoginPage(driver, wait);
            loginPage.GoTo();
            loginPage.SignUp(myLogin, myPassword);

            var usersPage = new EditUserForm(driver, wait);
            usersPage.GoToUsers();
            usersPage.EditUserPasswordByEmail("ania@gmail.pl");
            usersPage.FillOutPassword(passwordUser);

            string expectedResult = "Hasło zostało zmienione";
            //Assert.IsTrue(usersPage.PasswordEditedSuccessfully.Displayed, "Text is not displayed.");
            Assert.AreEqual(usersPage.PasswordEditedSuccessfully.Text, expectedResult, "Password is not updated.");
        }

    }
}
