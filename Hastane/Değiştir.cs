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
    public partial class Değiştir : Form
    {
        public string tc { get; set; }
        public Değiştir()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-L2ORHG2\\MSSQLSERVER01;Initial Catalog=Hastane;Integrated Security=True");
       void bilgi_degistirme()
        {
            baglanti.Open();
            SqlCommand guncelle = new SqlCommand("Update Hasta Set Sifre=@a1, HastaAdı=@a2, HastaSoyadı=@a3,HastaTelefon=@a4, HastaDogum_Yeri=@a5, HastaDogum_Tarihi=@a6, HastaCinsiyet=@a7  where HastaTc=@a8", baglanti);
            guncelle.Parameters.AddWithValue("@a8", maskedTextBox1.Text);
            guncelle.Parameters.AddWithValue("@a2", textBox1.Text);
            guncelle.Parameters.AddWithValue("@a3", textBox2.Text);
            guncelle.Parameters.AddWithValue("@a4", maskedTextBox2.Text);
            guncelle.Parameters.AddWithValue("@a5", comboBox2.Text);
            guncelle.Parameters.AddWithValue("@a6", maskedTextBox3.Text);
            guncelle.Parameters.AddWithValue("@a7", comboBox1.Text);
            guncelle.Parameters.AddWithValue("@a1", textBox4.Text);
            guncelle.ExecuteNonQuery();
            MessageBox.Show("Kayıt güncellendi");
            baglanti.Close();

        }
        private void button1_Click(object sender, EventArgs e)
        {
           bilgi_degistirme();
        }


        void bilgiler()
        {
            baglanti.Open();
            SqlCommand komutlar = new SqlCommand("Select * from iller ", baglanti);
            SqlDataReader r = komutlar.ExecuteReader();
            while (r.Read())
            {
                comboBox2.Items.Add(r[1]);
            }
            baglanti.Close();

            maskedTextBox1.Text = tc;
            baglanti.Open();
            SqlCommand ad = new SqlCommand("select * from Hasta where HastaTc=@a1", baglanti);
            ad.Parameters.AddWithValue("@a1", maskedTextBox1.Text);
            SqlDataReader dr = ad.ExecuteReader();
            if (dr.Read())
            {
                textBox1.Text = dr[2].ToString();
                textBox2.Text = dr[3].ToString();
                maskedTextBox2.Text = dr[4].ToString();
                comboBox2.Text = dr[5].ToString();
                maskedTextBox3.Text = dr[6].ToString();
                comboBox1.Text = dr[7].ToString();
                textBox4.Text = dr[8].ToString();

            }
            baglanti.Close();
        }
        private void Değiştir_Load(object sender, EventArgs e)
        {
            bilgiler();
        }

        private void Değiştir_FormClosed(object sender, FormClosedEventArgs e)
        {
            
            this.Hide();
            Application.OpenForms["Hasta_İşlem"].Show();
        }
    }
}
