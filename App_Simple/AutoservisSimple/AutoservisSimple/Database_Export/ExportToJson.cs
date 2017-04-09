using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;

namespace AutoservisSimple.Database_Objects
{
    class ExportToJson
    {
        // Default settings
        private static string defaultLanguage = "EN";

        // All translation objects
        private static Dictionary<string, Scenario_Translation> scenarios = new Dictionary<string, Scenario_Translation>();
        private static Dictionary<string, Section_Translation> sections = new Dictionary<string, Section_Translation>();
        private static Dictionary<string, CheckPoint_Translation> checkpoints = new Dictionary<string, CheckPoint_Translation>();
        private static Dictionary<string, Operation_Translation> operations = new Dictionary<string, Operation_Translation>();

        // Exporting objects
        private static Dictionary<string, Database_Export.Scenario> export_scenarios = new Dictionary<string, Database_Export.Scenario>();
        private static Dictionary<string, Database_Export.CheckPoint> export_checkpoints = new Dictionary<string, Database_Export.CheckPoint>();

        /// <summary>
        /// Generate database output in JSON
        /// </summary>
        /// <param name="language">Selected language</param>
        /// <param name="myConnection">Database connection</param>
        public static void Generate(string language, SqlConnection myConnection)
        {
            Directory.CreateDirectory(@".\export\" + language);

            // Get translated object from database
            GetScenarios(language, myConnection);
            GetSections(language, myConnection);
            GetCheckPoints(language, myConnection);
            GetOperations(language, myConnection);

            // Get connections from database
            BuildCheckPoints(myConnection);
            BuildScenarios(myConnection);

            // Create JSON and save into file
            StreamWriter sw;
            foreach (string key in scenarios.Keys)
            {
                sw = new StreamWriter(@".\export\" + language + @"\" + export_scenarios[key].name + ".json");
                sw.Write(export_scenarios[key].ToJson());
                sw.Flush();
                sw.Close();
            }

            // Clear old values
            scenarios = null;
            sections = null;
            checkpoints = null;
            operations = null;
            GC.Collect();
        }

        /// <summary>
        /// Build tree with checkpoint-operation connections
        /// </summary>
        /// <param name="myConnection">Database connection</param>
        private static void BuildCheckPoints(SqlConnection myConnection)
        {
            // Create exported checkpoint for every checkpoint
            foreach (KeyValuePair<string, CheckPoint_Translation> c in checkpoints)
            {
                export_checkpoints.Add(c.Key, new Database_Export.CheckPoint(c.Value.GetName(), c.Value.GetLanguage_Code()));
            }

            // Objects
            Database_Export.CheckPoint selected_checkPoint;
            Operation_Translation selected_Operation;

            // Get connections
            SqlCommand query = new SqlCommand("SELECT [ID_CheckPoint], [ID_Operation], [Order_Number] FROM [CheckPoints_Operations]", myConnection);
            SqlDataReader reader = query.ExecuteReader();
            while (reader.Read())
            {
                selected_Operation = operations[reader[1].ToString()];
                selected_checkPoint = export_checkpoints[reader[0].ToString()];
                selected_checkPoint.AddOperation(reader.GetInt32(2), selected_Operation);
            }
            reader.Close();
        }

        /// <summary>
        /// Build tree with scenario-operation-checkpoint connections
        /// </summary>
        /// <param name="myConnection">Database connection</param>
        private static void BuildScenarios(SqlConnection myConnection)
        {
            // Create exported scenario for every scenario
            foreach (KeyValuePair<string, Scenario_Translation> s in scenarios)
            {
                export_scenarios.Add(s.Key, new Database_Export.Scenario(s.Value.GetName(), s.Value.GetLanguage_Code()));
            }

            // Objects
            Database_Export.Scenario selected_Scenario;
            Section_Translation selected_Section;
            Database_Export.CheckPoint selected_CheckPoint;

            // Get connections
            SqlCommand query = new SqlCommand("SELECT [ID_Scenario], [ID_Section], [ID_CheckPoint], [Order_Number] FROM [Scenarios_Sections]", myConnection);
            SqlDataReader reader = query.ExecuteReader();
            while (reader.Read())
            {
                selected_Scenario = export_scenarios[reader[0].ToString()];
                selected_Section = sections[reader[1].ToString()];
                selected_CheckPoint = export_checkpoints[reader[2].ToString()];

                selected_Scenario.AddSection(reader.GetInt32(3), selected_Section);
                selected_Scenario.AddCheckPoint(reader.GetInt32(3), selected_CheckPoint);
            }
            reader.Close();
        }

        /// <summary>
        /// Get selected translation from database, if no translation, use default language
        /// </summary>
        /// <param name="language">Selected language</param>
        /// <param name="myConnection">Database connection</param>
        private static void GetScenarios(string language, SqlConnection myConnection)
        {
            // Database operations
            SqlCommand query;
            SqlDataReader reader;

            // Object ID
            List<int> all = new List<int>();
            query = new SqlCommand("SELECT [ID_Scenario] FROM [Scenarios]", myConnection);
            reader = query.ExecuteReader();
            while (reader.Read())
            {
                all.Add(reader.GetInt32(0));
            }
            reader.Close();


            // Object translations
            List<Scenario_Translation> all_Translations = new List<Scenario_Translation>();
            query = new SqlCommand("SELECT [ID_Scenario], [Language_Code], [Name] FROM [Scenarios_Translation]", myConnection);
            reader = query.ExecuteReader();
            Scenario_Translation current_Translation;
            while (reader.Read())
            {
                current_Translation = new Scenario_Translation(reader.GetInt32(0), reader[1].ToString(), reader[2].ToString());
                all_Translations.Add(current_Translation);
            }
            reader.Close();

            // Select wanted translation, if not here, use EN
            bool haveTranslation;
            foreach (int id in all)
            {
                // Reset flag
                haveTranslation = false;

                // Find wanted translation
                foreach (Scenario_Translation translation in all_Translations)
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
                    foreach (Scenario_Translation translation in all_Translations)
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
            SqlCommand query;
            SqlDataReader reader;

            // Object ID
            List<int> all = new List<int>();
            query = new SqlCommand("SELECT [ID_Section] FROM [Sections]", myConnection);
            reader = query.ExecuteReader();
            while (reader.Read())
            {
                all.Add(reader.GetInt32(0));
            }
            reader.Close();


            // Object translations
            List<Section_Translation> all_Translations = new List<Section_Translation>();
            query = new SqlCommand("SELECT [ID_Section], [Language_Code], [Name] FROM [Sections_Translation]", myConnection);
            reader = query.ExecuteReader();
            Section_Translation current_Translation;
            while (reader.Read())
            {
                current_Translation = new Section_Translation(reader.GetInt32(0), reader[1].ToString(), reader[2].ToString());
                all_Translations.Add(current_Translation);
            }
            reader.Close();

            // Select wanted translation, if not here, use EN
            bool haveTranslation;
            foreach (int id in all)
            {
                // Reset flag
                haveTranslation = false;

                // Find wanted translation
                foreach (Section_Translation translation in all_Translations)
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
                    foreach (Section_Translation translation in all_Translations)
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
            SqlCommand query;
            SqlDataReader reader;

            // Object ID
            List<int> all = new List<int>();
            query = new SqlCommand("SELECT [ID_CheckPoint] FROM [CheckPoints]", myConnection);
            reader = query.ExecuteReader();
            while (reader.Read())
            {
                all.Add(reader.GetInt32(0));
            }
            reader.Close();


            // Object translations
            List<CheckPoint_Translation> all_Translations = new List<CheckPoint_Translation>();
            query = new SqlCommand("SELECT [ID_CheckPoint], [Language_Code], [Name] FROM [CheckPoints_Translation]", myConnection);
            reader = query.ExecuteReader();
            CheckPoint_Translation current_Translation;
            while (reader.Read())
            {
                current_Translation = new CheckPoint_Translation(reader.GetInt32(0), reader[1].ToString(), reader[2].ToString());
                all_Translations.Add(current_Translation);
            }
            reader.Close();

            // Select wanted translation, if not here, use EN
            bool haveTranslation;
            foreach (int id in all)
            {
                // Reset flag
                haveTranslation = false;

                // Find wanted translation
                foreach (CheckPoint_Translation translation in all_Translations)
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
                    foreach (CheckPoint_Translation translation in all_Translations)
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
            SqlCommand query;
            SqlDataReader reader;

            // Object ID
            List<int> all = new List<int>();
            query = new SqlCommand("SELECT [ID_Operation] FROM [Operations]", myConnection);
            reader = query.ExecuteReader();
            while (reader.Read())
            {
                all.Add(reader.GetInt32(0));
            }
            reader.Close();


            // Object translations
            List<Operation_Translation> all_Translations = new List<Operation_Translation>();
            query = new SqlCommand("SELECT [ID_Operation], [Language_Code], [Name] FROM [Operations_Translation]", myConnection);
            reader = query.ExecuteReader();
            Operation_Translation current_Translation;
            while (reader.Read())
            {
                current_Translation = new Operation_Translation(reader.GetInt32(0), reader[1].ToString(), reader[2].ToString());
                all_Translations.Add(current_Translation);
            }
            reader.Close();

            // Select wanted translation, if not here, use EN
            bool haveTranslation;
            foreach (int id in all)
            {
                // Reset flag
                haveTranslation = false;

                // Find wanted translation
                foreach (Operation_Translation translation in all_Translations)
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
                    foreach (Operation_Translation translation in all_Translations)
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

        private static void Connect_CheckPointsToScenarios()
        {

        }

        private static void Connect_OperationsToChecKPoints()
        {

        }
    }
}
