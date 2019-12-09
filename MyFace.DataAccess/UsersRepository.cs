using Dapper;
using System.Collections.Generic;

namespace MyFace.DataAccess
{
    public interface IUserRepository
    {
        IEnumerable<Users> GetAllUsers();
        IEnumerable<string> GetFullName();
    }

    public class UserRepository : IUserRepository
    {

        public IEnumerable<Users> GetAllUsers()
        {
            using (var db = ConnectionHelper.CreateSqlConnection())
            {
                //TODO Fetch user list from user table instead of from posts and senders.
                return db.Query<Users>("SELECT * FROM \"Users\"");
            }
        }
        public IEnumerable<string> GetFullName()
        {
            using (var db = ConnectionHelper.CreateSqlConnection())
            {
                //TODO Fetch user list from user table instead of from posts and senders.
                return db.Query<string>("SELECT \"fullname\" FROM \"Users\"");
            }
        }
    }
}
