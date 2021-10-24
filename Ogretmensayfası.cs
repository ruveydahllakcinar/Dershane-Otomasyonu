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
    public partial class Ogretmensayfası : Form
    {
        OleDbConnection bag = new OleDbConnection("provider=microsoft.ace.oledb.12.0;data source=etutveritabani.accdb");
        
        DataTable tablo = new DataTable();
        OleDbCommand komut = new OleDbCommand();
        public Ogretmensayfası()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
           

           


        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            dataGridView1.Columns.Clear();
            ds.Tables.Clear();
            dataGridView1.Refresh();
            bag.Open();
            OleDbDataAdapter adtr = new OleDbDataAdapter("select * from Ders_Programi where Ogretmen_Adi like '"+textBox1.Text+"'", bag);
            adtr.Fill(ds, "Ders_Programi");
            dataGridView1.DataSource = ds.Tables["Ders_Programi"];
            bag.Close();

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            dataGridView1.Columns.Clear();
            ds.Tables.Clear();
            dataGridView1.Refresh();
            bag.Open();
            OleDbDataAdapter adtr = new OleDbDataAdapter("select * from Ders_Programi where Ders_Adi like '" + textBox2.Text + "'", bag);
            adtr.Fill(ds, "Ders_Programi");
            dataGridView1.DataSource = ds.Tables["Ders_Programi"];
            bag.Close();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {
           
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            bag.Open();
            DataSet ds = new DataSet();
            OleDbDataAdapter adtr = new OleDbDataAdapter("select * from Etut_Tablo where aktiflik=True", bag);

            adtr.Fill(ds, "Ders_Programi");
            dataGridView2.DataSource = ds.Tables["Ders_Programi"];


            bag.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            
            bag.Open();
            DataSet ds = new DataSet();
            OleDbDataAdapter adtr = new OleDbDataAdapter("select * from Etut_Tablo where aktiflik=False", bag);

            adtr.Fill(ds, "Ders_Programi");
            dataGridView3.DataSource = ds.Tables["Ders_Programi"];


            bag.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bag.Open();
            OleDbCommand komut2 = new OleDbCommand("insert into Etut_Tablo(Ogrenci_Ad,Ogr_No,Tarih,Saat,Hangi_Ders,Ogretmen_id) values('"+textBox3.Text + "','" + textBox6.Text + "','" + dateTimePicker1.Text + "','" + comboBox1.SelectedItem + ":"+ comboBox2.SelectedItem+ "','" + textBox5.Text + "','" + textBox7.Text + "')", bag);
            komut2.ExecuteNonQuery();
            MessageBox.Show("Talep Edilen Etüt Oluşturuldu", "Kayıt");

            DataSet ds = new DataSet();
            OleDbDataAdapter adtr = new OleDbDataAdapter("select * from Etut_Tablo", bag);

            adtr.Fill(ds, "Ders_Programi");
            dataGridView5.DataSource = ds.Tables["Ders_Programi"];

            bag.Close(); 

            textBox3.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            comboBox1.SelectedItem = null;
            comboBox2.SelectedItem = null;
            dateTimePicker1.Value = DateTime.Now;

        }

        private void button6_Click(object sender, EventArgs e)
        {
            bag.Open();
            DataSet ds = new DataSet();
            OleDbDataAdapter adtr = new OleDbDataAdapter("select * from Etut_Tablo", bag);

            adtr.Fill(ds, "Ders_Programi");
            dataGridView5.DataSource = ds.Tables["Ders_Programi"];


            bag.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView5.SelectedRows.Count; i++)
            {
                bag.Open();
                OleDbCommand komut2 = new OleDbCommand("delete from Etut_Tablo where Ogrenci_Ad='" + dataGridView5.SelectedRows[i].Cells["Ogrenci_Ad"].Value.ToString()+"'", bag);
                komut2.ExecuteNonQuery();   
                
            }
            DataSet ds = new DataSet();
            OleDbDataAdapter adtr = new OleDbDataAdapter("select * from Etut_Tablo", bag);

            adtr.Fill(ds, "Ders_Programi");
            dataGridView5.DataSource = ds.Tables["Ders_Programi"];
            bag.Close();
            MessageBox.Show("Seçilen Etüt Silindi.");
        }

        private void button18_Click(object sender, EventArgs e)
        {

            Application.Exit();
        }

        private void button27_Click(object sender, EventArgs e)
        {
            Form1 ac = new Form1();
            ac.Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            bag.Open();
            DataSet ds = new DataSet();
            OleDbDataAdapter adtr = new OleDbDataAdapter("select * from Ders_Programi", bag);

            adtr.Fill(ds, "Ders_Programi");
            dataGridView1.DataSource = ds.Tables["Ders_Programi"];
            bag.Close();
        }

        private void dataGridView5_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            

            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            bag.Open();


            OleDbCommand komut = new OleDbCommand();
            komut.Connection = bag;
            if (checkBox1.Checked)
            {
                komut.CommandText = "update Etut_Tablo set Ogretmen_Onay=True where id ='" + textBox15.Text + "'";
            }
            else if (checkBox1.Checked == false)
            {
                komut.CommandText = "update Etut_Tablo set Ogretmen_Onay=False where id ='" + textBox15.Text + "'";
            }

            komut.ExecuteNonQuery();
            DataSet ds = new DataSet();
            OleDbDataAdapter adtr = new OleDbDataAdapter("select * from Etut_Tablo", bag);

            adtr.Fill(ds, "Ders_Programi");
            dataGridView5.DataSource = ds.Tables["Ders_Programi"];

            checkBox1.Checked = false;

            bag.Close();
        }
    }
}
