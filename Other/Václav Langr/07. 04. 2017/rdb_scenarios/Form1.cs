using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Security;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace rdb_scenarios
{
    public partial class Form1 : Form
    {
        private SqlConnection myConnection;
        public Form1()
        {
            InitializeComponent();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            panel2.Visible = false;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            panel2.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            backgroundWorker1.RunWorkerAsync();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (myConnection != null) {
                myConnection.Close();
            }
        }

        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            SqlCredential user = null;
            if (radioButton2.Checked)
            {
                if(passwordBox.Text.Length <= 0)
                {
                    toolStripStatusLabel1.Text = "Prázdné heslo!";
                    return;
                }
                SecureString secure = new SecureString();
                foreach (char c in passwordBox.Text)
                {
                    secure.AppendChar(c);
                }
                user = new SqlCredential(userNameBox.Text, secure);
            }
            myConnection = new SqlConnection("Server=" + ipAddressBox.Text + ";database=" + dbNameBox.Text + ";Trusted_Connection=yes", user);
            try
            {
                myConnection.Open();
                toolStripStatusLabel1.Text = "Úspěšně připojeno k databázi!";
            }
            catch (SqlException ex)
            {
                toolStripStatusLabel1.Text = "Nepovedlo se připojit k databázi!";
            }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            if(myConnection != null)
            {
                radioButton1.Enabled = radioButton2.Enabled = false;
                userNameBox.Enabled = passwordBox.Enabled = ipAddressBox.Enabled = dbNameBox.Enabled = false;
                dbConnectButton.Enabled = false;
                dbDeleteButton.Enabled = dbCreateButton.Enabled = dbFillButton.Enabled = true;
            }
        }

        private void dbDeleteButton_Click(object sender, EventArgs e)
        {
            if (myConnection != null)
            {
                string script = File.ReadAllText(@"scripts/dropProcedures.sql");
                IEnumerable<string> commandStrings = Regex.Split(script, @"^\s*GO\s*$", RegexOptions.Multiline | RegexOptions.IgnoreCase);
                SqlCommand comm;
                foreach (string sql in commandStrings)
                {
                    if (!sql.Equals("")) {
                        comm = new SqlCommand(sql.Replace("\n","").Replace("\r", ""), myConnection);
                        comm.CommandType = System.Data.CommandType.Text;
                        try
                        {
                            comm.ExecuteNonQuery();
                        } catch(SqlException ex)
                        {

                        }
                    }
                }
                script = File.ReadAllText(@"scripts/dropTables.sql");
                commandStrings = Regex.Split(script, @"^\s*GO\s*$", RegexOptions.Multiline | RegexOptions.IgnoreCase);
                foreach (string sql in commandStrings)
                {
                    if (!sql.Equals(""))
                    {
                        comm = new SqlCommand(sql.Replace("\n", "").Replace("\r", ""), myConnection);
                        comm.CommandType = System.Data.CommandType.Text;
                        try
                        {
                            comm.ExecuteNonQuery();
                        }
                        catch (SqlException ex)
                        {

                        }
                    }
                }
            }
        }

        private void dbCreateButton_Click(object sender, EventArgs e)
        {
            if (myConnection != null)
            {
                string script = File.ReadAllText(@"scripts/createTables.sql");
                IEnumerable<string> commandStrings = Regex.Split(script, @"^\s*GO\s*$", RegexOptions.Multiline | RegexOptions.IgnoreCase);
                SqlCommand comm;
                foreach (string sql in commandStrings)
                {
                    if (!sql.Equals(""))
                    {
                        comm = new SqlCommand(sql.Replace("\n", "").Replace("\r", ""), myConnection);
                        comm.CommandType = System.Data.CommandType.Text;
                        try
                        {
                            comm.ExecuteNonQuery();
                        }
                        catch (SqlException ex)
                        {

                        }
                    }
                }
                script = File.ReadAllText(@"scripts/createProcedures.sql");
                commandStrings = Regex.Split(script, @"^\s*GO\s*$", RegexOptions.Multiline | RegexOptions.IgnoreCase);
                foreach (string sql in commandStrings)
                {
                    if (!sql.Equals(""))
                    {
                        comm = new SqlCommand(sql.Replace("\n", "").Replace("\r", ""), myConnection);
                        comm.CommandType = System.Data.CommandType.Text;
                        try
                        {
                            comm.ExecuteNonQuery();
                        }
                        catch (SqlException ex)
                        {

                        }
                    }
                }
            }
        }

        private void dbFillButton_Click(object sender, EventArgs e)
        {
            if (myConnection != null)
            {
                string script = File.ReadAllText(@"scripts/fillTables.sql");
                IEnumerable<string> commandStrings = Regex.Split(script, @"^\s*GO\s*$", RegexOptions.Multiline | RegexOptions.IgnoreCase);
                SqlCommand comm;
                foreach (string sql in commandStrings)
                {
                    if (!sql.Equals(""))
                    {
                        comm = new SqlCommand(sql.Replace("\n", "").Replace("\r", ""), myConnection);
                        comm.CommandType = System.Data.CommandType.Text;
                        try
                        {
                            comm.ExecuteNonQuery();
                        }
                        catch (SqlException ex)
                        {

                        }
                    }
                }
            }
        }

        private void generate_Click(object sender, EventArgs e)
        {
            if(scenarioLanguage.Text.Length <= 0)
            {
                DB_operations.generateScenarios.generate("general", myConnection);
            } else
            {
                DB_operations.generateScenarios.generate(scenarioLanguage.Text, myConnection);
            }
        }
    }
}
