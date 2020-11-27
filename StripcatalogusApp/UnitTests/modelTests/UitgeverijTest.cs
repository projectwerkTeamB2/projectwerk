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
    public class UitgeverijTest
    {
        [TestMethod]
        public void CreateUitgeverijWithId_Empty_Name_ThrowsArgumentException() {
            Uitgeverij u;
            Assert.ThrowsException<System.ArgumentException>(() => u = new Uitgeverij(1, ""));
        }

        [TestMethod]
        public void CreateUitgeverijNoId_Empty_Name_ThrowsArgumentException() {
            Uitgeverij u;
            Assert.ThrowsException<System.ArgumentException>(() => u = new Uitgeverij(""));
        }

    }
}