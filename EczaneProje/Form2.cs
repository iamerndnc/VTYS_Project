using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace EczaneProje
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        NpgsqlConnection baglanti = new NpgsqlConnection("server=localHost; port=5432; Database=Proje; userID=postgres; password=123qwe123");
        private void Form2_Load(object sender, EventArgs e)
        {
            

        }

        private void btnList_Click(object sender, EventArgs e)
        {
            string sorgu = "select * from hasta";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu, baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
        baglanti.Open();
        NpgsqlCommand komut2 = new NpgsqlCommand("Delete From hasta where id=@p1",baglanti);
        komut2.Parameters.AddWithValue("@p1", (textBox1.Text));
        komut2.ExecuteNonQuery();
        baglanti.Close();
        MessageBox.Show("Hasta silme ișlemi bașarili bir sekilde gerçeklesti", "Bilgi",
        MessageBoxButtons.OK, MessageBoxIcon.Stop);

        }

        private void btnAdd_Click_1(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand komut1 = new NpgsqlCommand("insert into hasta (id, ad, soyad, ilceid, sigortaturu, hastatc) values(@p1, @p2, @p3, @p4, @p5, @p6)", baglanti);
            komut1.Parameters.AddWithValue("@p1", (textBox1.Text));
            komut1.Parameters.AddWithValue("@p2", (textBox2.Text));
            komut1.Parameters.AddWithValue("@p3", (textBox3.Text));
            komut1.Parameters.AddWithValue("@p4", (textBox4.Text));
            komut1.Parameters.AddWithValue("@p5", (textBox5.Text));
            komut1.Parameters.AddWithValue("@p6", (textBox6.Text));
            komut1.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Hasta ekleme ișlemi bașarılı bir şekilde gerçekleşti");
        }

        private void btnList_Click_1(object sender, EventArgs e)
        {
            string sorgu = "select * from hasta";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu, baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand komut3 = new NpgsqlCommand("update hasta set ad = @p1, soyad = @p2, ilceid = @p3, hastatc = @p4 where id = @p5", baglanti);
            komut3.Parameters.AddWithValue("@p1", textBox2.Text);
            komut3.Parameters.AddWithValue("@p2", textBox3.Text);
            komut3.Parameters.AddWithValue("@p3", textBox4.Text);
            komut3.Parameters.AddWithValue("@p4", textBox6.Text);
            komut3.Parameters.AddWithValue("@p5", textBox1.Text);
            komut3.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Hasta güncelleme ișlemi bașarilı bir şekilde gerçeklesti", "Bilgi",
            MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Main gecis = new Main();
            gecis.Show();
            this.Hide();
        }
    }
}
