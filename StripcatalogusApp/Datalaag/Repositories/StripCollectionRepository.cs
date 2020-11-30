using DataLayer.Repositories;
using System;
using System.Collections.Generic;
using Businesslaag.Repositories;
using System.Text;
using Businesslaag.Models;
using Datalaag.Models;
using Datalaag.Mappers;
using System.Data.SqlClient;

namespace Datalaag.Repositories
{
    /// <summary>
    ///
    /// </summary>
    public class StripCollectionRepository : CRUDRepository<StripCollectionDB>, IStripCollectionRepository
    {
        public StripCollectionRepository(string connectionString)
  : base(connectionString)
        {
        }

        public void Add(StripCollection entity)
        {
            throw new NotImplementedException();
        }

        public void DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<StripCollection> GetAll()
        {
            throw new NotImplementedException();
        }

        public StripCollection GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(StripCollection entity)
        {
            throw new NotImplementedException();
        }
    }

}
         
       
     