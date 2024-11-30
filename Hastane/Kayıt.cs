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

namespace Hastane
{
    public partial class Kayıt : Form
    {
        public Kayıt()
        {
            InitializeComponent();
        }
        SqlConnection ekle = new SqlConnection("Data Source=DESKTOP-L2ORHG2\\MSSQLSERVER01;Initial Catalog=Hastane;Integrated Security=True");
        private void label8_Click(object sender, EventArgs e)
        {
        }
        void ilekle()
        {
            ekle.Open();
            SqlCommand komutlar = new SqlCommand("Select * from iller ", ekle);
            SqlDataReader r = komutlar.ExecuteReader();
            while (r.Read())
            {
                comboBox1.Items.Add(r[1]);
            }
            ekle.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            
            ekle.Open();
            SqlCommand komutlar = new SqlCommand("insert into Hasta(HastaTc,HastaAdı,HastaSoyadı, HastaTelefon, HastaDogum_Yeri, HastaDogum_Tarihi,HastaCinsiyet, Sifre) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8)", ekle);
            komutlar.Parameters.AddWithValue("@p1", maskedTextBox1.Text);
            komutlar.Parameters.AddWithValue("@p2", textBox1.Text);
            komutlar.Parameters.AddWithValue("@p3", textBox2.Text);
            komutlar.Parameters.AddWithValue("@p4", maskedTextBox2.Text);
            komutlar.Parameters.AddWithValue("@p5", comboBox1.Text);
            komutlar.Parameters.AddWithValue("@p6", maskedTextBox3.Text);
            komutlar.Parameters.AddWithValue("@p7", comboBox2.Text);
            komutlar.Parameters.AddWithValue("@p8", textBox3.Text);
            komutlar.ExecuteNonQuery();
            ekle.Close();
            MessageBox.Show("kayıt gerçekleşti");
            Form2 frm = new Form2();
            frm.Show();
            this.Hide();

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {  
        }

        private void Kayıt_Load(object sender, EventArgs e)
        {
            ilekle();
        }

        private void Kayıt_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form2 frm = new Form2();
            frm.Show();
        }
    }
}
