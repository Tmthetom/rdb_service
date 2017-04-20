using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace Service.Database_Operation
{
    class Update
    {
        /// <summary>
        /// Update scenario in database
        /// </summary>
        /// <param name="id">Id of row</param>
        /// <param name="language_Code">Language of description</param>
        /// <param name="name">New description</param>
        /// <param name="connection">Database connection</param>
        public static void Scenario(string id, string language_Code, string name, Connection connection)
        {
            // Database
            SqlConnection myConnection = connection.GetConnection();
            SqlCommand myCommand;

            // Update
            string sql = "UPDATE [Scenarios_Translation] SET [Name] = '" + name + "' WHERE [ID_Scenario] = " + id + " AND [Language_Code] = '" + language_Code + "'";
            myCommand = new SqlCommand(sql, myConnection);
            myCommand.ExecuteNonQuery();
        }

        /// <summary>
        /// Update section in database
        /// </summary>
        /// <param name="id">Id of row</param>
        /// <param name="language_Code">Language of description</param>
        /// <param name="name">New description</param>
        /// <param name="connection">Database connection</param>
        public static void Section(string id, string language_Code, string name, Connection connection)
        {
            // Database
            SqlConnection myConnection = connection.GetConnection();
            SqlCommand myCommand;

            // Update
            string sql = "UPDATE [Sections_Translation] SET [Name] = '" + name + "' WHERE [ID_Section] = " + id + " AND [Language_Code] = '" + language_Code + "'";
            myCommand = new SqlCommand(sql, myConnection);
            myCommand.ExecuteNonQuery();
        }

        /// <summary>
        /// Update checkPoint in database
        /// </summary>
        /// <param name="id">Id of row</param>
        /// <param name="language_Code">Language of description</param>
        /// <param name="name">New description</param>
        /// <param name="connection">Database connection</param>
        public static void CheckPoint(string id, string language_Code, string name, Connection connection)
        {
            // Database
            SqlConnection myConnection = connection.GetConnection();
            SqlCommand myCommand;

            // Update
            string sql = "UPDATE [CheckPoints_Translation] SET [Name] = '" + name + "' WHERE [ID_CheckPoint] = " + id + " AND [Language_Code] = '" + language_Code + "'";
            myCommand = new SqlCommand(sql, myConnection);
            myCommand.ExecuteNonQuery();
        }

        /// <summary>
        /// Update operation in database
        /// </summary>
        /// <param name="id">Id of row</param>
        /// <param name="language_Code">Language of description</param>
        /// <param name="name">New description</param>
        /// <param name="connection">Database connection</param>
        public static void Operation(string id, string language_Code, string name, Connection connection)
        {
            // Database
            SqlConnection myConnection = connection.GetConnection();
            SqlCommand myCommand;

            // Update
            string sql = "UPDATE [Operations_Translation] SET [Name] = '" + name + "' WHERE [ID_Operation] = " + id + " AND [Language_Code] = '" + language_Code + "'";
            myCommand = new SqlCommand(sql, myConnection);
            myCommand.ExecuteNonQuery();
        }
    }
}
