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
        private Database_Operation.Connection connection;

        /// <summary>
        /// Loading of form
        /// </summary>
        public Form1()
        {
            InitializeComponent();
            backgroundWorker_Connection.RunWorkerAsync();
        }

        #region Database Connection
        /// <summary>
        /// Connect to database with provided informations in different thread
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BackgroundWorker_Connection_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                connection = new Database_Operation.Connection("147.230.21.34", "RDB_Moravec", "student", "student");
            }
            catch (Exception exception)
            {
                if (!exception.Message.Contains("Login failed"))  // Not login problem
                {
                    MessageBox.Show(exception.Message);
                }
                connection = null;
            }
        }

        /// <summary>
        /// When database connection completed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BackgroundWorker_Connection_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            CheckDatabaseConnection();
            //Database_Export.ExportToJson.Generate("EN", connection.Get());
        }

        /// <summary>
        /// Check database connection failed or success
        /// </summary>
        private void CheckDatabaseConnection()
        {
            if (connection == null)  // Connection failed
            {
                statusStrip.BackColor = Color.DarkRed;
                toolStripStatusLabel.ForeColor = Color.White;
                toolStripStatusLabel.Text = "Connection failed";
            }
            else  // Connection success
            {
                statusStrip.BackColor = Color.YellowGreen;
                toolStripStatusLabel.ForeColor = SystemColors.ControlText;

                toolStripStatusLabel.Text = "Connected to " + connection.GetDatabaseName() + " at " + connection.GetServerAddress();
            }
        }
        #endregion
    }
}
