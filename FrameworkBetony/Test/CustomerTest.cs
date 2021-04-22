using FrameworkBetony.Model.Customer;
using FrameworkBetony.Pages;
using FrameworkBetony.Pages.AddCustomerForm;
using FrameworkBetony.Pages.Customers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            city = "Kielce",
            address = "Kielecka 33/3",
            postalCode = "25-331",
            number = "762163432",
            merchantLimit = "2"
        };
        internal static Customer customerProduct = new Customer
        {
            ProductType = Product.Naturalne,
            nameField = "firmaAn",
            TypeType = Model.Customer.Type.ŻwirPiasek,
            Unit = "m2",
            UnitPrice = "230"

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
        [Description("Check if new product is added.")]
        public void AddProduct()
        {
            var loginPage = new LoginPage(driver, wait);
            loginPage.GoTo();
            loginPage.SignUp(myLogin, myPassword);

            var customersPage = new AddAssortment(driver, wait);
            customersPage.GoToCustomersAndAddAssortment(customerProduct.nameField);
            customersPage.FillOutForm(customerProduct);
            //driver.FindElement(By.XPath("//*[@class = 'mat-cell cdk-cell cdk-column-companyFullName mat-column-companyFullName ng-star-inserted']//span[contains (text(),'firmaAn')]//following::sibling::td[@class='mat-cell cdk-cell cdk-column-actions mat-column-actions ng-star-inserted']"));
            customersPage.AssertProductsAreVisible(customerProduct.nameField);

            //bool isAdded = customersPage.isAdded(ania.email);
           // Assert.IsTrue(isAdded, "User isn't avaliable.");

        }


    }
}