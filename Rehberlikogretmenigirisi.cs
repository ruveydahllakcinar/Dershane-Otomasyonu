using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace DershaneEtut_Otomasyonu
{
    public partial class Rehberlikogretmenigirisi : Form
    {
        public Rehberlikogretmenigirisi()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OleDbConnection bag = new OleDbConnection("provider=microsoft.ace.oledb.12.0;data source=etutveritabani.accdb");
            bag.Open();

            OleDbCommand giris = new OleDbCommand("select * from RehberlikOgretmeni_Giris where Ogretmen_kullaniciadi = @Ogretmen_kullaniciadi and Sifre = @Sifre");
            giris.Connection = bag;
            giris.Parameters.Add("Ogretmen_kullaniciadi", textBox1.Text);
            giris.Parameters.Add("Sifre", textBox2.Text);

            OleDbDataReader oku = giris.ExecuteReader();

            if (oku.Read())
            {
                MenuSayfasi ac = new MenuSayfasi();
                ac.Show();
                this.Hide();
                bag.Close();
            }
            else
            {
                MessageBox.Show("hatalı giriş yaptınız");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 ac = new Form1();
            ac.Show();
            this.Hide();
        }
    }
}
