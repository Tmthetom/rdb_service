using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace rdb_scenarios.DB_operations
{
    class ScenarioDao
    {
        private SqlConnection myConnection;

        public ScenarioDao(SqlConnection myConnection)
        {
            this.myConnection = myConnection;
        }

        public bool create(DB_objects.Scenario s)
        {
            SqlCommand comm = new SqlCommand("INSERT INTO scenario(name, description) VALUES(@name, @description)", myConnection);
            comm.Parameters.Add("@name", s.name);
            comm.Parameters.Add("@description", s.description);
            int id = -1;
            id = (Int32)comm.ExecuteScalar();
            if (id == -1)
            {
                return false;
            }
            s.scenario_code = id;
            return true;
        }

        public List<DB_objects.Scenario> retrieve()
        {
            List<DB_objects.Scenario> result = new List<DB_objects.Scenario>();
            SqlCommand comm = new SqlCommand("SELECT scenario_code, name, description " +
                                             "FROM scenario ", myConnection);
            SqlDataReader reader = comm.ExecuteReader();
            DB_objects.Scenario s;
            while (reader.Read())
            {
                s = new DB_objects.Scenario();
                s.scenario_code = Int32.Parse(reader[0].ToString());
                s.name = reader[1].ToString();
                s.description = reader[2].ToString();
                result.Add(s);
            }
            reader.Close();
            return result;
        }

        public bool update(DB_objects.Scenario s)
        {
            SqlCommand comm = new SqlCommand("UPDATE scenario SET name=@name, description=@description WHERE scenario_code=@scenario_code", myConnection);
            comm.Parameters.Add("@name", s.name);
            comm.Parameters.Add("@description", s.description);
            comm.Parameters.Add("@scenario_code", s.scenario_code);
            return comm.ExecuteNonQuery() == 1;
        }

        public void delete(int scenario_code)
        {
            SqlCommand comm = new SqlCommand("DELETE FROM scenario WHERE scenario_code=@scenario_code", myConnection);
            comm.Parameters.Add("@scenario_code", scenario_code);
            comm.ExecuteNonQuery();
        }

        public TreeNode getScenario(int selectedScenarioView)
        {
            TreeNode n = new TreeNode();
            SqlCommand comm = new SqlCommand("SELECT s.section_code, s.name, s.description, c.check_code, c.name, c.description, sc.section_order " +
                                             "FROM section s JOIN scenario_checks sc on s.section_code = sc.section_code JOIN check_point c on c.check_code = sc.check_code " +
                                             "WHERE sc.scenario_code=@scenario_code " + 
                                             "ORDER BY section_order, check_order", myConnection);
            comm.Parameters.Add("@scenario_code", selectedScenarioView);
            SqlDataReader reader = comm.ExecuteReader();

            TreeNode section = null;
            string section_number = "-1";

            while(reader.Read())
            {
                if(!section_number.Equals(reader[6].ToString()))
                {
                    section = new TreeNode("Section(" + reader[0].ToString() + "): " + reader[1].ToString() + "[" + reader[2].ToString() + "]");
                    section_number = reader[6].ToString();
                    n.Nodes.Add(section);
                }
                section.Nodes.Add("Check(" + reader[3].ToString() + "): " + reader[4].ToString() + "[" + reader[5].ToString() + "]");
            }
            reader.Close();
            return n;
        }

        public List<DB_objects.CheckPoint> getAvailableChecks(int scenario_code, string selection)
        {
            List<DB_objects.CheckPoint> result = new List<DB_objects.CheckPoint>();
            SqlCommand comm = new SqlCommand("SELECT check_code, name, description " +
                                             "FROM check_point " +
                                             "WHERE check_code NOT IN " + selection, myConnection);
            comm.Parameters.Add("@scenario_code", scenario_code);

            SqlDataReader reader = comm.ExecuteReader();
            DB_objects.CheckPoint cp;
            while(reader.Read())
            {
                cp = new DB_objects.CheckPoint();
                cp.check_code = Int32.Parse(reader[0].ToString());
                cp.name = reader[1].ToString();
                cp.description = reader[2].ToString();
                result.Add(cp);
            }
            reader.Close();
            return result;
        }

        public void insertSections(int selectedScenarioView, TreeNodeCollection nodes)
        {
            SqlCommand comm = new SqlCommand("DELETE FROM scenario_checks WHERE scenario_code=@scenario_code", myConnection);
            comm.Parameters.Add("@scenario_code", selectedScenarioView);
            comm.ExecuteNonQuery();

            comm = new SqlCommand("INSERT INTO scenario_checks(section_order, scenario_code, section_code, check_code, check_order) VALUES(@section_order, @scenario_code, @section_code, @check_code, @check_order)", myConnection);
            comm.Parameters.Add("@scenario_code", selectedScenarioView);
            comm.Parameters.Add("@section_code", "");
            comm.Parameters.Add("@section_order", "");
            comm.Parameters.Add("@check_code", "");
            comm.Parameters.Add("@check_order", "");

            string arg0, arg1;
            Regex regexSection = new Regex("^Section\\((.*?)\\): (.*?)\\[(.*?)\\]$");
            Regex regexCheck = new Regex("^Check\\((.*?)\\): (.*?)\\[(.*?)\\]$");
            Match match;
            for(int i = 0; i < nodes.Count; i++)
            {
                match = regexSection.Match(nodes[i].Text);
                arg0 = match.Groups[1].Value;
                for(int j = 0; j < nodes[i].Nodes.Count; j++)
                {
                    match = regexCheck.Match(nodes[i].Nodes[j].Text);
                    arg1 = match.Groups[1].Value;
                    comm.Parameters["@section_code"].Value = arg0;
                    comm.Parameters["@section_order"].Value = i + 1;
                    comm.Parameters["@check_code"].Value = arg1;
                    comm.Parameters["@check_order"].Value = j + 1;
                    comm.ExecuteNonQuery();
                }
            }
        }
    }
}
