using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HR.DataAccess.Models;

namespace Web.Controllers
{
    public class JobApplicationsController : Controller
    {
        private readonly HR_ProjectContext _context;

        public JobApplicationsController(HR_ProjectContext context)
        {
            _context = context;
        }

        // GET: JobApplications
        public async Task<IActionResult> Index()
        {
            var hR_ProjectContext = _context.JobApplications
                .Include(j => j.JobOffer)
                .Include(j => j.User);
            return View(await hR_ProjectContext.ToListAsync());
        }


        // GET: JobApplications/Create/offerId
        public IActionResult Create(int id)
        {
            JobOffer offer;
            try
            {
                offer = _context.Offers.Include(x => x.Company).SingleOrDefault(x => x.Id == id);
            }
            catch
            {
                return NotFound();
            }
            //pora widok wystrugać
            //TODO: send default from user data.
            ViewData["Header"] = "Application for " + offer.Position + " in company " + offer.Company.Name;
            return View(new JobApplication() { JobOfferId=id});
        }

        // POST: JobApplications/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("JobOfferId,FirstName,LastName,PhoneNumber,EmailAddress,ContactAgreement")] JobApplication jobApplication)
        {
            jobApplication.ApplicationDate = DateTime.Now;
            jobApplication.UserId = 2;//TODO;

            if (ModelState.IsValid)
            {
                _context.Add(jobApplication);
                await _context.SaveChangesAsync();
                return RedirectToAction("Edit",new { id= jobApplication.Id });
            }
            return View(jobApplication);
        }

        // GET: JobApplications/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jobApplication = await _context.JobApplications.FindAsync(id);
            if (jobApplication == null)
                return NotFound();

            return View(jobApplication);
        }

        // POST: JobApplications/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,PhoneNumber,EmailAddress,ContactAgreement")] JobApplication jobApplication)
        {
            if (id != jobApplication.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(jobApplication);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JobApplicationExists(jobApplication.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }

            return View(jobApplication);
        }

        // GET: JobApplications/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            var jobApplication = await _context.JobApplications.FindAsync(id);
            _context.JobApplications.Remove(jobApplication);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool JobApplicationExists(int id)
        {
            return _context.JobApplications.Any(e => e.Id == id);
        }
    }
}
