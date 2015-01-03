using System.Data.Entity;

namespace EasyBoni.Models.MySQL
{
    public class MySqlConfiguration : DbConfiguration
    {
        public MySqlConfiguration()
        {
            SetHistoryContext(
                "MySql.Data.MySqlClient",
                (conn, schema) => new MySqlHistoryContext(conn, schema));
        }
    }
}