using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;

namespace Service.Database_Export
{
    class ExportToJson
    {
        // Default settings
        private static string defaultLanguage = "EN";

        // All translation objects
        private static Dictionary<string, Database_Objects.Scenario_Translation> scenarios = new Dictionary<string, Database_Objects.Scenario_Translation>();
        private static Dictionary<string, Database_Objects.Section_Translation> sections = new Dictionary<string, Database_Objects.Section_Translation>();
        private static Dictionary<string, Database_Objects.CheckPoint_Translation> checkpoints = new Dictionary<string, Database_Objects.CheckPoint_Translation>();
        private static Dictionary<string, Database_Objects.Operation_Translation> operations = new Dictionary<string, Database_Objects.Operation_Translation>();

        // Exporting objects
        private static Dictionary<string, Database_Export.Scenario> export_scenarios = new Dictionary<string, Database_Export.Scenario>();
        private static Dictionary<string, Database_Export.CheckPoint> export_checkpoints = new Dictionary<string, Database_Export.CheckPoint>();

        /// <summary>
        /// Generate database output in JSON, into 'export' file, in program folder
        /// </summary>
        /// <param name="language">Selected language</param>
        /// <param name="myConnection">Database connection</param>
        public static void Generate(string language, Database_Operation.Connection connection)
        {
            // Get SQL Connection
            SqlConnection myConnection = connection.GetConnection();

            // Load components
            LoadComponents(language, myConnection);

            // Create JSON and save into file
            Directory.CreateDirectory(@".\export\" + language);
            StreamWriter sw;
            foreach (string key in scenarios.Keys)
            {
                sw = new StreamWriter(@".\export\" + language + @"\" + export_scenarios[key].name + ".json");
                sw.Write(export_scenarios[key].ToJson());
                sw.Flush();
                sw.Close();
            }

            // Clear old values
            ClearComponents();
        }

        /// <summary>
        /// Get number of components for selected language
        /// </summary>
        /// <param name="language">Selected language</param>
        /// <param name="connection">Database connection</param>
        /// <returns>Dictionary of components names and their numbers</returns>
        public static Dictionary<string, int> GetNumerOfComponents(string language, Database_Operation.Connection connection)
        {
            // Get SQL Connection
            SqlConnection myConnection = connection.GetConnection();

            // Load components
            LoadComponents(language, myConnection);

            // Get number of component
            Dictionary<string, int> numberOf = new Dictionary<string, int>();
            int numberOfScenarios = 0;
            int numberOfSections = 0;
            int numberOfCheckPoints = 0;
            int numberOfOperations = 0;

            // Scenarios
            numberOfScenarios = export_scenarios.Count;

            // Sections
            foreach (Database_Export.Scenario scenario in export_scenarios.Values)
            {
                numberOfSections += scenario.sections.Count;
            }

            // CheckPoints
            numberOfCheckPoints = export_checkpoints.Count;

            // Operations
            foreach (Database_Export.CheckPoint checkPoint in export_checkpoints.Values)
            {
                numberOfOperations += checkPoint.operations.Count;
            }

            // Add all to output
            numberOf.Add("Scenarios", numberOfScenarios);
            numberOf.Add("Sections", numberOfSections);
            numberOf.Add("CheckPoints", numberOfCheckPoints);
            numberOf.Add("Operations", numberOfOperations);

            // Clear old values
            ClearComponents();

            return numberOf;
        }

        /// <summary>
        /// Load components in selected language
        /// </summary>
        /// <param name="language">Selected language</param>
        /// <param name="myConnection">Database connection</param>
        private static void LoadComponents(string language, SqlConnection myConnection)
        {
            // Get translated object from database
            GetScenarios(language, myConnection);
            GetSections(language, myConnection);
            GetCheckPoints(language, myConnection);
            GetOperations(language, myConnection);

            // Get connections from database
            BuildCheckPoints(myConnection);
            BuildScenarios(myConnection);
        }

        /// <summary>
        /// Destroy all resources
        /// </summary>
        private static void ClearComponents()
        {
            // All translation objects
            scenarios = new Dictionary<string, Database_Objects.Scenario_Translation>();
            sections = new Dictionary<string, Database_Objects.Section_Translation>();
            checkpoints = new Dictionary<string, Database_Objects.CheckPoint_Translation>();
            operations = new Dictionary<string, Database_Objects.Operation_Translation>();

            // Exporting objects
            export_scenarios = new Dictionary<string, Database_Export.Scenario>();
            export_checkpoints = new Dictionary<string, Database_Export.CheckPoint>();

            // Call garbage collector
            GC.Collect();
        }

        /// <summary>
        /// Build tree with checkpoint-operation connections
        /// </summary>
        /// <param name="myConnection">Database connection</param>
        private static void BuildCheckPoints(SqlConnection myConnection)
        {
            // Create exported checkpoint for every checkpoint
            foreach (KeyValuePair<string, Database_Objects.CheckPoint_Translation> c in checkpoints)
            {
                export_checkpoints.Add(c.Key, new Database_Export.CheckPoint(c.Value.GetName(), c.Value.GetLanguage_Code()));
            }

            // Objects
            Database_Export.CheckPoint selected_checkPoint;
            Database_Objects.Operation_Translation selected_Operation;

            // Get connections
            using (SqlCommand myCommand = new SqlCommand("SELECT [ID_CheckPoint], [ID_Operation], [Order_Number] FROM [CheckPoints_Operations]", myConnection))
            {
                using (SqlDataReader reader = myCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        selected_Operation = operations[reader[1].ToString()];
                        selected_checkPoint = export_checkpoints[reader[0].ToString()];
                        selected_checkPoint.AddOperation(reader.GetInt32(2), selected_Operation);
                    }
                }
            }
        }

        /// <summary>
        /// Build tree with scenario-operation-checkpoint connections
        /// </summary>
        /// <param name="myConnection">Database connection</param>
        private static void BuildScenarios(SqlConnection myConnection)
        {
            // Create exported scenario for every scenario
            foreach (KeyValuePair<string, Database_Objects.Scenario_Translation> s in scenarios)
            {
                export_scenarios.Add(s.Key, new Database_Export.Scenario(s.Value.GetName(), s.Value.GetLanguage_Code()));
            }

            // Objects
            Database_Export.Scenario selected_Scenario;
            Database_Objects.Section_Translation selected_Section;
            Database_Export.CheckPoint selected_CheckPoint;

            try
            {
                // Get connections
                using (SqlCommand myCommand = new SqlCommand("SELECT [ID_Scenario], [ID_Section], [ID_CheckPoint], [Order_Number] FROM [Scenarios_Sections]", myConnection))
                {
                    using (SqlDataReader reader = myCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            selected_Scenario = export_scenarios[reader[0].ToString()];
                            selected_Section = sections[reader[1].ToString()];
                            selected_CheckPoint = export_checkpoints[reader[2].ToString()];

                            selected_Scenario.AddSection(reader.GetInt32(3), selected_Section);
                            selected_Scenario.AddCheckPoint(reader.GetInt32(3), selected_CheckPoint);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show(e.ToString());
            }
        }

        /// <summary>
        /// Get selected translation from database, if no translation, use default language
        /// </summary>
        /// <param name="language">Selected language</param>
        /// <param name="myConnection">Database connection</param>
        private static void GetScenarios(string language, SqlConnection myConnection)
        {
            // Database operations
            SqlCommand myCommand;
            SqlDataReader reader;

            // Object ID
            List<int> all = new List<int>();
            using (myCommand = new SqlCommand("SELECT [ID_Scenario] FROM [Scenarios]", myConnection))
            {
                using (reader = myCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        all.Add(reader.GetInt32(0));
                    }
                }
            }

            // Object translations
            List<Database_Objects.Scenario_Translation> all_Translations = new List<Database_Objects.Scenario_Translation>();
            using (myCommand = new SqlCommand("SELECT [ID_Scenario], [Language_Code], [Name] FROM [Scenarios_Translation]", myConnection))
            {
                using (reader = myCommand.ExecuteReader())
                {
                    Database_Objects.Scenario_Translation current_Translation;
                    while (reader.Read())
                    {
                        current_Translation = new Database_Objects.Scenario_Translation(reader.GetInt32(0), reader[1].ToString(), reader[2].ToString());
                        all_Translations.Add(current_Translation);
                    }
                }
            }

            // Select wanted translation, if not here, use EN
            bool haveTranslation;
            foreach (int id in all)
            {
                // Reset flag
                haveTranslation = false;

                // Find wanted translation
                foreach (Database_Objects.Scenario_Translation translation in all_Translations)
                {
                    if (id == translation.GetID() && language == translation.GetLanguage_Code())
                    {
                        scenarios[id.ToString()] = translation;
                        haveTranslation = true;
                        break;
                    }
                }

                // If no translation, use EN
                if (haveTranslation == false)
                {
                    foreach (Database_Objects.Scenario_Translation translation in all_Translations)
                    {
                        if (id == translation.GetID() && language == defaultLanguage)
                        {
                            scenarios[id.ToString()] = translation;
                            break;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Get selected translation from database, if no translation, use default language
        /// </summary>
        /// <param name="language">Selected language</param>
        /// <param name="myConnection">Database connection</param>
        private static void GetSections(string language, SqlConnection myConnection)
        {
            // Database operations
            SqlCommand myCommand;
            SqlDataReader reader;

            // Object ID
            List<int> all = new List<int>();
            using (myCommand = new SqlCommand("SELECT [ID_Section] FROM [Sections]", myConnection))
            {
                using (reader = myCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        all.Add(reader.GetInt32(0));
                    }
                }
            }

            // Object translations
            List<Database_Objects.Section_Translation> all_Translations = new List<Database_Objects.Section_Translation>();
            using (myCommand = new SqlCommand("SELECT [ID_Section], [Language_Code], [Name] FROM [Sections_Translation]", myConnection))
            {
                using (reader = myCommand.ExecuteReader())
                {
                    Database_Objects.Section_Translation current_Translation;
                    while (reader.Read())
                    {
                        current_Translation = new Database_Objects.Section_Translation(reader.GetInt32(0), reader[1].ToString(), reader[2].ToString());
                        all_Translations.Add(current_Translation);
                    }
                }
            }
            
            // Select wanted translation, if not here, use EN
            bool haveTranslation;
            foreach (int id in all)
            {
                // Reset flag
                haveTranslation = false;

                // Find wanted translation
                foreach (Database_Objects.Section_Translation translation in all_Translations)
                {
                    if (id == translation.GetID() && language == translation.GetLanguage_Code())
                    {
                        sections[id.ToString()] = translation;
                        haveTranslation = true;
                        break;
                    }
                }

                // If no translation, use EN
                if (haveTranslation == false)
                {
                    foreach (Database_Objects.Section_Translation translation in all_Translations)
                    {
                        if (id == translation.GetID() && language == defaultLanguage)
                        {
                            sections[id.ToString()] = translation;
                            break;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Get selected translation from database, if no translation, use default language
        /// </summary>
        /// <param name="language">Selected language</param>
        /// <param name="myConnection">Database connection</param>
        private static void GetCheckPoints(string language, SqlConnection myConnection)
        {
            // Database operations
            SqlCommand myCommand;
            SqlDataReader reader;

            // Object ID
            List<int> all = new List<int>();
            using (myCommand = new SqlCommand("SELECT [ID_CheckPoint] FROM [CheckPoints]", myConnection))
            {
                using (reader = myCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        all.Add(reader.GetInt32(0));
                    }
                }
            }
                        
            // Object translations
            List<Database_Objects.CheckPoint_Translation> all_Translations = new List<Database_Objects.CheckPoint_Translation>();
            using (myCommand = new SqlCommand("SELECT [ID_CheckPoint], [Language_Code], [Name] FROM [CheckPoints_Translation]", myConnection))
            {
                using (reader = myCommand.ExecuteReader())
                {
                    Database_Objects.CheckPoint_Translation current_Translation;
                    while (reader.Read())
                    {
                        current_Translation = new Database_Objects.CheckPoint_Translation(reader.GetInt32(0), reader[1].ToString(), reader[2].ToString());
                        all_Translations.Add(current_Translation);
                    }
                }
            }
            
            // Select wanted translation, if not here, use EN
            bool haveTranslation;
            foreach (int id in all)
            {
                // Reset flag
                haveTranslation = false;

                // Find wanted translation
                foreach (Database_Objects.CheckPoint_Translation translation in all_Translations)
                {
                    if (id == translation.GetID() && language == translation.GetLanguage_Code())
                    {
                        checkpoints[id.ToString()] = translation;
                        haveTranslation = true;
                        break;
                    }
                }

                // If no translation, use EN
                if (haveTranslation == false)
                {
                    foreach (Database_Objects.CheckPoint_Translation translation in all_Translations)
                    {
                        if (id == translation.GetID() && language == defaultLanguage)
                        {
                            checkpoints[id.ToString()] = translation;
                            break;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Get selected translation from database, if no translation, use default language
        /// </summary>
        /// <param name="language">Selected language</param>
        /// <param name="myConnection">Database connection</param>
        private static void GetOperations(string language, SqlConnection myConnection)
        {
            // Database operations
            SqlCommand myCommand;
            SqlDataReader reader;

            // Object ID
            List<int> all = new List<int>();
            using (myCommand = new SqlCommand("SELECT [ID_Operation] FROM [Operations]", myConnection))
            {
                using (reader = myCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        all.Add(reader.GetInt32(0));
                    }
                }
            }
            
            // Object translations
            List<Database_Objects.Operation_Translation> all_Translations = new List<Database_Objects.Operation_Translation>();
            using (myCommand = new SqlCommand("SELECT [ID_Operation], [Language_Code], [Name] FROM [Operations_Translation]", myConnection))
            {
                using (reader = myCommand.ExecuteReader())
                {
                    Database_Objects.Operation_Translation current_Translation;
                    while (reader.Read())
                    {
                        current_Translation = new Database_Objects.Operation_Translation(reader.GetInt32(0), reader[1].ToString(), reader[2].ToString());
                        all_Translations.Add(current_Translation);
                    }
                }
            }

            // Select wanted translation, if not here, use EN
            bool haveTranslation;
            foreach (int id in all)
            {
                // Reset flag
                haveTranslation = false;

                // Find wanted translation
                foreach (Database_Objects.Operation_Translation translation in all_Translations)
                {
                    if (id == translation.GetID() && language == translation.GetLanguage_Code())
                    {
                        operations[id.ToString()] = translation;
                        haveTranslation = true;
                        break;
                    }
                }

                // If no translation, use EN
                if (haveTranslation == false)
                {
                    foreach (Database_Objects.Operation_Translation translation in all_Translations)
                    {
                        if (id == translation.GetID() && language == defaultLanguage)
                        {
                            operations[id.ToString()] = translation;
                            break;
                        }
                    }
                }
            }
        }
    }
}
