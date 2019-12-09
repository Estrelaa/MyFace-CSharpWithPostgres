using Dapper;
using MyFace.DataAccess;
using NUnit.Framework;
using System.Linq;

namespace MyFace.Unit_Tests
{
    [TestFixture]
    public class PasswordTests
    {
        [Test]
        public void PasswordForNewUserShouldBeHashed()
        {
            using (var db = ConnectionHelper.CreateSqlConnection())
            {
                var userName = "John49";
                var password = "Jam421";
                var fullName = "John Squarepants";
                HashPassword hashpassword = new HashPassword();
                password = hashpassword.Hashpassword(password);

                db.Execute("INSERT INTO \"Users\" (username, password, fullname) VALUES(@userName, @password, @fullName)", new { userName, password, fullName });
                var user = db.Query<string>("SELECT \"password\" FROM \"Users\"");

                foreach (var person in user.Reverse())
                {
                    Assert.AreNotEqual("Jam421", person);
                    break;
                }

                // Delete them from the table 
                db.Execute("DELETE FROM \"Users\" WHERE \"username\" = @userName", new { userName });
            }
        }
        [Test]
        public void CanCheckThatPasswordGivenIsSameAsHashedPassword()
        {
            using (var db = ConnectionHelper.CreateSqlConnection())
            {
                var userName = "John49";
                var password = "Jam421";
                var fullName = "John Squarepants";

                HashPassword hashpassword = new HashPassword();
                var passwordHashed = hashpassword.Hashpassword(password);
                var hashpasswordThatWillbeChecked = hashpassword.Hashpassword(password);

                db.Execute("INSERT INTO \"Users\" (username, password, fullname) VALUES(@userName, @passwordHashed, @fullName)", new { userName, passwordHashed, fullName });
                var user = db.Query<string>("SELECT \"password\" FROM \"Users\"");

                try
                {
                    foreach (var person in user.Reverse())
                    {
                        Assert.IsTrue(hashpassword.CovertPasswordBack(person, password));
                        break;
                    }
                }
                finally
                {
                    // Delete them from the table 
                    db.Execute("DELETE FROM \"Users\" WHERE \"username\" = @userName", new { userName });
                }
            }
        }
    }
}