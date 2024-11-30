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
    public partial class Şifremi_Unuttum : Form
    {
        public Şifremi_Unuttum()
        {
            InitializeComponent();
        }
        SqlConnection güncelle = new SqlConnection("Data Source=DESKTOP-L2ORHG2\\MSSQLSERVER01;Initial Catalog=Hastane;Integrated Security=True");
        private void button1_Click(object sender, EventArgs e)
        {
            güncelle.Open();
            SqlCommand güncel = new SqlCommand("Update Hasta Set Sifre=@a1 where HastaTc=@a2 ", güncelle);
            güncel.Parameters.AddWithValue("@a1", textBox1.Text);
            güncel.Parameters.AddWithValue("@a2", maskedTextBox1.Text);
            if (textBox1.Text == textBox2.Text)
            {
                güncel.ExecuteNonQuery();
                güncelle.Close();
            }
            else
            {
                MessageBox.Show("İki Şifre Aynı Değil!");
                güncelle.Close();
                return;
               
            }
            

            Form1 frm = new Form1();
            frm.Show();
            this.Close();


        }

        private void Şifremi_Unuttum_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
        }
    }
}
