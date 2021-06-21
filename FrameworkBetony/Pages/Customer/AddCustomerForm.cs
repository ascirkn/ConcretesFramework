using FrameworkBetony.Model;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace FrameworkBetony.Pages.AddCustomerForm
{
    class AddCustomerForm : BasePage
    {
        public AddCustomerForm(IWebDriver driver, WebDriverWait wait) : base(driver, wait) { }
        private IWebElement companyName => driver.FindElement(By.Id("mat-input-6"));
        private IWebElement shortCompanyName => driver.FindElement(By.Id("mat-input-7"));
        private IWebElement nip => driver.FindElement(By.Id("mat-input-9"));
        private IWebElement city => driver.FindElement(By.Id("mat-input-1"));
        private IWebElement address => driver.FindElement(By.Id("mat-input-2")); 
        private IWebElement postalCode => driver.FindElement(By.Id("mat-input-3"));
        private IWebElement number => driver.FindElement(By.Id("mat-input-4"));
        private IWebElement merchantLimit => driver.FindElement(By.Id("mat-input-5"));
        private IWebElement SaveButton => wait.Until(ElementToBeClickable(By.XPath("//*[@class='btn btn-success ng-star-inserted']")));
        private IWebElement UniqueShortcut => driver.FindElement(By.XPath("/html/body/app-maestro-app/app-authorised-layout/div/mat-sidenav-container/mat-sidenav-content/div[2]/app-customer-add/div/div/div/mat-card/mat-card-content/form/mat-accordion/mat-expansion-panel/div/div/div[1]/div[3]/mat-form-field/div/div[1]/div/input"));
        private IWebElement customersPage => wait.Until(ElementToBeClickable(By.XPath("//a[@href='#/authorised/customers/catalog']")));
        private IWebElement addCustomerButton => wait.Until(ElementToBeClickable(By.XPath("//*[@class='btn btn-primary']")));
        internal IWebElement actualResult => wait.Until(ElementIsVisible(By.XPath("//*[@class='mat-cell cdk-cell cdk-column-companyFullName mat-column-companyFullName ng-star-inserted' and contains(text(),'firmaAnn')]")));
        private IWebElement typePhysical => wait.Until(ElementToBeClickable(By.XPath("//*[@class='mat-radio-outer-circle' and contains(text(),'Fizyczna')]")));
        private IWebElement typeCompany => wait.Until(ElementToBeClickable(By.XPath("//*[@class='mat-radio-outer-circle' and contains(text(),'Firma')]")));
        private IWebElement typeBricklayer => wait.Until(ElementToBeClickable(By.XPath("//*[@class='mat-radio-outer-circle' and contains(text(),'Murarz')]")));
        internal void FillOutForm(Model.Customer customer)
        {
            companyName.SendKeys(customer.companyName);
            shortCompanyName.SendKeys(customer.shortCompanyName);
            UniqueShortcut.SendKeys(customer.UniqueShortcut);
            nip.SendKeys(customer.nip);
            city.SendKeys(customer.city);
            address.SendKeys(customer.address);
            postalCode.SendKeys(customer.postalCode);
            number.SendKeys(customer.number);
            merchantLimit.SendKeys(customer.merchantLimit);

            switch (customer.PersonType)
            {
                case Person.Fizyczna:
                    typePhysical.Click();
                    break;
                case Person.Firma:
                    typeCompany.Click();
                    break;
                case Person.Murarz:
                    typeBricklayer.Click();
                    break;
            }

            wait.Until(ElementToBeClickable(SaveButton)).Click();
        }
        internal void goToCustomersAndAddCustomer()
        {
            customersPage.Click();
            addCustomerButton.Click();
        }
        internal void expandRecords()
        {
            wait.Until(ElementToBeClickable(By.XPath("/html/body/app-maestro-app/app-authorised-layout/div/mat-sidenav-container/mat-sidenav-content/div[2]/app-customers-catalog/div/div/div/mat-card/mat-card-content/app-mat-table/div[2]/mat-paginator/div/div/div[1]/mat-form-field/div/div[1]/div/mat-select/div/div[1]"))).Click();
            wait.Until(ElementToBeClickable(By.XPath("//*[@class='mat-option-text' and contains(text(),'100')]"))).Click();
        }
        internal bool isAdded(string query)
        {
            IWebElement q = wait.Until(ElementIsVisible(By.XPath("//span[contains(text(), '"+query+"')]")));
            if (q.Displayed)
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