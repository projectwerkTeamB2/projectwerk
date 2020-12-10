using Businesslaag.Managers;
using Businesslaag.Models;
using Datalaag;
using Datalaag.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace integratieTests
{
    [TestClass]
    public class StripManager
    {
        GeneralManager generalManager = new GeneralManager(new StripRepository(DbFunctions.GetprojectwerkconnectionString()), new AuteurRepository(DbFunctions.GetprojectwerkconnectionString()), new ReeksRepository(DbFunctions.GetprojectwerkconnectionString()), new UitgeverijRepository(DbFunctions.GetprojectwerkconnectionString()));
        
        [TestInitialize]
        public void Initialize()
        {
            Initialize i = new Initialize();
            i.ClearDB();
            i.ClearDB();

            Auteur auteur = new Auteur(1, "testAut1");
            Auteur auteur2 = new Auteur(2, "testAut2");
            generalManager.AuteurManager.Add(auteur);
            generalManager.AuteurManager.Add(auteur2);
            List<Auteur> auteurs = new List<Auteur>();
            auteurs.Add(generalManager.AuteurManager.GetById(1));
            

            Reeks reeks = new Reeks(1, "testReeks");
            generalManager.ReeksManager.Add(reeks);
            
            

            Uitgeverij Uitgeverij = new Uitgeverij(1, "testUitgeverij");
            generalManager.UitgeverijManager.Add(Uitgeverij);

            Strip strip1 = new Strip(1, "test1",    1, auteurs, reeks, Uitgeverij);
            Strip strip2 = new Strip(2, "test2",    2, auteurs, reeks, Uitgeverij);
            Strip strip3 = new Strip(3, "test3",    3, auteurs, reeks, Uitgeverij);
            Strip strip4 = new Strip(4, "test4",    4, auteurs, reeks, Uitgeverij);

            generalManager.StripManager.Add(strip1);
            generalManager.StripManager.Add(strip2);
            generalManager.StripManager.Add(strip3);
            generalManager.StripManager.Add(strip4);
        }

        [TestMethod]
        public void select_allStrip_succes()
        {
            int expected = 4;
            List<Strip> gotten = generalManager.StripManager.GetAll();
            Assert.AreEqual(expected, gotten.Count);
        }

        [TestMethod]
        public void Add_Strip_No_Error()
        {
            List<Auteur> auteurs = new List<Auteur>();
            auteurs.Add(generalManager.AuteurManager.GetById(2));
            Strip testStrip = new Strip(5, "testStripTitel", 5, auteurs, generalManager.ReeksManager.GetById(1), generalManager.UitgeverijManager.GetById(1));
            generalManager.StripManager.Add(testStrip);

            Strip stripFromDb = generalManager.StripManager.GetById(5);

            List<Auteur> autDB = stripFromDb.Auteurs;
            List<Auteur> autTest = testStrip.Auteurs;
            
            Assert.IsTrue(stripFromDb.StripTitel == testStrip.StripTitel && stripFromDb.StripNr == testStrip.StripNr && stripFromDb.Reeks.ID == testStrip.Reeks.ID && stripFromDb.Uitgeverij.ID == testStrip.Uitgeverij.ID && autDB.SequenceEqual(autTest) == true);
        }
        [TestMethod]
        public void select_StripbyID_succes()
        {

            Reeks reeks = generalManager.ReeksManager.GetById(1);
            Auteur auteur = generalManager.AuteurManager.GetById(1);
            List<Auteur> auteurs = new List<Auteur>();
            auteurs.Add(auteur);
            Uitgeverij Uitgeverij = generalManager.UitgeverijManager.GetById(1);
            Strip testStrip = new Strip(1, "test1", 1, auteurs, reeks, Uitgeverij);
            Strip stripFromDb = generalManager.StripManager.GetById(testStrip.ID);

            List<Auteur> autDB = stripFromDb.Auteurs;
            List<Auteur> autTest = testStrip.Auteurs;

            Assert.IsTrue(stripFromDb.StripTitel == testStrip.StripTitel && stripFromDb.StripNr == testStrip.StripNr && stripFromDb.Reeks.ID == testStrip.Reeks.ID && stripFromDb.Uitgeverij.ID == testStrip.Uitgeverij.ID && autDB.SequenceEqual(autTest) == true);
        }

        [TestMethod]

        public void select_StripByName_succes()
        {
            Reeks reeks = generalManager.ReeksManager.GetById(1);
            Auteur auteur = generalManager.AuteurManager.GetById(1);
            List<Auteur> auteurs = new List<Auteur>();
            auteurs.Add(auteur);
            Uitgeverij Uitgeverij = generalManager.UitgeverijManager.GetById(1);
            Strip testStrip = new Strip(1, "test1", 1, auteurs, reeks, Uitgeverij);
            Strip stripFromDb = generalManager.StripManager.GetByName(testStrip.StripTitel);
            
            List<Auteur> autDB = stripFromDb.Auteurs;
            List<Auteur> autTest = testStrip.Auteurs;

            Assert.IsTrue(stripFromDb.StripTitel == testStrip.StripTitel && stripFromDb.StripNr == testStrip.StripNr && stripFromDb.Reeks.ID == testStrip.Reeks.ID && stripFromDb.Uitgeverij.ID == testStrip.Uitgeverij.ID && autDB.SequenceEqual(autTest) == true);
        }
        [TestMethod]
        public void updateStrip_succesvol()
        {
            Strip og = generalManager.StripManager.GetById(4);
            og.StripTitel = "inserted test value";
            generalManager.StripManager.Update(og);
            Assert.AreEqual(og.StripTitel, "inserted test value");
        }

        [TestMethod]

        public void DeleteStrip_succesvol()
        {
            int begincount = generalManager.StripManager.GetAll().Count;
            Strip strip = generalManager.StripManager.GetById(4);
            generalManager.StripManager.Delete(strip);
            Assert.IsTrue(generalManager.StripManager.GetAll().Count == begincount - 1);
            Assert.ThrowsException<System.NullReferenceException>(() => generalManager.StripManager.GetById(4));
        }
    }
}