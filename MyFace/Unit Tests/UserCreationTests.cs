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
                var userName = "John49";
                var password = "Jam421";
                var fullName = "John Squarepants";

                db.Execute("INSERT INTO \"Users\" (username, password, fullname) VALUES(@userName, @password, @fullName)", new { userName, password, fullName });
                var user = db.Query<string>("SELECT \"username\" FROM \"Users\"");

                foreach (var person in user.Reverse())
                {
                    Assert.AreEqual("John49", person);
                    break;
                }

                // Delete them from the table 
                db.Execute("DELETE FROM \"Users\" WHERE \"username\" = @userName", new { userName });
            }
        }
    }
}