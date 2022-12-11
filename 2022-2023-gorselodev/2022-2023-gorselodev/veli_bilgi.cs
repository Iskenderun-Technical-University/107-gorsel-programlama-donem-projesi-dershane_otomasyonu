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
    public partial class veli_bilgi : Form
    {
        public veli_bilgi()
        {
            InitializeComponent();
        }

        private void veli_bilgi_Load(object sender, EventArgs e)
        {
            sqlsorgu = "select sinav_takip.sinav_no,sinav_takip.ogr_no,sinav_takip.ogr_adsoyad,sinav_takip.turkce_neti,sinav_takip.matematik_neti,sinav_takip.geometri_neti,sinav_takip.tarih_neti,sinav_takip.felsefe_neti,sinav_takip.fizik_neti,sinav_takip.kimya_neti,sinav_takip.biyoloji_neti,sinav_takip.sayisal_puan,sinav_takip.esitagirlik_puan,sinav_takip.sozel_puan,veli_bilgileri.veli_adsoyad,veli_bilgileri.veli_telefon,veli_bilgileri.veli_mail from sinav_takip INNER JOIN veli_bilgileri ON sinav_takip.ogr_no=veli_bilgileri.ogr_no";
            GridDoldur(sqlsorgu);

        }
        SqlConnection con;
        SqlDataAdapter da;
        DataSet ds;
        string SqlCon = Class1.SqlCon;


        void GridDoldur(string sql)
        {
            con = new SqlConnection(SqlCon);
            da = new SqlDataAdapter(sql, con);
            ds = new DataSet();
            con.Open();
            da.Fill(ds, "sinav_takip");

            dataGridView1.DataSource = ds.Tables["sinav_takip"];
            con.Close();
        }
        public string sqlsorgu;
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                sqlsorgu = "select sinav_takip.sinav_no,sinav_takip.ogr_no,sinav_takip.ogr_adsoyad,sinav_takip.turkce_neti,sinav_takip.matematik_neti,sinav_takip.geometri_neti,sinav_takip.tarih_neti,sinav_takip.felsefe_neti,sinav_takip.fizik_neti,sinav_takip.kimya_neti,sinav_takip.biyoloji_neti,sinav_takip.sayisal_puan,sinav_takip.esitagirlik_puan,sinav_takip.sozel_puan,veli_bilgileri.veli_adsoyad,veli_bilgileri.veli_telefon,veli_bilgileri.veli_mail from sinav_takip INNER JOIN veli_bilgileri ON sinav_takip.ogr_no = veli_bilgileri.ogr_no where sinav_takip.ogr_adsoyad like '%" + textBox1.Text + "%'";
                GridDoldur(sqlsorgu);

            }
        }
}
