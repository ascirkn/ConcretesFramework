using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using System;
using static SeleniumExtras.WaitHelpers.ExpectedConditions;
using System.Threading;

namespace TestBetoniarnia
{
    [TestClass]
    public class BetoniarniaTests
    {
        [TestMethod]
        public void AddUser()
        {

            var driver = new ChromeDriver();
            var actions = new Actions(driver);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            GoToUrl(driver);
            driver.Manage().Window.Maximize();

            driver.FindElement(By.Id("Username")).SendKeys("igor.sprzedawca");
            driver.FindElement(By.Id("Password")).SendKeys("I.arabas123$");
            wait.Until(ElementToBeClickable(By.XPath("//*[@class='btn btn-primary']"))).Click();

            wait.Until(ElementToBeClickable(By.XPath("//a[@href='#/authorised/employees/catalog']"))).Click();
            wait.Until(ElementToBeClickable(By.XPath("//*[@class='btn btn-primary']"))).Click();

            driver.FindElement(By.Id("mat-input-1")).SendKeys("Nomn");
            driver.FindElement(By.Id("mat-input-2")).SendKeys("Piotrekk");
            driver.FindElement(By.Id("mat-input-3")).SendKeys("ZXCV");
            driver.FindElement(By.Id("mat-input-4")).SendKeys("zpotr@gmail.com");
            driver.FindElement(By.Id("mat-input-5")).SendKeys("613232123");
            driver.FindElement(By.Id("mat-input-6")).SendKeys("Hasl2o1!@#");
            driver.FindElement(By.Id("mat-input-7")).SendKeys("Hasl2o1!@#");

            wait.Until(ElementToBeClickable(By.XPath("//*[@class='mat-select-placeholder ng-tns-c214-105 ng-star-inserted']"))).Click();
            driver.FindElement(By.Id("mat-option-11")).Click();
            actions.SendKeys(Keys.Escape).Perform();



            wait.Until(ElementToBeClickable(By.XPath("//*[@class='mat-select-trigger ng-tns-c214-103']"))).Click();
            wait.Until(ElementToBeClickable(By.XPath("//*[@class='mat-option-text' and contains(text(),'BETONIARNIA3')]"))).Click();


            Thread.Sleep(3000);
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@class='btn btn-success']"))).Click();

            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@class='mat-cell cdk-cell cdk-column-name mat-column-name ng-star-inserted']")));

            var createdUser = driver.FindElement(By.XPath("//*[@class='mat-cell cdk-cell cdk-column-name mat-column-name ng-star-inserted' and contains(text(),'Nomn')]"));

            Assert.AreEqual("Nomn", createdUser.ToString());

            driver.Quit();

        }
        [TestMethod]
        public void deleteUser()
        {
            var driver = new ChromeDriver();
            var actions = new Actions(driver);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            GoToUrl(driver);
            driver.Manage().Window.Maximize();
            driver.FindElement(By.Id("Username")).SendKeys("igor.sprzedawca");
            driver.FindElement(By.Id("Password")).SendKeys("I.arabas123$");
            wait.Until(ElementToBeClickable(By.XPath("//*[@class='btn btn-primary']"))).Click();

            wait.Until(ElementToBeClickable(By.XPath("//a[@href='#/authorised/employees/catalog']"))).Click();


            //show 100 records
            wait.Until(ElementToBeClickable(By.XPath("//*[@class='mat-select-value ng-tns-c214-61']"))).Click();
            wait.Until(ElementToBeClickable(By.XPath("//*[@class='mat-option-text' and contains(text(),'100')]"))).Click();

            //Finding an icon
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@class='mat-cell cdk-cell cdk-column-email mat-column-email ng-star-inserted' and contains(text(),'zpotr@gmail.com')]")));
            //var firstClass = driver.FindElement(By.XPath("//*[@class='mat-cell cdk-cell cdk-column-email mat-column-email ng-star-inserted' and contains(text(),'zpotr@gmail.com')]"));
            //var secondClass = firstClass.FindElement(By.XPath("//*[@class='mat-cell cdk-cell cdk-column-actions mat-column-actions ng-star-inserted']"));
            //var thirdClass = secondClass.FindElement(By.XPath("//*[@class='mat-icon notranslate red material-icons mat-icon-no-color']"));

            var firstClass = driver.FindElement(By.XPath("//*[@class='mat-row cdk-row ng-star-inserted']/[@class='mat-cell cdk-cell cdk-column-email mat-column-email ng-star-inserted' and contains(text(),'kier@srx2.pl')]/following-sibling::[@class='mat-cell cdk-cell cdk-column-actions mat-column-actions ng-star-inserted']/[@class='mat-icon notranslate red material-icons mat-icon-no-color']"));

            firstClass.Click();
            //thirdClass.Click();
            // wait.Until(ElementToBeClickable(By.XPath("//*[@class='mat-focus-indicator modal-accept-button mat-raised-button mat-button-base mat-primary']"))).Click();

            //driver.Quit();
        }
        [TestMethod]

        public void modifyUser()
        {
            var driver = new ChromeDriver();
            var actions = new Actions(driver);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            GoToUrl(driver);
            driver.Manage().Window.Maximize();
            driver.FindElement(By.Id("Username")).SendKeys("igor.sprzedawca");
            driver.FindElement(By.Id("Password")).SendKeys("I.arabas123$");
            wait.Until(ElementToBeClickable(By.XPath("//*[@class='btn btn-primary']"))).Click();

            wait.Until(ElementToBeClickable(By.XPath("//a[@href='#/authorised/employees/catalog']"))).Click();

            //Finding an icon
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@class='mat-cell cdk-cell cdk-column-email mat-column-email ng-star-inserted' and contains(text(),'kiersrx@pp.pl')]")));
            var firstClass = driver.FindElement(By.XPath("//*[@class='mat-cell cdk-cell cdk-column-email mat-column-email ng-star-inserted' and contains(text(),'aa@pp.pl')]"));
            var secondClass = firstClass.FindElement(By.XPath("//*[@class='mat-cell cdk-cell cdk-column-actions mat-column-actions ng-star-inserted']"));
            var thirdClass = secondClass.FindElement(By.XPath("//*[@class='mat-icon notranslate green material-icons mat-icon-no-color']"));


            thirdClass.Click();


            //userEdit
            //var nameField = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@class='mat-input-element mat-form-field-autofill-control ng-tns-c143-98 cdk-text-field-autofill-monitored ng-pristine ng-valid ng-touched']")));
            var nameField = driver.FindElements(By.Id("mat-input-1"));
            nameField[0].Clear();
            nameField[0].SendKeys("EdytowanaNazwa");

            var nameField2 = driver.FindElements(By.Id("mat-input-2"));
            nameField2[0].Clear();
            nameField2[0].SendKeys("EdytowaneImie");

            var surname = driver.FindElements(By.Id("mat-input-3"));
            surname[0].Clear();
            surname[0].SendKeys("EdytowaneNazwisko");

            var mail = driver.FindElements(By.Id("mat-input-4"));
            mail[0].Clear();
            mail[0].SendKeys("Edytowany@mail.pl");

            var number = driver.FindElements(By.Id("mat-input-5"));
            number[0].Clear();
            number[0].SendKeys("111222111");

            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@class='mat-select-value ng-tns-c214-106']"))).Click();
            wait.Until(ElementToBeClickable(By.XPath("//*[@class='mat-option-text' and contains(text(),'Logistyk')]"))).Click();
            actions.SendKeys(Keys.Escape).Perform();

            wait.Until(ElementToBeClickable(By.XPath("//*[@class='mat-select-value ng-tns-c214-104']"))).Click();
            wait.Until(ElementToBeClickable(By.XPath("//*[@class='mat-option-text' and contains(text(),'ŻWIROWNIA')]"))).Click();


            //save
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@class='btn btn-success']"))).Click();

            driver.Quit();

        }
        private static void GoToUrl(IWebDriver driver)
        {
            driver.Navigate().GoToUrl("http://orders.devitmcode.pl");
        }



    }
}