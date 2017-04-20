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

        /// <summary>
        /// Delete section from database
        /// </summary>
        /// <param name="id">Id of row</param>
        /// <param name="connection">Database connection</param>
        public static void Sections(string id, Connection connection)
        {
            // Database
            SqlConnection myConnection = connection.GetConnection();
            SqlCommand myCommand;
            string sql;

            // Delete Scenarios-Sections Connections
            sql = "DELETE FROM [Scenarios_Sections] WHERE [ID_Section] = " + id;
            myCommand = new SqlCommand(sql, myConnection);
            myCommand.ExecuteNonQuery();

            // Delete Section Translations
            sql = "DELETE FROM [Sections_Translation] WHERE [ID_Section] = " + id;
            myCommand = new SqlCommand(sql, myConnection);
            myCommand.ExecuteNonQuery();

            // Delete Section
            sql = "DELETE FROM [Sections] WHERE [ID_Section] = " + id;
            myCommand = new SqlCommand(sql, myConnection);
            myCommand.ExecuteNonQuery();
        }

        /// <summary>
        /// Delete checkPoint from database
        /// </summary>
        /// <param name="id">Id of row</param>
        /// <param name="connection">Database connection</param>
        public static void CheckPoint(string id, Connection connection)
        {
            // Database
            SqlConnection myConnection = connection.GetConnection();
            SqlCommand myCommand;
            string sql;

            // Delete Scenarios-Sections Connections
            sql = "DELETE FROM [Scenarios_Sections] WHERE [ID_CheckPoint] = " + id;
            myCommand = new SqlCommand(sql, myConnection);
            myCommand.ExecuteNonQuery();

            // Delete CheckPoints_Operations Connections
            sql = "DELETE FROM [CheckPoints_Operations] WHERE [ID_CheckPoint] = " + id;
            myCommand = new SqlCommand(sql, myConnection);
            myCommand.ExecuteNonQuery();

            // Delete CheckPoint Translations
            sql = "DELETE FROM [CheckPoints_Translation] WHERE [ID_CheckPoint] = " + id;
            myCommand = new SqlCommand(sql, myConnection);
            myCommand.ExecuteNonQuery();

            // Delete CheckPoint
            sql = "DELETE FROM [CheckPoints] WHERE [ID_CheckPoint] = " + id;
            myCommand = new SqlCommand(sql, myConnection);
            myCommand.ExecuteNonQuery();
        }

        /// <summary>
        /// Delete operation from database
        /// </summary>
        /// <param name="id">Id of row</param>
        /// <param name="connection">Database connection</param>
        public static void Operation(string id, Connection connection)
        {
            // Database
            SqlConnection myConnection = connection.GetConnection();
            SqlCommand myCommand;
            string sql;

            // Delete CheckPoints_Operations Connections
            sql = "DELETE FROM [CheckPoints_Operations] WHERE [ID_Operation] = " + id;
            myCommand = new SqlCommand(sql, myConnection);
            myCommand.ExecuteNonQuery();

            // Delete Operation Translations
            sql = "DELETE FROM [Operations_Translation] WHERE [ID_Operation] = " + id;
            myCommand = new SqlCommand(sql, myConnection);
            myCommand.ExecuteNonQuery();

            // Delete Operation
            sql = "DELETE FROM [Operations] WHERE [ID_Operation] = " + id;
            myCommand = new SqlCommand(sql, myConnection);
            myCommand.ExecuteNonQuery();
        }

        /// <summary>
        /// Delete CheckPoints_Operation connection from database
        /// </summary>
        /// <param name="id_CheckPoint">Id of parent</param>
        /// <param name="id_Operation">Id of child</param>
        /// <param name="order_Number">Order number of child in parent</param>
        /// <param name="connection">Database connection</param>
        public static void CheckPoints_Operations(int id_CheckPoint, int id_Operation, int order_Number, Connection connection)
        {
            // Database
            SqlConnection myConnection = connection.GetConnection();
            SqlCommand myCommand;
            string sql;

            // Delete CheckPoints_Operations Connections
            sql = "DELETE FROM [CheckPoints_Operations] WHERE [ID_CheckPoint] = " + id_CheckPoint;
            sql += " AND [ID_Operation] = " + id_Operation + " AND [Order_Number] = " + order_Number;
            myCommand = new SqlCommand(sql, myConnection);
            myCommand.ExecuteNonQuery();
        }

        /// <summary>
        /// Delete Scenarios_Sections connection from database
        /// </summary>
        /// <param name="id_Scenario">Id of parent</param>
        /// <param name="id_Section">Id of child</param>
        /// <param name="id_CheckPoint">Id of child of child</param>
        /// <param name="order_Number">Order number of child in parent</param>
        /// <param name="connection">Database connection</param>
        public static void Scenarios_Sections(int id_Scenario, int id_Section, int id_CheckPoint, int order_Number, Connection connection)
        {
            // Database
            SqlConnection myConnection = connection.GetConnection();
            SqlCommand myCommand;
            string sql;

            // Delete CheckPoints_Operations Connections
            sql = "DELETE FROM [Scenarios_Sections] WHERE [ID_Scenario] = " + id_Scenario;
            sql += " AND [ID_Section] = " + id_Section + " AND [ID_CheckPoint] = " + id_CheckPoint;
            sql += " AND [Order_Number] = " + order_Number;
            myCommand = new SqlCommand(sql, myConnection);
            myCommand.ExecuteNonQuery();
        }
    }
}
