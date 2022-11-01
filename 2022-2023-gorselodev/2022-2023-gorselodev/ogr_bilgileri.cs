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

namespace _2022_2023_gorselodev
{
    public partial class ogr_bilgileri : Form
    {
        SqlConnection con;
        SqlDataAdapter da;
        SqlDataReader dr;
        SqlCommand cmd;
        DataSet ds;
        string SqlCon = Class1.SqlCon;
        public static string deger = "";
        public static string deger_1 = "";//velitcno(veli)
        public static string deger_2 = "";//veliadsoyad(veli)
        public static string deger_3 = "";//ogradsoyad(hesap)
        public static string deger_4 = "";//kayıt tarihi (hesap)


        void GridDoldur()
        {
            con = new SqlConnection(SqlCon);
            da = new SqlDataAdapter("Select * from ogr_bilgileri", con);
            ds = new DataSet();
            con.Open();
            da.Fill(ds, "ogr_bilgileri");

            dataGridView1.DataSource = ds.Tables["ogr_bilgileri"];
            con.Close();
        }
        public ogr_bilgileri()
        {
            InitializeComponent();
            if (Class1.BaglantiDurum())
            {
                // MessageBox.Show("Bağlantı Kuruldu");
            }
        }

        private void ogr_bilgileri_Load(object sender, EventArgs e)
        {
            Class1.GridDoldur(dataGridView1, "select * from ogr_bilgileri ");
            dataGridView1.Columns[0].HeaderCell.Value = "Öğrenci No";
            dataGridView1.Columns[1].HeaderCell.Value = "TC Kimlik No";
            dataGridView1.Columns[2].HeaderCell.Value = "Ad Soyad";
            dataGridView1.Columns[3].HeaderCell.Value = "Cinsiyet";
            dataGridView1.Columns[4].HeaderCell.Value = "Alan";
            dataGridView1.Columns[5].HeaderCell.Value = "Kayıt Tarihi";
            dataGridView1.Columns[6].HeaderCell.Value = "Veli TCNO";
            dataGridView1.Columns[7].HeaderCell.Value = "VELİ ADSOYAD";
            dataGridView1.Columns[8].HeaderCell.Value = "Telefon No";
            dataGridView1.Columns[9].HeaderCell.Value = "Email";
        }

        private void btnekle_Click(object sender, EventArgs e)
        {
            string sql = "insert into ogr_bilgileri(ogr_tcno,ogr_adsoyad,ogr_alan,ogr_cinsiyet,ogr_kayittarihi,veli_tcno,veli_adsoyad,ogr_telefon,ogr_eposta) values(@o1,@o2,@o3,@o7,@o4,@v1,@v2,@o5,@o6)";
            cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@o1", txtogrtcno.Text);
            cmd.Parameters.AddWithValue("@o2", txtogradsoyad.Text);
            cmd.Parameters.AddWithValue("@o3", cmbalan.Text);
            cmd.Parameters.AddWithValue("@o4", datekayit.Value.ToString("yyyy-MM-dd HH:mm:ss"));
            cmd.Parameters.AddWithValue("@v1", txtvtcno.Text);
            cmd.Parameters.AddWithValue("@v2", txtvadsoyad.Text);
            cmd.Parameters.AddWithValue("@o5", txtogrtelno.Text);
            cmd.Parameters.AddWithValue("@o6", txtogremail.Text);
            deger = txtogrtcno.Text;
            deger_1 = txtvtcno.Text;
            deger_2 = txtvadsoyad.Text;
            deger_3 = txtogradsoyad.Text;
            deger_4 = datekayit.Value.ToString("yyyy-MM-dd HH:mm:ss");
            if (radioButton1.Checked == true)
            {
                cmd.Parameters.AddWithValue("@o7", radioButton1.Text);
            }
            else if (radioButton2.Checked == true)
            {
                cmd.Parameters.AddWithValue("@o7", radioButton2.Text);
            }
            Class1.KomutYollaParametreli(sql, cmd);
            GridDoldur();
            this.Hide();
        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            string sql1 = "DELETE FROM ogr_bilgileri WHERE ogr_no=@ogr_no";
            string parametre = "@ogr_no";
            string sql = "Select * from ogr_bilgileri";
            foreach (DataGridViewRow drow in dataGridView1.SelectedRows)
            {
                int id = Convert.ToInt32(drow.Cells[0].Value);
                Class1.GridView_Delete(id, sql1, parametre);
            }
            Class1.GridDoldur(dataGridView1, sql);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        public static string ogrcinsiyet;
        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtogrtcno.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtogradsoyad.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            cmbalan.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            datekayit.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            txtvtcno.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            txtvadsoyad.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            txtogrtelno.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
            txtogremail.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();
            con = new SqlConnection(SqlCon);
            cmd = new SqlCommand();
            cmd.CommandText = "select ogr_cinsiyet from ogr_bilgileri where   ogr_tcno='" + txtogrtcno.Text + "'";
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            con.Open();
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                ogrcinsiyet = dr[0].ToString();
            }
            con.Close();
            if (ogrcinsiyet == "Kadın")
            {
                radioButton2.PerformClick();
            }
            else
            {
                radioButton1.PerformClick();
            }
        }

        private void btntemizle_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            txtogrtcno.Clear();
            txtogradsoyad.Clear();
            cmbalan.Text = "";
            datekayit.Value = DateTime.Now;
            txtvtcno.Clear();
            txtvadsoyad.Clear();
            txtogrtelno.Clear();
            txtogremail.Clear();
        }
    }
}