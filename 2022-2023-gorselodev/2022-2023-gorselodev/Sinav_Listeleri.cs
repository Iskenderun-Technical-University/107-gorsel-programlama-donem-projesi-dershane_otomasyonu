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
    public partial class Sinav_Listeleri : Form
    {
        public Sinav_Listeleri()
        {
            InitializeComponent();
        }
        string SqlCon = Class1.SqlCon;

        private void Sinav_Listeleri_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                if (radioButton5.Checked == true)
                {
                    string metin = "select * from sinav_takip where sinav_no='" + textBox1.Text + "' order by sayisal_puan asc";
                    Class1.GridDoldur(dataGridView1, metin);
                }
                else if (radioButton6.Checked == true)
                {
                    string metin = "select * from sinav_takip where sinav_no='" + textBox1.Text + "' order by sayisal_puan desc";
                    Class1.GridDoldur(dataGridView1, metin);
                }
                else
                {
                    MessageBox.Show("Artan veya azalan oldugunu seçiniz");
                }
                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[14].Visible = false;
                dataGridView1.Columns[15].Visible = false;

            }

            else if (radioButton3.Checked == true)
            {
                if (radioButton5.Checked == true)
                {
                    string metin = "select * from sinav_takip where sinav_no='" + textBox1.Text + "' order by esitagirlik_puan asc";
                    Class1.GridDoldur(dataGridView1, metin);
                }
                else if (radioButton6.Checked == true)
                {
                    string metin = "select * from sinav_takip where sinav_no='" + textBox1.Text + "' order by esitagirlik_puan desc";
                    Class1.GridDoldur(dataGridView1, metin);
                }
                else
                {
                    MessageBox.Show("Artan veya azalan oldugunu seçiniz");
                }
                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[13].Visible = false;
                dataGridView1.Columns[15].Visible = false;

            }
            else if (radioButton4.Checked == true)
            {
                if (radioButton5.Checked == true)
                {
                    string metin = "select * from sinav_takip where sinav_no='" + textBox1.Text + "' order by sozel_puan asc";
                    Class1.GridDoldur(dataGridView1, metin);
                }
                else if (radioButton6.Checked == true)
                {
                    string metin = "select * from sinav_takip where sinav_no='" + textBox1.Text + "' order by sozel_puan desc";
                    Class1.GridDoldur(dataGridView1, metin);
                }
                else
                {
                    MessageBox.Show("Artan veya azalan oldugunu seçiniz");
                }
                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[13].Visible = false;
                dataGridView1.Columns[14].Visible = false;
            }
            else
            {
                MessageBox.Show("Arama Kriterlerini seçiniz");
            }


        }
    }
}
