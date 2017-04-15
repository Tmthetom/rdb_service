using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace Service.Database_Operation
{
    class Insert
    {
        /// <summary>
        /// Insert scenario into database
        /// </summary>
        /// <param name="language_Code">Language of description</param>
        /// <param name="name">New description</param>
        /// <param name="connection">Database connection</param>
        public static void Scenario(string language_Code, string name, Connection connection)
        {
            // Database
            SqlConnection myConnection = connection.GetConnection();
            SqlCommand myCommand;

            // SQL strings
            string identityON = "SET IDENTITY_INSERT Scenarios ON ";
            string identityOFF = " SET IDENTITY_INSERT Scenarios OFF";

            // Get all ids
            List<int> ids = new List<int>();
            using (myCommand = new SqlCommand("SELECT [ID_Scenario] FROM [Scenarios]", myConnection))
            {
                using (SqlDataReader reader = myCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ids.Add(reader.GetInt32(0));
                    }
                }
            }

            // Create new iID
            int id = ids.Max() + 1;

            // Insert scenario
            myCommand = new SqlCommand(identityON + "INSERT INTO [Scenarios] (ID_Scenario) VALUES (" + id + ")" + identityOFF, myConnection);
            myCommand.ExecuteNonQuery();

            // Insert default translation
            string sql = "INSERT INTO [Scenarios_Translation] (ID_Scenario, Language_Code, Name) VALUES (" + id + ", '" + language_Code + "', '" + name + "')";
            myCommand = new SqlCommand(identityON + sql + identityOFF, myConnection);
            myCommand.ExecuteNonQuery();
        }

        /// <summary>
        /// Insert section into database
        /// </summary>
        /// <param name="language_Code">Language of description</param>
        /// <param name="name">New description</param>
        /// <param name="connection">Database connection</param>
        public static void Section(string language_Code, string name, Connection connection)
        {
            // Database
            SqlConnection myConnection = connection.GetConnection();
            SqlCommand myCommand;

            // SQL strings
            string identityON = "SET IDENTITY_INSERT Sections ON ";
            string identityOFF = " SET IDENTITY_INSERT Sections OFF";

            // Get all ids
            List<int> ids = new List<int>();
            using (myCommand = new SqlCommand("SELECT [ID_Section] FROM [Sections]", myConnection))
            {
                using (SqlDataReader reader = myCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ids.Add(reader.GetInt32(0));
                    }
                }
            }

            // Create new iID
            int id = ids.Max() + 1;

            // Insert scenario
            myCommand = new SqlCommand(identityON + "INSERT INTO [Sections] (ID_Section) VALUES (" + id + ")" + identityOFF, myConnection);
            myCommand.ExecuteNonQuery();

            // Insert default translation
            string sql = "INSERT INTO [Sections_Translation] (ID_Section, Language_Code, Name) VALUES (" + id + ", '" + language_Code + "', '" + name + "')";
            myCommand = new SqlCommand(identityON + sql + identityOFF, myConnection);
            myCommand.ExecuteNonQuery();
        }

        /// <summary>
        /// Insert checkPoint into database
        /// </summary>
        /// <param name="language_Code">Language of description</param>
        /// <param name="name">New description</param>
        /// <param name="connection">Database connection</param>
        public static void CheckPoint(string language_Code, string name, Connection connection)
        {
            // Database
            SqlConnection myConnection = connection.GetConnection();
            SqlCommand myCommand;

            // SQL strings
            string identityON = "SET IDENTITY_INSERT CheckPoints ON ";
            string identityOFF = " SET IDENTITY_INSERT CheckPoints OFF";

            // Get all ids
            List<int> ids = new List<int>();
            using (myCommand = new SqlCommand("SELECT [ID_CheckPoint] FROM [CheckPoints]", myConnection))
            {
                using (SqlDataReader reader = myCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ids.Add(reader.GetInt32(0));
                    }
                }
            }

            // Create new iID
            int id = ids.Max() + 1;

            // Insert scenario
            myCommand = new SqlCommand(identityON + "INSERT INTO [CheckPoints] (ID_CheckPoint) VALUES (" + id + ")" + identityOFF, myConnection);
            myCommand.ExecuteNonQuery();

            // Insert default translation
            string sql = "INSERT INTO [CheckPoints_Translation] (ID_CheckPoint, Language_Code, Name) VALUES (" + id + ", '" + language_Code + "', '" + name + "')";
            myCommand = new SqlCommand(identityON + sql + identityOFF, myConnection);
            myCommand.ExecuteNonQuery();
        }

        /// <summary>
        /// Insert operation into database
        /// </summary>
        /// <param name="language_Code">Language of description</param>
        /// <param name="name">New description</param>
        /// <param name="connection">Database connection</param>
        public static void Operation(string language_Code, string name, Connection connection)
        {
            // Database
            SqlConnection myConnection = connection.GetConnection();
            SqlCommand myCommand;

            // SQL strings
            string identityON = "SET IDENTITY_INSERT Operations ON ";
            string identityOFF = " SET IDENTITY_INSERT Operations OFF";

            // Get all ids
            List<int> ids = new List<int>();
            using (myCommand = new SqlCommand("SELECT [ID_Operation] FROM [Operations]", myConnection))
            {
                using (SqlDataReader reader = myCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ids.Add(reader.GetInt32(0));
                    }
                }
            }

            // Create new iID
            int id = ids.Max() + 1;

            // Insert scenario
            myCommand = new SqlCommand(identityON + "INSERT INTO [Operations] (ID_Operation) VALUES (" + id + ")" + identityOFF, myConnection);
            myCommand.ExecuteNonQuery();

            // Insert default translation
            string sql = "INSERT INTO [Operations_Translation] (ID_Operation, Language_Code, Name) VALUES (" + id + ", '" + language_Code + "', '" + name + "')";
            myCommand = new SqlCommand(identityON + sql + identityOFF, myConnection);
            myCommand.ExecuteNonQuery();
        }
    }
}
