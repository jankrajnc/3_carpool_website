using Npgsql;

namespace DataAccess
{

    public class PostgresConnector
    {



        private NpgsqlConnection conn;

        public PostgresConnector(PostgresConnectorOptions options)
        {
            conn = new NpgsqlConnection(options.connString);
        }

        public void OpenConnection()
        {
            conn.Open();
        }

        public void CloseConnection()
        {
            conn.Close();
        }

        public void ExecuteNonQuery(string sql)
        {
            OpenConnection();
            cmd = new NpgsqlCommand(sql, conn);
            cmd.ExecuteNonQuery();
            CloseConnection();
        }

        public NpgsqlDataReader ExecuteQuery(string sql)
        {
            OpenConnection();
            cmd = new NpgsqlCommand(sql, conn);
            NpgsqlDataReader reader = cmd.ExecuteReader();
            return reader;
        }

    }
}