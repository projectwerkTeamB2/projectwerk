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
       
        [TestMethod]
       
        public void StripManagerShouldAddStrip()
        {
            GeneralManager generalManager = new GeneralManager(new StripRepository(DbFunctions.GetprojectwerkconnectionString()), new AuteurRepository(DbFunctions.GetprojectwerkconnectionString()), new ReeksRepository(DbFunctions.GetprojectwerkconnectionString()), new UitgeverijRepository(DbFunctions.GetprojectwerkconnectionString()));
           int count = generalManager.StripManager.GetAll().Count;
            Auteur a1 = generalManager.AuteurManager.GetById(1);
            Auteur a2 = generalManager.AuteurManager.GetById(2);
            List<Auteur> auteurs = new List<Auteur>();
            auteurs.Add(a1);
            auteurs.Add(a2);
            Reeks reeks = generalManager.ReeksManager.GetById(1);
            Uitgeverij Uitgeverij = generalManager.UitgeverijManager.GetById(1);
            Strip strip = new Strip(9999, "teststrip", 1, auteurs, reeks, Uitgeverij) ;
            generalManager.StripManager.Add(strip);
            int newcount = generalManager.StripManager.GetAll().Count;
            Assert.IsTrue(newcount == count + 1);

            Strip stripFromDb = generalManager.StripManager.GetById(9999);
            Assert.AreEqual(stripFromDb, strip); 
        }
    }
}
