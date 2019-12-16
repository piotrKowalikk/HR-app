using HR.DataAccess.Models;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.IO;
using System.Reflection;
using Xunit;

namespace Web.AutomatedUITests
{
    public class CreateJobOfferTests
    {
        private readonly IWebDriver _driver;
        private CreateJobOfferPage _page;

        private readonly JobOffer[] jobOffersWrong = new JobOffer[]
        {
            new JobOffer(),
            new JobOffer(){Company= new Company(){Name="Netcompany" } },
            new JobOffer(){Company= new Company(){Name="Netcompany" }, DateExpiration= DateTime.MaxValue },
            new JobOffer(){Company= new Company(){Name="Netcompany" }, DateExpiration= DateTime.MaxValue }
           // new JobOffer(){Company= new Company(){Name="Netcompany" }, DateExpiration= DateTime.MaxValue, SalaryFrom=10,SalaryTo=1000  }
        };

        private readonly JobOffer[] jobOffersCorrect = new JobOffer[]
{
            new JobOffer(){Company= new Company(){Name="ITBoom" } ,DateExpiration= DateTime.Now,SalaryFrom=1000, SalaryTo=10000, Position="Senior .Net Developer" }
            //new JobOffer(){Company= new Company(){Name="ITBoom" } ,DateExpiration= DateTime.Now,SalaryFrom=2000, SalaryTo=3000, Position="Junior .Net Developer" },
            //new JobOffer(){Company= new Company(){Name="ITBoom" } ,DateExpiration= DateTime.Now,SalaryFrom=5000, SalaryTo=7000, Position=".Net Developer" },
};


        public CreateJobOfferTests()
        {
            _driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            _page = new CreateJobOfferPage(_driver);
            _page.Navigate();
        }

        [Fact]
        public void TestWrongJobOffer()
        {
            foreach (var offer in jobOffersWrong)
            {
                if (offer.DateExpiration != null) _page.PopulateDateExpiration(offer.DateExpiration.ToString());
                if (offer.Company != null) _page.PopulateCompany(offer.Company.Name);
                if (offer.Description != null) _page.PopulateDescription(offer.Description.ToString());
                if (offer.Position != null) _page.PopulatePostion(offer.Position.ToString());
                if (offer.SalaryFrom.HasValue) _page.PopulateSalaryFrom(offer.SalaryFrom.Value);
                if (offer.SalaryTo.HasValue) _page.PopulateSalaryTo(offer.SalaryTo.Value);
                _page.ClickCreate();
                Assert.NotEqual(0, _page.GetNumberOfErrors());
            }
        }
        [Fact]
        public void TestValidJobOffer()
        {
            foreach (var offer in jobOffersCorrect)
            {
                _page.Navigate();
                if (offer.DateExpiration != null) _page.PopulateDateExpiration(offer.DateExpiration.ToShortDateString());
                if (offer.Company != null) _page.PopulateCompany(offer.Company.Name);
                if (offer.Description != null) _page.PopulateDescription(offer.Description.ToString());
                if (offer.Position != null) _page.PopulatePostion(offer.Position.ToString());
                if (offer.SalaryFrom.HasValue) _page.PopulateSalaryFrom(offer.SalaryFrom.Value);
                if (offer.SalaryTo.HasValue) _page.PopulateSalaryTo(offer.SalaryTo.Value);
             //   _page.ClickCreate();
                Assert.Equal(0, _page.GetNumberOfErrors());
            }
        }
    }
}
