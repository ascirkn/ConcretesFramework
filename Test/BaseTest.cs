using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;

namespace FrameworkBetony
{
    [TestClass]
    public class BaseTest
    {
        public IWebDriver driver;
        public WebDriverWait wait { get; private set; }
       
        public static readonly string myLogin = "igor.sprzedawca";
        public static readonly string myPassword = "I.arabas123$";

        [TestInitialize]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            
        }
        [TestCleanup]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}
