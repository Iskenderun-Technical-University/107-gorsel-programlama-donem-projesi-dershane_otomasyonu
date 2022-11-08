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
    public partial class Sinav_Takip : Form
    {
        public Sinav_Takip()
        {
            InitializeComponent();
        }

        private void Sinav_Takip_Load(object sender, EventArgs e)
        {
            Class1.GridDoldur(dataGridView1, "select * from sinav_takip");
            dataGridView1.Columns[0].HeaderCell.Value = "Sıra No";
            dataGridView1.Columns[1].HeaderCell.Value = "Sınav No";
            dataGridView1.Columns[2].HeaderCell.Value = "Ad Soyad";
            dataGridView1.Columns[3].HeaderCell.Value = "Öğrenci No";
            dataGridView1.Columns[4].HeaderCell.Value = "Türkçe Neti";
            dataGridView1.Columns[5].HeaderCell.Value = "Matematik Neti";
            dataGridView1.Columns[6].HeaderCell.Value = "Geometri Neti";
            dataGridView1.Columns[7].HeaderCell.Value = "Tarih Neti";
            dataGridView1.Columns[8].HeaderCell.Value = "Coğrafya Neti";
            dataGridView1.Columns[9].HeaderCell.Value = "Felsefe Neti";
            dataGridView1.Columns[10].HeaderCell.Value = "Fizik Neti";
            dataGridView1.Columns[11].HeaderCell.Value = "Kimya Neti";
            dataGridView1.Columns[12].HeaderCell.Value = "Biyoloji Neti";
            dataGridView1.Columns[13].HeaderCell.Value = "Sayısal Puan";
            dataGridView1.Columns[14].HeaderCell.Value = "Eşit Ağırlık";
            dataGridView1.Columns[15].HeaderCell.Value = "Sözel Puan";
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int secim = dataGridView1.SelectedCells[0].RowIndex;
            textBox1.Text = dataGridView1.Rows[secim].Cells[0].Value.ToString();
            txtsinavno.Text = dataGridView1.Rows[secim].Cells[1].Value.ToString();
            txtadsoyad.Text = dataGridView1.Rows[secim].Cells[2].Value.ToString();
            txtnumara.Text = dataGridView1.Rows[secim].Cells[3].Value.ToString();
            txtturkce.Text = dataGridView1.Rows[secim].Cells[4].Value.ToString();
            txtmat.Text = dataGridView1.Rows[secim].Cells[5].Value.ToString();
            txtgeo.Text = dataGridView1.Rows[secim].Cells[6].Value.ToString();
            txttarih.Text = dataGridView1.Rows[secim].Cells[7].Value.ToString();
            txtcografya.Text = dataGridView1.Rows[secim].Cells[8].Value.ToString();
            txtfelsefe.Text = dataGridView1.Rows[secim].Cells[9].Value.ToString();
            txtfizik.Text = dataGridView1.Rows[secim].Cells[10].Value.ToString();
            txtkimya.Text = dataGridView1.Rows[secim].Cells[11].Value.ToString();
            txtbiyoloji.Text = dataGridView1.Rows[secim].Cells[12].Value.ToString();
            txtsayisal.Text = dataGridView1.Rows[secim].Cells[13].Value.ToString();
            txtesitagirlik.Text = dataGridView1.Rows[secim].Cells[14].Value.ToString();
            txtsozel.Text = dataGridView1.Rows[secim].Cells[15].Value.ToString();
        }
    }
}
