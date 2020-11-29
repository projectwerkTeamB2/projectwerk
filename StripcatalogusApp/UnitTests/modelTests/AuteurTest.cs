using Businesslaag.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests.modelTests
{
    //Hier komen alle testen van business en data laag
    [TestClass]
    public class AuteurTest
    {
        [TestMethod]
        public void CreateAuteur_NoName_ShouldThrowError() {
            Auteur auteur;
            Assert.ThrowsException<System.ArgumentException>(() => auteur = new Auteur(1, ""));
        }

        [TestMethod]
        public void CreateAuteur_NoName_OnlyName_ArgumentException() {
            Auteur auteur;
            Assert.ThrowsException<System.ArgumentException>(() => auteur = new Auteur(""));
        }
    }  
}

