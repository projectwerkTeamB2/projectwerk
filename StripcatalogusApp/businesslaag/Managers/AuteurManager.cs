using Businesslaag.Models;
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
        #region [Constructor]
        /// <summary>
        /// Default constructor
        /// </summary>
        public AuteurManager(GeneralManager generalManager)
        {
            _gm = generalManager;
        }
        #endregion

        public void Add(Auteur auteur)
        {
            if (DoubleAuteurNotFound(auteur)) 
            _gm._auteurRepository.Add(auteur);

        }

        public List<Auteur> GetAll()
        {
            return (List<Auteur>)_gm._auteurRepository.GetAll();

        }

        public Auteur GetById(int id)
        {
            return _gm._auteurRepository.GetById(id);

        }

        public void Update(Auteur auteur)
        {
            if (GetById(auteur.ID) != null)
            {
                throw new ArgumentException("trying to update an Author that does not exist");
            }
            else
                _gm._auteurRepository.Update(auteur);

        }

        public void Delete(Auteur auteur)
        {
            if(GetById(auteur.ID) == null)
            {
                _gm._auteurRepository.DeleteById(auteur.ID);
            }
            else
            {
                    throw new ArgumentException("trying to delete an Author that does not exist");
            }
        }

        private Boolean DoubleAuteurNotFound(Auteur auteur)
        {
            if (_gm._auteurRepository.GetAll().Any(i => i.ID == auteur.ID && i.Naam == auteur.Naam))
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