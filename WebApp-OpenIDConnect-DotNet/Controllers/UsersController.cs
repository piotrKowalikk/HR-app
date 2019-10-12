using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HR.BusinessLogic.Interfaces;
using HR.DataAccess.Models;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class UsersController : Controller
    {
        IUserService<AppUsers> userService;
        public UsersController(IUserService<AppUsers> service)
        {
            userService= service;
        }

        public IActionResult Index()
        {

            return View(userService.SelectAll());
        }
    }
}