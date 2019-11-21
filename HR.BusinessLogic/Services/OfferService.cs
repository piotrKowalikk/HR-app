using HR.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace HR.BusinessLogic.Services
{

    public class OfferService : Interfaces.IOfferService<JobOffer>
    {
        HR_ProjectContext _context;

        public OfferService(HR_ProjectContext context)
        {
            this._context = context;
        }

        public JobOffer Add(JobOffer entity)
        {
            _context.Add(entity);
            return entity;
        }

        public void Delete(JobOffer entity)
        {
            _context.Remove<JobOffer>(entity);
        }

        public void DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public JobOffer FindById(int id)
        {
            return _context.Offers.Find(id);
        }

        public IEnumerable<JobOffer> SelectAll()
        {
            var c = (from n in _context.Offers
                     select n).AsNoTracking();
            return c;
        }

        public void Update(JobOffer entity)
        {
            _context.Update(entity);
        }
    }
}
