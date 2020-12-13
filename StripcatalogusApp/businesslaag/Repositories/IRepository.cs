using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Businesslaag.Repositories
{
    /// <summary>
    /// interface die de repositories gaan gebruiken, verzamelplaats voor verplichte functies volgens "contractuele verplichting"
    /// </summary>
    /// <typeparam name="T"> is altijd een classe zie datalaag voor een voorbeeld </typeparam>
    public interface IRepository<T> where T : class
    {
         void Add(T entity);
         void Update(T entity);
         void DeleteById(int id);   
         T GetById(int id);
         IEnumerable<T> GetAll();
       
     }
}
