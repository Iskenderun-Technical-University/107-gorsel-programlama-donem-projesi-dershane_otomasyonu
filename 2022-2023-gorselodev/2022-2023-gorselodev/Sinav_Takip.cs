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
    public partial class Sinav_Takip : Form
    {
        SqlConnection con;
        SqlDataAdapter da;
        SqlDataReader dr;
        SqlCommand cmd;
        DataSet ds;
        public static string SqlCon = @"Data Source=DESKTOP-DN85P15\SQLEXPRESS;Initial Catalog=odev;Integrated Security=True";
        void GridDoldur()
        {
            con = new SqlConnection(SqlCon);
            da = new SqlDataAdapter("Select * from sinav_takip", con);
            ds = new DataSet();
            con.Open();
            da.Fill(ds, "sinav_takip");

            dataGridView1.DataSource = ds.Tables["sinav_takip"];
            con.Close();
        }
        public Sinav_Takip()
        {
            InitializeComponent();
            if (Class1.BaglantiDurum())
            {
                // MessageBox.Show("Bağlantı Kuruldu");
            }
        }

        private void Sinav_Takip_Load(object sender, EventArgs e)
        {
            Class1.GridDoldur(dataGridView1, "select * from sinav_takip");
            dataGridView1.Columns[0].HeaderCell.Value = "Sıra No";
            dataGridView1.Columns[1].HeaderCell.Value = "Sınav No";
            dataGridView1.Columns[2].HeaderCell.Value = "Ad Soyad";
            dataGridView1.Columns[3].HeaderCell.Value = "Öğrenci No";
            dataGridView1.Columns[4].HeaderCell.Value = "Türkçe Neti";
            dataGridView1.Columns[5].HeaderCell.Value = "Matematik Neti";
            dataGridView1.Columns[6].HeaderCell.Value = "Geometri Neti";
            dataGridView1.Columns[7].HeaderCell.Value = "Tarih Neti";
            dataGridView1.Columns[8].HeaderCell.Value = "Coğrafya Neti";
            dataGridView1.Columns[9].HeaderCell.Value = "Felsefe Neti";
            dataGridView1.Columns[10].HeaderCell.Value = "Fizik Neti";
            dataGridView1.Columns[11].HeaderCell.Value = "Kimya Neti";
            dataGridView1.Columns[12].HeaderCell.Value = "Biyoloji Neti";
            dataGridView1.Columns[13].HeaderCell.Value = "Sayısal Puan";
            dataGridView1.Columns[14].HeaderCell.Value = "Eşit Ağırlık";
            dataGridView1.Columns[15].HeaderCell.Value = "Sözel Puan";
        }

        

        private void btnekle_Click_1(object sender, EventArgs e)
        {
            string sql = "insert into sinav_takip(sinav_no,ogr_adsoyad,ogr_no,turkce_neti,matematik_neti,geometri_neti,tarih_neti,cografya_neti,felsefe_neti,fizik_neti,kimya_neti,biyoloji_neti,sayisal_puan,esitagirlik_puan,sozel_puan) values(@o1,@o2,@o3,@o4,@o5,@o6,@o7,@o8,@o9,@o10,@o11,@o12,@o13,@o14,@o15)";
            cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@o1", txtsinavno.Text);
            cmd.Parameters.AddWithValue("@o2", txtadsoyad.Text);
            cmd.Parameters.AddWithValue("@o3", txtnumara.Text);
            cmd.Parameters.AddWithValue("@o4", txtturkce.Text);
            cmd.Parameters.AddWithValue("@o5", txtmat.Text);
            cmd.Parameters.AddWithValue("@o6", txtgeo.Text);
            cmd.Parameters.AddWithValue("@o7", txttarih.Text);
            cmd.Parameters.AddWithValue("@o8", txtcografya.Text);
            cmd.Parameters.AddWithValue("@o9", txtfelsefe.Text);
            cmd.Parameters.AddWithValue("@o10", txtfizik.Text);
            cmd.Parameters.AddWithValue("@o11", txtkimya.Text);
            cmd.Parameters.AddWithValue("@o12", txtbiyoloji.Text);
            cmd.Parameters.AddWithValue("@o13", txtsayisal.Text);
            cmd.Parameters.AddWithValue("@o14", txtesitagirlik.Text);
            cmd.Parameters.AddWithValue("@o15", txtsozel.Text);
            Class1.KomutYollaParametreli(sql, cmd);
            GridDoldur();
        }

        private void btnguncelle_Click_1(object sender, EventArgs e)
        {
            string sql = "Update sinav_takip set sinav_no=@sinavno, ogr_adsoyad=@ogradsoyad, ogr_no=@no, turkce_neti=@turkce,matematik_neti=@mat,geometri_neti=@geo,tarih_neti=@tarih,cografya_neti=@cog,felsefe_neti=@fel,fizik_neti=@fizik,kimya_neti=@kimya,biyoloji_neti=@biyo,sayisal_puan=@sayisal,esitagirlik_puan=@esit,sozel_puan=@sozel where sinav_id='" + textBox1.Text + "'";
            cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@sinavno", txtsinavno.Text);
            cmd.Parameters.AddWithValue("@ogradsoyad", txtadsoyad.Text);
            cmd.Parameters.AddWithValue("@no", txtnumara.Text);
            cmd.Parameters.AddWithValue("@turkce", txtturkce.Text);
            cmd.Parameters.AddWithValue("@mat", txtmat.Text);
            cmd.Parameters.AddWithValue("@geo", txtgeo.Text);
            cmd.Parameters.AddWithValue("@tarih", txttarih.Text);
            cmd.Parameters.AddWithValue("@cog", txtcografya.Text);
            cmd.Parameters.AddWithValue("@fel", txtfelsefe.Text);
            cmd.Parameters.AddWithValue("@fizik", txtfizik.Text);
            cmd.Parameters.AddWithValue("@kimya", txtkimya.Text);
            cmd.Parameters.AddWithValue("@biyo", txtbiyoloji.Text);
            cmd.Parameters.AddWithValue("@sayisal", txtsayisal.Text);
            cmd.Parameters.AddWithValue("@esit", txtesitagirlik.Text);
            cmd.Parameters.AddWithValue("@sozel", txtsozel.Text);
            Class1.KomutYollaParametreli(sql, cmd);
            GridDoldur();
            MessageBox.Show("Veli Güncellemesi Tamamlandı ");
        }

        private void Ara_TextChanged_1(object sender, EventArgs e)
        {
            string sql = "select * from sinav_takip where ogr_adsoyad like '%";
            Class1.ara(dataGridView1, Ara, sql);
        }

        private void btntemizle_Click_1(object sender, EventArgs e)
        {
            textBox1.Clear();
            txtsinavno.Clear();
            txtadsoyad.Clear();
            txtnumara.Clear();
            txtturkce.Clear();
            txtmat.Clear();
            txtgeo.Clear();
            txttarih.Clear();
            txtcografya.Clear();
            txtfelsefe.Clear();
            txtfizik.Clear();
            txtkimya.Clear();
            txtbiyoloji.Clear();
            txtsayisal.Clear();
            txtesitagirlik.Clear();
            txtsozel.Clear();
        }

        private void btnsil_Click_1(object sender, EventArgs e)
        {
            string sql1 = "DELETE FROM sinav_takip WHERE sinav_id=@sinav_id";
            string parametre = "@sinav_id";
            string sql = "Select * from sinav_takip";
            foreach (DataGridViewRow drow in dataGridView1.SelectedRows)
            {
                int id = Convert.ToInt32(drow.Cells[0].Value);
                Class1.GridView_Delete(id, sql1, parametre);
            }
            Class1.GridDoldur(dataGridView1, sql);
        }

        private void dataGridView1_CellDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {
            int secim = dataGridView1.SelectedCells[0].RowIndex;
            textBox1.Text = dataGridView1.Rows[secim].Cells[0].Value.ToString();
            txtsinavno.Text = dataGridView1.Rows[secim].Cells[1].Value.ToString();
            txtadsoyad.Text = dataGridView1.Rows[secim].Cells[2].Value.ToString();
            txtnumara.Text = dataGridView1.Rows[secim].Cells[3].Value.ToString();
            txtturkce.Text = dataGridView1.Rows[secim].Cells[4].Value.ToString();
            txtmat.Text = dataGridView1.Rows[secim].Cells[5].Value.ToString();
            txtgeo.Text = dataGridView1.Rows[secim].Cells[6].Value.ToString();
            txttarih.Text = dataGridView1.Rows[secim].Cells[7].Value.ToString();
            txtcografya.Text = dataGridView1.Rows[secim].Cells[8].Value.ToString();
            txtfelsefe.Text = dataGridView1.Rows[secim].Cells[9].Value.ToString();
            txtfizik.Text = dataGridView1.Rows[secim].Cells[10].Value.ToString();
            txtkimya.Text = dataGridView1.Rows[secim].Cells[11].Value.ToString();
            txtbiyoloji.Text = dataGridView1.Rows[secim].Cells[12].Value.ToString();
            txtsayisal.Text = dataGridView1.Rows[secim].Cells[13].Value.ToString();
            txtesitagirlik.Text = dataGridView1.Rows[secim].Cells[14].Value.ToString();
            txtsozel.Text = dataGridView1.Rows[secim].Cells[15].Value.ToString();
        }
    }
}

