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
        public IWebElement time => driver.FindElement(By.CssSelector("#result-stats > nobr"));


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
            string b = time.Text;
            string c = result.Text.Remove(a.Length - b.Length);
            string d = new String(c.Where(char.IsDigit).ToArray());         
            
                                
                Assert.That(Int32.Parse(d), Is.GreaterThan(100));
           
            
        }
        

        [TearDown]

        public void Quit()
        {
            driver.Quit();
        }
    }
}