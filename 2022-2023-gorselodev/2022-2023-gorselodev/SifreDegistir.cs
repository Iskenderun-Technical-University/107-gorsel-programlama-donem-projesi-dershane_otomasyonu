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
    public partial class SifreDegistir : Form
    {
        SqlConnection con;
        SqlDataAdapter da;
        SqlDataReader dr;
        SqlCommand cmd;
        string SqlCon = Class1.SqlCon;
        public int sonuc = 0;
        public SifreDegistir()
        {
            InitializeComponent();
        }

        private void SifreDegistir_Load(object sender, EventArgs e)
        {
            label_Mesaj.Text = "";
            CaptchaOlustur();
        }

        private void button_SifreDegistir_Click(object sender, EventArgs e)
        {
            if (textBox_Captcha.Text == sonuc.ToString())
            {
                label_Mesaj.Text = "";
                if (textBox_YeniSifre.Text == textBox_YeniSifreOnay.Text)
                {
                    EskiSifreKontrol();
                    textBox_EskiSifre.Clear();
                    textBox_YeniSifre.Clear();
                    textBox_YeniSifreOnay.Clear();
                    textBox_Captcha.Clear();
                    textBox_EskiSifre.Focus();
                    CaptchaOlustur();
                }

                else
                {
                    label_Mesaj.Text = "Yeni Şifre Tekrarı Yanlış Girildi...";
                }

            }

            else
            {
                label_Mesaj.Text = "Captcha Yanlış Girildi...";
                CaptchaOlustur();
            }

        }

        public void EskiSifreKontrol()
        {
            string sorgu = "select sifre from tbl_login where kullanici=@user and sifre=@pass";

            con = new SqlConnection(SqlCon);
            cmd = new SqlCommand(sorgu, con);
            cmd.Parameters.AddWithValue("@user", giris.kullanicimSession);
            cmd.Parameters.AddWithValue("@pass", Class1.MD5Sifrele(textBox_EskiSifre.Text));

            con.Open();
            dr = cmd.ExecuteReader();
            //Eğer veri geldiyse
            if (dr.Read())
            {

                string sql = "update tbl_login set sifre= '" + Class1.MD5Sifrele(textBox_YeniSifre.Text) + "'";
                Class1.KomutYolla(sql);
                MessageBox.Show("Şifre Değiştirildi...");
                label_Mesaj.Text = "Şifreniz Değiştirildi...";
            }
            else
            {
                label_Mesaj.Text = "Eski Şifreniz Hatalı...";

            }
            con.Close();
        }

        public void CaptchaOlustur()
        {
            Random r = new Random();
            int ilk = r.Next(0, 50);
            int ikinci = r.Next(0, 50);
            sonuc = ilk + ikinci;
            label_Captcha.Text = ilk.ToString() + "+" + ikinci.ToString() + "=";
            label_Mesaj.Text = giris.kullanicimSession;
        }

    }
}