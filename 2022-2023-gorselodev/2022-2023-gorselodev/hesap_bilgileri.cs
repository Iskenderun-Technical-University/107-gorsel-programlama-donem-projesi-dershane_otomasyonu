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
    public partial class hesap_bilgileri : Form
    {
        SqlConnection con;
        SqlDataAdapter da;
        SqlDataReader dr;
        SqlCommand cmd;
        DataSet ds;
        string SqlCon = Class1.SqlCon;
        void GridDoldur()
        {
            con = new SqlConnection(SqlCon);
            da = new SqlDataAdapter("Select * from hesap_bilgileri", con);
            ds = new DataSet();
            con.Open();
            da.Fill(ds, "hesap_bilgileri");

            dataGridView1.DataSource = ds.Tables["hesap_bilgileri"];
            con.Close();
        }
        public hesap_bilgileri()
        {
            InitializeComponent();
            if (Class1.BaglantiDurum())
            {
                // MessageBox.Show("Bağlantı Kuruldu");
            }
        }

        private void hesap_bilgileri_Load(object sender, EventArgs e)
        {
            string veri = "select * from ogr_bilgileri where ogr_tcno='" + ogr_bilgileri.deger + "'";
            hesapogrno.Text = Convert.ToString(Class1.IdDegeri(veri));
            hesapogradsoyad.Text = ogr_bilgileri.deger_3;
            datekayittarihi.Text = ogr_bilgileri.deger_4;
            ogrkayitucreti.Text = veli_bilgileri.deger_5;

            Class1.GridDoldur(dataGridView1, "select * from hesap_bilgileri ");
            dataGridView1.Columns[0].HeaderCell.Value = "Sıra No";
            dataGridView1.Columns[1].HeaderCell.Value = "Öğrenci No";
            dataGridView1.Columns[2].HeaderCell.Value = "Öğrenci Ad Soyad";
            dataGridView1.Columns[3].HeaderCell.Value = "Kayıt Tarihi";
            dataGridView1.Columns[4].HeaderCell.Value = "Kayıt Ücreti";
            dataGridView1.Columns[5].HeaderCell.Value = "Ödenen Tutar";
            dataGridView1.Columns[6].HeaderCell.Value = "Ödeme Tarihi";
            dataGridView1.Columns[7].HeaderCell.Value = "Ödeyen Kişi";
        }
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int secim = dataGridView1.SelectedCells[0].RowIndex;
            textBox1.Text = dataGridView1.Rows[secim].Cells[0].Value.ToString();
            hesapogrno.Text = dataGridView1.Rows[secim].Cells[1].Value.ToString();
            hesapogradsoyad.Text = dataGridView1.Rows[secim].Cells[2].Value.ToString();
            datekayittarihi.Text = dataGridView1.Rows[secim].Cells[3].Value.ToString();
            ogrkayitucreti.Text = dataGridView1.Rows[secim].Cells[4].Value.ToString();
            odenentutar.Text = dataGridView1.Rows[secim].Cells[5].Value.ToString();
            odemetarihi.Text = dataGridView1.Rows[secim].Cells[6].Value.ToString();
            odeyenkisi.Text = dataGridView1.Rows[secim].Cells[7].Value.ToString();

        }
        private void btnsil_Click(object sender, EventArgs e)
        {
            {
                string sql1 = "DELETE FROM hesap_bilgileri WHERE odeme_id=@hesap_id";
                string parametre = "@hesap_id";
                string sql = "Select * from hesap_bilgileri";
                foreach (DataGridViewRow drow in dataGridView1.SelectedRows)
                {
                    int id = Convert.ToInt32(drow.Cells[0].Value);
                    Class1.GridView_Delete(id, sql1, parametre);
                }
                Class1.GridDoldur(dataGridView1, sql);
            }
        }
        private void btntemizle_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            hesapogrno.Clear();
            hesapogradsoyad.Clear();
            datekayittarihi.Text = "";
            ogrkayitucreti.Clear();
            odenentutar.Clear();
            odemetarihi.Text = "";
            odeyenkisi.Clear();
        }
        private void btnekle_Click(object sender, EventArgs e)
        {
            string veri = "select * from ogr_bilgileri where ogr_tcno='" + ogr_bilgileri.deger + "'";
            hesapogrno.Text = Convert.ToString(Class1.IdDegeri(veri));
            hesapogradsoyad.Text = ogr_bilgileri.deger_3;
            datekayittarihi.Text = ogr_bilgileri.deger_4;
            ogrkayitucreti.Text = veli_bilgileri.deger_5;

            string sql = "insert into hesap_bilgileri(ogr_no,ogr_adsoyad,ogr_kayittarihi,kayit_ucreti,odenen_tutar,odeme_tarihi,odeyen_kisi) values(@o1,@o2,@o3,@o4,@o5,@o6,@o7)";
            cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@o1", Class1.IdDegeri(veri));
            cmd.Parameters.AddWithValue("@o2", ogr_bilgileri.deger_3);
            cmd.Parameters.AddWithValue("@o3", ogr_bilgileri.deger_4);
            cmd.Parameters.AddWithValue("@o4", veli_bilgileri.deger_5);
            cmd.Parameters.AddWithValue("@o5", odenentutar.Text);
            cmd.Parameters.AddWithValue("@o6", odemetarihi.Value.ToString("yyyy-MM-dd HH:mm:ss"));
            cmd.Parameters.AddWithValue("@o7", odeyenkisi.Text);
            Class1.KomutYollaParametreli(sql, cmd);
            GridDoldur();
            MessageBox.Show("Kayıt İşlemi Tamamlandı ");
            con.Close();

        }
        private void btnguncelle_Click(object sender, EventArgs e)
        {
            string sql = "Update hesap_bilgileri set odenen_tutar=@odenenpara, odeme_tarihi=@odemetarihi, odeyen_kisi=@odeyenkisi where odeme_id='" + textBox1.Text + "'";
            cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@odenenpara", odenentutar.Text);
            cmd.Parameters.AddWithValue("@odemetarihi", odemetarihi.Value.ToString("yyyy-MM-dd HH:mm:ss"));
            cmd.Parameters.AddWithValue("@odeyenkisi", odeyenkisi.Text);
            Class1.KomutYollaParametreli(sql, cmd);
            GridDoldur();
            MessageBox.Show("Veli Güncellemesi Tamamlandı ");
            con.Close();
        }
        private void search_TextChanged(object sender, EventArgs e)
        {
            string sql = "select * from hesap_bilgileri where ogr_adsoyad like '%";
            Class1.ara(dataGridView1, search2, sql);
        }
    }
}
