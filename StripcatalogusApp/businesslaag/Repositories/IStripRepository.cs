using businesslaag;
using System;
using System.Collections.Generic;
using System.Text;

namespace Businesslaag.Repositories
{
   public interface IStripRepository
    {
        void AddStrip(Strip strip);
        void RemoveStripById(int id);
        Strip FindStripById(int id);
        IEnumerable<Strip> FindAll_strip();
        IEnumerable<Strip> FindAll_ByReeks(Reeks reeks); 
        IEnumerable<Strip> FindAll_ByAuteur(Auteur auteur); 
    }
}
