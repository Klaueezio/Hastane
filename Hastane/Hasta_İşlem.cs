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
    public partial class Hasta_İşlem : Form
    {

        public string kullanıcı { get; set; }
        public Hasta_İşlem()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-L2ORHG2\\MSSQLSERVER01;Initial Catalog=Hastane;Integrated Security=True");
        void il()
        {
            baglanti.Open();
            SqlCommand komutlar = new SqlCommand("Select * from iller ", baglanti);
            SqlDataReader r = komutlar.ExecuteReader();
            while (r.Read())
            {
                comboBox1.Items.Add(r[1]);
            }
            baglanti.Close();
        }

        void hastabilgi()
        {
            label4.Text = kullanıcı;
            baglanti.Open();
            SqlCommand ad = new SqlCommand("select * from Hasta where HastaTc=@a1", baglanti);
            ad.Parameters.AddWithValue("@a1", label4.Text);
            SqlDataReader dr = ad.ExecuteReader();
            if (dr.Read())
            {
                this.label3.Text = dr[2].ToString();
                label6.Text = dr[3].ToString();
            }
            baglanti.Close();
        }

        void datagrid()
        {
            baglanti.Open();
            string select = "Select * from Randevu where HastaTc=@p1 ";
            SqlCommand komut = new SqlCommand(select, baglanti);
            komut.Parameters.AddWithValue("@p1", label4.Text);
            SqlDataAdapter randevu = new SqlDataAdapter(komut);
            DataTable randevular = new DataTable();
            randevu.Fill(randevular);
            dataGridView2.DataSource = randevular;
            baglanti.Close();
        }
        private void Hasta_İşlem_Load(object sender, EventArgs e)
        {
            
            il();
            hastabilgi();
            datagrid();
            
        }


        void randevualma()
        {
            baglanti.Open();
            SqlCommand komutlar = new SqlCommand("insert into Randevu(Randevuİl, RandevuKlinik, RandevuTarih, RandevuSaat, HastaTc) values (@p1,@p2,@p3,@p4,@p5)", baglanti);
            komutlar.Parameters.AddWithValue("@p1", comboBox1.Text);
            komutlar.Parameters.AddWithValue("@p2", comboBox3.Text);
            komutlar.Parameters.AddWithValue("@p5", label4.Text.ToString());
            string girilenSaat = maskedTextBox1.Text.Trim();
            komutlar.Parameters.AddWithValue("@p4", girilenSaat);
            if (TimeSpan.TryParse(girilenSaat, out TimeSpan saat))
            {
            }
            else
            {
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
            MessageBox.Show("Randevu Başarıyla Alınmıştır.");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            randevualma();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Değiştir frm = new Değiştir();
            frm.tc = label4.Text;
            frm.Show();
            this.Hide();
            //form değiştirme
           
        }

        private void label3_Click(object sender, EventArgs e)
        {
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.Items.Clear();
            comboBox2.Text = string.Empty;
            comboBox3.Items.Clear();
            comboBox3.Text = string.Empty;
            baglanti.Open();
            SqlCommand komutlar = new SqlCommand("Select * from Hastane where sehirid=@a1 ", baglanti);
            komutlar.Parameters.AddWithValue("@a1", comboBox1.SelectedIndex + 1);
            SqlDataReader r = komutlar.ExecuteReader();
            while (r.Read())
            {
                comboBox2.Items.Add(r[4]);
            }
            baglanti.Close();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

            comboBox3.Items.Clear();
            comboBox3.Text = string.Empty;
            baglanti.Open();
            SqlCommand komutlar = new SqlCommand("Select * from Poliklinik ", baglanti);
            SqlDataReader r = komutlar.ExecuteReader();
            while (r.Read())
            {
                comboBox3.Items.Add(r[1]);
            }
            baglanti.Close();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            string select = "Select * from Randevu where HastaTc=@p1 ";
            SqlCommand komut = new SqlCommand(select, baglanti);
            komut.Parameters.AddWithValue("@p1", label4.Text);
            SqlDataAdapter randevu = new SqlDataAdapter(komut);
            DataTable randevular = new DataTable();
            randevu.Fill(randevular);
            dataGridView2.DataSource = randevular;
            baglanti.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
            
        }

        private void Hasta_İşlem_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit(); 
        }
    }
}
