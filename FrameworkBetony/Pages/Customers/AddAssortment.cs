using FrameworkBetony.Model.Customer;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace FrameworkBetony.Pages.Customers
{
    class AddAssortment : BasePage
    {
        public AddAssortment(IWebDriver driver, WebDriverWait wait) : base(driver, wait) { }
        private IWebElement openProduct => wait.Until(ElementToBeClickable(By.XPath("//*[@class='mat-select-placeholder ng-tns-c214-104 ng-star-inserted']")));
        private IWebElement Naturalne => wait.Until(ElementToBeClickable(By.XPath("//*[@class='mat-option-text' and contains(text(),'Naturalne')]")));
        private IWebElement B450 => wait.Until(ElementToBeClickable(By.XPath("//*[@class='mat-option-text' and contains(text(),'B450')]")));
        private IWebElement Piach => wait.Until(ElementToBeClickable(By.XPath("//*[@class='mat-option-text' and contains(text(),'Piach')]")));
        private IWebElement nameField => driver.FindElement(By.Id("mat-input-1"));
        private IWebElement openType => wait.Until(ElementToBeClickable(By.XPath("//*[@class='mat-select-trigger ng-tns-c214-106']")));
        private IWebElement Beton => wait.Until(ElementToBeClickable(By.XPath("//*[@class='mat-option-text' and contains(text(),'Beton')]")));
        private IWebElement ZwirPiasek => wait.Until(ElementToBeClickable(By.XPath("//*[@class='mat-option-text' and contains(text(),'Żwir/Piasek')]")));
        private IWebElement Unit => driver.FindElement(By.Id("mat-input-2"));
        private IWebElement UnitPrice => driver.FindElement(By.Id("mat-input-3"));
        private IWebElement Save => wait.Until(ElementToBeClickable(By.XPath("//*[@class='btn btn-success ng-star-inserted']")));
        private IWebElement customersPage => wait.Until(ElementToBeClickable(By.XPath("//a[@href='#/authorised/customers/catalog']")));
        private IWebElement GoToProducts => wait.Until(ElementToBeClickable(By.XPath("//a[@href='#/authorised/items/catalog']")));
        private IWebElement NumOfSite => wait.Until(ElementToBeClickable(By.XPath("//*[@class='mat-paginator-range-label']")));

        internal void FillOutForm(Customer customer)
        {
            openProduct.Click();
            switch (customer.ProductType)
            {
                case Product.Naturalne:
                    Naturalne.Click();
                    break;
                case Product.B450:
                    B450.Click();
                    break;
                case Product.Piach:
                    Piach.Click();
                    break;
            }
            nameField.Clear();
            nameField.SendKeys(customer.nameField);

            openType.Click();
            switch (customer.TypeType)
            {
                case Model.Customer.Type.Beton:
                    Beton.Click();
                    break;
                case Model.Customer.Type.ŻwirPiasek:
                    ZwirPiasek.Click();
                    break;
            }
            Unit.Clear();
            Unit.SendKeys(customer.Unit);
            UnitPrice.SendKeys(customer.UnitPrice);
            Save.Click();
        }
        internal void GoToCustomersAndAddAssortment(string customer)
        {
            customersPage.Click();
            IWebElement query = wait.Until(ElementToBeClickable(By.XPath("//*[@class = 'mat-cell cdk-cell cdk-column-companyFullName mat-column-companyFullName ng-star-inserted']//span[contains (text(),'" + customer + "')]/parent::td[@class='mat-cell cdk-cell cdk-column-companyFullName mat-column-companyFullName ng-star-inserted']//following-sibling::td[@class='mat-cell cdk-cell cdk-column-actions mat-column-actions ng-star-inserted']//mat-icon[@class='mat-icon notranslate material-icons mat-icon-no-color']")));
            query.Click();

        }
        internal void AssertProductsAreVisible(string productName)

        { 
            GoToProducts.Click();
            string NumberOfSite = NumOfSite.Text;
            string FirstOf1 = "Strona 1 z 1";
            if (NumOfSite.Text == "Strona 1 z 1")
            {
            wait.Until(ElementToBeClickable(By.XPath("//*[@class='mat-select-arrow ng-tns-c214-129']"))).Click();
            wait.Until(ElementToBeClickable(By.XPath("//*[@class='mat-option-text' and contains(text(),'100')]"))).Click();
            }
            else
            {
                wait.Until(ElementToBeClickable(By.XPath("//*[@class='mat-select-arrow ng-tns-c214-129']"))).Click();
            }

        IWebElement query = wait.Until(ElementToBeClickable(By.XPath("//*[@class = 'mat-cell cdk-cell cdk-column-name mat-column-name ng-star-inserted']//span[contains (text(),'"+productName+"')]/parent::td[@class='mat-row cdk-row ng-star-inserted']//following-sibling::td[@class='mat-cell cdk-cell cdk-column-actions mat-column-actions ng-star-inserted']//mat-icon[@class='mat-icon notranslate green material-icons mat-icon-no-color']")));
            query.Click();




        }

    }
}
