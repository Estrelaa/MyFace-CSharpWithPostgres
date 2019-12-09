using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Configuration;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Npgsql;

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
