using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Security.Cryptography;

namespace _2022_2023_gorselodev
{
    public partial class Yardimci_Form : Form
    {
        SqlConnection con;
        SqlDataAdapter da;
        SqlCommand cmd;
        DataSet ds;
        string SqlCon = Class1.SqlCon;

        void GridDoldur()
        {
            con = new SqlConnection(SqlCon);
            da = new SqlDataAdapter("Select * from tbl_login", con);
            ds = new DataSet();
            con.Open();
            da.Fill(ds, "tbl_login");

            dataGridView1.DataSource = ds.Tables["tbl_login"];
            con.Close();
        }
        public Yardimci_Form()
        {
            InitializeComponent();
            if (Class1.BaglantiDurum())
            {
                // MessageBox.Show("Bağlantı Kuruldu");
            }
        }

        private void Yardimci_Form_Load(object sender, EventArgs e)
        {
            Class1.GridDoldur(dataGridView1, "select * from tbl_login");
            dataGridView1.Columns[2].Visible = false;
            dataGridView1.Columns[1].HeaderCell.Value = "Kullanıcı Adı";
            dataGridView1.Columns[3].HeaderCell.Value = "Son Giriş Tarihi";
            dataGridView1.Columns[1].Width = 100;
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            dateTimePicker1.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sql = "insert into tbl_login(kullanici, sifre, tarih) values (@user,@password,@tarih)";
            cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@user", textBox2.Text);
            cmd.Parameters.AddWithValue("@password", Class1.MD5Sifrele(textBox3.Text));
            cmd.Parameters.AddWithValue("@tarih", DateTime.Parse(dateTimePicker1.Text));

            Class1.KomutYollaParametreli(sql, cmd);
            GridDoldur();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string sql = "delete from tbl_login where kullanici='" + textBox2.Text + "' and sifre='" + textBox3.Text + "' and kID=" + textBox1.Text;
            Class1.KomutYolla(sql);
            GridDoldur();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string sql = "update tbl_login set sifre='" + Class1.MD5Sifrele(textBox3.Text) + "' where kullanici='" + textBox2.Text + "' and kID=" + textBox1.Text;
            Class1.KomutYolla(sql);
            GridDoldur();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            dateTimePicker1.Value = DateTime.Now;
        }
    }
}
