using System;
using System.IO;
using System.Collections.Generic;
using System.Web;
using System.Linq;
using System.Net.Http;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using HR.BusinessLogic.Interfaces;
using HR.DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using WebApp_OpenIDConnect_DotNet;
using WebApp_OpenIDConnect_DotNet.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using System.IO;
using WebApp_OpenIDConnect_DotNet.Helpers;

namespace Web.Controllers
{
    public class APIController : Controller
    {
        AzureAdB2COptions AzureAdB2COptions;
        IUserService<ApplicationUser> userService;
        private readonly HR_ProjectContext _context;
        IOptions<MyConfig> options;

        public APIController(IOptions<AzureAdB2COptions> azureAdB2COptions,
            IUserService<ApplicationUser> uService,
            IOfferService<JobOffer> oService,
            IOptions<MyConfig> options,
            HR_ProjectContext context)
        {
            AzureAdB2COptions = azureAdB2COptions.Value;
            userService = uService;
            _context = context;
            this.options = options;

        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult GetJobOffers(int pageNo = 1, int pageSize = 5, string filter = null)
        {
            int totalPage, totalRecord;

            totalRecord = _context.Offers.Count();
            totalPage = (totalRecord / pageSize) + ((totalRecord % pageSize) > 0 ? 1 : 0);
            var record = (from u in _context.Offers
                          .Include(i => i.Company)
                          where filter == null || filter == "" || u.Position.Contains(filter) || u.Company.Name.Contains(filter)
                          orderby u.Company.Name, u.Position
                          select u).Skip((pageNo - 1) * pageSize).Take(pageSize).Select(x => new OfferViewModel() { Position = x.Position, Company = x.Company.Name, Id = x.Id }).ToList();

            PagingViewModel empData = new PagingViewModel
            {
                Offers = record,
                TotalPage = totalPage
            };

            return Json(empData);
        }


        [HttpGet]
        public JsonResult GetCompanies()
        {
            var user = User;
            var companies = _context.Companies.Select(x => x);
            var json = Json(companies);
            return json;
        }

        [HttpGet]
        public JsonResult GetRoles()
        {
            var roles = _context.Roles.Select(x => x);
            var json = Json(roles);
            return json;
        }

        [HttpPost]
        public async Task<IActionResult> PostCV(string applicationId, List<IFormFile> files)
        {
            var filePath = Guid.NewGuid().ToString() + "--" + files[0].FileName;
            int.TryParse(applicationId, out int appId);
            JobApplication jobApp;
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await files[0].CopyToAsync(stream);
            }

            string storageConnectionString = options.Value.ConnectionParameters;
            string uri = "";
            CloudStorageAccount storageAccount;
            if (CloudStorageAccount.TryParse(storageConnectionString, out storageAccount))
            {
                CloudBlobClient cloudBlobClient = storageAccount.CreateCloudBlobClient();
                CloudBlobContainer cloudBlobContainer = cloudBlobClient.GetContainerReference(options.Value.ContainerName);
                CloudBlockBlob cloudBlockBlob = cloudBlobContainer.GetBlockBlobReference(filePath);
                await cloudBlockBlob.UploadFromFileAsync(filePath);
                uri = cloudBlockBlob.Uri.AbsoluteUri;
            }

            try
            {
                jobApp = _context.JobApplications.Find(appId);
                jobApp.CVurl = uri;
                _context.Update(jobApp);
                _context.SaveChanges();
            }
            catch
            {
                return Json(new { status = "error", message = "bad applicationId" });
            }
            var fileInfo = new System.IO.FileInfo(@".\" + filePath);
            fileInfo.Delete();
            return Json(new { filePath = uri });
        }


        [HttpPost]
        public JsonResult SetUserRole(int userId, int userRole)
        {
            var user = _context.Users.First(x => x.Id == userId);
            user.RoleId = userRole;
            _context.SaveChanges();

            return Json(true);
        }

        public async void DeleteInB2C(int id)//receives null
        {
            ApplicationUser user = userService.FindById(id);

            var authContext = new AuthenticationContext("https://login.microsoftonline.com/" + this.AzureAdB2COptions.Tenant);
            var credential = new ClientCredential(this.AzureAdB2COptions.ClientId, this.AzureAdB2COptions.ClientSecret);

            AuthenticationResult result = await authContext.AcquireTokenAsync("https://graph.windows.net", credential);
            HttpClient http = new HttpClient();
            string url = "https://graph.windows.net/" + this.AzureAdB2COptions.Tenant + "/users" + "?" + "version=1.6";

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, url);
            var c = result.AccessToken;
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", result.AccessToken);
            HttpResponseMessage response = http.SendAsync(request).Result;

            //maybe not so important
        }

    }
}