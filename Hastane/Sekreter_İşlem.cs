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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Hastane
{
    public partial class Sekreter_İşlem : Form
    {
        public string kullanıcı { get; set; }
        public Sekreter_İşlem()
        {
            InitializeComponent();
        }
       void Poliklink()
        {
            baglanti.Open();
            SqlCommand komutlar = new SqlCommand("Select * from Poliklinik ", baglanti);
            SqlDataReader r = komutlar.ExecuteReader();
            while (r.Read())
            {
                comboBox1.Items.Add(r[1]);
            }
            baglanti.Close();
        }
        void ad()
        {
            baglanti.Open();
            SqlCommand ad = new SqlCommand("select * from Sekreter where SekreterTc=@a1", baglanti);
            ad.Parameters.AddWithValue("@a1", label4.Text);
            SqlDataReader dr = ad.ExecuteReader();
            if (dr.Read())
            {
                label3.Text = dr[2].ToString();
                label6.Text = dr[3].ToString();
                label12.Text = dr[5].ToString();
            }
            baglanti.Close();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-L2ORHG2\\MSSQLSERVER01;Initial Catalog=Hastane;Integrated Security=True");
        private void Sekreter_İşlem_Load(object sender, EventArgs e)
        {
            
            Poliklink();
            label4.Text = kullanıcı;
            ad();
  
        }


        private void button2_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komutlar = new SqlCommand("insert into Randevu(Randevuİl, RandevuKlinik, RandevuTarih, RandevuSaat, HastaTc) values (@p1,@p2,@p3,@p4,@p5)", baglanti);
            komutlar.Parameters.AddWithValue("@p1", label12.Text.ToString());
            komutlar.Parameters.AddWithValue("@p2", comboBox1.Text);
            komutlar.Parameters.AddWithValue("@p5", maskedTextBox1.Text);
            string girilenSaat = maskedTextBox2.Text.Trim();
            komutlar.Parameters.AddWithValue("@p4", girilenSaat);
            if (TimeSpan.TryParse(girilenSaat, out TimeSpan saat))
            {

            }
            else
            {
                // Hatalı format
                MessageBox.Show("Geçersiz saat formatı. Lütfen doğru formatta girin!");
                baglanti.Close();
                return;
            }
            DateTime tarih = dateTimePicker1.Value;
            komutlar.Parameters.AddWithValue("@p3", tarih);
            if (tarih == DateTime.Now.Date || tarih > DateTime.Now.Date)
            {

                komutlar.ExecuteNonQuery();
                baglanti.Close();

            }
            else
            {
                MessageBox.Show("Geçerli Bir Tarih Seçiniz!");
                baglanti.Close();
                return;

            }
            MessageBox.Show("Randevu Kaydedildi!");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komutlar = new SqlCommand("insert into Duyuru(Duyuru) values (@p1)", baglanti);
            komutlar.Parameters.AddWithValue("@p1", textBox1.Text);
            komutlar.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Duyuru Oluşturuldu");

        }

        private void Sekreter_İşlem_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
