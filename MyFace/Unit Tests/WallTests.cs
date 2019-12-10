using Dapper;
using MyFace.DataAccess;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/* Due to how the controllers work, something which i have no idea on
 * the tests are done by directly talking to the database. This means
 * that the test are more towards the DB and Functions outside of the
 * controllers.
 */

namespace MyFace.Unit_Tests
{
    [TestFixture]
    public class WallTests
    {
        [Test]
        public void CheckThatThePostDBExist()
        {
            using (var db = ConnectionHelper.CreateSqlConnection())
            {
                db.Query<string>("SELECT * FROM \"posts\"");
                Assert.Pass();
            }
        }
        [Test]
        public void AddAPostToTheWall()
        {
            using (var db = ConnectionHelper.CreateSqlConnection())
            {
                var Sender = "James";
                var Recipent = "Sam";
                var Content = "This is a post on the wall";

                //db.Execute("INSERT INTO \"posts\" (Sender, Recipent, Content) VALUES(@Sender, @Recipent, @Content)", new { Sender, Recipent, Content });

                var Posts = db.Query<string>("SELECT * FROM \"posts\"");

                // If post is found
                    // test passes
                // if not found
                    // test fails
            }
        }
    }
}
