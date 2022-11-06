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
    public partial class veli_bilgiler : Form
    {
        SqlConnection con;
        SqlDataAdapter da;
        SqlCommand cmd;
        DataSet ds;
        string SqlCon = Class1.SqlCon;
        public static string deger_5 = "";
        void GridDoldur()
        {
            con = new SqlConnection(SqlCon);
            da = new SqlDataAdapter("Select * from veli_bilgileri", con);
            ds = new DataSet();
            con.Open();
            da.Fill(ds, "veli_bilgileri");

            dataGridView1.DataSource = ds.Tables["veli_bilgileri"];
            con.Close();
        }
        public veli_bilgiler()
        {
            InitializeComponent();
            if (Class1.BaglantiDurum())
            {
                // MessageBox.Show("Bağlantı Kuruldu");
            }
        }

        private void veli_bilgiler_Load(object sender, EventArgs e)
        {
            string veri = "select * from ogr_bilgileri where ogr_tcno='" + ogr_bilgileri.deger + "'";
            veliogrno.Text = Convert.ToString(Class1.IdDegeri(veri));
            velitcno.Text = ogr_bilgileri.deger_1;
            veliadsoyad.Text = ogr_bilgileri.deger_2;

            Class1.GridDoldur(dataGridView1, "select * from veli_bilgileri ");
            dataGridView1.Columns[0].HeaderCell.Value = "Sıra No";
            dataGridView1.Columns[1].HeaderCell.Value = "TC Kimlik No";
            dataGridView1.Columns[2].HeaderCell.Value = "Ad Soyad";
            dataGridView1.Columns[3].HeaderCell.Value = "Veli Yakınlığı";
            dataGridView1.Columns[4].HeaderCell.Value = "Adres";
            dataGridView1.Columns[5].HeaderCell.Value = "Telefon";
            dataGridView1.Columns[6].HeaderCell.Value = "Mail";
            dataGridView1.Columns[7].HeaderCell.Value = "Kayıt Ücreti";
            dataGridView1.Columns[8].HeaderCell.Value = "Veli Öğrenci No";
        }

        private void btnekle_Click(object sender, EventArgs e)
        {
            string veri = "select * from ogr_bilgileri where ogr_tcno='" + ogr_bilgileri.deger + "'";
            veliogrno.Text = Convert.ToString(Class1.IdDegeri(veri));
            velitcno.Text = ogr_bilgileri.deger_1;
            veliadsoyad.Text = ogr_bilgileri.deger_2;
            string sql = "insert into veli_bilgileri(veli_tcno,veli_adsoyad,veli_yakinlik,veli_isadresi,veli_telefon,veli_mail,kayit_ucreti,ogr_no) values(@o1,@o2,@o3,@o4,@o5,@o6,@o7,@o9)";
            cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@o1", ogr_bilgileri.deger_1);
            cmd.Parameters.AddWithValue("@o2", ogr_bilgileri.deger_2);
            cmd.Parameters.AddWithValue("@o3", veliyak.Text);
            cmd.Parameters.AddWithValue("@o4", veliadres.Text);
            cmd.Parameters.AddWithValue("@o5", velitelefon.Text);
            cmd.Parameters.AddWithValue("@o6", velieposta.Text);
            cmd.Parameters.AddWithValue("@o7", kayitucreti.Text);
            cmd.Parameters.AddWithValue("@o9", Class1.IdDegeri(veri));
            deger_5 = kayitucreti.Text;
            Class1.KomutYollaParametreli(sql, cmd);
            GridDoldur();
            // hesap_bilgileri hes = new hesap_bilgileri();
            // hes.Show();
            this.Hide();
        }
    }
}
