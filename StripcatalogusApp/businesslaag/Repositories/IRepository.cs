using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Businesslaag.Repositories
{
    public interface IRepository<T> where T : class
    {
         void Add(T entity);
         void Update(T entity);
         void DeleteById(int id);   
         T GetById(int id);
         IEnumerable<T> GetAll();
       //  IEnumerable<T> Find(Expression<Func<T, bool>> expr);
        // int Count();
     }
}
