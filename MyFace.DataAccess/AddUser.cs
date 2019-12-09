using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFace.DataAccess
{
    public class AddUser
    {
        public IEnumerable<string> AddUserToSite(string UserName, string PassWord, string FullName)
        {
            using (var db = ConnectionHelper.CreateSqlConnection())
            {
                //TODO Fetch user list from user table instead of from posts and senders.
                return db.Query<string>("(SELECT DISTINCT recipient FROM posts) UNION (SELECT DISTINCT sender FROM posts)");
            }
        }
    }
}
