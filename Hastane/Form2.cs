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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        SqlConnection b = new SqlConnection("Data Source=DESKTOP-L2ORHG2\\MSSQLSERVER01;Initial Catalog=Hastane;Integrated Security=True");
        private void Form2_Load(object sender, EventArgs e)
        {
            Text = "Hasta_Giriş";
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Şifremi_Unuttum frm = new Şifremi_Unuttum();
            frm.Show();
            this.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Kayıt frm = new Kayıt();
            frm.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            b.Open();
            SqlCommand komut = new SqlCommand("Select*From Hasta where HastaTc=@p1 and Sifre=@p2", b);
            komut.Parameters.AddWithValue("@p1", maskedTextBox1.Text);
            komut.Parameters.AddWithValue("@p2", textBox1.Text);
            SqlDataReader dr = komut.ExecuteReader();
            if(dr.Read())
            {
                Hasta_İşlem frm = new Hasta_İşlem();
                frm.kullanıcı = maskedTextBox1.Text;
                frm.Show();
                this.Hide();

            }
            else
            {
                MessageBox.Show("Tekrar Deneyiniz!");
            }
          b.Close();

            


        }
        

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBox1.PasswordChar = '\0';
            }
            else
            {
                textBox1.PasswordChar = '*';
            }
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
        }
    }
}
