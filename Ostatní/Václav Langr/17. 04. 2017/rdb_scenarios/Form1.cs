using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Security;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace rdb_scenarios
{
    public partial class Form1 : Form
    {
        private SqlConnection myConnection;
        public static string logged_user;
        public Form1()
        {
            InitializeComponent();
        }
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            panel2.Visible = false;
            label1.Visible = label2.Visible = true;
            ipAddressBox.Visible = dbNameBox.Visible = true; ;
        }
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            panel2.Visible = true;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if(backgroundWorker1.IsBusy)
            {
                backgroundWorker1.CancelAsync();
            }
            backgroundWorker1.RunWorkerAsync();
            if(radioButton1.Checked)
            {
                logged_user = Environment.UserName;
            } else
            {
                logged_user = userNameBox.Text;
            }
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
            if (radioButton3.Checked)
            {
                myConnection = new SqlConnection("network address=147.230.21.34; password=student; user id=student; database=RDB_Langr");
                logged_user = "student";
            }
            else
            {
                myConnection = new SqlConnection("Server=" + ipAddressBox.Text + ";database=" + dbNameBox.Text + ";Trusted_Connection=yes", user);
            }
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
            if(myConnection != null && myConnection.State == System.Data.ConnectionState.Open)
            {
                radioButton1.Enabled = radioButton2.Enabled = false;
                userNameBox.Enabled = passwordBox.Enabled = ipAddressBox.Enabled = dbNameBox.Enabled = false;
                dbConnectButton.Enabled = false;
                dbDeleteButton.Enabled = dbCreateButton.Enabled = dbFillButton.Enabled = button1.Enabled = true;
            }
        }
        private void dbDeleteButton_Click(object sender, EventArgs e)
        {
            if (myConnection != null)
            {
                string script = Scripts.dropProcedures;
                IEnumerable<string> commandStrings = Regex.Split(script, @"^\s*GO\s*$", RegexOptions.Multiline | RegexOptions.IgnoreCase);
                SqlCommand comm;
                foreach (string sql in commandStrings)
                {
                    if (!sql.Equals("")) {
                        comm = new SqlCommand(sql.Replace("\n"," ").Replace("\r", " "), myConnection);
                        comm.CommandType = System.Data.CommandType.Text;
                        try
                        {
                            comm.ExecuteNonQuery();
                        } catch(SqlException ex)
                        {

                        }
                    }
                }
                script = Scripts.dropTables;
                commandStrings = Regex.Split(script, @"^\s*GO\s*$", RegexOptions.Multiline | RegexOptions.IgnoreCase);
                foreach (string sql in commandStrings)
                {
                    if (!sql.Equals(""))
                    {
                        comm = new SqlCommand(sql.Replace("\n", " ").Replace("\r", " "), myConnection);
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
                string script = Scripts.createTables;
                IEnumerable<string> commandStrings = Regex.Split(script, @"^\s*GO\s*$", RegexOptions.Multiline | RegexOptions.IgnoreCase);
                SqlCommand comm;
                foreach (string sql in commandStrings)
                {
                    if (!sql.Equals(""))
                    {
                        comm = new SqlCommand(sql.Replace("\n", " ").Replace("\r", " "), myConnection);
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
                script = Scripts.createProcedures;
                commandStrings = Regex.Split(script, @"^\s*GO\s*$", RegexOptions.Multiline | RegexOptions.IgnoreCase);
                foreach (string sql in commandStrings)
                {
                    if (!sql.Equals(""))
                    {
                        comm = new SqlCommand(sql.Replace("\n", " ").Replace("\r", " "), myConnection);
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
                script = Scripts.createLogTriggers;
                commandStrings = Regex.Split(script, @"^\s*GO\s*$", RegexOptions.Multiline | RegexOptions.IgnoreCase);
                foreach (string sql in commandStrings)
                {
                    if (!sql.Equals(""))
                    {
                        comm = new SqlCommand(sql.Replace("\n", " ").Replace("\r", " ").Replace("\t", " "), myConnection);
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
                script = Scripts.createValidationTriggers;
                commandStrings = Regex.Split(script, @"^\s*GO\s*$", RegexOptions.Multiline | RegexOptions.IgnoreCase);
                foreach (string sql in commandStrings)
                {
                    if (!sql.Equals(""))
                    {
                        comm = new SqlCommand(sql.Replace("\n", " ").Replace("\r", " ").Replace("\t", " "), myConnection);
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
                string script = Scripts.fillTables;
                IEnumerable<string> commandStrings = Regex.Split(script, @"^\s*GO\s*$", RegexOptions.Multiline | RegexOptions.IgnoreCase);
                SqlCommand comm;
                foreach (string sql in commandStrings)
                {
                    if (!sql.Equals(""))
                    {
                        comm = new SqlCommand(sql.Replace("\n", " ").Replace("\r", " "), myConnection);
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
        private void button1_Click_1(object sender, EventArgs e)
        {
            AdministrationForm f = new AdministrationForm(myConnection);
            f.Show();
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            panel2.Visible = false;
            ipAddressBox.Visible = false;
            dbNameBox.Visible = false;
            label1.Visible = label2.Visible = false;
        }
    }
}
