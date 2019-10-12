using HR.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace HR.BusinessLogic.Services
{

    class OfferService : Interfaces.IOfferService<AppOffers>
    {
        HR_ProjectContext _context;

        public OfferService(HR_ProjectContext context)
        {
            this._context = context;
        }

        public AppOffers Add(AppOffers entity)
        {
            _context.Add(entity);
            return entity;
        }

        public void Delete(AppOffers entity)
        {
            _context.Remove<AppOffers>(entity);
        }

        public void DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public AppOffers FindById(int id)
        {
            return _context.AppOffers.Find(id);
        }

        public IEnumerable<AppOffers> SelectAll()
        {
            var c= (from n in _context.AppOffers
                    select n).AsNoTracking();
            return c;
        }

        public void Update(AppOffers entity)
        {
            _context.Update(entity);
        }
    }
}
