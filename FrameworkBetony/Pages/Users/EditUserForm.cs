using FrameworkBetony.Model;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace FrameworkBetony.Pages
{
    class EditUserForm : BasePage
    {
        public EditUserForm(IWebDriver driver, WebDriverWait wait) : base(driver, wait) { }

        private IWebElement nameField => driver.FindElement(By.Id("mat-input-1"));
        private IWebElement FirstNameField => driver.FindElement(By.Id("mat-input-2"));
        private IWebElement secondNameField => driver.FindElement(By.Id("mat-input-3"));
        private IWebElement email => driver.FindElement(By.Id("mat-input-4"));
        private IWebElement number => driver.FindElement(By.Id("mat-input-5"));
        private IWebElement roles => wait.Until(ElementToBeClickable(By.XPath("//*[@class='mat-select-trigger ng-tns-c214-106']")));
        private IWebElement choosenNode => wait.Until(ElementToBeClickable(By.XPath("//*[@class='mat-option mat-focus-indicator ng-tns-c214-103 ng-star-inserted']")));
        private IWebElement Users => wait.Until(ElementToBeClickable(By.XPath("//a[@href='#/authorised/employees/catalog']")));
        private IWebElement editButton => wait.Until(ElementToBeClickable(By.XPath("//*[@class='mat-icon notranslate green material-icons mat-icon-no-color']")));
        private IWebElement SaveEditedUser => wait.Until(ElementToBeClickable(By.XPath("//*[@class='btn btn-success']")));
        private IWebElement editPassword => wait.Until(ElementToBeClickable(By.XPath("//*[@class='btn btn-primary ng-star-inserted']")));
        private IWebElement PasswordField => wait.Until(ElementIsVisible(By.Id("mat-input-6")));
        private IWebElement RePasswordField => wait.Until(ElementIsVisible(By.Id("mat-input-7")));
        //private IWebElement ConfirmNewPassword => wait.Until(ElementIsVisible(By.XPath("//*[@class='ng-dirty ng-touched ng-valid']//div[@class='form-actions']//button[@class='btn btn-success']")));
        private IWebElement ConfirmNewPassword => wait.Until(ElementToBeClickable(By.XPath("/html/body/div[2]/div[2]/div/mat-dialog-container/app-employee-reset-password/mat-card-content/form/div[2]/button")));
        private IWebElement ContinueWhileEditPass => wait.Until(ElementToBeClickable(By.XPath("//*[@class='mat-button-wrapper' and contains(text(),'Kontynuuj')]")));
        internal IWebElement PasswordEditedSuccessfully => wait.Until(ElementIsVisible(By.Id("mat-dialog-title-0")));
        private IWebElement SearchInput => wait.Until(ElementToBeClickable(By.XPath("/html/body/app-maestro-app/app-authorised-layout/div/mat-sidenav-container/mat-sidenav-content/div[2]/app-employees-catalog/div/div/div/mat-card/mat-card-subtitle/mat-form-field/div/div[1]/div[2]/input")));
        private IWebElement enterNodeField => wait.Until(ElementToBeClickable(By.XPath("//*[@class='mat-select-trigger ng-tns-c214-104']")));
        private IWebElement BETONIARNIA => wait.Until(ElementToBeClickable(By.XPath("//*[@class='mat-option-text' and contains(text(),'BETONIARNIA')]")));
        private IWebElement BETONIARNIA2 => wait.Until(ElementToBeClickable(By.XPath("//*[@class='mat-option-text' and contains(text(),'BETONIARNIA2')]")));
        private IWebElement BETONIARNIA3 => wait.Until(ElementToBeClickable(By.XPath("//*[@class='mat-option-text' and contains(text(),'BETONIARNIA3')]")));
        private IWebElement ZWIROWNIA => wait.Until(ElementToBeClickable(By.XPath("//*[@class='mat-option-text' and contains(text(),'ŻWIROWNIA')]")));
        private IWebElement ZWIROWNIA2 => wait.Until(ElementToBeClickable(By.XPath("//*[@class='mat-option-text' and contains(text(),'ŻWIROWNIA2')]")));
        private IWebElement SuperUser => wait.Until(ElementToBeClickable(By.XPath("//*[@class='mat-option-text' and contains(text(),'SuperUser')]")));
        private IWebElement Ladowacz => wait.Until(ElementToBeClickable(By.XPath("//*[@class='mat-option-text' and contains(text(),'Ładowacz')]")));
        private IWebElement Logistyk => wait.Until(ElementToBeClickable(By.XPath("//*[@class='mat-option-text' and contains(text(),'Logistyk')]")));
        private IWebElement KierowcaZewnetrzny => wait.Until(ElementToBeClickable(By.XPath("//*[@class='mat-option-text' and contains(text(),'KierowcaZewnętrzny')]")));
        private IWebElement SuperSprzedawca => wait.Until(ElementToBeClickable(By.XPath("//*[@class='mat-option-text' and contains(text(),'SuperSprzedawca')]")));
        private IWebElement Kierowca => wait.Until(ElementToBeClickable(By.XPath("//*[@class='mat-option-text' and contains(text(),'Kierowca')]")));
        private IWebElement Sprzedawca => wait.Until(ElementToBeClickable(By.XPath("//*[@class='mat-option-text' and contains(text(),'Sprzedawca')]")));
        private IWebElement Wezlowy => wait.Until(ElementToBeClickable(By.XPath("//*[@class='mat-option-text' and contains(text(),'Węzłowy')]")));
        internal void editUser()
        {
            editButton.Click();
        }
        internal void editUserr(string EditQuery)
        {
            IWebElement query = wait.Until(ElementToBeClickable(By.XPath("//*[@class='mat-row cdk-row ng-star-inserted']//td[@class = 'mat-cell cdk-cell cdk-column-email mat-column-email ng-star-inserted' and contains(text(),'" + EditQuery + "')]//following-sibling::td[@class = 'mat-cell cdk-cell cdk-column-actions mat-column-actions ng-star-inserted']//mat-icon[@class = 'mat-icon notranslate green material-icons mat-icon-no-color']")));
            query.Click();

        }
        internal void reFillOutForm(User user)
        {
            nameField.Clear();
            nameField.SendKeys(user.nameField);
            FirstNameField.Clear();
            FirstNameField.SendKeys(user.FirstNameField);
            secondNameField.Clear();
            secondNameField.SendKeys(user.secondNameField);
            email.Clear();
            email.SendKeys(user.email);
            number.Clear();
            number.SendKeys(user.number);
            roles.Click();
            switch (user.RoleType)
            {
                case Role.SuperUser:
                    SuperUser.Click();
                    break;
                case Role.Ładowacz:
                    Ladowacz.Click();
                    break;
                case Role.Logistyk:
                    Logistyk.Click();
                    break;
                case Role.KierowcaZewnętrzny:
                    KierowcaZewnetrzny.Click();
                    break;
                case Role.SuperSprzedawca:
                    SuperSprzedawca.Click();
                    break;
                case Role.Kierowca:
                    Kierowca.Click();
                    break;
                case Role.Sprzedawca:
                    Sprzedawca.Click();
                    break;
                case Role.Węzłowy:
                    Wezlowy.Click();
                    break;
            }
            Actions actionProvider = new Actions(driver);
            actionProvider.SendKeys(Keys.Escape).Perform();
            enterNodeField.Click();
            switch (user.NodeType)
            {
                case Node.BETONIARNIA:
                    BETONIARNIA.Click();
                    break;
                case Node.BETONIARNIA2:
                    BETONIARNIA2.Click();
                    break;
                case Node.BETONIARNIA3:
                    BETONIARNIA3.Click();
                    break;
                case Node.ŻWIROWNIA:
                    ZWIROWNIA.Click();
                    break;
                case Node.ŻWIROWNIA2:
                    ZWIROWNIA2.Click();
                    break;
            }
            wait.Until(ElementToBeClickable(SaveEditedUser)).Click();
            SaveEditedUser.Click();
        }
        internal void GoToUsers()
        {
            Users.Click();
        }
        internal void expandRecords()
        {
            wait.Until(ElementToBeClickable(By.XPath("//*[@class='mat-select-value-text ng-tns-c214-61 ng-star-inserted']"))).Click();
            wait.Until(ElementToBeClickable(By.XPath("//*[@class='mat-option-text' and contains(text(),'100')]"))).Click();

        }
        internal void FillOutPassword(User user)
        {
            PasswordField.SendKeys(user.password);
            RePasswordField.SendKeys(user.rePassword);
            ConfirmNewPassword.Click();
            //ContinueWhileEditPass.Click();
            //saveUser.Click();
        }
        internal void EditUserPasswordByEmail(string editQuery)
        {
            expandRecords();
            IWebElement query = wait.Until(ElementToBeClickable(By.XPath("//*[@class='mat-row cdk-row ng-star-inserted']//td[@class = 'mat-cell cdk-cell cdk-column-email mat-column-email ng-star-inserted' and contains(text(),'" + editQuery + "')]//following-sibling::td[@class = 'mat-cell cdk-cell cdk-column-actions mat-column-actions ng-star-inserted']//mat-icon[@class = 'mat-icon notranslate green material-icons mat-icon-no-color']")));
            query.Click();
            editPassword.Click();
        }
        internal bool isUserEdited(string editQuery)
        {
            IWebElement query = wait.Until(ElementIsVisible(By.XPath("//*[@class='mat-row cdk-row ng-star-inserted']//td[@class = 'mat-cell cdk-cell cdk-column-email mat-column-email ng-star-inserted' and contains(text(),'" + editQuery + "')]")));
            if (query.Displayed)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        internal void search(string query)
        {
            wait.Until(ElementToBeClickable(SearchInput)).Click();
            SearchInput.Clear();
            SearchInput.SendKeys(query);
        }
    }
}