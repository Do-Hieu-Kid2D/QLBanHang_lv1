using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace GUI
{
    public partial class fChiTietHTTT : Form
    {
        public fChiTietHTTT(formQuanLy fQL)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterParent;

        }

        private void fChiTietHTTT_Load(object sender, EventArgs e)
        {
            loadData();
        }

        private void loadData()
        {
            // Tên sever và database 
            string strCon = Properties.Settings.Default.strCon;
            // câu lệnh mk mu
            string query = "select * from THANHTOAN;";
            DataTable dataTable = new DataTable();
            
            SqlConnection sqlCon = new SqlConnection(strCon);
            sqlCon.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = sqlCon;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = query;

            SqlDataReader reader = cmd.ExecuteReader(); 
            dataTable.Load(reader);

            dgvHTTT.DataSource = dataTable;
            settingdgv();


        }

        private void settingdgv()
        {
            // Bỏ cột mặc định dataGridView
            dgvHTTT.RowHeadersVisible = false;
            dgvHTTT.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 12, FontStyle.Bold);
            dgvHTTT.Columns[0].HeaderText = " Mã HTTT  ";
            dgvHTTT.Columns[1].HeaderText = " Tên HTTT ";

            dgvHTTT.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvHTTT.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            foreach (DataGridViewColumn col in dgvHTTT.Columns)
            {
                col.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            dgvHTTT.DefaultCellStyle.Font = new Font("Arial", 12); // Thay đổi font và kích thước phù hợp với nhu cầu của bạn

        }
    }
}
