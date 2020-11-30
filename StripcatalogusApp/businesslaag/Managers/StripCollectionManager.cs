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
    public class StripCollectionManager
    {

        private GeneralManager _gm;
        internal IStripCollectionRepository  _StripCollectionRepository;
        #region [Constructor]
        /// <summary>
        /// Default constructor
        /// </summary>
        public StripCollectionManager(GeneralManager generalManager, IStripCollectionRepository stripCollectionRepository )
        {
            this._gm = generalManager;
            this._StripCollectionRepository = stripCollectionRepository;

        }

        #endregion

        public void Add(StripCollection collection)
        {
            if (DoubleStripCollectionNotFound(collection))
            {
                for (int i = 0; i < collection.Strips.Count; i++)
                {
                    // does this fruit exist
                    Strip strip = _gm.StripManager.GetByName(collection.Strips[i].StripTitel);
                    // yes good gimme

                    if (strip != null)
                    {
                        collection.Strips[i] = strip;
                    }
                    // no make new bosbes error
                    else
                        throw new ArgumentException("the author does not exist");

                }
                this._StripCollectionRepository.Add(collection);


            }
        }

        public List<StripCollection> GetAll()
        {
            return (List<StripCollection>)this._StripCollectionRepository.GetAll();
        }

        public StripCollection GetById(int id)
        {
            return this._StripCollectionRepository.GetById(id);

        }

        public void Update(StripCollection Collection)
        {
            if (GetById(Collection.Id) == null)
            {
                throw new ArgumentException("trying to update a stripcollection that does not exist");
            }
            else
                this._StripCollectionRepository.Update(Collection);

        }

        public void Delete(StripCollection Collection)
        {
            if (GetById(Collection.Id) != null)
            {
                this._StripCollectionRepository.DeleteById(Collection.Id);
            }
            else
            {
                throw new ArgumentException("trying to delete a stripcollection that does not exist");
            }

        }

        private Boolean DoubleStripCollectionNotFound(StripCollection Collection)
        {
            if (this._StripCollectionRepository.GetAll().Any(i => i.Nummer == Collection.Nummer && i.Titel == Collection.Titel))
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