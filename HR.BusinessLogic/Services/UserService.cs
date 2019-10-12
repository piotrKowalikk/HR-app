﻿using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using HR.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace HR.BusinessLogic.Services
{
   public class UserService : Interfaces.IUserService<AppUsers>
    {
        HR_ProjectContext _context;
        public UserService(HR_ProjectContext context)
        {
            this._context = context;
        }

        public AppUsers Add(AppUsers entity)
        {
            var v=_context.AppUsers.Where(x => x.Email == entity.Email);
            if (v.FirstOrDefault() != null)
                return null;

            _context.Add(entity);
            return entity;
        }

        public void Delete(AppUsers entity)
        {
            _context.Remove<AppUsers>(entity);
        }

        public void DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public AppUsers FindById(int id)
        {
            return _context.AppUsers.Find(id);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public IEnumerable<AppUsers> SelectAll()
        {
            var c = (from n in _context.AppUsers
                     select n).AsNoTracking();
            return c;
        }

        public void Update(AppUsers entity)
        {
            _context.Update(entity);
        }

    }
}
