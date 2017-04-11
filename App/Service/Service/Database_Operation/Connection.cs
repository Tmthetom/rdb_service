using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Database_Operation
{
    class Connection
    {
        private SqlConnection connection;

        private string server = " Server = ";
        private string database = "; Database = ";
        private string user = "; User Id = ";
        private string pass = "; Password = ";

        /// <summary>
        /// Create new SQL connection without credentials
        /// </summary>
        /// <param name="serverAdress">Local or IP address</param>
        /// <param name="databaseName">Name of Database</param>
        public Connection(string serverAdress, string databaseName)
        {
            string connectionString = server + serverAdress + database + databaseName + ";";
            connection = new SqlConnection(connectionString);
            connection.Open();
        }

        /// <summary>
        /// Create new SQL connection with credentials
        /// </summary>
        /// <param name="serverAdress">Local or IP address</param>
        /// <param name="databaseName">Name of Database</param>
        /// <param name="username">Login username</param>
        /// <param name="password">Login password</param>
        public Connection(string serverAdress, string databaseName, string username, string password)
        {
            string connectionString = server + serverAdress + database + databaseName + user + username + pass + password + ";";
            connection = new SqlConnection(connectionString);
            connection.Open();
        }

        /// <summary>
        /// Open SqlConnection
        /// </summary>
        public void Open()
        {
            connection.Open();
        }

        /// <summary>
        /// Open SqlConnection
        /// </summary>
        public void Close()
        {
            connection.Close();
        }

        /// <summary>
        /// Return SqlConnection reference
        /// </summary>
        /// <returns></returns>
        public SqlConnection Get()
        {
            return connection;
        }
    }
}
