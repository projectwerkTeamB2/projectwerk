using DataLayer.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace integratieTests {
    [TestClass]
    class CRUDRepoTest {
        //CRUDRepository crud = new CRUDRepository();
        [TestMethod]
        public void GetRecordTest() {
            string Command = "SELECT * FROM Auteur WHERE id = @id";


        }
    }
}
