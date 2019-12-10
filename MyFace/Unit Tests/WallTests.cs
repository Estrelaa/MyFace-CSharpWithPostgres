using Dapper;
using MyFace.DataAccess;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyFace.Unit_Tests
{
    [TestFixture]
    public class WallTests
    {
        [Test]
        public void CreateAPostInTheDatabase()
        {
            using (var db = ConnectionHelper.CreateSqlConnection())
            {
                Assert.IsNotNull(db.Query<string>("SELECT * FROM \"Posts\""));
            }
        }
    }
}
