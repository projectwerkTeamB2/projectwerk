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
    public class UitgeverijManager {
        GeneralManager generalManager = new GeneralManager(new StripRepository(DbFunctions.GetprojectwerkconnectionString()), new AuteurRepository(DbFunctions.GetprojectwerkconnectionString()), new ReeksRepository(DbFunctions.GetprojectwerkconnectionString()), new UitgeverijRepository(DbFunctions.GetprojectwerkconnectionString()));

        [TestInitialize]
        public void Initialize()
        {
            Initialize i = new Initialize();
            i.ClearDB();
            Uitgeverij Uitgeverij1 = new Uitgeverij(1, "Uitgeverij1");
            Uitgeverij Uitgeverij2 = new Uitgeverij(2, "Uitgeverij2");
            Uitgeverij Uitgeverij3 = new Uitgeverij(3, "Uitgeverij3");
            Uitgeverij Uitgeverij4 = new Uitgeverij(4, "Uitgeverij4");
            generalManager.UitgeverijManager.Add(Uitgeverij1);
            generalManager.UitgeverijManager.Add(Uitgeverij2);
            generalManager.UitgeverijManager.Add(Uitgeverij3);
            generalManager.UitgeverijManager.Add(Uitgeverij4);

        }

        [TestMethod]
        public void select_allUitgeverij_succes()
        {
            int expected = 4;
            List<Uitgeverij> gotten = generalManager.UitgeverijManager.GetAll();
            Assert.AreEqual(expected, gotten.Count);
        }

        [TestMethod]
        public void Add_Uitgeverij_No_Error()
        {
            Uitgeverij testUitgeverij = new Uitgeverij(9999, "testuitgeverij");
            generalManager.UitgeverijManager.Add(testUitgeverij);

            Uitgeverij reeksFromDb = generalManager.UitgeverijManager.GetById(9999);
            Assert.AreEqual(testUitgeverij, reeksFromDb);
        }
        [TestMethod]
        public void select_uitgeverijbyID_succes()
        {
            Uitgeverij expected = new Uitgeverij(4, "Uitgeverij4");
            Uitgeverij gotten = generalManager.UitgeverijManager.GetById(expected.ID);
            Assert.AreEqual(expected, gotten);
        }

        [TestMethod]

        public void select_uitgeverijByName_succes()
        {
            Uitgeverij expected = new Uitgeverij(4, "Uitgeverij4");
            Uitgeverij gotten = generalManager.UitgeverijManager.GetByName(expected.Naam);
            Assert.AreEqual(expected, gotten);
        }
        [TestMethod]
        public void updateUitgeverij_succesvol()
        {
            Uitgeverij og = generalManager.UitgeverijManager.GetById(4);
            og.Naam = "inserted test value";
            generalManager.UitgeverijManager.Update(og);
            Assert.AreEqual(og.Naam, "inserted test value");
        }

        [TestMethod]

        public void DeleteUitgeverij_succesvol()
        {
            int begincount = generalManager.UitgeverijManager.GetAll().Count;
            Uitgeverij uitgeverij = generalManager.UitgeverijManager.GetById(4);
            generalManager.UitgeverijManager.Delete(uitgeverij);
            Assert.IsTrue(generalManager.UitgeverijManager.GetAll().Count == begincount - 1);
        }
    }
}
