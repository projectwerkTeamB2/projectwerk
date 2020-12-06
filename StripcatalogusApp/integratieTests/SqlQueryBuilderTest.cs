using Datalaag;
using Datalaag.Models;
using DataLayer.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
            var sqlQueryB = new SqlQueryBuilder<StripDB>(s);
            var test = sqlQueryB.GetInsertCommand();
            //assert dat Checkt of het een SQlcommand teruggeeft
            Assert.IsInstanceOfType(test, typeof(SqlCommand));
        }
        //
        [TestMethod]
        public void GetInsertTest_CheckString() {
            List<AuteurDB> aut = new List<AuteurDB>();
            aut.Add(new AuteurDB("test"));
            aut.Add(new AuteurDB("test2"));
            StripDB s = new StripDB(1, "Test", 1, aut, new ReeksDB("test"), new UitgeverijDB("test"));
            var sqlQueryB = new SqlQueryBuilder<StripDB>(s);
            var test = sqlQueryB.GetInsertCommand();
            Assert.IsTrue(test.CommandText.Contains("INSERT"));
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
            List<AuteurDB> auteurDBs = new List<AuteurDB>();
            auteurDBs.Add(new AuteurDB("test"));
            StripDB s = new StripDB(1, "test", 1, auteurDBs, new ReeksDB("test"), new UitgeverijDB("test"));
            var Sql = new SqlQueryBuilder<StripDB>(s);
            var test = Sql.GetUpdateCommand();
            Assert.IsInstanceOfType(test, typeof(SqlCommand));
        }
        [TestMethod]
        public void GetUpdateCommand_CheckString() {
            List<AuteurDB> aut = new List<AuteurDB>();
            aut.Add(new AuteurDB("test"));
            aut.Add(new AuteurDB("test2"));
            StripDB s = new StripDB(1, "Test", 1, aut, new ReeksDB("test"), new UitgeverijDB("test"));
            var sqlQueryB = new SqlQueryBuilder<StripDB>(s);
            var test = sqlQueryB.GetUpdateCommand();
            Assert.IsTrue(test.CommandText.Contains("UPDATE"));
        }
        #endregion

        #region Delete
        [TestMethod]
        public void GetDeleteCommand_ThrowsException() {
            StripDB s = new StripDB();
            var sqlB = new SqlQueryBuilder<StripDB>(s);
            Assert.ThrowsException<System.Exception>(() => ExecuteCommand(sqlB.GetDeleteCommand()));
        }

        [TestMethod]
        public void GetDeleteCommand_CheckIfInstanceOfSqlCommand() {
            List<AuteurDB> aut = new List<AuteurDB>();
            aut.Add(new AuteurDB("test"));
            aut.Add(new AuteurDB("test2"));
            StripDB s = new StripDB(1, "Test", 1, aut, new ReeksDB("test"), new UitgeverijDB("test"));
            var sqlQueryB = new SqlQueryBuilder<StripDB>(s);
            var test = sqlQueryB.GetDeleteCommand();
            //assert dat Checkt of het een SQlcommand teruggeeft
            Assert.IsInstanceOfType(test, typeof(SqlCommand));
        }

        [TestMethod]
        public void GetDeleteCommand_CheckString() {
            List<AuteurDB> aut = new List<AuteurDB>();
            aut.Add(new AuteurDB("test"));
            aut.Add(new AuteurDB("test2"));
            StripDB s = new StripDB(1, "Test", 1, aut, new ReeksDB("test"), new UitgeverijDB("test"));
            var sqlQueryB = new SqlQueryBuilder<StripDB>(s);
            var test = sqlQueryB.GetInsertCommand();
            //assert dat Checkt of het een SQlcommand teruggeeft
            Assert.IsTrue(test.CommandText.Contains("DELETE"));
        }
        #endregion
    }
}
