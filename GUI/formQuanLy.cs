using BLL;
using Project_CSDLBanHang;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace GUI
{
    public partial class formQuanLy : Form
    {
        formDangNhap fDN;
        public formQuanLy(formDangNhap dangNhap)
        {
            InitializeComponent();
            fDN = dangNhap;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Size = new Size(1010, 600);
            txtTimMatHang.ForeColor = Color.Gray; // Màu xám
            txtTimKhachHang.ForeColor = Color.Gray; // Màu xám
            txtTimNhanVien.ForeColor = Color.Gray; // Màu xám
            txtTimDonHang.ForeColor = Color.Gray; // Màu xám
            this.dgvDataMH.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;

        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn đăng xuất không?", "Thông báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (result == DialogResult.Yes)
            {
                fDN.Show();
                this.Close();
            }

        }

        private void txtTimKiem_MouseClick(object sender, MouseEventArgs e)
        {
            txtTimMatHang.Text = "";
            txtTimMatHang.ForeColor = Color.Black; // Đen
        }

        private void formQuanLy_Load(object sender, EventArgs e)
        {
            //hienThiALLMatHang();
            //hienThiALLKhachHang();
            //hienThiAllDonHang();
            //hienThiAllNhanVien();
        }

        public void settingDgvMH()
        {
            try
            {
                // Bỏ cột mặc định dataGridView
                dgvDataMH.RowHeadersVisible = false;

                dgvDataMH.Columns[8].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                dgvDataMH.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dgvDataMH.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 12, FontStyle.Bold);
                dgvDataMH.Columns[0].HeaderText = "Mã hàng";
                dgvDataMH.Columns[1].HeaderText = "                Tên hàng              ";
                dgvDataMH.Columns[2].HeaderText = "Mã NCC";
                dgvDataMH.Columns[3].HeaderText = "Mã LH";
                dgvDataMH.Columns[4].HeaderText = "Số lượng";
                dgvDataMH.Columns[5].HeaderText = "ĐV tính";
                dgvDataMH.Columns[6].HeaderText = "Giá nhập";
                dgvDataMH.Columns[7].HeaderText = "Giá bán";
                dgvDataMH.Columns[8].HeaderText = "Hình ảnh";

                dgvDataMH.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvDataMH.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvDataMH.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvDataMH.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvDataMH.Columns[6].DefaultCellStyle.Format = "N0";
                dgvDataMH.Columns[7].DefaultCellStyle.Format = "N0";

                foreach (DataGridViewColumn col in dgvDataMH.Columns)
                {
                    col.SortMode = DataGridViewColumnSortMode.NotSortable;
                }

                dgvDataMH.Columns[1].Width = 110;
                dgvDataMH.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                //splitContainer8.FixedPanel = FixedPanel.Panel1; // Khóa Panel1 cố định kích thước
                //splitContainer8.FixedPanel = FixedPanel.Panel2; // Khóa Panel2 cố định kích thước


            }
            catch { }

        }

        public void hienThiALLMatHang()
        {
            DataTable data = MatHangBLL.layALLMatHang();
            //dgvDataMH.Rows.Clear();
            dgvDataMH.DataSource = data;
            settingDgvMH();
        }

        private void btnALlHang_Click(object sender, EventArgs e)
        {
            hienThiALLMatHang();
        }

        private void btnAllKhachHang_Click(object sender, EventArgs e)
        {
            hienThiALLKhachHang();
        }

        public void hienThiALLKhachHang()
        {
            DataTable data = KhachHangBLL.layALLKhachHang();
            //dgvDataMH.Rows.Clear();
            dgvDataKH.DataSource = data;
            settingDgvKH();
        }

        public void settingDgvKH()
        {
            // Bỏ cột mặc định dataGridView
            dgvDataKH.RowHeadersVisible = false;
            dgvDataKH.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 12, FontStyle.Bold);
            dgvDataKH.Columns[0].HeaderText = " Mã KH  ";
            dgvDataKH.Columns[1].HeaderText = "Tên KH";
            dgvDataKH.Columns[2].HeaderText = "Giới tính";
            dgvDataKH.Columns[3].HeaderText = "Tên CT";
            dgvDataKH.Columns[4].HeaderText = "Địa chỉ";
            dgvDataKH.Columns[5].HeaderText = "Email";
            dgvDataKH.Columns[6].HeaderText = "Điện thoại";

            foreach (DataGridViewColumn col in dgvDataKH.Columns)
            {
                col.SortMode = DataGridViewColumnSortMode.NotSortable;
            }


        }

        private void btnDonHang_Click(object sender, EventArgs e)
        {
            hienThiAllDonHang();
        }

        public void hienThiAllDonHang()
        {
            DataTable data = DonHangBLL.layALLDonHang();
            //dgvDataMH.Rows.Clear();
            dgvDataDH.DataSource = data;
            settingDgvDH();
        }

        public void settingDgvDH()
        {
            // Bỏ cột mặc định dataGridView
            dgvDataDH.RowHeadersVisible = false;
            // Thiết lập font đậm cho dòng header của DataGridView
            dgvDataDH.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 12, FontStyle.Bold);

            dgvDataDH.Columns[0].HeaderText = " Số HĐ  ";
            dgvDataDH.Columns[1].HeaderText = "    Mã KH    ";
            dgvDataDH.Columns[2].HeaderText = "    Mã NV    ";
            dgvDataDH.Columns[3].HeaderText = " Ngày ĐH";
            dgvDataDH.Columns[4].HeaderText = " Ngày GH";
            dgvDataDH.Columns[5].HeaderText = "Thanh Toán";
            dgvDataDH.Columns[6].HeaderText = " Địa chỉ giao hàng ";
            dgvDataDH.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            foreach (DataGridViewColumn col in dgvDataDH.Columns)
            {
                col.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        private void txtTimNhanVien_TextChanged(object sender, EventArgs e)
        {
            txtTimNhanVien.Text = "";
            txtTimNhanVien.ForeColor = Color.Black; // Đen
        }

        private void txtTimNhanVien_MouseClick(object sender, MouseEventArgs e)
        {
            txtTimNhanVien.Text = "";
            txtTimNhanVien.ForeColor = Color.Black; // Đen
        }

        private void txtTimDonHang_MouseClick(object sender, MouseEventArgs e)
        {
            txtTimDonHang.Text = "";
            txtTimDonHang.ForeColor = Color.Black; // Đen
        }

        private void txtTimKhachHang_MouseClick(object sender, MouseEventArgs e)
        {
            txtTimKhachHang.Text = "";
            txtTimKhachHang.ForeColor = Color.Black; // Đen
        }

        private void btnNhanVien_Click(object sender, EventArgs e)
        {
            hienThiAllNhanVien();
        }

        public void hienThiAllNhanVien()
        {
            DataTable data = NhanVienBLL.layAllNhanVien();
            //dgvDataMH.Rows.Clear();
            dgvDataNV.DataSource = data;
            settingDgvNV();

        }
        
        public void settingDgvNV()
        {
            // Bỏ cột mặc định dataGridView
            dgvDataNV.RowHeadersVisible = false;
            // Thiết lập font đậm cho dòng header của DataGridView
            dgvDataNV.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 12, FontStyle.Bold);

            dgvDataNV.Columns[0].HeaderText = " Mã NV  ";
            dgvDataNV.Columns[1].HeaderText = "Họ tên";
            dgvDataNV.Columns[2].HeaderText = "Giới tính";
            dgvDataNV.Columns[3].HeaderText = "Ngày sinh";
            dgvDataNV.Columns[4].HeaderText = "Ngày nhận việc";
            dgvDataNV.Columns[5].HeaderText = "Điện thoại";
            dgvDataNV.Columns[6].HeaderText = "Lương";
            dgvDataNV.Columns[7].HeaderText = "Phụ cấp";
            dgvDataNV.Columns[8].HeaderText = "Địa chỉ";
            dgvDataNV.Columns[9].HeaderText = "Tài khoản";
            dgvDataNV.Columns[10].HeaderText = "Mật khẩu";

            dgvDataNV.Columns[6].DefaultCellStyle.Format = "N0";
            dgvDataNV.Columns[7].DefaultCellStyle.Format = "N0";

            foreach (DataGridViewColumn col in dgvDataNV.Columns)
            {
                col.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            //dgvDataDH.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }
    }
}
