using System;
using System.Collections.Generic;
using System.Text;
using HR.DataAccess.Models;

namespace HR.BusinessLogic.Interfaces
{
   public interface IOfferService<T> where T: Entity
    {
        T FindById(int id);
        IEnumerable<T> SelectAll();
        T Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        void DeleteById(int id);
    }
}
