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
    public partial class SifreOlustur : Form
    {
        public SifreOlustur()
        {
            InitializeComponent();
        }

        private void SifreOlustur_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {

                richTextBox1.Text = Class1.MD5Sifrele(textBox1.Text);
                label4.Text = richTextBox1.Text.Length.ToString();
                richTextBox2.Text = Class1.SHA256Sifrele(textBox1.Text);
                label5.Text = richTextBox2.Text.Length.ToString();
            }
        }
    }
}
