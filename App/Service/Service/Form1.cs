using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Service
{
    public partial class Form1 : Form
    {
        private Database_Operation.Connection myConnection;

        /// <summary>
        /// Loading of form
        /// </summary>
        public Form1()
        {
            InitializeComponent();
            ControlsDisable();  // Disable all controls, except of database connection
            DatabaseConnection_Init();  // Try to connect into database
        }

        /// <summary>
        /// Initialize when connection success
        /// </summary>
        private void InitializeForm()
        {
            Export_Init();  // Load export tab
        }

        /// <summary>
        /// Clear form when connection lost
        /// </summary>
        private void ClearForm()
        {
            // Export tab
            comboBox_Export_ExportLanguage.Items.Clear();
            textBox_Export_Scenarios.Clear();
            textBox_Export_Sections.Clear();
            textBox_Export_CheckPoints.Clear();
            textBox_Export_Operations.Clear();
        }


        #region Database

        #region Database_Connection
        /// <summary>
        /// Initialize database connection
        /// </summary>
        private void DatabaseConnection_Init()
        {
             // Select first item
            comboBox_Connection_PreferedServer.SelectedIndex = 0;

            // Run initial connection
            backgroundWorker_Connection.RunWorkerAsync();
        }

        /// <summary>
        /// Connect to database with provided informations in different thread
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DatabaseConnection_Run(object sender, DoWorkEventArgs e)
        {
            try
            {
                string serverAddress = textBox_Connection_ServerAddress.Text;
                string databaseName = textBox_Connection_DatabaseName.Text;
                string username = textBox_Connection_Username.Text;
                string password = textBox_Connection_Password.Text;


                myConnection = new Database_Operation.Connection(serverAddress, databaseName, username, password);
            }
            catch (Exception exception)
            {
                if (!exception.Message.Contains("Login failed"))  // Not login problem
                {
                    MessageBox.Show(exception.Message);
                }
                myConnection = null;
            }
        }

        /// <summary>
        /// When database connection completed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DatabaseConnection_Completed(object sender, RunWorkerCompletedEventArgs e)
        {
            if (DatabaseConnection_Check())  // If connection success
            {
                if (Database_Operation.GetFromDatabase.NumberOfTables(myConnection) > 0)  // Check if tables are here
                {
                    InitializeForm();  // Load export tab
                }
                else
                {
                    Message("Database is empty");
                }
            }
        }

        /// <summary>
        /// Check database connection failed or success
        /// </summary>
        private bool DatabaseConnection_Check()
        {
            // Connection failed
            if (myConnection == null)
            {
                // Toolstrip information
                statusStrip.BackColor = Color.DarkRed;
                toolStripStatusLabel.ForeColor = Color.White;
                toolStripStatusLabel.Text = "Connection failed";

                // Controls lock
                ControlsDisable();
                return false;
            }

            // Connection success
            else
            {
                // Toolstrip information
                statusStrip.BackColor = Color.YellowGreen;
                toolStripStatusLabel.ForeColor = SystemColors.ControlText;
                toolStripStatusLabel.Text = "Connected to " + myConnection.GetDatabaseName() + " at " + myConnection.GetServerAddress();

                // Controls lock
                ControlsEnable();
                return true;
            }
        }

        /// <summary>
        /// Manual connect to database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Database_Connect_Click(object sender, EventArgs e)
        {
            // Toolstrip information
            statusStrip.BackColor = Color.Orange;
            toolStripStatusLabel.ForeColor = SystemColors.ControlText;
            toolStripStatusLabel.Text = "Connecting...";

            // Try to connect
            if (!backgroundWorker_Connection.IsBusy)
            {
                backgroundWorker_Connection.RunWorkerAsync();
            }
            else
            {
                Message("Připojování již probíhá...");
            }
        }

        /// <summary>
        /// Database connection selected server changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ComboBox_Connection_PreferedServer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_Connection_PreferedServer.Text == "Technical University of Liberec")
            {
                textBox_Connection_ServerAddress.Text = "147.230.21.34";
                textBox_Connection_DatabaseName.Text = "RDB_Moravec";
                textBox_Connection_Username.Text = "student";
                textBox_Connection_Password.Text = "student";
            }
            else
            {
                textBox_Connection_ServerAddress.Text = "";
                textBox_Connection_DatabaseName.Text = "";
                textBox_Connection_Username.Text = "";
                textBox_Connection_Password.Text = "";
            }
        }
        #endregion

        #region Do Scripts
        /// <summary>
        /// When panel clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Database_DragAndDrop_Click(object sender, EventArgs e)
        {
            // Show file dialog
            DialogResult result = openFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                // Color panel
                Panel panel = sender as Panel;
                if (panel.Name == "panel_CreateScript_DragAndDrop")
                {
                    panel = panel_CreateScript_DragAndDrop;
                }
                else if (panel.Name == "panel_InsertScript_DragAndDrop")
                {
                    panel = panel_InsertScript_DragAndDrop;
                }
                else
                {
                    panel = panel_DropScript_DragAndDrop;
                }
                panel.BackColor = Color.GreenYellow;

                Button button;
                if (panel.Name == "panel_CreateScript_DragAndDrop")
                {
                    button = button_CreateScript;
                }
                else if (panel.Name == "panel_InsertScript_DragAndDrop")
                {
                    button = button_InsertScript;
                }
                else
                {
                    button = button_DropScript;
                }
                button.Enabled = true;
            }
        }

        /// <summary>
        /// When file enter panel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Database_DragAndDrop_DragEnter(object sender, DragEventArgs e)
        {
            // Enable DragAndDrop
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy;

            // Color panel
            Panel panel = sender as Panel;
            if (panel.Name == "panel_CreateScript_DragAndDrop")
            {
                panel = panel_CreateScript_DragAndDrop;
            }
            else if (panel.Name == "panel_InsertScript_DragAndDrop")
            {
                panel = panel_InsertScript_DragAndDrop;
            }
            else
            {
                panel = panel_DropScript_DragAndDrop;
            }
            panel.BackColor = Color.GreenYellow;
        }


        /// <summary>
        /// When file leave panel without drop
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Database_DragAndDrop_DragLeave(object sender, EventArgs e)
        {
            // Reset panel
            Panel panel = sender as Panel;
            if (panel.Name == "panel_CreateScript_DragAndDrop")
            {
                panel = panel_CreateScript_DragAndDrop;
            }
            else if (panel.Name == "panel_InsertScript_DragAndDrop")
            {
                panel = panel_InsertScript_DragAndDrop;
            }
            else
            {
                panel = panel_DropScript_DragAndDrop;
            }
            panel.BackColor = Color.Transparent;
        }

        /// <summary>
        /// When file drop into panel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Database_DragAndDrop_DragDrop(object sender, DragEventArgs e)
        {
            // Enable button
            Panel panel = sender as Panel;
            Button button;
            if (panel.Name == "panel_CreateScript_DragAndDrop")
            {
                button = button_CreateScript;
            }
            else if (panel.Name == "panel_InsertScript_DragAndDrop")
            {
                button = button_InsertScript;
            }
            else
            {
                button = button_DropScript;
            }
            button.Enabled = true;
        }
        
        /// <summary>
        /// When do script button clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Database_Button_Click(object sender, EventArgs e)
        {
            // Reset button
            Button button = sender as Button;
            button.Enabled = false;

            // Reset panel
            Panel panel;
            if (button.Name == "button_CreateScript")
            {
                panel = panel_CreateScript_DragAndDrop;
            }
            else if (button.Name == "button_InsertScript")
            {
                panel = panel_InsertScript_DragAndDrop;
            }
            else
            {
                panel = panel_DropScript_DragAndDrop;
            }
            panel.BackColor = Color.Transparent;

            // Do script
            try
            {
                Database_Operation.RunScript.FromFile(openFileDialog, myConnection);
            }
            catch (Exception exception)
            {
                Message(exception.Message);
            }
        }
        #endregion

        #endregion

        #region Export
        /// <summary>
        /// Initialize export tab
        /// </summary>
        private void Export_Init()
        {
            Export_LanguagesRefresh();
        }

        /// <summary>
        /// Export database into JSON in selected language
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Export_Click(object sender, EventArgs e)
        {
            try
            {
                Database_Export.ExportToJson.Generate(comboBox_Export_ExportLanguage.Text, myConnection);
            }
            catch (Exception exception)
            {
                Message(exception.Message);
            }
        }

        /// <summary>
        /// Refresh languages for export
        /// </summary>
        private void Export_LanguagesRefresh()
        {
            List<string> languages = Database_Operation.GetFromDatabase.Languages(myConnection);

            try
            {
                // Clear old languages
                comboBox_Export_ExportLanguage.Items.Clear();

                // Add new languages
                foreach (string language in languages)
                {
                    comboBox_Export_ExportLanguage.Items.Add(language);
                }

                // Select first item
                comboBox_Export_ExportLanguage.SelectedIndex = 0;
            }
            catch (Exception exception)
            {
                Message(exception.Message);
            }
        }

        /// <summary>
        /// Refresh export information for selected language
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ComboBox_Export_ExportLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            Dictionary<string, int> components = Database_Export.ExportToJson.GetNumerOfComponents(comboBox_Export_ExportLanguage.Text, myConnection);

            textBox_Export_Scenarios.Text = components["Scenarios"].ToString();
            textBox_Export_Sections.Text = components["Sections"].ToString();
            textBox_Export_CheckPoints.Text = components["CheckPoints"].ToString();
            textBox_Export_Operations.Text = components["Operations"].ToString();
        }
        #endregion

        #region Message
        /// <summary>
        /// Show message in messageBox
        /// </summary>
        /// <param name="message">Message to show</param>
        private void Message(string message)
        {
            MessageBox.Show(message);
        }

        #endregion

        #region FormControls

        /// <summary>
        /// Enable all controls, except of database connection
        /// </summary>
        private void ControlsEnable()
        {
            // Main tabs
            tabPage_Scenarios.Enabled = true;  // Scenarios
            tabPage_Editor.Enabled = true;  // Editor
            tabPage_Language.Enabled = true;  // Language
            tabPage_Export.Enabled = true;  // Export

            // Database tabs
            tabPage_Database_CreateScript.Enabled = true;  // Create script
            tabPage_Database_InsertScript.Enabled = true;  // Insert script
            tabPage_Database_DropScript.Enabled = true;  // Drop script
        }

        /// <summary>
        /// Disable all control. except of database connection
        /// </summary>
        private void ControlsDisable()
        {
            tabPage_Scenarios.Enabled = false;  // Scenarios
            tabPage_Editor.Enabled = false;  // Editor
            tabPage_Language.Enabled = false;  // Language
            tabPage_Export.Enabled = false;  // Export

            // Database tabs
            tabPage_Database_CreateScript.Enabled = false;  // Create script
            tabPage_Database_InsertScript.Enabled = false;  // Insert script
            tabPage_Database_DropScript.Enabled = false;  // Drop script

        }

        #endregion
    }
}
