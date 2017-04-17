using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;

namespace rdb_scenarios.DB_operations
{
    class generateScenarios
    {
        static Dictionary<string, DB_objects.Scenario> scenarios = new Dictionary<string, DB_objects.Scenario>();
        static Dictionary<string, DB_objects.Section> sections = new Dictionary<string, DB_objects.Section>();
        static Dictionary<string, DB_objects.CheckPoint> checks = new Dictionary<string, DB_objects.CheckPoint>();
        static Dictionary<string, DB_objects.Operation> operations = new Dictionary<string, DB_objects.Operation>();

        public static void generate(string language, SqlConnection connection)
        {
            scenarios = new Dictionary<string, DB_objects.Scenario>();
            sections = new Dictionary<string, DB_objects.Section>();
            checks = new Dictionary<string, DB_objects.CheckPoint>();
            operations = new Dictionary<string, DB_objects.Operation>();
            if(Directory.Exists(@".\scenarios\" + language))
            {
                foreach(string file in Directory.GetFiles(@".\scenarios\" + language))
                {
                    File.Delete(file);
                }
            }
            Directory.CreateDirectory(@".\scenarios\" + language);
            fillScenarios(language, connection);
            fillSections(language, connection);
            fillChecks(language, connection);
            fillOperations(language, connection);

            connectOperationsToCheck(connection);
            connectChecksToScenario(connection);

            StreamWriter sw;
            foreach(string key in scenarios.Keys)
            {
                sw = new StreamWriter(@".\scenarios\" + language + @"\" + scenarios[key].name + ".json");
                sw.Write(scenarios[key].toJson());
                sw.Flush();
                sw.Close();
            }

            scenarios = null;
            sections = null;
            checks = null;
            operations = null;
            GC.Collect();
        }

        private static void connectChecksToScenario(SqlConnection connection)
        {
            SqlCommand cmd = new SqlCommand("SELECT section_order, scenario_code, section_code, check_code, check_order FROM scenario_checks", connection);
            cmd.CommandType = System.Data.CommandType.Text;
            SqlDataReader reader = cmd.ExecuteReader();

            DB_objects.Scenario sc;
            DB_objects.Section se;
            DB_objects.CheckPoint cp;

            int section_order, check_order;

            while (reader.Read())
            {
                sc = scenarios[reader[1].ToString()];
                se = sections[reader[2].ToString()];
                cp = checks[reader[3].ToString()];

                section_order = int.Parse(reader[0].ToString());
                check_order = int.Parse(reader[4].ToString());

                sc.addSection(section_order, se);
                sc.addCheck(section_order, check_order, cp);
            }
            reader.Close();
        }

        private static void connectOperationsToCheck(SqlConnection connection)
        {
            SqlCommand cmd = new SqlCommand("SELECT operation_code, check_code, [order] FROM check_operations", connection);
            cmd.CommandType = System.Data.CommandType.Text;
            SqlDataReader reader = cmd.ExecuteReader();

            DB_objects.CheckPoint c;
            DB_objects.Operation o;

            while (reader.Read())
            {
                o = operations[reader[0].ToString()];
                c = checks[reader[1].ToString()];
                c.addOperation(int.Parse(reader[2].ToString()), o);
            }
            reader.Close();
        }

        private static void fillOperations(string language, SqlConnection connection)
        {
            SqlCommand cmd = new SqlCommand("sp_connectOperation", connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add("@selectedLanguage", System.Data.SqlDbType.NVarChar).Value = language;
            SqlDataReader reader = cmd.ExecuteReader();
            DB_objects.Operation o;
            while (reader.Read())
            {
                o = new DB_objects.Operation(reader[1].ToString(), reader[2].ToString());
                o.addAttribute(reader[3].ToString(), reader[4].ToString(), reader[5].ToString());
                operations[reader[0].ToString()] = o;
            }
            reader.Close();
        }

        private static void fillChecks(string language, SqlConnection connection)
        {
            SqlCommand cmd = new SqlCommand("sp_connectCheck", connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add("@selectedLanguage", System.Data.SqlDbType.NVarChar).Value = language;
            SqlDataReader reader = cmd.ExecuteReader();
            DB_objects.CheckPoint cp;
            while (reader.Read())
            {
                cp = new DB_objects.CheckPoint(reader[1].ToString(), reader[2].ToString());
                cp.addAttribute(reader[3].ToString(), reader[4].ToString(), reader[5].ToString());
                checks[reader[0].ToString()] = cp;
            }
            reader.Close();
        }

        private static void fillSections(string language, SqlConnection connection)
        {
            SqlCommand cmd = new SqlCommand("sp_connectSection", connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add("@selectedLanguage", System.Data.SqlDbType.NVarChar).Value = language;
            SqlDataReader reader = cmd.ExecuteReader();
            DB_objects.Section s;
            while (reader.Read())
            {
                s = new DB_objects.Section(reader[1].ToString(), reader[2].ToString());
                s.addAttribute(reader[3].ToString(), reader[4].ToString(), reader[5].ToString());
                sections[reader[0].ToString()] = s;
            }
            reader.Close();
        }

        private static void fillScenarios(string language, SqlConnection connection)
        {
            SqlCommand cmd = new SqlCommand("sp_connectScenario", connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add("@selectedLanguage", System.Data.SqlDbType.NVarChar).Value = language;
            SqlDataReader reader = cmd.ExecuteReader();
            DB_objects.Scenario s;
            while(reader.Read())
            {
                s = new DB_objects.Scenario(reader[1].ToString(), reader[2].ToString());
                s.addAttribute(reader[3].ToString(), reader[4].ToString(), reader[5].ToString());
                scenarios[reader[0].ToString()] = s;
            }
            reader.Close();
        }
    }
}
