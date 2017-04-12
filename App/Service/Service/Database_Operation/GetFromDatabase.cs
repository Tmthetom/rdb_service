using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Service.Database_Operation
{
    class GetFromDatabase
    {
        /// <summary>
        /// Return all languages in table Languages
        /// </summary>
        /// <param name="connection">Database connection</param>
        /// <returns>List of languages</returns>
        public static List<string> Languages(Connection connection)
        {
            List<string> languages = new List<string>();
            SqlConnection myConnection = connection.GetConnection();
            SqlCommand command;
            using (command = new SqlCommand("SELECT Language_Code FROM Languages", myConnection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        languages.Add(reader.GetString(0));
                    }
                }
            }
            return languages;
        }

        /// <summary>
        /// Return number of all tables in database
        /// </summary>
        /// <param name="connection">Database connection</param>
        /// <returns>Number of tables</returns>
        public static int NumberOfTables(Connection connection)
        {
            int tables = 0;
            SqlConnection myConnection = connection.GetConnection();
            SqlCommand command;
            using (command = new SqlCommand("SELECT COUNT(*) FROM information_schema.tables WHERE table_type = 'base table'", myConnection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        tables = reader.GetInt32(0);
                    }
                }
            }
            return tables;
        }
    }
}
