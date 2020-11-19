using Businesslaag.Models;
using Businesslaag.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Businesslaag.Managers
{
    /// <summary>
    ///
    /// </summary>
    /// 
  
    public class AuteurManager
    {
        private GeneralManager _gm;
        internal IAuteurRepository _auteurRepository;
        #region [Constructor]
        /// <summary>
        /// Default constructor
        /// </summary>
        public AuteurManager(GeneralManager generalManager, IAuteurRepository auteurRepository)
        {
            _gm = generalManager;
            _auteurRepository = auteurRepository;
        }
        #endregion

        public void Add(Auteur auteur)
        {
            if (DoubleAuteurNotFound(auteur)) 
            this._auteurRepository.Add(auteur);

        }

        public List<Auteur> GetAll()
        {
            return (List<Auteur>)this._auteurRepository.GetAll();

        }

        public Auteur GetById(int id)
        {
            return this._auteurRepository.GetById(id);

        }

        public void Update(Auteur auteur)
        {
            if (GetById(auteur.ID) == null)
            {
                throw new ArgumentException("trying to update an Author that does not exist");
            }
            else
                this._auteurRepository.Update(auteur);

        }

        public void Delete(Auteur auteur)
        {
            if(GetById(auteur.ID) != null)
            {
                this._auteurRepository.DeleteById(auteur.ID);
            }
            else
            {
                    throw new ArgumentException("trying to delete an Author that does not exist");
            }
        }

        private Boolean DoubleAuteurNotFound(Auteur auteur)
        {
            if (this._auteurRepository.GetAll().Any(i => i.ID == auteur.ID && i.Naam == auteur.Naam))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public Auteur GetByName(string auteurNaam)
        {
            return this._auteurRepository.GetAll().Where(n=>n.Naam.Equals(auteurNaam)).FirstOrDefault();
        }

    }
}