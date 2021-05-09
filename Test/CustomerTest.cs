using FrameworkBetony.Model;
using FrameworkBetony.Pages;
using FrameworkBetony.Pages.AddCustomerForm;
using FrameworkBetony.Pages.Customer;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FrameworkBetony.Test
{
    [TestClass]
    [TestCategory("Customer")]
    public class CustomerTest : BaseTest
    {
        internal static Customer customer = new Customer
        {
            companyName = "firmaAnnn",
            shortCompanyName = "Annn",
            nip = "9514498124",
            UniqueShortcut = "ZzzzZ",
            city = "Kielce",
            address = "Kielecka 33/3",
            postalCode = "25-331",
            number = "762163432",
            merchantLimit = "2"
        };
        internal static Customer NewCustomer = new Customer
        {
            companyName = "NowaFirma123",
            shortCompanyName = "FirNowa123",
            nip = "9516962353",
            UniqueShortcut = "poqwe",
            city = "Kielce",
            address = "Kielecka 43/3",
            postalCode = "25-231",
            number = "762663433",
            merchantLimit = "1"
        };
        [TestMethod]
        [Description("Checks if new customer is added.")]
        public void AddCustomer()
        {
            var loginPage = new LoginPage(driver, wait);
            loginPage.GoTo();
            loginPage.SignUp(myLogin, myPassword);

            var customersPage = new AddCustomerForm(driver, wait);
            customersPage.goToCustomersAndAddCustomer();
            customersPage.FillOutForm(customer);

            customersPage.expandRecords();
            bool isAdded = customersPage.isAdded(customer.companyName);
            Assert.IsTrue(isAdded, "Customer isn't avaliable.");


        }
        [TestMethod]
        [Description("Checks if customer is edited.")]
        public void EditCustomer()
        {
            var loginPage = new LoginPage(driver, wait);
            loginPage.GoTo();
            loginPage.SignUp(myLogin, myPassword);

            var customersPage = new EditCustomerForm(driver, wait);
            customersPage.EditCustomer("firmaAn");
            customersPage.FillOutForm(NewCustomer);
            customersPage.search(NewCustomer.companyName);

            bool isEdited = customersPage.isCustomerEdited(NewCustomer.companyName);
            Assert.IsTrue(isEdited, "Customer isn't edited.");
        }

    }
}