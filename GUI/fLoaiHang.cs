using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class fLoaiHang : Form
    {
        public fLoaiHang(formQuanLy fql)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterParent;
            dgvLoaiHang.DefaultCellStyle.Font = new Font("Arial", 12); // Thay đổi font và kích thước phù hợp với nhu cầu của bạn
        }

        private void fLoaiHang_Load(object sender, EventArgs e)
        {
            loadData();
        }

        private void loadData()
        {
            // Tên sever và database 
            string strCon = Properties.Settings.Default.strCon;
            // câu lệnh mk mu
            string query = "select * from LOAIHANG;";
            DataTable dataTable = new DataTable();

            SqlConnection sqlCon = new SqlConnection(strCon);
            sqlCon.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = sqlCon;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = query;

            SqlDataReader reader = cmd.ExecuteReader();
            dataTable.Load(reader);

            dgvLoaiHang.DataSource = dataTable;
            settingdgv();


        }

        private void settingdgv()
        {
            // Bỏ cột mặc định dataGridView
            dgvLoaiHang.RowHeadersVisible = false;
            dgvLoaiHang.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 12, FontStyle.Bold);
            dgvLoaiHang.Columns[0].HeaderText = "Mã loại hàng";
            dgvLoaiHang.Columns[1].HeaderText = "Tên loại hàng";

            dgvLoaiHang.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvLoaiHang.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            foreach (DataGridViewColumn col in dgvLoaiHang.Columns)
            {
                col.SortMode = DataGridViewColumnSortMode.NotSortable;
            }


        }
    }
}
