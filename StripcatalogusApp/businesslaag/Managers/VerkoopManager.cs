using Businesslaag.Models;
using Businesslaag.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Businesslaag.Managers {
    public class VerkoopManager
    {
     private GeneralManager _gm;
    internal IVerkoopRepository _IVerkoopRepository;
    #region [Constructor]
    /// <summary>
    /// Default constructor
    /// </summary>
    public VerkoopManager(GeneralManager generalManager, IVerkoopRepository IVerkoopRepository)
    {
        _gm = generalManager;
            _IVerkoopRepository = IVerkoopRepository;
    }
    #endregion

    public void Add(Verkoop verkoop)
    {
        if (DoubleVerkoopNotFound(verkoop))
        {
            this._IVerkoopRepository.Add(verkoop);
        }
        else throw new ArgumentException("verkoop bestaat al");
    }

    public List<Verkoop> GetAll()
    {
        return (List<Verkoop>)this._IVerkoopRepository.GetAll();
    }

    public Verkoop GetById(int id)
    {
        return this._IVerkoopRepository.GetById(id);
    }

    public void Update(Verkoop verkoop)
    {
        if (GetById(verkoop.ID) == null)
        {
            throw new ArgumentException("trying to update an verkoop that does not exist");
        }
        else
            this._IVerkoopRepository.Update(verkoop);
    }

    public void Delete(Verkoop verkoop)
    {
        if (GetById(verkoop.ID) != null)
        {
            this._IVerkoopRepository.DeleteById(verkoop.ID);
        }
        else
        {
            throw new ArgumentException("trying to delete an Verkoop that does not exist");
        }
    }

    private Boolean DoubleVerkoopNotFound(Verkoop verkoop)
    {
        if (this._IVerkoopRepository.GetAll().Any(i => i.ID == verkoop.ID))
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
