using Businesslaag.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTests.modelTests
{
    /// <summary>
    ///
    /// </summary>
    /// 
    [TestClass]
    public class StripTest
    {
        [TestMethod]
        public void CreateStrip_Empty_Title_ThrowsArgumentException() {
            List<Auteur> lA = new List<Auteur> { new Auteur("test") };
            Strip s;
            Assert.ThrowsException<System.ArgumentException>(() => s = new Strip(1, "", 1, lA, new Reeks("test"), new Uitgeverij("test")));
        }

        [TestMethod]
        public void CreateStrip_Empty_AuteurList_ThrowsArgumentException() {
            List<Auteur> lA = new List<Auteur>();
            Strip s;
            Assert.ThrowsException<System.ArgumentException>(() => s = new Strip(1, "Test", 1,  lA, new Reeks("Test"), new Uitgeverij("Test")));
        }

        [TestMethod]
        public void Add_Auteur_ToStrip_Double_ThrowsArgumentException() {
            List<Auteur> lA = new List<Auteur> { new Auteur(1, "test") };
            Strip s = new Strip(1, "Test", 1, lA, new Reeks("test"), new Uitgeverij("test"));
            Assert.ThrowsException<System.ArgumentException>(() => s.addAuteur(new Auteur(1, "test")));
        }

        [TestMethod]
        public void Add_Auteurs_ToStripµ_Double_ShouldThrowArgumentException() {
            List<Auteur> lA = new List<Auteur> { new Auteur(1, "test") };
            Strip s = new Strip(1, "Test", 1, lA, new Reeks("test"), new Uitgeverij("test"));
            List<Auteur> testL = new List<Auteur> { new Auteur(1, "test"), new Auteur(2, "test32") };
            Assert.ThrowsException<System.ArgumentException>(() => s.addAuteurs(testL));
        }
    }
}