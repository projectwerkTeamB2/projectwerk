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
        GeneralManager generalManager = new GeneralManager(new StripRepository(DbFunctions.GetprojectwerkconnectionString()), new AuteurRepository(DbFunctions.GetprojectwerkconnectionString()), new ReeksRepository(DbFunctions.GetprojectwerkconnectionString()), new UitgeverijRepository(DbFunctions.GetprojectwerkconnectionString()), new StripCollectionRepository(DbFunctions.GetprojectwerkconnectionString()));
        
        [TestInitialize]
        public void Initialize()
        {
            Auteur auteur1 = new Auteur(1, "test1");
            Auteur auteur2 = new Auteur(2, "test2");
            Auteur auteur3 = new Auteur(3, "test3");
            Auteur auteur4 = new Auteur(4, "test4");
            generalManager.AuteurManager.Add(auteur1);
            generalManager.AuteurManager.Add(auteur2);
            generalManager.AuteurManager.Add(auteur3);
            generalManager.AuteurManager.Add(auteur4);
           
        }

        [TestMethod]
        public void select_allAuteurs_succes()
        {
            int expected = 4;
            List<Auteur>  gotten = generalManager.AuteurManager.GetAll();
            Assert.AreEqual(expected, gotten.Count);
        }

        [TestMethod]
        public void Add_Auteur_No_Error() {
            Auteur testAuteur = new Auteur(9999, "testAuteur");
            generalManager.AuteurManager.Add(testAuteur);

            Auteur auteurFromDb = generalManager.AuteurManager.GetById(9999);
            Assert.AreEqual(testAuteur, auteurFromDb);
        }
        [TestMethod]
        public void select_auteurbyID_succes() 
        {
            Auteur expected = new Auteur(9999, "testAuteur");
            Auteur gotten = generalManager.AuteurManager.GetById(expected.ID);
            Assert.AreEqual(expected, gotten);
        }

        [TestMethod]
        public void select_auteurByName_succes() 
        {
            Auteur expected = new Auteur(1, "test1");
            Auteur gotten = generalManager.AuteurManager.GetByName(expected.Naam);
            Assert.AreEqual(expected, gotten);
        }
        [TestMethod]
        public void updateAuteur_succesvol() 
        {
          Auteur og =  generalManager.AuteurManager.GetById(1);
            og.Naam = "inserted test value";
            generalManager.AuteurManager.Update(og);
            Assert.AreEqual(og.Naam, "inserted test value");
        }

        [TestMethod]
        public void DeleteAuteur_succesvol() 
        {
            int begincount = generalManager.AuteurManager.GetAll().Count;
            Auteur auteur = generalManager.AuteurManager.GetById(1);
            generalManager.AuteurManager.Delete(auteur);
            Assert.IsTrue(generalManager.AuteurManager.GetAll().Count == begincount - 1);
        }
    }
}
