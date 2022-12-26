using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;
using NpgsqlTypes;

namespace EczaneProje
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        NpgsqlConnection baglanti = new NpgsqlConnection("server=localHost; port=5432; Database=Proje; userID=postgres; password=123qwe123");
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnList_Click(object sender, EventArgs e)
        {
            string sorgu = "select * from ilaclar";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu, baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand komut1 = new NpgsqlCommand("insert into ilaclar (id, barkod, urunadi, etkinmadde, atckodu, ruhsatsahibi, ruhsatnumarasi, kullanimyasi, fiyat) values(@p1, @p2, @p3, @p4, @p5, @p6, @p7, @p8, @p9)", baglanti);
            komut1.Parameters.AddWithValue("@p1", (textBox1.Text));
            komut1.Parameters.AddWithValue("@p2", (textBox2.Text));
            komut1.Parameters.AddWithValue("@p3", (textBox3.Text));
            komut1.Parameters.AddWithValue("@p4", (textBox4.Text));
            komut1.Parameters.AddWithValue("@p5", (textBox5.Text));
            komut1.Parameters.AddWithValue("@p6", (textBox6.Text));
            komut1.Parameters.AddWithValue("@p7", (textBox7.Text));
            komut1.Parameters.AddWithValue("@p8", (textBox8.Text));
            komut1.Parameters.AddWithValue("@p9", (textBox9.Text));
            komut1.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("İlaç ekleme ișlemi bașarılı bir şekilde gerçekleşti");

        }
        private void btnDelete_Click_1(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand komut2 = new NpgsqlCommand("Delete From ilaclar where id=@p1", baglanti);
            komut2.Parameters.AddWithValue("@p1", (textBox1.Text));
            komut2.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("İlaç silme ișlemi bașarili bir sekilde gerçeklesti", "Bilgi",
            MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand komut3 = new NpgsqlCommand("update ilaclar set barkod = @p1, urunadi = @p2, fiyat = @p3 where id = @p4", baglanti);
            komut3.Parameters.AddWithValue("@p1", textBox2.Text);
            komut3.Parameters.AddWithValue("@p2", textBox3.Text);
            komut3.Parameters.AddWithValue("@p3", textBox9.Text);
            komut3.Parameters.AddWithValue("@p4", textBox1.Text);
            komut3.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("İlaç güncelleme ișlemi bașarilı bir şekilde gerçeklesti", "Bilgi",
            MessageBoxButtons.OK, MessageBoxIcon.Warning);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form4 gecis = new Form4();
            gecis.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form5 gecis = new Form5();
            gecis.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Main gecis = new Main();
            gecis.Show();
            this.Hide();
        }
    }
}
