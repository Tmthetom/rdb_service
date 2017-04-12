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
            List<string> languages = Database_Operation.GetLanguages.Get(myConnection);

            try
            {
                comboBox_Export_ExportLanguage.Items.Clear();

                foreach (string language in languages)
                {
                    comboBox_Export_ExportLanguage.Items.Add(language);
                }

                comboBox_Export_ExportLanguage.SelectedIndex = 0;  // Select first item
            }
            catch (Exception exception)
            {
                Message(exception.Message);
            }
        }

        #endregion

        #region Database Connection
        /// <summary>
        /// Initialize database connection
        /// </summary>
        private void DatabaseConnection_Init()
        {
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
                myConnection = new Database_Operation.Connection("147.230.21.34", "RDB_Moravec", "student", "student");
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
            DatabaseConnection_Check();
        }

        /// <summary>
        /// Check database connection failed or success
        /// </summary>
        private void DatabaseConnection_Check()
        {
            // Connection failed
            if (myConnection == null)
            {
                // Toolstrip information
                statusStrip.BackColor = Color.DarkRed;
                toolStripStatusLabel.ForeColor = Color.White;
                toolStripStatusLabel.Text = "Connection failed";
            }

            // Connection success
            else
            {
                // Toolstrip information
                statusStrip.BackColor = Color.YellowGreen;
                toolStripStatusLabel.ForeColor = SystemColors.ControlText;
                toolStripStatusLabel.Text = "Connected to " + myConnection.GetDatabaseName() + " at " + myConnection.GetServerAddress();

                Export_Init();
            }
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
