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
    public class ReeksTest
    {
        [TestMethod]
        public void CreateReeksWithId_Empty_Name_ThrowsArgumentException() {
            Reeks r;
            Assert.ThrowsException<System.ArgumentException>(() => r = new Reeks(1, ""));
        }

        [TestMethod]
        public void CreateReeksNoId_Empty_Name_ThrowsArgumentException() {
            Reeks r;
            Assert.ThrowsException<System.ArgumentException>(() => r = new Reeks(""));
        }

    }
}