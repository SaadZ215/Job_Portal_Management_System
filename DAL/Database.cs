using Microsoft.Data.Sqlite;

namespace PROJECTS_API.DAL
{
    public static class Database
    {
        public static string ConnectionString =
            "Data Source=Data/jobportal.db";

        public static SqliteConnection GetConnection()
        {
            var conn = new SqliteConnection(ConnectionString);

            conn.Open();

            return conn;
        }
    }
}
