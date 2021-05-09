using FrameworkBetony.Model;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace FrameworkBetony.Pages.Customer
{
    class EditCustomerForm : BasePage
    {
        public EditCustomerForm(IWebDriver driver, WebDriverWait wait) : base(driver, wait) { }
        private IWebElement companyName => driver.FindElement(By.XPath("/html/body/app-maestro-app/app-authorised-layout/div/mat-sidenav-container/mat-sidenav-content/div[2]/app-customer-add/div/div/div/mat-card[1]/mat-card-content/form/mat-accordion/mat-expansion-panel/div/div/div[1]/div[1]/mat-form-field/div/div[1]/div/input"));
        private IWebElement shortCompanyName => driver.FindElement(By.XPath("/html/body/app-maestro-app/app-authorised-layout/div/mat-sidenav-container/mat-sidenav-content/div[2]/app-customer-add/div/div/div/mat-card[1]/mat-card-content/form/mat-accordion/mat-expansion-panel/div/div/div[1]/div[2]/mat-form-field/div/div[1]/div/input"));
        private IWebElement nip => driver.FindElement(By.Id("mat-input-9"));
        private IWebElement city => driver.FindElement(By.Id("mat-input-1"));
        private IWebElement address => driver.FindElement(By.Id("mat-input-2"));
        private IWebElement postalCode => driver.FindElement(By.Id("mat-input-3"));
        private IWebElement number => driver.FindElement(By.Id("mat-input-4"));
        private IWebElement merchantLimit => driver.FindElement(By.Id("mat-input-5"));
        private IWebElement SaveButton => wait.Until(ElementToBeClickable(By.XPath("//*[@class='btn btn-success ng-star-inserted']")));
        private IWebElement UniqueShortcut => driver.FindElement(By.XPath("/html/body/app-maestro-app/app-authorised-layout/div/mat-sidenav-container/mat-sidenav-content/div[2]/app-customer-add/div/div/div/mat-card[1]/mat-card-content/form/mat-accordion/mat-expansion-panel/div/div/div[1]/div[3]/mat-form-field/div/div[1]/div/input"));
        private IWebElement customersPage => wait.Until(ElementToBeClickable(By.XPath("//a[@href='#/authorised/customers/catalog']")));
        private IWebElement EditCustomerButton => wait.Until(ElementToBeClickable(By.XPath("//*[@class='btn btn-primary']")));
        internal IWebElement actualResult => wait.Until(ElementIsVisible(By.XPath("//*[@class='mat-cell cdk-cell cdk-column-companyFullName mat-column-companyFullName ng-star-inserted' and contains(text(),'firmaAnn')]")));
        private IWebElement SearchInput => wait.Until(ElementToBeClickable(By.XPath("/html/body/app-maestro-app/app-authorised-layout/div/mat-sidenav-container/mat-sidenav-content/div[2]/app-customers-catalog/div/div/div/mat-card/mat-card-subtitle/mat-form-field/div/div[1]/div[2]/input")));


        internal void FillOutForm(Model.Customer customer)
        {
            companyName.Clear();
            companyName.SendKeys(customer.companyName);
            shortCompanyName.Clear();
            shortCompanyName.SendKeys(customer.shortCompanyName);
            UniqueShortcut.Clear();
            UniqueShortcut.SendKeys(customer.UniqueShortcut);
            nip.Clear();
            nip.SendKeys(customer.nip);
            city.Clear();
            city.SendKeys(customer.city);
            address.Clear();
            address.SendKeys(customer.address);
            postalCode.Clear();
            postalCode.SendKeys(customer.postalCode);
            number.Clear();
            number.SendKeys(customer.number);
            merchantLimit.Clear();
            merchantLimit.SendKeys(customer.merchantLimit);
            SaveButton.Click();
        }
        internal void EditCustomer(string EditQuery)
        {
            customersPage.Click();
            IWebElement query = wait.Until(ElementToBeClickable(By.XPath("//*[@class='mat-cell cdk-cell cdk-column-companyFullName mat-column-companyFullName ng-star-inserted']//span[contains(text(),'"+ EditQuery +"')]//ancestor::td[@class='mat-cell cdk-cell cdk-column-companyFullName mat-column-companyFullName ng-star-inserted']//following-sibling::td[@class='mat-cell cdk-cell cdk-column-actions mat-column-actions ng-star-inserted']//mat-icon[@class='mat-icon notranslate green material-icons mat-icon-no-color']")));
            query.Click();
        }
        internal void search(string query)
        {
            SearchInput.Clear();
            SearchInput.Click();
            SearchInput.SendKeys(query);
        }
        internal bool isCustomerEdited(string EditQuery)
        {
            IWebElement query = driver.FindElement(By.XPath("//*[@class='mat-cell cdk-cell cdk-column-companyFullName mat-column-companyFullName ng-star-inserted']//span[contains(text(),'" + EditQuery + "')]"));
            if (query.Displayed)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

}
