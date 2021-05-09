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
    class ChangeOrderStatus : BasePage
    {
        public ChangeOrderStatus(IWebDriver driver, WebDriverWait wait) : base(driver, wait) { }
        private IWebElement Orders => wait.Until(ElementToBeClickable(By.XPath("//a[@href='#/authorised/orders/catalog']")));
        private IWebElement ChangeStatus => wait.Until(ElementToBeClickable(By.XPath("/html/body/app-maestro-app/app-authorised-layout/div/mat-sidenav-container/mat-sidenav-content/div[2]/app-orders-catalog/div/div/div/mat-card/mat-card-content/app-mat-table/div[1]/div/table/tbody/tr[2]/td[18]/button/span/mat-icon")));
        private IWebElement EnterStatus => wait.Until(ElementToBeClickable(By.XPath("/html/body/app-maestro-app/app-authorised-layout/div/mat-sidenav-container/mat-sidenav-content/div[2]/app-orders-catalog/div/div/div/mat-card/mat-card-content/app-mat-table/div[1]/div/table/tbody/tr[2]/td[18]/button/span/mat-icon")));
        private IWebElement Oferta => wait.Until(ElementToBeClickable(By.XPath("//*[@class='item-text' and contains(text(),'Oferta')]")));
        private IWebElement Nowe => wait.Until(ElementToBeClickable(By.XPath("//*[@class='item-text' and contains(text(),'Nowe')]")));
        private IWebElement WTrakcieProdukcji => wait.Until(ElementToBeClickable(By.XPath("//*[@class='item-text' and contains(text(),'WTrakcieProdukcji')]")));
        private IWebElement Zrealizowane => wait.Until(ElementToBeClickable(By.XPath("//*[@class='item-text' and contains(text(),'Zrealizowane')]")));
        private IWebElement Niezrealizowano => wait.Until(ElementToBeClickable(By.XPath("//*[@class='item-text' and contains(text(),'Niezrealizowano')]")));
        private IWebElement Anulowane => wait.Until(ElementToBeClickable(By.XPath("//*[@class='item-text' and contains(text(),'Anulowane')]")));
        private IWebElement ZmianaWZamowieniu => wait.Until(ElementToBeClickable(By.XPath("//*[@class='item-text' and contains(text(),'ZmianaWZamowieniu')]")));
        private IWebElement SprawdzoneWz => wait.Until(ElementToBeClickable(By.XPath("//*[@class='item-text' and contains(text(),'SprawdzoneWz')]")));
        private IWebElement Potwierdzone => wait.Until(ElementToBeClickable(By.XPath("//*[@class='item-text' and contains(text(),'Potwierdzone')]")));


        internal void GoToOrders()
        {
            Orders.Click();
        }
        internal void ChooseStatus(Model.Order.Order status)
        {
            EnterStatus.Click();
            switch (status.StatusType)
            {
                case Status.Oferta:
                    Oferta.Click();
                    break;
                case Status.Nowe:
                    Nowe.Click();
                    break;
                case Status.WTrakcieProdukcji:
                    WTrakcieProdukcji.Click();
                    break;
                case Status.Zrealizowane:
                    Zrealizowane.Click();
                    break;
                case Status.Niezrealizowano:
                    Niezrealizowano.Click();
                    break;
                case Status.Anulowane:
                    WTrakcieProdukcji.Click();
                    break;
                case Status.ZmianaWZamowieniu:
                    ZmianaWZamowieniu.Click();
                    break;
                case Status.SprawdzoneWz:
                    SprawdzoneWz.Click();
                    break;
                case Status.Potwierdzone:
                    Potwierdzone.Click();
                    break;

            }
        }
    }
}
