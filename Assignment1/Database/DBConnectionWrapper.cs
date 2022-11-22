using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment1.Database
{
    public class DBConnectionWrapper
    {

        private static readonly string server = "localhost";
        private readonly string database;
        private static readonly string username = "root";
        private static readonly uint port= 3308;
       private static readonly string password = "Dalia-7100";

        private MySqlConnection connection = null;

        public DBConnectionWrapper(string database)
        {
            this.database = database;
        }

        public MySqlConnection InitializeConnection()
        {
            MySqlBaseConnectionStringBuilder connString = new MySqlConnectionStringBuilder();
            connString.Server = server;
           connString.Port = port;
            connString.Database = database;
            connString.UserID = username;
            connString.Password = password;
            connString.SslMode = MySqlSslMode.Preferred;

            connection = new MySqlConnection(connString.ToString());
            return connection;
        }

        public MySqlConnection GetConnection()
        {
            return connection;
        }

    }
}
