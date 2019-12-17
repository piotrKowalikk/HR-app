using HR.DataAccess.Models;
using Microsoft.AspNetCore.Http;
using Moq;
using System;
using System.Net;
using System.Threading.Tasks;
using Web.Controllers;
using Xunit;

namespace HR_Project.UnitTests
{
    public class UnitTest1
    {
        [Fact]
        public void GetCompanies_NotThrowingErrors()
        {
            //WebRequest companiesCall = WebRequest.Create("https://localhost:5000/api/GetCompanies");
            //HttpWebResponse response = (HttpWebResponse)companiesCall.GetResponse();

            //companiesCall.GetRequestStream();
        }
    }
}
