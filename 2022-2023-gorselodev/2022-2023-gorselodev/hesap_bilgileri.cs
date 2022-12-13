using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
    }
}
