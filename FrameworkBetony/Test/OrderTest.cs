using FrameworkBetony.Model;
using FrameworkBetony.Model.Order;
using FrameworkBetony.Pages;
using FrameworkBetony.Pages.Order;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FrameworkBetony.Test
{
    [TestClass]
    [TestCategory("Order")]
    public class OrderTest : BaseTest
    {
        internal static Order order = new Order
        {
            amount = "2",
            netPrice = "5",
            price = "5",
            customer = "P zxc",
            PaymentMethod = Payment.Gotowka,
            MerchandiseType = Merchandise.Naturalne
        };
        internal static Order status = new Order
        {
            StatusType = Status.Oferta
        };
        [TestMethod]
        [Description("Checks if new order is added.")]
        public void AddOrder()
        {
            var loginPage = new LoginPage(driver, wait);
            loginPage.GoTo();
            loginPage.SignUp(myLogin, myPassword);

            var ordersPage = new AddOrder(driver, wait);
            ordersPage.CreateNewOrder();
            ordersPage.FillOutForm(order);
            Assert.IsTrue(ordersPage.isDisplayed, "Orders page is not ");
        }
        [TestMethod]
        [Description("Checks if status is changed.")]
        public void ChangeStatus()
        {
            var loginPage = new LoginPage(driver, wait);
            loginPage.GoTo();
            loginPage.SignUp(myLogin, myPassword);

            var ChangeOrderPage = new ChangeOrderStatus(driver, wait);
            ChangeOrderPage.GoToOrders();
            ChangeOrderPage.ChooseStatus(status);

        }
    }
}
