using Businesslaag.Models;
using Businesslaag.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Businesslaag.Managers {
    public class VerkoopManager {
        private GeneralManager _generalManager;
        internal IVerkoopRepository _verkoopRepository;

        public VerkoopManager (GeneralManager general, IVerkoopRepository iverkoop) {
            _generalManager = general;
            _verkoopRepository = iverkoop;
        }

        //Simple add voor te starten
        //Todo: Nakijken of hier bepaalde dingen in moeten staan (checken voor dubbele,...)
        public void Add(Verkoop verkoop) {
            //Check voor dubbele

        }
    }
}
