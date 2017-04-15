using System.Collections.Generic;
using System.Data.SqlClient;

namespace Service.Database_Operation
{
    class Get
    {
        /// <summary>
        /// Return number of all tables in database
        /// </summary>
        /// <param name="connection">Database connection</param>
        /// <returns>Number of tables</returns>
        public static int NumberOfTables(Connection connection)
        {
            int tables = 0;
            SqlConnection myConnection = connection.GetConnection();
            SqlCommand myCommand;
            using (myCommand = new SqlCommand("SELECT COUNT(*) FROM information_schema.tables WHERE table_type = 'base table'", myConnection))
            {
                using (SqlDataReader reader = myCommand.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        tables = reader.GetInt32(0);
                    }
                }
            }
            return tables;
        }

        /// <summary>
        /// Return all languages in table Languages
        /// </summary>
        /// <param name="connection">Database connection</param>
        /// <returns>List of languages</returns>
        public static List<string> Languages(Connection connection)
        {
            List<string> languages = new List<string>();
            SqlConnection myConnection = connection.GetConnection();
            SqlCommand myCommand;
            using (myCommand = new SqlCommand("SELECT Language_Code FROM Languages", myConnection))
            {
                using (SqlDataReader reader = myCommand.ExecuteReader())
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
        /// Get all scenarios for selected language
        /// </summary>
        /// <param name="language">Selected language</param>
        /// <param name="connection">Database connection</param>
        /// <returns>List of scenarios</returns>
        public static List<Database_Objects.Scenario_Translation> Scenarios(string language, Connection connection)
        {
            List<Database_Objects.Scenario_Translation> scenarios = new List<Database_Objects.Scenario_Translation>();
            
            // Database operations
            SqlCommand myCommand;
            SqlDataReader reader;
            SqlConnection myConnection = connection.GetConnection();

            // Object ID
            List<int> all = new List<int>();
            myCommand = new SqlCommand("SELECT [ID_Scenario] FROM [Scenarios]", myConnection);
            reader = myCommand.ExecuteReader();
            while (reader.Read())
            {
                all.Add(reader.GetInt32(0));
            }
            reader.Close();


            // Object translations
            List<Database_Objects.Scenario_Translation> all_Translations = new List<Database_Objects.Scenario_Translation>();
            myCommand = new SqlCommand("SELECT [ID_Scenario], [Language_Code], [Name] FROM [Scenarios_Translation]", myConnection);
            reader = myCommand.ExecuteReader();
            Database_Objects.Scenario_Translation current_Translation;
            while (reader.Read())
            {
                current_Translation = new Database_Objects.Scenario_Translation(reader.GetInt32(0), reader[1].ToString(), reader[2].ToString());
                all_Translations.Add(current_Translation);
            }
            reader.Close();

            // Select wanted translation
            foreach (int id in all)
            {
                // Find wanted translation
                foreach (Database_Objects.Scenario_Translation translation in all_Translations)
                {
                    if (id == translation.GetID() && language == translation.GetLanguage_Code())
                    {
                        scenarios.Add(translation);
                        break;
                    }
                }
            }

            return scenarios;
        }

        /// <summary>
        /// Get all sections for selected language
        /// </summary>
        /// <param name="language">Selected language</param>
        /// <param name="connection">Database connection</param>
        /// <returns>List of sections</returns>
        public static List<Database_Objects.Section_Translation> Sections(string language, Connection connection)
        {
            List<Database_Objects.Section_Translation> sections = new List<Database_Objects.Section_Translation>();

            // Database operations
            SqlCommand myCommand;
            SqlDataReader reader;
            SqlConnection myConnection = connection.GetConnection();

            // Object ID
            List<int> all = new List<int>();
            myCommand = new SqlCommand("SELECT [ID_Section] FROM [Sections]", myConnection);
            reader = myCommand.ExecuteReader();
            while (reader.Read())
            {
                all.Add(reader.GetInt32(0));
            }
            reader.Close();


            // Object translations
            List<Database_Objects.Section_Translation> all_Translations = new List<Database_Objects.Section_Translation>();
            myCommand = new SqlCommand("SELECT [ID_Section], [Language_Code], [Name] FROM [Sections_Translation]", myConnection);
            reader = myCommand.ExecuteReader();
            Database_Objects.Section_Translation current_Translation;
            while (reader.Read())
            {
                current_Translation = new Database_Objects.Section_Translation(reader.GetInt32(0), reader[1].ToString(), reader[2].ToString());
                all_Translations.Add(current_Translation);
            }
            reader.Close();

            // Select wanted translation
            foreach (int id in all)
            {
                // Find wanted translation
                foreach (Database_Objects.Section_Translation translation in all_Translations)
                {
                    if (id == translation.GetID() && language == translation.GetLanguage_Code())
                    {
                        sections.Add(translation);
                        break;
                    }
                }
            }
            return sections;
        }

        /// <summary>
        /// Get all checkPoints for selected language
        /// </summary>
        /// <param name="language">Selected language</param>
        /// <param name="connection">Database connection</param>
        /// <returns>List of checkPoints</returns>
        public static List<Database_Objects.CheckPoint_Translation> CheckPoints(string language, Connection connection)
        {
            List<Database_Objects.CheckPoint_Translation> checkpoints = new List<Database_Objects.CheckPoint_Translation>();

            // Database operations
            SqlCommand myCommand;
            SqlDataReader reader;
            SqlConnection myConnection = connection.GetConnection();

            // Object ID
            List<int> all = new List<int>();
            myCommand = new SqlCommand("SELECT [ID_CheckPoint] FROM [CheckPoints]", myConnection);
            reader = myCommand.ExecuteReader();
            while (reader.Read())
            {
                all.Add(reader.GetInt32(0));
            }
            reader.Close();


            // Object translations
            List<Database_Objects.CheckPoint_Translation> all_Translations = new List<Database_Objects.CheckPoint_Translation>();
            myCommand = new SqlCommand("SELECT [ID_CheckPoint], [Language_Code], [Name] FROM [CheckPoints_Translation]", myConnection);
            reader = myCommand.ExecuteReader();
            Database_Objects.CheckPoint_Translation current_Translation;
            while (reader.Read())
            {
                current_Translation = new Database_Objects.CheckPoint_Translation(reader.GetInt32(0), reader[1].ToString(), reader[2].ToString());
                all_Translations.Add(current_Translation);
            }
            reader.Close();

            // Select wanted translation
            foreach (int id in all)
            {
                // Find wanted translation
                foreach (Database_Objects.CheckPoint_Translation translation in all_Translations)
                {
                    if (id == translation.GetID() && language == translation.GetLanguage_Code())
                    {
                        checkpoints.Add(translation);
                        break;
                    }
                }
            }
            return checkpoints;
        }

        /// <summary>
        /// Get all operations for selected language
        /// </summary>
        /// <param name="language">Selected language</param>
        /// <param name="connection">Database connection</param>
        /// <returns>List of operations</returns>
        public static List<Database_Objects.Operation_Translation> Operations(string language, Connection connection)
        {
            List<Database_Objects.Operation_Translation> operations = new List<Database_Objects.Operation_Translation>();

            // Database operations
            SqlCommand myCommand;
            SqlDataReader reader;
            SqlConnection myConnection = connection.GetConnection();

            // Object ID
            List<int> all = new List<int>();
            myCommand = new SqlCommand("SELECT [ID_Operation] FROM [Operations]", myConnection);
            reader = myCommand.ExecuteReader();
            while (reader.Read())
            {
                all.Add(reader.GetInt32(0));
            }
            reader.Close();


            // Object translations
            List<Database_Objects.Operation_Translation> all_Translations = new List<Database_Objects.Operation_Translation>();
            myCommand = new SqlCommand("SELECT [ID_Operation], [Language_Code], [Name] FROM [Operations_Translation]", myConnection);
            reader = myCommand.ExecuteReader();
            Database_Objects.Operation_Translation current_Translation;
            while (reader.Read())
            {
                current_Translation = new Database_Objects.Operation_Translation(reader.GetInt32(0), reader[1].ToString(), reader[2].ToString());
                all_Translations.Add(current_Translation);
            }
            reader.Close();

            // Select wanted translation
            foreach (int id in all)
            {
                // Find wanted translation
                foreach (Database_Objects.Operation_Translation translation in all_Translations)
                {
                    if (id == translation.GetID() && language == translation.GetLanguage_Code())
                    {
                        operations.Add(translation);
                        break;
                    }
                }
            }
            return operations;
        }
    }
}
