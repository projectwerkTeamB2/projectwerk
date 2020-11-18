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
        private GeneralManager generalManager = new GeneralManager(new StripRepository(DbFunctions.GetprojectwerkconnectionString()), new AuteurRepository(DbFunctions.GetprojectwerkconnectionString()), new ReeksRepository(DbFunctions.GetprojectwerkconnectionString()), new UitgeverijRepository(DbFunctions.GetprojectwerkconnectionString()));

        [TestMethod]
        public void Create_Reeks_No_Error() {
            Reeks testReeks = new Reeks(9999, "testReeks");
            generalManager.ReeksManager.Add(testReeks);

            Reeks reeksFromDb = generalManager.ReeksManager.GetById(9999);

            Assert.AreEqual(testReeks, reeksFromDb);
        }
    }
}
