using Dapper;

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
