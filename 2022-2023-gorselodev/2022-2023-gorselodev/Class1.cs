using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using System.Security.Cryptography;


namespace _2022_2023_gorselodev
{
   internal class Class1
    {
        Class1()
        {

        }

    static SqlConnection con;
    static SqlDataAdapter da;
    static SqlCommand cmd;
    static SqlDataReader dr;
    static System.Data.DataSet ds;

    public static string SqlCon = @"Data Source=DESKTOP-DN85P15\SQLEXPRESS;Initial Catalog=odev;Integrated Security=True";

    public static bool BaglantiDurum()
    {
        //Veritabanı Bağlantısı Kontrolü
        using (con = new SqlConnection(SqlCon))
        {
            try
            {
                con.Open();
                return true;
            }
            catch (SqlException exp)
            {
                return false;
                System.Windows.Forms.MessageBox.Show(exp.Message);
            }
        }
    }

    public static DataGridView GridDoldur(DataGridView gridim, string sqlSelectSorgu)
    {
        con = new SqlConnection(SqlCon);
        da = new SqlDataAdapter(sqlSelectSorgu, con);
        ds = new System.Data.DataSet();
        con.Open();
        da.Fill(ds, sqlSelectSorgu);
        gridim.DataSource = ds.Tables[sqlSelectSorgu];
        con.Close();
        return gridim;
    }

        public static bool giriskont(string girissorgu, string kullaniciAdi, string sifre)
        {


            con = new SqlConnection(SqlCon);
            cmd = new SqlCommand(girissorgu, con);
            cmd.Parameters.AddWithValue("@kullanici", kullaniciAdi);
            cmd.Parameters.AddWithValue("@pass", Class1.MD5Sifrele(sifre));

            con.Open();
            dr = cmd.ExecuteReader();

            if (dr.Read())
            {

                con.Close();
                return true;
            }
            else
            {

                con.Close();
                return false;
            }



        }

        public static string MD5Sifrele(string sifrelecenecekmetin)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] dizi = Encoding.UTF8.GetBytes(sifrelecenecekmetin);


            dizi = md5.ComputeHash(dizi);

            StringBuilder sb = new StringBuilder();
            foreach (byte item in dizi)
                sb.Append(item.ToString("x2").ToLower());

            return sb.ToString();
        }

        public static string SHA256Sifrele(string sifrelenecekmetin)
        {
            SHA256 Sha256Hash = SHA256.Create();

            byte[] dizi = Encoding.UTF8.GetBytes(sifrelenecekmetin);
            dizi = Sha256Hash.ComputeHash(dizi);

            StringBuilder sb = new StringBuilder();
            foreach (byte item in dizi)
                sb.Append(item.ToString("x2").ToLower());


            return sb.ToString();

        }
        public static void GridView_Delete(int numara, string sql, string parametre)
        {
            con.Open();
            cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue(parametre, numara);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public static void kayitsayisigösterme(DataGridView Grid, Label Lbl)
        {
            int kayitsayisi = Grid.RowCount - 1;
            Lbl.Text = kayitsayisi.ToString();
        }

        public static void KomutYolla(string sql)
        {
            con = new SqlConnection(SqlCon);
            cmd = new SqlCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public static void ara(DataGridView grid, TextBox txt, string sql)
        {
            con = new SqlConnection(SqlCon);
            con.Open();
            DataTable tbl = new DataTable();
            SqlDataAdapter aramayap1 = new SqlDataAdapter(sql + txt.Text + "%'", con);
            aramayap1.Fill(tbl);
            con.Close();
            grid.DataSource = tbl;
        }
        public static void KomutYollaParametreli(string sql, SqlCommand cmd)
        {
            con = new SqlConnection(SqlCon);
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public static int IdDegeri(string metin)
        {
            int x = 0;
            con = new SqlConnection(SqlCon);
            cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = metin;
            con.Open();
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                x = Convert.ToInt32(dr[0]);
            }
            con.Close();
            return x;
        }
    }
}
