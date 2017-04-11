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

        public Form1()
        {
            InitializeComponent();

            // Do this only when VPN online
            connection = new Database_Operation.Connection("147.230.21.34", "RDB_Moravec", "student", "student");
            Database_Export.ExportToJson.Generate("EN", connection.Get());
        }

        private void backgroundWorker_Connection_DoWork(object sender, DoWorkEventArgs e)
        {

        }
    }
}
