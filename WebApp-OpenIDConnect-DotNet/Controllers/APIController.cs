using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using HR.BusinessLogic.Interfaces;
using HR.DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using WebApp_OpenIDConnect_DotNet;

namespace Web.Controllers
{
    public class APIController : Controller
    {
        AzureAdB2COptions AzureAdB2COptions;
        IUserService<AppUsers> userService;

        public APIController(IOptions<AzureAdB2COptions> azureAdB2COptions, IUserService<AppUsers> uService, IOfferService<AppOffers> oService)
        {
            AzureAdB2COptions = azureAdB2COptions.Value;
            userService = uService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async void DeleteInB2C(int id)//receives null
        {
            AppUsers user = userService.FindById(id);

            var authContext = new AuthenticationContext("https://login.microsoftonline.com/"+this.AzureAdB2COptions.Tenant);
            var credential = new ClientCredential(this.AzureAdB2COptions.ClientId, this.AzureAdB2COptions.ClientSecret);

            AuthenticationResult result = await authContext.AcquireTokenAsync("https://graph.windows.net",credential);
            HttpClient http = new HttpClient();
            string url = "https://graph.windows.net/"+this.AzureAdB2COptions.Tenant+"/users" +"?"+"version=1.6";

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get,url);
            var c = result.AccessToken;
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer",result.AccessToken);
            HttpResponseMessage response = http.SendAsync(request).Result;

            //maybe not so important
        }

    }
}