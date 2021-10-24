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
    public partial class MenuSayfasi : Form
    {
        OleDbConnection bag = new OleDbConnection("provider=microsoft.ace.oledb.12.0;data source=etutveritabani.accdb");
        
        DataTable tablo = new DataTable();
        OleDbCommand komut = new OleDbCommand();
        public MenuSayfasi()
        {
            InitializeComponent();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e) // Etüt sayfasi - Etüt ekle
        {
            bag.Open();
            OleDbCommand komut = new OleDbCommand("insert into Etut_Tablo(Ogrenci_Ad,Tarih,Hangi_Ders,Saat,Ogretmen_id) values('" + textBox3.Text + "','" + dateTimePicker1.Text + "','" + textBox6.Text + "','" + comboBox1.SelectedItem + ":" + comboBox2.SelectedItem + "','" + textBox6.Text + "')", bag);
            komut.ExecuteNonQuery();
            MessageBox.Show("Talep Edilen Etüt Oluşturuldu", "Kayıt");

            DataSet ds = new DataSet();
            OleDbDataAdapter adtr = new OleDbDataAdapter("select * from Etut_Tablo", bag);

            adtr.Fill(ds, "Ders_Programi");
            dataGridView1.DataSource = ds.Tables["Ders_Programi"];

            bag.Close();

            textBox3.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            
            comboBox1.SelectedItem = null;
            comboBox2.SelectedItem = null;
            dateTimePicker1.Value = DateTime.Now;
        }

        private void button10_Click(object sender, EventArgs e) // Etüt sayfasi - Etüt listele
        {
            bag.Open();
            DataSet ds = new DataSet();
            OleDbDataAdapter adtr = new OleDbDataAdapter("select * from Etut_Tablo", bag);

            adtr.Fill(ds, "Ders_Programi");
            dataGridView1.DataSource = ds.Tables["Ders_Programi"];


            bag.Close();
        }

        private void button9_Click(object sender, EventArgs e) // Etüt sayfasi - Etüt sil
        {
            for (int i = 0; i < dataGridView1.SelectedRows.Count; i++)
            {
                bag.Open();
                OleDbCommand komut2 = new OleDbCommand("delete from Etut_Tablo where Ogrenci_Ad='" + dataGridView1.SelectedRows[i].Cells["Ogrenci_Ad"].Value.ToString() + "'", bag);
                komut2.ExecuteNonQuery();

            }
            DataSet ds = new DataSet();
            OleDbDataAdapter adtr = new OleDbDataAdapter("select * from Etut_Tablo", bag);

            adtr.Fill(ds, "Ders_Programi");
            dataGridView1.DataSource = ds.Tables["Ders_Programi"];
            bag.Close();
            MessageBox.Show("Seçilen Etüt Silindi.");
        }

        private void button4_Click(object sender, EventArgs e) // öğretmen bilgileri sayfasi - öğretmen ekle
        {
            bag.Open();
            OleDbCommand komut = new OleDbCommand("insert into Ogretmen_Tablo(AdSoyad,Bransi,Mail,Telefon_No) values('" + textBox2.Text + "','" + comboBox4.SelectedItem + "','" + textBox4.Text + "','" + maskedTextBox1.Text.ToString() + "')", bag);
            komut.ExecuteNonQuery();
            MessageBox.Show("Talep Edilen Etüt Oluşturuldu", "Kayıt");

            DataSet ds = new DataSet();
            OleDbDataAdapter adtr = new OleDbDataAdapter("select * from Ogretmen_Tablo", bag);

            adtr.Fill(ds, "Ders_Programi");
            dataGridView2.DataSource = ds.Tables["Ders_Programi"];

            bag.Close();

            textBox2.Text = "";
            textBox4.Text = "";
            comboBox4.SelectedItem = null;
            maskedTextBox1.Text = "";
        }

        private void button5_Click(object sender, EventArgs e)  // öğretmen bilgileri sayfasi - öğretmen sil
        {
            for (int i = 0; i < dataGridView2.SelectedRows.Count; i++)
            {
                bag.Open();
                OleDbCommand komut2 = new OleDbCommand("delete from Ogretmen_Tablo where AdSoyad='" + dataGridView2.SelectedRows[i].Cells["AdSoyad"].Value.ToString() + "'", bag);
                komut2.ExecuteNonQuery();

            }
            DataSet ds = new DataSet();
            OleDbDataAdapter adtr = new OleDbDataAdapter("select * from Ogretmen_Tablo", bag);

            adtr.Fill(ds, "Ders_Programi");
            dataGridView2.DataSource = ds.Tables["Ders_Programi"];
            bag.Close();
            MessageBox.Show("Seçilen Öğretmen Silindi.");
        }

        private void button19_Click(object sender, EventArgs e)  // öğretmen bilgileri sayfasi - listeleme
        {
            bag.Open();
            DataSet ds = new DataSet();
            OleDbDataAdapter adtr = new OleDbDataAdapter("select * from Ogretmen_Tablo", bag);

            adtr.Fill(ds, "Ders_Programi");
            dataGridView2.DataSource = ds.Tables["Ders_Programi"];

            bag.Close();

        }

        private void button6_Click(object sender, EventArgs e)  // öğretmen bilgileri sayfasi - öğretmen bilgileri güncelleme
        {
            bag.Open();


            OleDbCommand komut = new OleDbCommand();
            komut.Connection = bag;

            komut.CommandText = "update Ogretmen_Tablo set AdSoyad='" + textBox2.Text + "', Bransi='" + comboBox4.Text + "', Mail='" + textBox4.Text + "', Telefon_No='" + maskedTextBox1.Text + "' where id ='" + textBox17.Text + "'";

            komut.ExecuteNonQuery();
            DataSet ds = new DataSet();
            OleDbDataAdapter adtr = new OleDbDataAdapter("select * from Ogretmen_Tablo", bag);

            adtr.Fill(ds, "Ders_Programi");
            dataGridView2.DataSource = ds.Tables["Ders_Programi"];

            bag.Close();


        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e) // öğretmen bilgileri sayfasi -  datagrid
        {
            textBox17.Text = dataGridView2.CurrentRow.Cells[0].Value.ToString();
            textBox2.Text = dataGridView2.CurrentRow.Cells[1].Value.ToString();
            comboBox4.Text = dataGridView2.CurrentRow.Cells[2].Value.ToString();
            textBox4.Text = dataGridView2.CurrentRow.Cells[5].Value.ToString();
            maskedTextBox1.Text = dataGridView2.CurrentRow.Cells[6].Value.ToString();

        }

        private void button1_Click(object sender, EventArgs e) // öğrenci  bilgileri sayfasi - öğrenci ekle
        {
            bag.Open();
            OleDbCommand komut = new OleDbCommand("insert into Ogrenci_Tablo(AdSoyad,Okul_No,Sinif,Telefon_No,Mail) values('" + textBox8.Text + "','" + textBox1.Text + "','" +  comboBox5.SelectedItem + "','" +  maskedTextBox2.Text.ToString() + "','" + textBox9.Text + "')", bag);
            komut.ExecuteNonQuery();
            MessageBox.Show("Öğrenci Kaydı Oluşturuldu", "Kayıt");

            DataSet ds = new DataSet();
            OleDbDataAdapter adtr = new OleDbDataAdapter("select * from Ogrenci_Tablo", bag);

            adtr.Fill(ds, "Ders_Programi");
            dataGridView3.DataSource = ds.Tables["Ders_Programi"];

            bag.Close();

            textBox8.Text = "";
            textBox1.Text = "";
            comboBox5.SelectedItem = null;
            maskedTextBox2.Text = "";
        }

        private void button2_Click(object sender, EventArgs e) // öğrenci  bilgileri sayfasi - öğrenci bilgisi sil
        {
            for (int i = 0; i < dataGridView3.SelectedRows.Count; i++)
            {
                bag.Open();
                OleDbCommand komut2 = new OleDbCommand("delete from Ogrenci_Tablo where AdSoyad='" + dataGridView3.SelectedRows[i].Cells["AdSoyad"].Value.ToString() + "'", bag);
                komut2.ExecuteNonQuery();

            }

            DataSet ds = new DataSet();
            OleDbDataAdapter adtr = new OleDbDataAdapter("select * from Ogrenci_Tablo", bag);

            adtr.Fill(ds, "Ders_Programi");
            dataGridView3.DataSource = ds.Tables["Ders_Programi"];
            bag.Close();
            MessageBox.Show("Seçilen Öğrenci Silindi.");
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)  // öğrenci  bilgileri sayfasi - datagrid
        {
            textBox18.Text = dataGridView3.CurrentRow.Cells[0].Value.ToString();
            textBox8.Text = dataGridView3.CurrentRow.Cells[1].Value.ToString();
            textBox1.Text = dataGridView3.CurrentRow.Cells[5].Value.ToString();
            textBox9.Text = dataGridView3.CurrentRow.Cells[2].Value.ToString();

            comboBox5.Text = dataGridView3.CurrentRow.Cells[4].Value.ToString();
            textBox4.Text = dataGridView3.CurrentRow.Cells[4].Value.ToString();
            maskedTextBox2.Text = dataGridView3.CurrentRow.Cells[6].Value.ToString();
        }

        private void button20_Click(object sender, EventArgs e) // öğrenci  bilgileri sayfasi - öğrenci bilgileri
        {
            bag.Open();
            DataSet ds = new DataSet();
            OleDbDataAdapter adtr = new OleDbDataAdapter("select * from Ogrenci_Tablo", bag);

            adtr.Fill(ds, "Ders_Programi");
            dataGridView3.DataSource = ds.Tables["Ders_Programi"];

            bag.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) // Etüt sayfasi - Etüt datagrid
        {
           

        }

        private void button14_Click(object sender, EventArgs e) // sinif bilgileri - ekleme
        {
            bag.Open();
            OleDbCommand komut = new OleDbCommand("insert into Sinif_Tablo(Sınıf_No_id,Sira_Sayisi) values('" + textBox12.Text + "','" + textBox19.Text + "')", bag);
            komut.ExecuteNonQuery();
            MessageBox.Show("Sınıf Kaydı Oluşturuldu", "Kayıt");

            DataSet ds = new DataSet();
            OleDbDataAdapter adtr = new OleDbDataAdapter("select * from Sinif_Tablo", bag);

            adtr.Fill(ds, "Ders_Programi");
            dataGridView5.DataSource = ds.Tables["Ders_Programi"];

            bag.Close();

            textBox12.Text = "";
            textBox19.Text = "";
        }

        private void button13_Click(object sender, EventArgs e) // sinif bilgileri - silme
        {
            for (int i = 0; i < dataGridView5.SelectedRows.Count; i++)
            {
                bag.Open();
                OleDbCommand komut2 = new OleDbCommand("delete from Sinif_Tablo where Sınıf_No_id='" + dataGridView5.SelectedRows[i].Cells["Sınıf_No_id"].Value.ToString() + "'", bag);
                komut2.ExecuteNonQuery();

            }

            DataSet ds = new DataSet();
            OleDbDataAdapter adtr = new OleDbDataAdapter("select * from Sinif_Tablo", bag);

            adtr.Fill(ds, "Ders_Programi");
            dataGridView5.DataSource = ds.Tables["Ders_Programi"];
            bag.Close();
            MessageBox.Show("Seçilen Sınıf Silindi.");
        }

        private void button21_Click(object sender, EventArgs e) // sinif bilgileri - listeleme
        {
            bag.Open();
           
            DataSet ds = new DataSet();
            OleDbDataAdapter adtr = new OleDbDataAdapter("select * from Sinif_Tablo", bag);

            adtr.Fill(ds, "Ders_Programi");
            dataGridView5.DataSource = ds.Tables["Ders_Programi"];

            bag.Close();
        }

        private void dataGridView5_CellContentClick(object sender, DataGridViewCellEventArgs e) // sınıf  bilgileri sayfasi - datagrid
        {
           
        }

        private void button11_Click(object sender, EventArgs e) // ders ekle
        {
            bag.Open();
            OleDbCommand komut = new OleDbCommand("insert into Ders_Tablosu(Ders_adi) values('" + textBox7.Text  + "')", bag);
            komut.ExecuteNonQuery();
            MessageBox.Show("Ders Kaydı Oluşturuldu", "Kayıt");

            DataSet ds = new DataSet();
            OleDbDataAdapter adtr = new OleDbDataAdapter("select * from Ders_Tablosu", bag);

            adtr.Fill(ds, "Ders_Programi");
            dataGridView4.DataSource = ds.Tables["Ders_Programi"];

            bag.Close();

            textBox7.Text = "";
        }

        private void button12_Click(object sender, EventArgs e) // ders silme
        {
            for (int i = 0; i < dataGridView4.SelectedRows.Count; i++)
            {
                bag.Open();
                OleDbCommand komut2 = new OleDbCommand("delete from Ders_Tablosu where Ders_adi='" + dataGridView4.SelectedRows[i].Cells["Ders_adi"].Value.ToString() + "'", bag);
                komut2.ExecuteNonQuery();

            }

            DataSet ds = new DataSet();
            OleDbDataAdapter adtr = new OleDbDataAdapter("select * from Ders_Tablosu", bag);

            adtr.Fill(ds, "Ders_Programi");
            dataGridView4.DataSource = ds.Tables["Ders_Programi"];
            bag.Close();
            MessageBox.Show("Seçilen Ders Silindi.");
        }

        private void button22_Click(object sender, EventArgs e) // ders listeleme
        {
            bag.Open();

            DataSet ds = new DataSet();
            OleDbDataAdapter adtr = new OleDbDataAdapter("select * from Ders_Tablosu", bag);

            adtr.Fill(ds, "Ders_Programi");
            dataGridView4.DataSource = ds.Tables["Ders_Programi"];

            bag.Close();
        }

        private void MenuSayfasi_Load(object sender, EventArgs e)
        {
           
            
        }

        private void button17_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button18_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button15_Click(object sender, EventArgs e) // ayarlar - admin - ekle
        {
            bag.Open();
            OleDbCommand komut = new OleDbCommand("insert into RehberlikOgretmeni_giris(Ogretmen_kullaniciadi,Sifre) values('" + textBox13.Text + "','" + textBox14.Text + "')", bag);
            komut.ExecuteNonQuery();
            MessageBox.Show("Rehberlik Öğretmeninin Kaydı Oluşturuldu", "Kayıt");

            DataSet ds = new DataSet();
            OleDbDataAdapter adtr = new OleDbDataAdapter("select * from RehberlikOgretmeni_giris", bag);

            adtr.Fill(ds, "Ders_Programi");
            dataGridView6.DataSource = ds.Tables["Ders_Programi"];

            bag.Close();

            textBox13.Text = "";
            textBox14.Text = "";
        }

        private void button16_Click(object sender, EventArgs e) // ayarlar - admin - silme
        {
            for (int i = 0; i < dataGridView6.SelectedRows.Count; i++)
            {
                bag.Open();
                OleDbCommand komut2 = new OleDbCommand("delete from RehberlikOgretmeni_giris where Ogretmen_kullaniciadi='" + dataGridView6.SelectedRows[i].Cells["Ogretmen_kullaniciadi"].Value.ToString() + "'", bag);
                komut2.ExecuteNonQuery();

            }

            DataSet ds = new DataSet();
            OleDbDataAdapter adtr = new OleDbDataAdapter("select * from RehberlikOgretmeni_giris", bag);

            adtr.Fill(ds, "Ders_Programi");
            dataGridView6.DataSource = ds.Tables["Ders_Programi"];
            bag.Close();
            MessageBox.Show("Seçilen Kayıt Silindi.");
        }

        private void button23_Click(object sender, EventArgs e) // ayarlar - admin - listele
        {
            bag.Open();
            DataSet ds = new DataSet();
            OleDbDataAdapter adtr = new OleDbDataAdapter("select * from RehberlikOgretmeni_giris", bag);

            adtr.Fill(ds, "Ders_Programi");
            dataGridView6.DataSource = ds.Tables["Ders_Programi"];
            bag.Close();
        }

        private void button25_Click(object sender, EventArgs e) // ayarlar - öğretmen - ekle
        {
            bag.Open();
            OleDbCommand komut = new OleDbCommand("insert into Ogretmen_giris(Ogretmen_kullaniciadi,Sifre) values('" + textBox11.Text + "','" + textBox10.Text + "')", bag);
            komut.ExecuteNonQuery();
            MessageBox.Show("Öğretmeninin Kaydı Oluşturuldu", "Kayıt");

            DataSet ds = new DataSet();
            OleDbDataAdapter adtr = new OleDbDataAdapter("select * from Ogretmen_giris", bag);

            adtr.Fill(ds, "Ders_Programi");
            dataGridView7.DataSource = ds.Tables["Ders_Programi"];

            bag.Close();

            textBox11.Text = "";
            textBox10.Text = "";
        }

        private void button24_Click(object sender, EventArgs e) // ayarlar - öğretmen - silme
        {
            for (int i = 0; i < dataGridView7.SelectedRows.Count; i++)
            {
                bag.Open();
                OleDbCommand komut2 = new OleDbCommand("delete from Ogretmen_giris where Ogretmen_kullaniciadi='" + dataGridView7.SelectedRows[i].Cells["Ogretmen_kullaniciadi"].Value.ToString() + "'", bag);
                komut2.ExecuteNonQuery();

            }

            DataSet ds = new DataSet();
            OleDbDataAdapter adtr = new OleDbDataAdapter("select * from Ogretmen_giris", bag);

            adtr.Fill(ds, "Ders_Programi");
            dataGridView7.DataSource = ds.Tables["Ders_Programi"];
            bag.Close();
            MessageBox.Show("Seçilen Kayıt Silindi.");
        }

        private void button26_Click(object sender, EventArgs e) // ayarlar - öğretmen - listele
        {
            bag.Open();
            DataSet ds = new DataSet();
            OleDbDataAdapter adtr = new OleDbDataAdapter("select * from Ogretmen_giris", bag);

            adtr.Fill(ds, "Ders_Programi");
            dataGridView7.DataSource = ds.Tables["Ders_Programi"];
            bag.Close();
        }

        private void dataGridView6_CellContentClick(object sender, DataGridViewCellEventArgs e) // ayarlar - admin - datagrid
        {
            textBox13.Text = dataGridView3.CurrentRow.Cells[1].Value.ToString();
            textBox14.Text = dataGridView3.CurrentRow.Cells[2].Value.ToString();
        }

        private void dataGridView7_CellContentClick(object sender, DataGridViewCellEventArgs e) // ayarlar - öğretmen - datagrid
        {

            textBox11.Text = dataGridView3.CurrentRow.Cells[1].Value.ToString();
            textBox10.Text = dataGridView3.CurrentRow.Cells[2].Value.ToString();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            
        }

        private void button27_Click(object sender, EventArgs e)
        {
            Form1 ac = new Form1();
            ac.Show();
            this.Hide();
        }

        private void button8_Click(object sender, EventArgs e) // Etüt sayfasi - Etüt onay
        {
            bag.Open();


            OleDbCommand komut = new OleDbCommand();
            komut.Connection = bag;
            if (checkBox1.Checked)
            {
                komut.CommandText = "update Etut_Tablo set Onay=True where id ='" + textBox15.Text + "'";
            }
            else if (checkBox1.Checked == false)
            {
                komut.CommandText = "update Etut_Tablo set Onay=False where id ='" + textBox15.Text + "'";
            }

            komut.ExecuteNonQuery();
            DataSet ds = new DataSet();
            OleDbDataAdapter adtr = new OleDbDataAdapter("select * from Etut_Tablo", bag);

            adtr.Fill(ds, "Ders_Programi");
            dataGridView1.DataSource = ds.Tables["Ders_Programi"];

            checkBox1.Checked = false;

            bag.Close();
        }

        private void button3_Click(object sender, EventArgs e) // öğrenci  bilgileri sayfasi - öğrenci bilgileri güncelleme
        {
            bag.Open();


            OleDbCommand komut = new OleDbCommand();
            komut.Connection = bag;

            komut.CommandText = "update Ogrenci_Tablo set AdSoyad='" + textBox8.Text + "', Sinif='" + comboBox5.Text + "', Mail='" + textBox9.Text + "', Telefon_No='" + maskedTextBox2.Text + "', Okul_No='" + textBox1.Text + "' where id ='" + textBox18.Text + "'";

            komut.ExecuteNonQuery();
            DataSet ds = new DataSet();
            OleDbDataAdapter adtr = new OleDbDataAdapter("select * from Ogrenci_Tablo", bag);

            adtr.Fill(ds, "Ders_Programi");
            dataGridView3.DataSource = ds.Tables["Ders_Programi"];

            bag.Close();
        }

        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e) // ders sayfası datagrid
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
           
        }

        private void button28_Click(object sender, EventArgs e)
        {
            

        }

        private void button29_Click(object sender, EventArgs e)
        {
            
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            try
            {
                Font font = new Font("Calibre", 14);
                SolidBrush firca = new SolidBrush(Color.Black);
                e.Graphics.DrawString($"Tarih:{DateTime.Now.ToString("dd.MM.yyyy")}", font, firca, 60, 25);
                e.Graphics.DrawString("Etüt listesi", font,firca,350,70);
                e.Graphics.DrawString("------------------", font, firca, 335, 115);

                e.Graphics.DrawString("Sınıf No", font, firca, 60,170);
                e.Graphics.DrawString("Öğrenci", font, firca, 140, 170);
                e.Graphics.DrawString("Öğretmen", font, firca, 380, 170);
                e.Graphics.DrawString("Tarih", font, firca, 520, 170);
                e.Graphics.DrawString("Saat", font, firca, 630, 170);
                e.Graphics.DrawString("Ders", font, firca, 700, 170);

                int i = 0;
                int y = 210;
                while (i<= dataGridView1.Rows.Count-2)
                {
                    e.Graphics.DrawString(dataGridView1.Rows[i].Cells[1].Value.ToString(), font, firca, 60, y);
                    e.Graphics.DrawString(dataGridView1.Rows[i].Cells[6].Value.ToString(), font, firca, 140, y);
                    e.Graphics.DrawString(dataGridView1.Rows[i].Cells[4].Value.ToString(), font, firca, 380, y);
                    e.Graphics.DrawString(dataGridView1.Rows[i].Cells[7].Value.ToString(), font, firca, 520, y);
                    e.Graphics.DrawString(dataGridView1.Rows[i].Cells[8].Value.ToString(), font, firca, 630, y);
                    e.Graphics.DrawString(dataGridView1.Rows[i].Cells[10].Value.ToString(), font, firca, 700, y);
                    y = y + 40;
                    i = i + 1;
                }


            }
            catch (Exception)
            {

                throw;
            }
        }

        private void button31_Click(object sender, EventArgs e)
        {
            printDocument1.Print();
        }

        private void button30_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.ShowDialog();
        }
    }
}
