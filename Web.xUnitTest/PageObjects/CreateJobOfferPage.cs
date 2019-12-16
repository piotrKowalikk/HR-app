using OpenQA.Selenium;
using System;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Collections.ObjectModel;
using Web.AutomatedUITests.Extenders;

namespace Web.AutomatedUITests
{


    class CreateJobOfferPage
    {
        private readonly IWebDriver _driver;
        private readonly string URI = "localhost:5000/JobOffers/Create";

        private IWebElement PositionElement => _driver.FindElement(By.Name("Position"));
        private IWebElement CompanyIdElement()
        {
            return _driver.FindElement(By.Name("CompanyId"));
        }
        private IWebElement SalaryFromElement => _driver.FindElement(By.Name("SalaryFrom"));
        private IWebElement SalaryToElement => _driver.FindElement(By.Name("SalaryTo"));
        private IWebElement DateExpirationElement => _driver.FindElement(By.Name("DateExpiration"));
        private IWebElement DescriptionElement => _driver.FindElement(By.Name("Description"));
        private IWebElement CreateElement => _driver.FindElement(By.Name("Create"));
        private IWebElement BackToListElement => _driver.FindElement(By.Name("BackToList"));
        private ReadOnlyCollection<IWebElement> Errors => _driver.FindElements(By.ClassName("field-validation-error"));

        public CreateJobOfferPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public void Navigate() => _driver.Navigate()
               .GoToUrl(URI);


        public void PopulateCompany(string company)
        {
            
            var companySelect = SelectElementExtender.FindSelectElementWhenPopulated(_driver, By.Name("CompanyId"), 5);
            companySelect.SelectByText(company);
        }
        public void PopulatePostion(string Position) => PositionElement.SendKeys(Position);
        public void PopulateSalaryFrom(int SalaryFrom) => SalaryFromElement.SendKeys(SalaryFrom.ToString());
        public void PopulateSalaryTo(int SalaryTo) => SalaryToElement.SendKeys(SalaryTo.ToString());
        public void PopulateDateExpiration(string DateExpiration) => DateExpirationElement.SendKeys(DateExpiration);
        public void PopulateDescription(string Description) => DescriptionElement.SendKeys(Description);
        public void ClickCreate() => CreateElement.Click();
        public void ClickBackToListElement() => BackToListElement.Click();
        public int GetNumberOfErrors() => this.Errors.Count;
    }
}
