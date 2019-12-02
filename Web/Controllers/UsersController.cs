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
        HR_ProjectContext _context;
        public UsersController(HR_ProjectContext context)
        {
            _context= context;
        }

        // GET: Users/Delete/5
        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var company =  _context.Users
                .FirstOrDefault(m => m.Id == id);

            _context.Users.Remove(company);
            await _context.SaveChangesAsync();
            if (company == null)
            {
                return NotFound();
            }

            return RedirectToAction("Index");
        }

        public IActionResult Index()
        {
            return View(_context.Users.Select(x=>x));
        }
    }
}