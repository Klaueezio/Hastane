using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hastane
{
    public partial class Duyuru : Form
    {
        public Duyuru()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-L2ORHG2\\MSSQLSERVER01;Initial Catalog=Hastane;Integrated Security=True"); 
        private void Duyuru_Load(object sender, EventArgs e)
        {
            this.duyuruTableAdapter.Fill(this.hastaneDataSet2.Duyuru);

        }
    }
}
