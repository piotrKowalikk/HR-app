using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using Xunit;

namespace Web.AutomatedUITests
{
    public class CreateJobOfferButtonTest
    {
        private readonly string URI = "localhost:5000/JobOffers";
        private readonly IWebDriver _driver;

        public CreateJobOfferButtonTest()
        {
            _driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
        }

        [Fact]
        public void GoToCreateJobOfferFromIndex()
        {
            _driver.Navigate().GoToUrl(URI);
            IWebElement createNewButton = _driver.FindElement(By.Name("CreateNew"));
            createNewButton.Click();
            Assert.Contains("Create", _driver.Title);

        }
    }
}
