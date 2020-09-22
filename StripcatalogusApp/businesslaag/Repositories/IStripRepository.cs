using businesslaag;
using System;
using System.Collections.Generic;
using System.Text;

namespace Businesslaag.Repositories
{
   public interface IStripRepository
    {
        void AddStrip(Strip strip);
        void RemoveStrip(int id);
        Strip FindStrip(int id);
        IEnumerable<Strip> FindAll_stip();
        IEnumerable<Strip> FindAll_vanReeks(Reeks reeks);
        IEnumerable<Strip> FindAll_vanAuteur(Auteur auteur);
    }
}
