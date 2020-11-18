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
        private GeneralManager generalManager = new GeneralManager(new StripRepository(DbFunctions.GetprojectwerkconnectionString()), new AuteurRepository(DbFunctions.GetprojectwerkconnectionString()), new ReeksRepository(DbFunctions.GetprojectwerkconnectionString()), new UitgeverijRepository(DbFunctions.GetprojectwerkconnectionString()));

        [TestMethod]
        public void Create_Uitgeverij_No_Error() {
            Uitgeverij testUitgeverij = new Uitgeverij(9999, "testUitgeverij");
            generalManager.UitgeverijManager.Add(testUitgeverij);

            Uitgeverij uitgeverijFromDb = generalManager.UitgeverijManager.GetById(9999);

            Assert.AreEqual(testUitgeverij, uitgeverijFromDb);
        }

    }
}
