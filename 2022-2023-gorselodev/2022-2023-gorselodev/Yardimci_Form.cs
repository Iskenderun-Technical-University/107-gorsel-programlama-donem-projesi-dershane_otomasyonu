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
    public partial class Yardimci_Form : Form
    {
        SqlConnection con;
        SqlDataAdapter da;
        SqlCommand cmd;
        DataSet ds;
        string SqlCon = Class1.SqlCon;

        void GridDoldur()
        {
            con = new SqlConnection(SqlCon);
            da = new SqlDataAdapter("Select * from tbl_login", con);
            ds = new DataSet();
            con.Open();
            da.Fill(ds, "tbl_login");

            dataGridView1.DataSource = ds.Tables["tbl_login"];
            con.Close();
        }
        public Yardimci_Form()
        {
            InitializeComponent();
            if (Class1.BaglantiDurum())
            {
                // MessageBox.Show("Bağlantı Kuruldu");
            }
        }

        private void Yardimci_Form_Load(object sender, EventArgs e)
        {
            Class1.GridDoldur(dataGridView1, "select * from tbl_login");
            dataGridView1.Columns[2].Visible = false;
            dataGridView1.Columns[1].HeaderCell.Value = "Kullanıcı Adı";
            dataGridView1.Columns[3].HeaderCell.Value = "Son Giriş Tarihi";
            dataGridView1.Columns[1].Width = 100;
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            dateTimePicker1.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
        }
    }
}
