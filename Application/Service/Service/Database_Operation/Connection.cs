using System.Data.SqlClient;

namespace Service.Database_Operation
{
    class Connection
    {
        private SqlConnection connection;

        // Object default strings
        private string server = " Server = ";
        private string database = "; Database = ";
        private string user = "; User Id = ";
        private string pass = "; Password = ";
        private string trusted = "; Trusted_Connection = True";

        // Database information
        private string serverAddress;
        private string databaseName;

        /// <summary>
        /// Create new SQL connection without credentials
        /// </summary>
        /// <param name="serverAddress">Local or IP address</param>
        /// <param name="databaseName">Name of Database</param>
        public Connection(string serverAddress, string databaseName)
        {
            this.serverAddress = serverAddress;
            this.databaseName = databaseName;
            string connectionString = server + serverAddress + database + databaseName + trusted + ";";
            connection = new SqlConnection(connectionString);
            connection.Open();
        }

        /// <summary>
        /// Create new SQL connection with credentials
        /// </summary>
        /// <param name="serverAddress">Local or IP address</param>
        /// <param name="databaseName">Name of Database</param>
        /// <param name="username">Login username</param>
        /// <param name="password">Login password</param>
        public Connection(string serverAddress, string databaseName, string username, string password)
        {
            this.serverAddress = serverAddress;
            this.databaseName = databaseName;
            string connectionString = server + serverAddress + database + databaseName + user + username + pass + password + ";";
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
        /// <returns>SqlConnection with connection string in</returns>
        public SqlConnection GetConnection()
        {
            return connection;
        }

        /// <summary>
        /// Return current connected server address
        /// </summary>
        /// <returns>IP Adress or Local</returns>
        public string GetServerAddress()
        {
            return serverAddress;
        }

        /// <summary>
        /// Return current connected server address
        /// </summary>
        /// <returns>Database name</returns>
        public string GetDatabaseName()
        {
            return databaseName;
        }
    }
}
