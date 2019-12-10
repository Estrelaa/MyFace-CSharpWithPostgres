using Dapper;
using System.Collections.Generic;

namespace MyFace.DataAccess
{
    public interface IUserRepository
    {
        IEnumerable<Users> GetAllUsers();
        string GetFullName(string UserName);
    }

    public class UserRepository : IUserRepository
    {

        public IEnumerable<Users> GetAllUsers()
        {
            using (var db = ConnectionHelper.CreateSqlConnection())
            {
                return db.Query<Users>("SELECT * FROM \"Users\"");
            }
        }
        public IEnumerable<Users> GetUser(string Username)
        {
            using (var db = ConnectionHelper.CreateSqlConnection())
            {
                return db.Query<Users>("SELECT * FROM \"Users\" WHERE \"username\" = @Username", new { Username });
            }
        }
        public string GetFullName(string UserName)
        {
            using (var db = ConnectionHelper.CreateSqlConnection())
            {
                var result = db.Query<string>("SELECT \"fullname\" FROM \"Users\" where \"username\" = @UserName", new { UserName }).AsList();

                foreach (var name in result)
                {
                    return name;
                }
                return result.ToString();
            }
        }
    }
}
