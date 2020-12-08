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
    public class ReeksManager {
        GeneralManager generalManager = new GeneralManager(new StripRepository(DbFunctions.GetprojectwerkconnectionString()), new AuteurRepository(DbFunctions.GetprojectwerkconnectionString()), new ReeksRepository(DbFunctions.GetprojectwerkconnectionString()), new UitgeverijRepository(DbFunctions.GetprojectwerkconnectionString()));

        [TestInitialize]
        public void Initialize()
        {
            Initialize i = new Initialize();
            i.ClearDB();
            Reeks reeks1 = new Reeks(1, "test1");
            Reeks reeks2 = new Reeks(2, "test2");
            Reeks reeks3 = new Reeks(3, "test3");
            Reeks reeks4 = new Reeks(4, "test4");
            generalManager.ReeksManager.Add(reeks1);
            generalManager.ReeksManager.Add(reeks2);
            generalManager.ReeksManager.Add(reeks3);
            generalManager.ReeksManager.Add(reeks4);

        }

        [TestMethod]
        public void select_allreeks_succes()
        {
            int expected = 4;
            List<Reeks> gotten = generalManager.ReeksManager.GetAll();
            Assert.AreEqual(expected, gotten.Count);
        }

        [TestMethod]
        public void Add_Reeks_No_Error()
        {
            Reeks testreeks = new Reeks(5, "testAdd");
            generalManager.ReeksManager.Add(testreeks);

            Reeks reeksFromDb = generalManager.ReeksManager.GetById(5);
            Assert.AreEqual(testreeks, reeksFromDb);
        }
        [TestMethod]
        public void select_reeksbyID_succes()
        {
            Reeks expected = new Reeks(1, "test1");
            Reeks gotten = generalManager.ReeksManager.GetById(expected.ID);
            Assert.AreEqual(expected, gotten);
        }

        [TestMethod]

        public void select_ReeksByName_succes()
        {
            Reeks expected = new Reeks(1, "test1");
            Reeks gotten = generalManager.ReeksManager.GetByName(expected.Naam);
            Assert.AreEqual(expected, gotten);
        }
        [TestMethod]
        public void updateReeks_succesvol()
        {
            Reeks og = generalManager.ReeksManager.GetById(1);
            og.Naam = "inserted test value";
            generalManager.ReeksManager.Update(og);
            Assert.AreEqual(og.Naam, "inserted test value");
        }

        [TestMethod]

        public void DeleteReeks_succesvol()
        {
            int begincount = generalManager.ReeksManager.GetAll().Count;
            Reeks reeks = generalManager.ReeksManager.GetById(1);
            generalManager.ReeksManager.Delete(reeks);
            Assert.IsTrue(generalManager.ReeksManager.GetAll().Count == begincount - 1);
        }


    }
}
