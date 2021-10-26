using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using SeleniumExtras.WaitHelpers;
using System.Linq;

namespace NUnitTest
{
    public class Tests
    {
        private IWebDriver driver;
        public IWebElement search => driver.FindElement(By.CssSelector("input[type=text]"));
        public IWebElement button => driver.FindElement(By.CssSelector("input[type=submit]"));
        public IWebElement result => driver.FindElement(By.Id("result-stats"));

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.google.com/");
        }

        [Test]
        public void Test1()
        {
            
            search.SendKeys("IT Craft");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementToBeClickable(button));
            button.Click();

            string a = result.Text;
            string b = new String(a.Where(char.IsDigit).ToArray());         
            Console.WriteLine("Result ="+b);
            Assert.Pass();
        }
        

        [TearDown]

        public void Quit()
        {
            driver.Quit();
        }
    }
}