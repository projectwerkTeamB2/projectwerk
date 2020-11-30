using Businesslaag.Managers;
using Businesslaag.Models;
using Datalaag;
using Datalaag.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace integratieTests
{
    [TestClass]
    public class StripManager
    {
        GeneralManager generalManager = new GeneralManager(new StripRepository(DbFunctions.GetprojectwerkconnectionString()), new AuteurRepository(DbFunctions.GetprojectwerkconnectionString()), new ReeksRepository(DbFunctions.GetprojectwerkconnectionString()), new UitgeverijRepository(DbFunctions.GetprojectwerkconnectionString()), new StripCollectionRepository(DbFunctions.GetprojectwerkconnectionString()));

        [TestInitialize]
        public void Initialize()
        {
            Reeks reeks = generalManager.ReeksManager.GetById(4);
           
            Auteur auteur = generalManager.AuteurManager.GetById(4);

            List<Auteur> auteurs = new List<Auteur>();
            auteurs.Add(auteur);
            Uitgeverij Uitgeverij = generalManager.UitgeverijManager.GetById(4);

            Strip strip1 = new Strip(1, "test1", 1,auteurs,reeks,Uitgeverij) ;
            Strip strip2 = new Strip(2, "test2",2, auteurs, reeks, Uitgeverij);
            Strip strip3 = new Strip(3, "test3",3, auteurs, reeks, Uitgeverij);
            Strip strip4 = new Strip(4, "test4", 4, auteurs, reeks, Uitgeverij);

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
            auteurs.Add(generalManager.AuteurManager.GetById(4));
            Strip testStrip = new Strip(9999, "testStripTitel", 9999, auteurs, generalManager.ReeksManager.GetById(4), generalManager.UitgeverijManager.GetById(4));
            generalManager.StripManager.Add(testStrip);

            Strip stripFromDb = generalManager.StripManager.GetById(9999);
            Assert.AreEqual(testStrip, stripFromDb);
        }
        [TestMethod]
        public void select_StripbyID_succes()
        {

            Reeks reeks = new Reeks(4, "test");
            generalManager.ReeksManager.Add(reeks);
            Auteur auteur = new Auteur(4, "test");
            generalManager.AuteurManager.Add(auteur);
            List<Auteur> auteurs = new List<Auteur>();
            auteurs.Add(auteur);
            Uitgeverij Uitgeverij = new Uitgeverij(4, "Uitgeverij");
            generalManager.UitgeverijManager.Add(Uitgeverij);
            Strip expected = new Strip(1, "test1", 1, auteurs, reeks, Uitgeverij);
            Reeks gotten = generalManager.ReeksManager.GetById(expected.ID);
            Assert.AreEqual(expected, gotten);
        }

        [TestMethod]

        public void select_StripByName_succes()
        {
            Reeks reeks = generalManager.ReeksManager.GetById(4);
            Auteur auteur = generalManager.AuteurManager.GetById(4);
            List<Auteur> auteurs = new List<Auteur>();
            auteurs.Add(auteur);
            Uitgeverij Uitgeverij = generalManager.UitgeverijManager.GetById(4);
            Strip expected = new Strip(1, "test1", 1, auteurs, reeks, Uitgeverij);
            Strip gotten = generalManager.StripManager.GetByName(expected.StripTitel);
            Assert.AreEqual(expected, gotten);
        }
        [TestMethod]
        public void updateStrip_succesvol()
        {
            Strip og = generalManager.StripManager.GetById(9999);
            og.StripTitel = "inserted test value";
            generalManager.StripManager.Update(og);
            Assert.AreEqual(og.StripTitel, "inserted test value");
        }

        [TestMethod]

        public void DeleteStrip_succesvol()
        {
            int begincount = generalManager.StripManager.GetAll().Count;
            Strip strip = generalManager.StripManager.GetById(9999);
            generalManager.StripManager.Delete(strip);
            Assert.IsTrue(generalManager.StripManager.GetAll().Count == begincount - 1);
        }
    }
}