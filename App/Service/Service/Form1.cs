using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Service
{
    public partial class Form1 : Form
    {
        private SqlConnection myConnection;
        private Log.Logger log;

        public Form1()
        {
            InitializeComponent();
            Init_Log();
            Log("Inicializace");
        }

        private void Init_Log()
        {
            log = new Log.Logger();
            dataGridView_Log.DataSource = log.GetList();
        }

        private void Log(string message)
        {
            log.Add(message);
        }

        private void backgroundWorker_Connection_DoWork(object sender, DoWorkEventArgs e)
        {
            /*
            SqlCredential user = null;
            if (radioButton2.Checked)
            {
                if (passwordBox.Text.Length <= 0)
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
            }*/
        }
    }
}
