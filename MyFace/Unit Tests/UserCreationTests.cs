using NUnit.Framework;
using System;
using MyFace.DataAccess;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dapper;

namespace MyFace.Unit_Tests
{
    [TestFixture]
    public class UserCreationTests
    {
        [Test]
        public void CreateUser()
        {
            using (var db = ConnectionHelper.CreateSqlConnection())
            {
                db.Execute("INSERT INTO \"Users\" (username, password, fullname) VALUES(\"Jonh49\", \"Jam421\", \"John Squarepants\")");
                var user = db.Query<string>("SELECT \"UserName\" FROM \"Users\"");

                Assert.AreEqual("John41", user);

                // Delete them from the table 
                db.Execute("DELETE FROM \"Users\" WHERE \"UserName\" = \"John49\"");
            }
        }
    }
}