using Npgsql;
using System.Configuration;
using System.Data;

namespace MyFace.DataAccess
{
    public static class ConnectionHelper
    {
        public static IDbConnection CreateSqlConnection()
        {
            return new NpgsqlConnection(ConfigurationManager.ConnectionStrings["MyPostgres"].ConnectionString);
        }
    }
}
