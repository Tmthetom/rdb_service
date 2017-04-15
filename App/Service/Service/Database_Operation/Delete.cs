using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace Service.Database_Operation
{
    class Delete
    {
        /// <summary>
        /// Delete scenario from database
        /// </summary>
        /// <param name="id">Id of row</param>
        /// <param name="connection">Database connection</param>
        public static void Scenario(string id, Connection connection)
        {
            // Database
            SqlConnection myConnection = connection.GetConnection();
            SqlCommand myCommand;
            string sql;

            // Delete Scenarios-Sections Connections
            sql = "DELETE FROM [Scenarios_Sections] WHERE [ID_Scenario] = " + id;
            myCommand = new SqlCommand(sql, myConnection);
            myCommand.ExecuteNonQuery();

            // Delete Scenario Translations
            sql = "DELETE FROM [Scenarios_Translation] WHERE [ID_Scenario] = " + id;
            myCommand = new SqlCommand(sql, myConnection);
            myCommand.ExecuteNonQuery();

            // Delete Scenario
            sql = "DELETE FROM [Scenarios] WHERE [ID_Scenario] = " + id;
            myCommand = new SqlCommand(sql, myConnection);
            myCommand.ExecuteNonQuery();
        }
    }
}
