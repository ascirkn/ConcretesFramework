using FrameworkBetony.Model.Order;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace FrameworkBetony.Pages.Order
{
    class AddOrder : BasePage
    {
        public AddOrder(IWebDriver driver, WebDriverWait wait) : base(driver, wait) { }
        private IWebElement amount => driver.FindElement(By.Id("mat-input-8"));
        private IWebElement netPrice => driver.FindElement(By.Id("mat-input-9"));
        private IWebElement price => driver.FindElement(By.Id("mat-input-3"));
        private IWebElement Orders => wait.Until(ElementToBeClickable(By.XPath("//a[@href='#/authorised/orders/catalog']")));
        private IWebElement GotoAddOrder => wait.Until(ElementToBeClickable(By.XPath("/html/body/app-maestro-app/app-authorised-layout/div/mat-sidenav-container/mat-sidenav-content/div[2]/app-orders-catalog/div/div/div/mat-card/mat-card-subtitle/div/div[3]/button")));
        private IWebElement customer => wait.Until(ElementToBeClickable(By.Id("mat-input-7")));
        private IWebElement chooseCustomer => wait.Until(ElementToBeClickable(By.XPath("//*[@class='mat-option-text' and contains(text(),' P zxc NIP: ; Nr tel: 888552241;  ')]")));
        private IWebElement Address => wait.Until(ElementToBeClickable(By.XPath("/html/body/div[3]/div[2]/div/mat-dialog-container/app-gravel-pit-order-form/form/div/div[2]/div[1]/div/app-gravel-pit-order/mat-card/div/div[2]/div/table/tr/td/mat-form-field/div/div[1]/div[1]/input")));
        private IWebElement ChooseAdress => wait.Until(ElementToBeClickable(By.XPath("//*[@class='mat-option-text' and contains(text(),' Nowa 3/3 ')]")));
        private IWebElement EnterPayment => wait.Until(ElementToBeClickable(By.Id("mat-select-3")));
        private IWebElement FakturaPrzelew => wait.Until(ElementToBeClickable(By.XPath("//*[@class='mat-option-text' and contains(text(),' Faktura - gotówka ')]")));
        private IWebElement Gotowka => wait.Until(ElementToBeClickable(By.XPath("//*[@class='mat-option-text' and contains(text(),' Gotówka ')]")));
        private IWebElement Przedplata => wait.Until(ElementToBeClickable(By.XPath("//*[@class='mat-option-text' and contains(text(),' Przedpłata ')]")));
        private IWebElement Zaplacono => wait.Until(ElementToBeClickable(By.XPath("//*[@class='mat-option-text' and contains(text(),' Zapłacono ')]")));
        private IWebElement GotowkaWKasie => wait.Until(ElementToBeClickable(By.XPath("//*[@class='mat-option-text' and contains(text(),' Gotówka w kasie ')]")));
        private IWebElement NieDotyczy => wait.Until(ElementToBeClickable(By.XPath("//*[@class='mat-option-text' and contains(text(),' Nie dotyczy ')]")));
        private IWebElement EnterMerchandise => wait.Until(ElementToBeClickable(By.Id("mat-select-4")));
        private IWebElement Naturalne => wait.Until(ElementToBeClickable(By.XPath("//*[@class='mat-option-text' and contains(text(),' Naturalne ')]")));
        private IWebElement Piasek => wait.Until(ElementToBeClickable(By.XPath("//*[@class='mat-option-text' and contains(text(),' Piasek ')]")));
        private IWebElement SaveOrder => wait.Until(ElementToBeClickable(By.XPath("//*[@class='mat-button-wrapper' and contains(text(),' Zapisz ')]")));
        internal void GoToOrders()
        {
            Orders.Click();
        }
        internal void CreateNewOrder()
        {
            Orders.Click();
            GotoAddOrder.Click();
        }
        internal void FillOutForm(Model.Order.Order order)
        { 
            amount.Clear();
            amount.SendKeys(order.amount);
            netPrice.SendKeys(order.netPrice);
            price.SendKeys(order.netPrice);
            customer.SendKeys(order.customer);
            chooseCustomer.Click();
            Address.Click();
            ChooseAdress.Click();
            EnterPayment.Click();
            switch (order.PaymentMethod)
            {
                case Payment.FakturaPrzelew:
                    FakturaPrzelew.Click();
                    break;
                case Payment.Gotowka:
                    Gotowka.Click();
                    break;
                case Payment.Przedplata:
                    Przedplata.Click();
                    break;
                case Payment.Zaplacono:
                    Zaplacono.Click();
                    break;
                case Payment.GotowkaWKasie:
                    GotowkaWKasie.Click();
                    break;
                case Payment.NieDotyczy:
                    NieDotyczy.Click();
                    break;
            }
            EnterMerchandise.Click();
            switch (order.MerchandiseType)
            {
                case Merchandise.Naturalne:
                    Naturalne.Click();
                    break;
                case Merchandise.Piasek:
                    Piasek.Click();
                    break;
            }
            SaveOrder.Click();
        }
        internal bool isDisplayed => Orders.Displayed;

    }
}
