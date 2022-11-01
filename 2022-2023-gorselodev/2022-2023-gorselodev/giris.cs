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
    public partial class giris : Form
    {
        SqlDataAdapter da;
        SqlConnection con;
        SqlDataReader dr;
        SqlCommand cmd;
        DataSet ds;
        string SqlCon = Class1.SqlCon;
        public static string kullanici;

        public int DenemeSayisi = 0;

        public static string kullanicimSession;
        public giris()
        {
            InitializeComponent();
            InitializeComponent();
            con = new SqlConnection(SqlCon);
            da = new SqlDataAdapter("Select * from tbl_login", con);
            ds = new DataSet();
        }

        private void giris_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sorgu = "select * from tbl_login where kullanici=@kullanici and sifre=@pass";
            con = new SqlConnection(SqlCon);
            cmd = new SqlCommand();
            cmd.CommandText = "SELECT kullanici FROM tbl_login where kullanici='" + textBox1.Text + "'";
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            con.Open();
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                kullanici = dr[0].ToString(); ;
            }
            con.Close();
            if (Class1.giriskont(sorgu, textBox1.Text, textBox2.Text))
            {
                kullanicimSession = textBox1.Text;

                if (kullanici == "rehberlik")
                {

                    anasayfa ana = new anasayfa();
                    ana.button1.Enabled = false;
                    ana.button3.Enabled = false;
                    ana.button5.Enabled = false;
                    ana.button6.Enabled = false;
                    ana.button4.Enabled = false;
                    ana.Show();
                    this.Hide();
                }
                else if (kullanici == "emre")
                {
                    anasayfa sayfa = new anasayfa();
                    sayfa.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("ggg");
                }


            }
            else
            {
                MessageBox.Show("Kullanıcı Adı ve Parola Uyuşmamaktadır!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
    
}
