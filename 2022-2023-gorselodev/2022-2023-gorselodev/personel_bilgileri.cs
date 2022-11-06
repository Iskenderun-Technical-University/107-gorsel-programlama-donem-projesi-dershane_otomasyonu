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

namespace vtgb_otomasyon
{
    public partial class personel_bilgileri : Form
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
            da = new SqlDataAdapter("Select * from personel_bilgileri", con);
            ds = new DataSet();
            con.Open();
            da.Fill(ds, "personel_bilgileri");

            dataGridView1.DataSource = ds.Tables["personel_bilgileri"];
            con.Close();
        }
        public personel_bilgileri()
        {
            InitializeComponent();
            if (Class1.BaglantiDurum())
            {
                // MessageBox.Show("Bağlantı Kuruldu");
            }
        }

        private void Ara_TextChanged(object sender, EventArgs e)
        {
            string sql = "select * from personel_bilgileri where per_adsoyad like '%";
            Class1.ara(dataGridView1, Search, sql);
        }

        private void personel_bilgileri_Load(object sender, EventArgs e)
        {
            Class1.GridDoldur(dataGridView1, "select * from personel_bilgileri ");
            dataGridView1.Columns[0].HeaderCell.Value = "Sıra No";
            dataGridView1.Columns[1].HeaderCell.Value = "TC Kimlik No";
            dataGridView1.Columns[2].HeaderCell.Value = "Ad Soyad";
            dataGridView1.Columns[3].HeaderCell.Value = "Cinsiyet";
            dataGridView1.Columns[4].HeaderCell.Value = "Görev";
            dataGridView1.Columns[5].HeaderCell.Value = "Adres";
            dataGridView1.Columns[6].HeaderCell.Value = "Telefon";
            dataGridView1.Columns[7].HeaderCell.Value = "E-Posta";
            dataGridView1.Columns[8].HeaderCell.Value = "Maaş";

        }

        private void btnekle_Click(object sender, EventArgs e)
        {
            string sql = "insert into personel_bilgileri(per_tcno,per_adsoyad,per_cinsiyet,per_gorev,per_adres,per_telefon,per_eposta,maas) values(@o1,@o2,@o3,@o4,@o5,@o6,@o7,@o8)";
            cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@o1", pertcno.Text);
            cmd.Parameters.AddWithValue("@o2", peradsoyad.Text);
            cmd.Parameters.AddWithValue("@o4", pergorev.Text);
            cmd.Parameters.AddWithValue("@o5", peradres.Text);
            cmd.Parameters.AddWithValue("@o6", pertelefon.Text);
            cmd.Parameters.AddWithValue("@o7", pereposta.Text);
            cmd.Parameters.AddWithValue("@o8", permaas.Text);
            if (radioButton1.Checked == true)
            {
                cmd.Parameters.AddWithValue("@o3", radioButton1.Text);
            }
            else if (radioButton2.Checked == true)
            {
                cmd.Parameters.AddWithValue("@o3", radioButton2.Text);
            }
            Class1.KomutYollaParametreli(sql, cmd);
            GridDoldur();
        }

        private void btnguncelle_Click(object sender, EventArgs e)
        {
            string sql = "Update personel_bilgileri set per_tcno=@tc, per_adsoyad=@adsoyad, per_cinsiyet=@percins, per_gorev=@gorev, per_adres=@adres,per_telefon=@telefon,per_eposta=@eposta,maas=@maas where per_id='" + textBox1.Text + "'";
            cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@tc", pertcno.Text);
            cmd.Parameters.AddWithValue("@adsoyad", peradsoyad.Text);
            cmd.Parameters.AddWithValue("@gorev", pergorev.Text);
            cmd.Parameters.AddWithValue("@adres", peradres.Text);
            cmd.Parameters.AddWithValue("@alan", pergorev.Text);
            cmd.Parameters.AddWithValue("@velitc", peradres.Text);
            cmd.Parameters.AddWithValue("@telefon", pertelefon.Text);
            cmd.Parameters.AddWithValue("@eposta", pereposta.Text);
            cmd.Parameters.AddWithValue("@maas", permaas.Text);

            if (radioButton1.Checked == true)
            {
                cmd.Parameters.AddWithValue("@percins", radioButton1.Text);
            }
            else
            {
                cmd.Parameters.AddWithValue("@percins", radioButton2.Text);
            }
            Class1.KomutYollaParametreli(sql, cmd);
            GridDoldur();
            MessageBox.Show("Öğrenci Güncellemesi Tamamlandı ");
        }
        public static string percinsiyet;
        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            pertcno.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            peradsoyad.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            pergorev.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            peradres.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            pertelefon.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            pereposta.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            permaas.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
            con = new SqlConnection(SqlCon);
            cmd = new SqlCommand();
            cmd.CommandText = "select per_cinsiyet from personel_bilgileri where per_tcno='" + pertcno.Text + "'";
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            con.Open();
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                percinsiyet = dr[0].ToString();
            }
            con.Close();
            if (percinsiyet == "Kadın")
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
            pertcno.Clear();
            peradsoyad.Clear();
            pergorev.Text = "";
            peradres.Clear();
            pertelefon.Clear();
            pereposta.Clear();
            permaas.Clear();

        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            string sql1 = "DELETE FROM personel_bilgileri WHERE per_id=@per_id";
            string parametre = "@per_id";
            string sql = "Select * from personel_bilgileri";
            foreach (DataGridViewRow drow in dataGridView1.SelectedRows)
            {
                int id = Convert.ToInt32(drow.Cells[0].Value);
                Class1.GridView_Delete(id, sql1, parametre);
            }
            Class1.GridDoldur(dataGridView1, sql);
        }
    }
}

