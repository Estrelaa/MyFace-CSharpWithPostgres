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
        public void  AddUserToSite(string UserName, string PassWord, string FullName)
        {
            using (var db = ConnectionHelper.CreateSqlConnection())
            {
                db.Execute("INSERT INTO \"Users\" (username, password, fullname) VALUES(@UserName, @PassWord, @FullName)", new { UserName, PassWord, FullName } );
            }
        }
    }
}
