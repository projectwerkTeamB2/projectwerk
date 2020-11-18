using Businesslaag.Managers;
using Businesslaag.Models;
using Datalaag;
using Datalaag.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace integratieTests {
    [TestClass]
    public class AuteurManager {
        GeneralManager generalManager = new GeneralManager(new StripRepository(DbFunctions.GetprojectwerkconnectionString()), new AuteurRepository(DbFunctions.GetprojectwerkconnectionString()), new ReeksRepository(DbFunctions.GetprojectwerkconnectionString()), new UitgeverijRepository(DbFunctions.GetprojectwerkconnectionString()));

        [TestMethod]
        public void Add_Auteur_No_Error() {
            Auteur testAuteur = new Auteur(9999, "testAuteur");
            generalManager.AuteurManager.Add(testAuteur);

            Auteur auteurFromDb = generalManager.AuteurManager.GetById(9999);
            Assert.AreEqual(testAuteur, auteurFromDb);
        }

    }
}
