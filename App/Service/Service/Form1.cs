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
            DatabaseConnection_Init();
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
                return false;
            }

            // Connection success
            else
            {
                // Toolstrip information
                statusStrip.BackColor = Color.YellowGreen;
                toolStripStatusLabel.ForeColor = SystemColors.ControlText;
                toolStripStatusLabel.Text = "Connected to " + myConnection.GetDatabaseName() + " at " + myConnection.GetServerAddress();
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
            backgroundWorker_Connection.RunWorkerAsync();
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

        #region Database_CreateScript
        private void Panel_CreateScript_DragAndDrop_Click(object sender, EventArgs e)
        {

        }

        private void Panel_CreateScript_DragAndDrop_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy;
            panel_CreateScript_DragAndDrop.BackColor = Color.GreenYellow;
        }

        private void Panel_CreateScript_DragAndDrop_DragLeave(object sender, EventArgs e)
        {
            panel_CreateScript_DragAndDrop.BackColor = Color.Transparent;
        }

        private void Panel_CreateScript_DragAndDrop_DragDrop(object sender, DragEventArgs e)
        {
            button_CreateScript.Enabled = true;
        }

        private void Button_CreateScript_Click(object sender, EventArgs e)
        {
            button_CreateScript.Enabled = false;
            panel_CreateScript_DragAndDrop.BackColor = Color.Transparent;
        }
        #endregion

        #region Database_InsertScript
        private void Panel_InsertScript_DragAndDrop_Click(object sender, EventArgs e)
        {

        }

        private void Panel_InsertScript_DragAndDrop_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy;
            panel_InsertScript_DragAndDrop.BackColor = Color.GreenYellow;
        }

        private void Panel_InsertScript_DragAndDrop_DragLeave(object sender, EventArgs e)
        {
            panel_InsertScript_DragAndDrop.BackColor = Color.Transparent;
        }

        private void Panel_InsertScript_DragAndDrop_DragDrop(object sender, DragEventArgs e)
        {
            button_InsertScript.Enabled = true;
        }

        private void Button_InsertScript_Click(object sender, EventArgs e)
        {
            button_InsertScript.Enabled = false;
            panel_InsertScript_DragAndDrop.BackColor = Color.Transparent;
        }
        #endregion

        #region Database_DropScript
        private void Panel_DropScript_DragAndDrop_Click(object sender, EventArgs e)
        {

        }

        private void Panel_DropScript_DragAndDrop_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy;
            panel_DropScript_DragAndDrop.BackColor = Color.GreenYellow;
        }

        private void Panel_DropScript_DragAndDrop_DragLeave(object sender, EventArgs e)
        {
            panel_DropScript_DragAndDrop.BackColor = Color.Transparent;
        }

        private void Panel_DropScript_DragAndDrop_DragDrop(object sender, DragEventArgs e)
        {
            button_DropScript.Enabled = true;
        }

        private void Button_DropScript_Click(object sender, EventArgs e)
        {
            button_DropScript.Enabled = false;
            panel_DropScript_DragAndDrop.BackColor = Color.Transparent;
        }
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
    }
}
