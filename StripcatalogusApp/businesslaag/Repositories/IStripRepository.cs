using System.Collections.Generic;
using Businesslaag.Models;

namespace Businesslaag.Repositories
{
   public interface IStripRepository : CRUDRepository<Strip>
    {
        IEnumerable<Strip> FindAll_ByReeks(Reeks reeks); 
        IEnumerable<Strip> FindAll_ByAuteur(Auteur auteur); 
    }
}
