using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Ststistics : Form
    {
        MySqlCommand scom = null;
        MySqlDataReader sdr = null;
        DateTime selectedDate;

        public Ststistics(MySqlCommand scom)
        {
            InitializeComponent();
            DatabaseSetting(scom);
            SetDate();
            SetStst();
        }

        private void SetDate()
        {

        }

        private void DatabaseSetting(MySqlCommand scom)
        {
            this.scom = scom;
        }

        private void StstisticsLoad(object sender, EventArgs e)
        {

        }
    }
}
