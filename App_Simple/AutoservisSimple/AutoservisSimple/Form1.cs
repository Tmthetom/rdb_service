using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace AutoservisSimple
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            comboBox.SelectedIndex = 0;
        }

        /*string connectionString = "" +
            "server=(local)\\SQLExpress;" +
            "database=Autoservis;" +
            "integrated Security=SSPI;";*/
        string connectionString = "Server=147.230.21.34;" +
            "database=RDB_TomasMoravec;" +
            "Trusted_Connection=yes" +
            "User ID=student" + 
            "password=student";
        Color OkeyColor = Color.Green;
        Color ErrorColor = Color.Red;

        private void Button_CreateTables_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = openFileDialog1.ShowDialog();
                if (result == DialogResult.OK)
                {
                    // Prepare data
                    string file = openFileDialog1.FileName;
                    string createScript = File.ReadAllText(file);
                    IEnumerable<string> commandStrings = SplitSqlStatements(createScript);

                    // Database connection
                    SqlConnection connection = new SqlConnection(connectionString);
                    SqlCommand command;
                    connection.Open();

                    // Create tables
                    foreach (string oneCommand in commandStrings)
                    {
                        command = new SqlCommand(oneCommand, connection)
                        {
                            CommandType = CommandType.Text
                        };
                        command.ExecuteNonQuery();
                    }
                }
                else
                {
                    throw new ArgumentException("File not selected");
                }

                panel_CreateTables.BackColor = OkeyColor;
            }
            catch (Exception exception)
            {
                if (!exception.ToString().Contains("File not selected"))
                {
                    Report(exception.ToString());
                }
                panel_CreateTables.BackColor = ErrorColor;
            }
        }

        private static IEnumerable<string> SplitSqlStatements(string sqlScript)
        {
            // Split by "GO" statements
            var statements = Regex.Split(
                    sqlScript,
                    @"^\s*GO\s*$",
                    RegexOptions.Multiline |
                    RegexOptions.IgnorePatternWhitespace |
                    RegexOptions.IgnoreCase);

            // Remove empties, trim, and return
            return statements
                .Where(x => !string.IsNullOrWhiteSpace(x))
                .Select(x => x.Trim(' ', '\r', '\n'));
        }

        private void Button_InsertRows_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = openFileDialog1.ShowDialog();
                if (result == DialogResult.OK)
                {
                    // Prepare data
                    string file = openFileDialog1.FileName;
                    string createScript = File.ReadAllText(file);
                    IEnumerable<string> commandStrings = SplitSqlStatements(createScript);

                    // Database connection
                    SqlConnection connection = new SqlConnection(connectionString);
                    SqlCommand command;
                    connection.Open();

                    // Insert rows
                    foreach (string oneCommand in commandStrings)
                    {
                        command = new SqlCommand(oneCommand, connection)
                        {
                            CommandType = CommandType.Text
                        };
                        command.ExecuteNonQuery();
                    }

                    // Load languages from database
                    using (command = new SqlCommand("SELECT Language_Code FROM Languages", connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            comboBox.Items.Clear();

                            while (reader.Read())
                            {
                                comboBox.Items.Add(reader.GetString(0));
                            }
                        }

                        comboBox.SelectedIndex = 0;
                    }
                }
                else
                {
                    throw new ArgumentException("File not selected");
                }

                panel_InsertRows.BackColor = OkeyColor;
            }
            catch (Exception exception)
            {
                if (!exception.ToString().Contains("File not selected"))
                {
                    Report(exception.ToString());
                }
                panel_InsertRows.BackColor = ErrorColor;
            }
        }

        private void ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (panel_InsertRows.BackColor == OkeyColor)
            {
                try
                {
                    panel_SelectLanguage.BackColor = OkeyColor;
                }
                catch
                {
                    panel_SelectLanguage.BackColor = ErrorColor;
                }
            }
        }

        private void Button_Export_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            Database_Objects.ExportToJson.Generate("CS", connection);

            /*
            if (panel_SelectLanguage.BackColor == OkeyColor)
            {
                try
                {
                    ExportToJson();
                    panel_Export.BackColor = OkeyColor;
                }
                catch (Exception exception)
                {
                    Report(exception.ToString());
                    panel_Export.BackColor = ErrorColor;
                }
            }*/
        }

        private void Button_Clear_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = openFileDialog1.ShowDialog();
                if (result == DialogResult.OK)
                {
                    // Prepare data
                    string file = openFileDialog1.FileName;
                    string createScript = File.ReadAllText(file);
                    IEnumerable<string> commandStrings = SplitSqlStatements(createScript);

                    // Database connection
                    SqlConnection connection = new SqlConnection(connectionString);
                    SqlCommand command;
                    connection.Open();

                    // Drop tables
                    foreach (string oneCommand in commandStrings)
                    {
                        command = new SqlCommand(oneCommand, connection)
                        {
                            CommandType = CommandType.Text
                        };
                        command.ExecuteNonQuery();
                    }
                }
                else
                {
                    throw new ArgumentException("File not selected");
                }

                // Clear settings
                panel_CreateTables.BackColor = SystemColors.Control;
                panel_InsertRows.BackColor = SystemColors.Control;
                panel_SelectLanguage.BackColor = SystemColors.Control;
                panel_Export.BackColor = SystemColors.Control;
                panel_Clear.BackColor = SystemColors.Control;
            }
            catch (Exception exception)
            {
                if (!exception.ToString().Contains("File not selected"))
                {
                    Report(exception.ToString());
                }
                panel_Clear.BackColor = ErrorColor;
            }
        }

        private void Report(string message)
        {
            MessageBox.Show(message);
        }
    }
}