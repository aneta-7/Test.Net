using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace Selenium
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Login()
        {
            IWebDriver driver = new FirefoxDriver();

            driver.Navigate().GoToUrl("http://localhost:34302/");

            IWebElement myLink = driver.FindElement(By.LinkText("Log in"));
            myLink.Click();

            driver.FindElement(By.Id("Email")).SendKeys("prezes@prezes.pl");
            driver.FindElement(By.Id("Password")).SendKeys("12345678");

            driver.FindElement(By.XPath("//div[@class='col-md-offset-2 col-md-10']/input[@value='Log in']")).Click();

            var actual = driver.FindElement(By.XPath("//a[@title='Manage']")).Text;

            Assert.AreEqual("Hello prezes@prezes.pl!", actual);

            driver.Quit();
        }

        [TestMethod]
        public void AddProduct()
        {

            IWebDriver driver = new FirefoxDriver();

            driver.Navigate().GoToUrl("http://localhost:34302/");

            IWebElement myLink = driver.FindElement(By.LinkText("Log in"));
            myLink.Click();

            driver.FindElement(By.Id("Email")).SendKeys("prezes@prezes.pl");
            driver.FindElement(By.Id("Password")).SendKeys("12345678");

            driver.FindElement(By.XPath("//div[@class='col-md-offset-2 col-md-10']/input[@value='Log in']")).Click();

            var actual = driver.FindElement(By.XPath("//a[@title='Manage']")).Text;

            Assert.AreEqual("Hello prezes@prezes.pl!", actual);

            driver.FindElement(By.XPath("//a[@href='/samoloty/Create']")).Click();

            driver.FindElement(By.Id("Name")).SendKeys("NowyTestowySamolot");
            driver.FindElement(By.Id("Type")).SendKeys("NowyTestowySamolot");

            Screenshot ss = ((ITakesScreenshot)driver).GetScreenshot();
            ss.SaveAsFile("addElement.png", System.Drawing.Imaging.ImageFormat.Png);

            driver.FindElement(By.XPath("//input[@value='Dodaj']")).Click();

            var title = driver.Title;

            Assert.AreEqual("- My Flights Application", title);

            driver.Quit();
        }


        [TestMethod]
        public void Search()
        {
            IWebDriver driver = new FirefoxDriver();

            driver.Navigate().GoToUrl("http://localhost:34302/");

            IWebElement myLink = driver.FindElement(By.LinkText("Lista samolotów"));
            myLink.Click();

            driver.FindElement(By.Id("searchName")).SendKeys("NowySamolotTestowy");
            driver.FindElement(By.XPath("//input[@value='Szukaj']")).Click();

            Screenshot ss = ((ITakesScreenshot)driver).GetScreenshot();
            ss.SaveAsFile("serachElement.png", System.Drawing.Imaging.ImageFormat.Png);

            var actual = driver.FindElement(By.XPath("//tr[contains(td, 'NowySamolotTestowy')]")).Text;


            Assert.AreEqual("NowySamolotTestowy nowy Szczegóły", actual);


            driver.Quit();
        }
    }
}
