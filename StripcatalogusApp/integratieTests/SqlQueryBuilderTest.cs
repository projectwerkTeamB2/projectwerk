using Datalaag;
using Datalaag.Models;
using DataLayer.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace integratieTests {
    [TestClass]
    class SqlQueryBuilderTest : CRUDRepository<StripDB> {
        public SqlQueryBuilderTest(string connectionString)
   : base(connectionString) {
        }

        #region insertTests
        [TestMethod]
        public void GetInsertTest_Throws_Error() {
            StripDB s = new StripDB();
            var sqlQueryB = new SqlQueryBuilder<StripDB>(s);
            Assert.ThrowsException<System.Exception>(() => ExecuteCommand(sqlQueryB.GetInsertCommand()));
        }

        [TestMethod]
        public void GetInsertTest_ReturnSqlCommand() {
            List<AuteurDB> aut = new List<AuteurDB>();
            aut.Add(new AuteurDB("test"));
            aut.Add(new AuteurDB("test2"));
            StripDB s = new StripDB(1, "Test", 1, aut, new ReeksDB("test"), new UitgeverijDB("test"));

            //assert dat Checkt of het een SQlcommand teruggeeft
        }
        #endregion

        #region Update
        [TestMethod]
        public void GetUpdateTest_Throws_Error() {
            StripDB s = new StripDB();
            var sqlQueryB = new SqlQueryBuilder<StripDB>(s);
            Assert.ThrowsException<System.Exception>(() => ExecuteCommand(sqlQueryB.GetUpdateCommand()));
        }

        [TestMethod]
        public void GetUpdateCommand_ReturnSqlCommand() {

        }
        #endregion
    }
}
