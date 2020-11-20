using Businesslaag.Models;
using Businesslaag.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Businesslaag.Managers
{
    public class StripManager
    {
        private GeneralManager _gm;
        internal IStripRepository _stripRepository;
        #region [Constructor]
        /// <summary>
        /// Default constructor
        /// </summary>
        public StripManager(GeneralManager generalManager, IStripRepository stripRepository)
        {
            _gm = generalManager;
            _stripRepository = stripRepository;
        }
        #endregion



        public void Add(Strip strip)
        {
            if (DoubleStripNotFound(strip))
            {
                for (int i = 0; i < strip.Auteurs.Count; i++)
                {
                    // does this fruit exist
                    Auteur auteur = _gm.AuteurManager.GetByName(strip.Auteurs[i].Naam);
                    // yes good gimme

                    if (auteur != null)
                    {
                        strip.Auteurs[i] = auteur;
                    }
                    // no make new bosbes error
                    else
                        throw new ArgumentException("the author does not exist");

                }
                Reeks reeks = _gm.ReeksManager.GetByName(strip.Reeks.Naam);
                if (reeks != null)
                {
                    strip.Reeks = reeks;
                }
                else
                {
                    throw new ArgumentException("de reeks bestaat niet");
                }
                Uitgeverij uitgeverij = _gm.UitgeverijManager.GetByName(strip.Uitgeverij.Naam);
                if(uitgeverij != null)
                {
                    strip.Uitgeverij = uitgeverij;
                }
                else 
                {
                    throw new ArgumentException("uitgeverij bestaat niet");
                }

                this._stripRepository.Add(strip);

            }


        }
        public List<Strip> GetAll()
        {
            return (List<Strip>)this._stripRepository.GetAll();

        }

        public Strip GetById(int id)
        {
            return this._stripRepository.GetById(id);

        }

        public Strip GetByName(string stripnaam)
        {
            return this._stripRepository.GetAll().Where(n => n.StripTitel.Equals(stripnaam)).FirstOrDefault();
        }



        public Strip getLastId()
        {
            return this._stripRepository.GetLastStrip();
        }

        public void Update(Strip strip)
        {
            if (GetById(strip.ID) != null)
            {
                throw new ArgumentException("trying to update a strip that does not exist");
            }
            else
                this._stripRepository.Update(strip);

        }

        public void Delete(Strip strip)
        {
            if (GetById(strip.ID) != null)
            {
                this._stripRepository.DeleteById(strip.ID);
            }
            else
            {
                throw new ArgumentException("trying to delete an Author that does not exist");
            }

        }

        private Boolean DoubleStripNotFound(Strip strip)
        {
            if (this._stripRepository.GetAll().Any(i => i.StripNr == strip.StripNr && i.StripTitel == strip.StripTitel))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

    }
}