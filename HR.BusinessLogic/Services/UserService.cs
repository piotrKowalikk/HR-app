using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using HR.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace HR.BusinessLogic.Services
{
   public class UserService : Interfaces.IUserService<ApplicationUser>
    {
        HR_ProjectContext _context;
        public UserService(HR_ProjectContext context)
        {
            this._context = context;
        }

        public ApplicationUser Add(ApplicationUser entity)
        {
            var v=_context.Users.Where(x => x.Email == entity.Email);
            if (v.FirstOrDefault() != null)
                return null;

            _context.Add(entity);
            return entity;
        }

        public void Delete(ApplicationUser entity)
        {
            _context.Remove<ApplicationUser>(entity);
        }

        public void DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public ApplicationUser FindById(int id)
        {
            return _context.Users.Find(id);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public IEnumerable<ApplicationUser> SelectAll()
        {
            var c = (from n in _context.Users
                     select n).AsNoTracking();
            return c;
        }

        public void Update(ApplicationUser entity)
        {
            _context.Update(entity);
        }

    }
}
