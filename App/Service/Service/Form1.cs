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
        private SqlConnection myConnection;

        public Form1()
        {
            InitializeComponent();
            Log("Spuštění programu");
        }

        private void Log(string message)
        {
            //dataGridView_Log.Rows.Add(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss", CultureInfo.InvariantCulture), message);
        }

        private void backgroundWorker_Connection_DoWork(object sender, DoWorkEventArgs e)
        {

        }
    }
}
