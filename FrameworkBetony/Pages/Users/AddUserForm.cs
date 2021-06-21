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

namespace FrameworkBetony.Pages
{
    internal class AddUserForm : BasePage
    {

        public AddUserForm(IWebDriver driver, WebDriverWait wait) : base(driver, wait) { }
        private IWebElement nameField => driver.FindElement(By.Id("mat-input-1"));
        private IWebElement FirstNameField => driver.FindElement(By.Id("mat-input-2"));
        private IWebElement secondNameField => driver.FindElement(By.Id("mat-input-3"));
        private IWebElement email => driver.FindElement(By.Id("mat-input-4"));
        private IWebElement number => driver.FindElement(By.Id("mat-input-5"));
        private IWebElement password => driver.FindElement(By.Id("mat-input-6"));
        private IWebElement rePassword => driver.FindElement(By.Id("mat-input-7"));


        private IWebElement roles => wait.Until(ElementToBeClickable(By.XPath("//*[@class='mat-select-placeholder ng-tns-c214-105 ng-star-inserted']")));
        private IWebElement choosenRoles => driver.FindElement(By.XPath("//*[@class='mat-pseudo-checkbox mat-option-pseudo-checkbox ng-star-inserted']"));
        private IWebElement enterNodeField => wait.Until(ElementToBeClickable(By.XPath("//*[@class='mat-select-placeholder ng-tns-c214-103 ng-star-inserted']")));
        private IWebElement choosenNode => wait.Until(ElementToBeClickable(By.XPath("//*[@class='mat-option mat-focus-indicator ng-tns-c214-103 ng-star-inserted']")));
        private IWebElement Users => wait.Until(ElementToBeClickable(By.XPath("//a[@href='#/authorised/employees/catalog']")));
        private IWebElement createUser => wait.Until(ElementToBeClickable(By.XPath("//*[@class='btn btn-primary']")));
        private IWebElement addUser => wait.Until(ElementToBeClickable(By.XPath("//*[@class='btn btn-success']")));
        internal IWebElement actualResult => wait.Until(ElementIsVisible(By.XPath("//*[@class='mat-cell cdk-cell cdk-column-email mat-column-email ng-star-inserted' and contains(text(), '" + email + "')]")));
        //private IWebElement deleteUserButton => wait.Until(ElementToBeClickable(By.XPath("//*[@class='mat-row cdk-row ng-star-inserted']//td[@class = 'mat-cell cdk-cell cdk-column-email mat-column-email ng-star-inserted' and contains(text(),'"+delQuery+"')]//following-sibling::td[@class = 'mat-cell cdk-cell cdk-column-actions mat-column-actions ng-star-inserted']//mat-icon[@class = 'mat-icon notranslate red material-icons mat-icon-no-color']")));
        //private IWebElement confirmDelButton => wait.Until(ElementToBeClickable(By.XPath("//*[@class='mat-focus-indicator modal-accept-button mat-raised-button mat-button-base mat-primary']")));
        private IWebElement confirmDelButton => wait.Until(ElementToBeClickable(By.XPath("//*[@class='mat-button-wrapper' and contains(text(),' Tak ')]")));
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
        private IWebElement SearchInput => wait.Until(ElementToBeClickable(By.XPath("/html/body/app-maestro-app/app-authorised-layout/div/mat-sidenav-container/mat-sidenav-content/div[2]/app-employees-catalog/div/div/div/mat-card/mat-card-subtitle/mat-form-field/div/div[1]/div[2]/input")));
     
        internal void GoToAddUser()
        {
            Users.Click();
            createUser.Click();
        }
        internal void GoToUsers()
        {
            Users.Click();
        }
        internal void search(string query)
        {
            SearchInput.Clear();
            SearchInput.Click();
            SearchInput.SendKeys(query);
        }
        internal void FillOutForm(User user)
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
            password.SendKeys(user.password);
            rePassword.SendKeys(user.rePassword);
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
            //actionProvider.DoubleClick(Node).Build().Perform();
            //  choosenNode.Click();

            wait.Until(ElementToBeClickable(addUser)).Click();
        }
        internal void expandRecords()
        {
            wait.Until(ElementToBeClickable(By.XPath("//*[@class='mat-select-arrow ng-tns-c214-117']"))).Click();
            wait.Until(ElementToBeClickable(By.XPath("//*[@class='mat-option-text' and contains(text(),'100')]"))).Click();

        }
        internal void DeleteUser(string DelQuery)
        {
            IWebElement delete = wait.Until(ElementIsVisible(By.XPath("//*[@class='mat-row cdk-row ng-star-inserted']//td[@class = 'mat-cell cdk-cell cdk-column-email mat-column-email ng-star-inserted' and contains(text(),'" + DelQuery + "')]//following-sibling::td[@class = 'mat-cell cdk-cell cdk-column-actions mat-column-actions ng-star-inserted']//mat-icon[@class = 'mat-icon notranslate red material-icons mat-icon-no-color']")));
 
            wait.Until(ElementToBeClickable(delete)).Click();
            confirmDelButton.Click();
            Thread.Sleep(5000);
            //path to delete choosen user
            //driver.FindElement(By.XPath("//*[@class='mat-row cdk-row ng-star-inserted']/[@class='mat-cell cdk-cell cdk-column-email mat-column-email ng-star-inserted' and contains(text(),'aa@aa.pl')]/following-sibling::[@class='mat-cell cdk-cell cdk-column-actions mat-column-actions ng-star-inserted']/[@class='mat-icon notranslate green material-icons mat-icon-no-color']"));

            // working path 
            //driver.FindElement(By.XPath("//*[@class='mat-row cdk-row ng-star-inserted']//td[@class = 'mat-cell cdk-cell cdk-column-email mat-column-email ng-star-inserted' and contains(text(),'marcin@marcin.pl')]"));
            //newest
            //driver.FindElement(By.XPath("//*[@class='mat-row cdk-row ng-star-inserted']//td[@class = 'mat-cell cdk-cell cdk-column-email mat-column-email ng-star-inserted' and contains(text(),'marcin@marcin.pl')]//following-sibling::td[@class = 'mat-cell cdk-cell cdk-column-actions mat-column-actions ng-star-inserted']"));
            //driver.FindElement(By.XPath("//*[@class='mat-row cdk-row ng-star-inserted']//td[@class = 'mat-cell cdk-cell cdk-column-email mat-column-email ng-star-inserted' and contains(text(),'marcin@marcin.pl')]//following-sibling::td[@class = 'mat-cell cdk-cell cdk-column-actions mat-column-actions ng-star-inserted']//mat-icon[@class = 'mat-icon notranslate red material-icons mat-icon-no-color']"));
        }
       internal bool IsUserDeleted(string delQuery)
       {
            //IWebElement query = driver.FindElement(By.XPath("//*[@class='mat-row cdk-row ng-star-inserted']//td[@class = 'mat-cell cdk-cell cdk-column-email mat-column-email ng-star-inserted' and contains(text(),'" + delQuery + "')]//following-sibling::td[@class = 'mat-cell cdk-cell cdk-column-actions mat-column-actions ng-star-inserted']//mat-icon[@class = 'mat-icon notranslate red material-icons mat-icon-no-color']"));
            IReadOnlyCollection<IWebElement> query = driver.FindElements(By.XPath("//*[@class='mat-row cdk-row ng-star-inserted']//td[@class = 'mat-cell cdk-cell cdk-column-email mat-column-email ng-star-inserted' and contains(text(),'" + delQuery + "')]//following-sibling::td[@class = 'mat-cell cdk-cell cdk-column-actions mat-column-actions ng-star-inserted']//mat-icon[@class = 'mat-icon notranslate red material-icons mat-icon-no-color']"));
            
            if (query.Count>0)
               {
                  return false;
              }
             else
               {
                return true;
               }
              

        }


    

        internal bool isAdded(string delQuery)
        {
            IWebElement query = wait.Until(ElementIsVisible(By.XPath("//*[@class='mat-row cdk-row ng-star-inserted']//td[@class = 'mat-cell cdk-cell cdk-column-email mat-column-email ng-star-inserted' and contains(text(),'" + delQuery + "')]//following-sibling::td[@class = 'mat-cell cdk-cell cdk-column-actions mat-column-actions ng-star-inserted']//mat-icon[@class = 'mat-icon notranslate red material-icons mat-icon-no-color']")));
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